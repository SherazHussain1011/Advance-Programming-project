using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Services
{
    public class DBEnrollmentService : IEnrollmentService
    {
        private readonly string _connectionString;

        public DBEnrollmentService(string connString)
        {
            _connectionString = connString;
        }

        void IEnrollmentService.Add(Enrollment enrollment)
        {
            enrollment.Id = "ENR-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Check course status before enrolling
                SqlCommand checkCourse = new SqlCommand(
                    "SELECT AvailableSeats, Status FROM Course WHERE Id=@CourseId", conn);
                checkCourse.Parameters.AddWithValue("@CourseId", enrollment.CourseId);

                using (var reader = checkCourse.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string courseStatus = reader["Status"].ToString();
                        int seats = Convert.ToInt32(reader["AvailableSeats"]);

                        if (courseStatus == CourseStatusEnum.Cancelled.ToString())
                            throw new Exception("This course has been cancelled and cannot accept enrollments.");

                        if (courseStatus == CourseStatusEnum.Full.ToString())
                            throw new Exception("This course is already full and cannot accept more enrollments.");

                        if (seats <= 0)
                            throw new Exception("This course has no available seats.");
                    }
                    else
                    {
                        throw new Exception("The selected course could not be found.");
                    }
                }

                // Insert enrollment record
                string sql = "INSERT INTO Enrollment(Id, CourseId, CourseTitle, StudentId, StudentName, EnrollDate, EndDate, Grade, Status) " +
                             "VALUES (@Id, @CourseId, @CourseTitle, @StudentId, @StudentName, @EnrollDate, @EndDate, @Grade, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", enrollment.Id);
                cmd.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                cmd.Parameters.AddWithValue("@CourseTitle", enrollment.CourseTitle ?? "");
                cmd.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", enrollment.StudentName ?? "");
                cmd.Parameters.AddWithValue("@EnrollDate", enrollment.EnrollDate);
                cmd.Parameters.AddWithValue("@EndDate", (object)enrollment.EndDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Grade", (object)enrollment.Grade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", enrollment.Status.ToString());
                cmd.ExecuteNonQuery();

                // Decrease available seats by 1 and mark the course Full if seats reach 0
                SqlCommand decreaseSeats = new SqlCommand(
                    "UPDATE Course SET AvailableSeats = AvailableSeats - 1, " +
                    "Status = CASE WHEN AvailableSeats - 1 <= 0 THEN @FullStatus ELSE Status END " +
                    "WHERE Id = @CourseId", conn);
                decreaseSeats.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                decreaseSeats.Parameters.AddWithValue("@FullStatus", CourseStatusEnum.Full.ToString());
                decreaseSeats.ExecuteNonQuery();
            }
        }

        void IEnrollmentService.Update(Enrollment enrollment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Get old status
                SqlCommand getOld = new SqlCommand("SELECT Status FROM Enrollment WHERE Id=@Id", conn);
                getOld.Parameters.AddWithValue("@Id", enrollment.Id);
                string oldStatus = getOld.ExecuteScalar()?.ToString();

                // Guard: a Completed or Dropped record is final — it cannot be reopened back to Enrolled
                bool oldIsFinal = oldStatus == EnrollmentStatusEnum.Completed.ToString() ||
                                   oldStatus == EnrollmentStatusEnum.Dropped.ToString();

                if (oldIsFinal && enrollment.Status == EnrollmentStatusEnum.Enrolled)
                {
                    throw new InvalidOperationException(
                        "A completed or dropped enrollment record cannot be changed back to Enrolled.");
                }

                // Update enrollment record
                string sql = "UPDATE Enrollment SET CourseId=@CourseId, CourseTitle=@CourseTitle, StudentId=@StudentId, " +
                             "StudentName=@StudentName, EnrollDate=@EnrollDate, EndDate=@EndDate, Grade=@Grade, Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", enrollment.Id);
                cmd.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                cmd.Parameters.AddWithValue("@CourseTitle", enrollment.CourseTitle ?? "");
                cmd.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", enrollment.StudentName ?? "");
                cmd.Parameters.AddWithValue("@EnrollDate", enrollment.EnrollDate);
                cmd.Parameters.AddWithValue("@EndDate", (object)enrollment.EndDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Grade", (object)enrollment.Grade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", enrollment.Status.ToString());
                cmd.ExecuteNonQuery();

                // Seat adjustment based on status transition.
                // Completed/Dropped records are permanently locked once set — no transition away from
                // either is allowed (enforced above), so the only seat-affecting transition possible here is:
                //   Enrolled → Completed  or  Enrolled → Dropped : the student no longer occupies the seat, free it up.
                bool wasEnrolled = oldStatus == EnrollmentStatusEnum.Enrolled.ToString();
                bool nowFinal = enrollment.Status == EnrollmentStatusEnum.Completed ||
                                 enrollment.Status == EnrollmentStatusEnum.Dropped;

                if (wasEnrolled && nowFinal)
                {
                    // Seat freed up — increase AvailableSeats, mark Open if the course was Full
                    SqlCommand increaseSeats = new SqlCommand(
                        "UPDATE Course SET AvailableSeats = AvailableSeats + 1, " +
                        "Status = CASE WHEN Status = @FullStatus THEN @OpenStatus ELSE Status END " +
                        "WHERE Id = @CourseId", conn);
                    increaseSeats.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                    increaseSeats.Parameters.AddWithValue("@FullStatus", CourseStatusEnum.Full.ToString());
                    increaseSeats.Parameters.AddWithValue("@OpenStatus", CourseStatusEnum.Open.ToString());
                    increaseSeats.ExecuteNonQuery();
                }
                // Completed ↔ Dropped is blocked above when going back to Enrolled; switching directly
                // between the two terminal statuses is not offered in the UI, so no further case to handle.
            }
        }

        void IEnrollmentService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Enrollment WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        Enrollment IEnrollmentService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Enrollment WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return ReadEnrollment(reader);
                }
            }
            return null;
        }

        List<Enrollment> IEnrollmentService.GetAll()
        {
            var enrollments = new List<Enrollment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Enrollment ORDER BY EnrollDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        enrollments.Add(ReadEnrollment(reader));
                }
            }
            return enrollments;
        }

        List<Enrollment> IEnrollmentService.GetByStudentId(string studentId)
        {
            var enrollments = new List<Enrollment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Enrollment WHERE StudentId=@StudentId ORDER BY EnrollDate DESC", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        enrollments.Add(ReadEnrollment(reader));
                }
            }
            return enrollments;
        }

        List<Enrollment> IEnrollmentService.GetByStatus(EnrollmentStatusEnum status)
        {
            var enrollments = new List<Enrollment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Enrollment WHERE Status=@Status ORDER BY EnrollDate DESC", conn);
                cmd.Parameters.AddWithValue("@Status", status.ToString());
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        enrollments.Add(ReadEnrollment(reader));
                }
            }
            return enrollments;
        }

        private Enrollment ReadEnrollment(SqlDataReader reader)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Id = reader["Id"].ToString();
            enrollment.CourseId = reader["CourseId"].ToString();
            enrollment.CourseTitle = reader["CourseTitle"].ToString();
            enrollment.StudentId = reader["StudentId"].ToString();
            enrollment.StudentName = reader["StudentName"].ToString();
            enrollment.EnrollDate = Convert.ToDateTime(reader["EnrollDate"]);
            enrollment.EndDate = reader["EndDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["EndDate"]);
            enrollment.Grade = reader["Grade"] == DBNull.Value ? null : reader["Grade"].ToString();
            string statusStr = reader["Status"].ToString();
            enrollment.Status = Enum.TryParse<EnrollmentStatusEnum>(statusStr, true, out var s) ? s : EnrollmentStatusEnum.Enrolled;
            return enrollment;
        }
    }
}
