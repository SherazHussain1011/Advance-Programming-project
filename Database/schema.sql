-- ============================================================
-- Course Enrollment System — Database Schema
-- Target: Microsoft SQL Server (tested against SQL Server 2019+)
-- ============================================================
-- Run this whole script in SQL Server Management Studio (SSMS),
-- Azure Data Studio, or sqlcmd to create the database, tables,
-- and a small set of sample data so the application has
-- something to show the first time it is run.
-- ============================================================

IF DB_ID('CourseEnrollmentDB') IS NULL
BEGIN
    CREATE DATABASE CourseEnrollmentDB;
END
GO

USE CourseEnrollmentDB;
GO

-- ------------------------------------------------------------
-- Drop tables if re-running this script (children first)
-- ------------------------------------------------------------
IF OBJECT_ID('dbo.Enrollment', 'U') IS NOT NULL DROP TABLE dbo.Enrollment;
IF OBJECT_ID('dbo.Course', 'U') IS NOT NULL DROP TABLE dbo.Course;
IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL DROP TABLE dbo.Student;
IF OBJECT_ID('dbo.Announcement', 'U') IS NOT NULL DROP TABLE dbo.Announcement;
GO

-- ------------------------------------------------------------
-- Course
-- ------------------------------------------------------------
CREATE TABLE dbo.Course
(
    Id              NVARCHAR(20)    NOT NULL PRIMARY KEY,
    Code            NVARCHAR(20)    NULL,
    Title           NVARCHAR(200)   NOT NULL,
    Instructor      NVARCHAR(150)   NOT NULL,
    Department      NVARCHAR(50)    NOT NULL,   -- stores the DepartmentEnum name
    Credits         INT             NOT NULL    CONSTRAINT CK_Course_Credits CHECK (Credits BETWEEN 1 AND 6),
    AvailableSeats  INT             NOT NULL    CONSTRAINT CK_Course_Seats CHECK (AvailableSeats >= 0),
    Status          NVARCHAR(20)    NOT NULL    -- stores the CourseStatusEnum name: Open / Full / Cancelled
);
GO

-- ------------------------------------------------------------
-- Student
-- ------------------------------------------------------------
CREATE TABLE dbo.Student
(
    Id              NVARCHAR(20)    NOT NULL PRIMARY KEY,
    Name            NVARCHAR(150)   NOT NULL,
    Phone           NVARCHAR(20)    NOT NULL,
    Email           NVARCHAR(150)   NULL,
    Department      NVARCHAR(100)   NULL        -- free-text home department / major
);
GO

-- ------------------------------------------------------------
-- Enrollment
-- ------------------------------------------------------------
CREATE TABLE dbo.Enrollment
(
    Id              NVARCHAR(20)    NOT NULL PRIMARY KEY,
    CourseId        NVARCHAR(20)    NOT NULL,
    CourseTitle     NVARCHAR(200)   NOT NULL,
    StudentId       NVARCHAR(20)    NOT NULL,
    StudentName     NVARCHAR(150)   NOT NULL,
    EnrollDate      DATETIME        NOT NULL,
    EndDate         DATETIME        NULL,
    Grade           NVARCHAR(10)    NULL,
    Status          NVARCHAR(20)    NOT NULL,   -- stores the EnrollmentStatusEnum name: Enrolled / Completed / Dropped
    CONSTRAINT FK_Enrollment_Course FOREIGN KEY (CourseId) REFERENCES dbo.Course(Id),
    CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentId) REFERENCES dbo.Student(Id)
);
GO

-- ------------------------------------------------------------
-- Announcement
-- ------------------------------------------------------------
CREATE TABLE dbo.Announcement
(
    Id              NVARCHAR(20)    NOT NULL PRIMARY KEY,
    Title           NVARCHAR(200)   NOT NULL,
    Message         NVARCHAR(1000)  NOT NULL,
    PostedDate      DATETIME        NOT NULL,
    IsActive        BIT             NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- Sample data — enough to explore every screen immediately.
-- (Feel free to delete these rows once you no longer need them;
--  the app works perfectly well against an empty database too.)
-- ============================================================

INSERT INTO dbo.Course (Id, Code, Title, Instructor, Department, Credits, AvailableSeats, Status) VALUES
('CRS-A1B2C3', 'CS101',   'Introduction to Programming', 'Dr. Sarah Khan',       'ComputerScience',         3, 2, 'Open'),
('CRS-D4E5F6', 'MATH101', 'Calculus I',                  'Dr. Ahmed Raza',       'Mathematics',             4, 0, 'Full'),
('CRS-G7H8I9', 'PHY101',  'General Physics',             'Dr. Imran Latif',      'Physics',                 3, 5, 'Open'),
('CRS-J1K2L3', 'CHEM201', 'Organic Chemistry',            'Dr. Ayesha Malik',     'Chemistry',               4, 3, 'Open'),
('CRS-M4N5O6', 'BUS150',  'Business Ethics',              'Prof. Bilal Hussain',  'BusinessAdministration',  3, 0, 'Cancelled'),
('CRS-P7Q8R9', 'CS201',   'Data Structures',              'Dr. Sarah Khan',       'ComputerScience',         4, 4, 'Open');

INSERT INTO dbo.Student (Id, Name, Phone, Email, Department) VALUES
('STU-S1T2U3', 'Ali Raza',       '03001234567', 'ali.raza@example.com',       'Computer Science'),
('STU-V4W5X6', 'Fatima Sheikh',  '03007654321', 'fatima.sheikh@example.com',  'Mathematics'),
('STU-Y7Z8A9', 'Hassan Iqbal',   '03331112233', 'hassan.iqbal@example.com',   'Physics'),
('STU-B1C2D3', 'Zainab Tariq',   '03219876543', 'zainab.tariq@example.com',   'Chemistry'),
('STU-E4F5G6', 'Omar Farooq',    '03451239876', 'omar.farooq@example.com',    'Computer Science');

INSERT INTO dbo.Enrollment (Id, CourseId, CourseTitle, StudentId, StudentName, EnrollDate, EndDate, Grade, Status) VALUES
('ENR-H1I2J3', 'CRS-A1B2C3', 'Introduction to Programming', 'STU-S1T2U3', 'Ali Raza',      '2026-01-15', NULL,         NULL,  'Enrolled'),
('ENR-K4L5M6', 'CRS-A1B2C3', 'Introduction to Programming', 'STU-E4F5G6', 'Omar Farooq',   '2026-01-16', NULL,         NULL,  'Enrolled'),
('ENR-N7O8P9', 'CRS-D4E5F6', 'Calculus I',                  'STU-V4W5X6', 'Fatima Sheikh', '2025-09-02', '2025-12-18', 'A-',  'Completed'),
('ENR-Q1R2S3', 'CRS-D4E5F6', 'Calculus I',                  'STU-Y7Z8A9', 'Hassan Iqbal',  '2026-01-10', NULL,         NULL,  'Enrolled'),
('ENR-T4U5V6', 'CRS-J1K2L3', 'Organic Chemistry',           'STU-B1C2D3', 'Zainab Tariq',  '2026-01-12', NULL,         NULL,  'Enrolled'),
('ENR-W7X8Y9', 'CRS-P7Q8R9', 'Data Structures',              'STU-S1T2U3', 'Ali Raza',      '2025-09-05', '2025-12-19', NULL,  'Dropped');

INSERT INTO dbo.Announcement (Id, Title, Message, PostedDate, IsActive) VALUES
('ANN-Z1A2B3', 'Welcome to Spring 2026!',          'Course registration is now open for all currently enrolled students. Please check with your advisor for any enrollment holds.', '2026-01-05', 1),
('ANN-C4D5E6', 'Library Hours Extended',           'The university library will now be open until midnight during exam weeks.', '2026-01-10', 1),
('ANN-F7G8H9', 'Fall 2025 Semester Concluded',     'Final grades for the Fall 2025 semester have been posted. Contact the registrar with any discrepancies.', '2025-12-20', 0);
GO
