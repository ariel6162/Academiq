CREATE TABLE Student
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(50)
)

CREATE TABLE Lecturer
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(50)
)

CREATE TABLE Course
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    LecturerId INT,
    Duration INT,
    FOREIGN KEY (LecturerId) REFERENCES Lecturer(Id)
)

CREATE TABLE Registration
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT,
    Status INT,
    FOREIGN KEY (StudentId) REFERENCES Student(Id)
)

CREATE TABLE RegistrationCourse
(
    RegistrationId INT,
    CourseId INT,
    PRIMARY KEY (RegistrationId, CourseId),
    FOREIGN KEY (RegistrationId) REFERENCES Registration(Id),
    FOREIGN KEY (CourseId) REFERENCES Course(Id)
)

-- Inserting data into the Lecturer table
INSERT INTO Lecturer (FirstName, LastName, Email)
VALUES ('John', 'Doe', 'john@sqlinq.com'),
       ('Jane', 'Smith', 'jane@sqlinq.com');

-- Inserting data into the Course table
INSERT INTO Course (Name, LecturerId, Duration)
VALUES ('Course 1', 1, 200),
       ('Course 2', 2, 200);

-- Inserting data into the Student table
INSERT INTO Student (FirstName, LastName, Email)
VALUES ('Student', 'One', 'student1@sqlinq.com'),
       ('Student', 'Two', 'student2@sqlinq.com');

-- Inserting data into the Registration table
-- Assuming that the Status column is an integer where 0 = InProgress, 1 = Completed, 2 = Cancelled
INSERT INTO Registration (StudentId, Status)
VALUES (1, 0),
       (2, 0);

-- Inserting data into the RegistrationCourse table
INSERT INTO RegistrationCourse (RegistrationId, CourseId)
VALUES (1, 1),
       (2, 2);
