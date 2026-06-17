using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Services
{
    public class DBCourseService : ICourseService
    {
        private readonly string _connectionString;

        public DBCourseService(string connString)
        {
            _connectionString = connString;
        }

        Course ICourseService.Add(Course course)
        {
            course.Id = "CRS-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Course(Id, Code, Title, Instructor, Department, Credits, AvailableSeats, Status) " +
                             "VALUES (@Id, @Code, @Title, @Instructor, @Department, @Credits, @AvailableSeats, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", course.Id);
                cmd.Parameters.AddWithValue("@Code", course.Code ?? "");
                cmd.Parameters.AddWithValue("@Title", course.Title);
                cmd.Parameters.AddWithValue("@Instructor", course.Instructor);
                cmd.Parameters.AddWithValue("@Department", course.Department.ToString());
                cmd.Parameters.AddWithValue("@Credits", course.Credits);
                cmd.Parameters.AddWithValue("@AvailableSeats", course.AvailableSeats);
                cmd.Parameters.AddWithValue("@Status", course.Status.ToString());

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    return course;
                else
                    return null;
            }
        }

        bool ICourseService.Update(Course course)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Course SET Code=@Code, Title=@Title, Instructor=@Instructor, Department=@Department, " +
                             "Credits=@Credits, AvailableSeats=@AvailableSeats, Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", course.Id);
                cmd.Parameters.AddWithValue("@Code", course.Code ?? "");
                cmd.Parameters.AddWithValue("@Title", course.Title);
                cmd.Parameters.AddWithValue("@Instructor", course.Instructor);
                cmd.Parameters.AddWithValue("@Department", course.Department.ToString());
                cmd.Parameters.AddWithValue("@Credits", course.Credits);
                cmd.Parameters.AddWithValue("@AvailableSeats", course.AvailableSeats);
                cmd.Parameters.AddWithValue("@Status", course.Status.ToString());

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        bool ICourseService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Course WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        Course ICourseService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Course WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadCourse(reader);
                    }
                }
            }
            return null;
        }

        List<Course> ICourseService.GetAll()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Course ORDER BY Title", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(ReadCourse(reader));
                    }
                }
            }
            return courses;
        }

        List<Course> ICourseService.Search(string text, DepartmentEnum? department, CourseStatusEnum? status)
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string sql = "SELECT * FROM Course WHERE (Title LIKE @text OR Instructor LIKE @text OR Code LIKE @text)";

                if (department != null)
                    sql += " AND Department=@dept";

                if (status != null)
                    sql += " AND Status=@status";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@text", "%" + text.Trim() + "%");

                if (department != null)
                    cmd.Parameters.AddWithValue("@dept", department.ToString());

                if (status != null)
                    cmd.Parameters.AddWithValue("@status", status.ToString());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(ReadCourse(reader));
                    }
                }
            }
            return courses;
        }

        // Helper method to avoid repeating reader parsing code
        private Course ReadCourse(SqlDataReader reader)
        {
            Course course = new Course();
            course.Id = reader["Id"].ToString();
            course.Code = reader["Code"].ToString();
            course.Title = reader["Title"].ToString();
            course.Instructor = reader["Instructor"].ToString();

            string deptStr = reader["Department"].ToString();
            course.Department = Enum.TryParse<DepartmentEnum>(deptStr, ignoreCase: true, out var deptParsed) ? deptParsed : DepartmentEnum.General;

            course.Credits = Convert.ToInt32(reader["Credits"]);
            course.AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]);

            string statusStr = reader["Status"].ToString();
            course.Status = Enum.TryParse<CourseStatusEnum>(statusStr, ignoreCase: true, out var statusParsed) ? statusParsed : CourseStatusEnum.Open;

            return course;
        }
    }
}
