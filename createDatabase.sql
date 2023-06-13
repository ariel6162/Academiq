CREATE DATABASE AcademiqDB;
GO

USE AcademiqDB;
GO

CREATE TABLE Lecturer
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Email NVARCHAR(50),
    PhoneNumber NVARCHAR(15)
);
GO

CREATE TABLE Course
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    LecturerId INT,
    Duration INT,
    DayOfWeek INT,
    StartTime TIME,
    EndTime TIME,
    FOREIGN KEY (LecturerId) REFERENCES Lecturer(Id)
);
GO

INSERT INTO Lecturer (Name, Email, PhoneNumber)
VALUES
('Avi Cohen', 'avi.cohen@sqlinq.com', '050-555-5555'),
('Miriam Levy', 'miriam.levy@sqlinq.com', '052-444-4444');
GO

INSERT INTO Course (Name, LecturerId, Duration, DayOfWeek, StartTime, EndTime)
VALUES
('Physics', 1, 60, 1, '09:00:00', '10:00:00'),
('Math', 2, 90, 1, '09:00:00', '10:00:00'),
('English', 1, 45, 2, '11:00:00', '11:45:00'),
('History', 2, 75, 2, '13:00:00', '14:15:00');
GO
