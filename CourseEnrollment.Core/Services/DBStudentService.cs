using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Services
{
    public class DBStudentService : IStudentService
    {
        private readonly string _connectionString;

        public DBStudentService(string connString)
        {
            _connectionString = connString;
        }

        void IStudentService.Add(Student student)
        {
            student.Id = "STU-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Student(Id, Name, Phone, Email, Department) VALUES (@Id, @Name, @Phone, @Email, @Department)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Phone", student.Phone ?? "");
                cmd.Parameters.AddWithValue("@Email", student.Email ?? "");
                cmd.Parameters.AddWithValue("@Department", student.Department ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        void IStudentService.Update(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Student SET Name=@Name, Phone=@Phone, Email=@Email, Department=@Department WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Phone", student.Phone ?? "");
                cmd.Parameters.AddWithValue("@Email", student.Email ?? "");
                cmd.Parameters.AddWithValue("@Department", student.Department ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        void IStudentService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Student WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        Student IStudentService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Student WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadStudent(reader);
                    }
                }
            }
            return null;
        }

        List<Student> IStudentService.GetAll()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student ORDER BY Name", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(ReadStudent(reader));
                    }
                }
            }
            return students;
        }

        List<Student> IStudentService.Search(string query)
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Student WHERE Name LIKE @query OR Phone LIKE @query OR Email LIKE @query OR Department LIKE @query";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@query", "%" + query.Trim() + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(ReadStudent(reader));
                    }
                }
            }
            return students;
        }

        // Helper method to avoid repeating reader parsing code
        private Student ReadStudent(SqlDataReader reader)
        {
            Student student = new Student();
            student.Id = reader["Id"].ToString();
            student.Name = reader["Name"].ToString();
            student.Phone = reader["Phone"].ToString();
            student.Email = reader["Email"].ToString();
            student.Department = reader["Department"].ToString();
            return student;
        }
    }
}
