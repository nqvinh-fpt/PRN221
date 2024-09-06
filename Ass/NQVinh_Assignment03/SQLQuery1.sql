
use PRN_Ass3
-- Tạo bảng EventCategories
CREATE TABLE EventCategories (
    CategoryID int PRIMARY KEY NOT NULL IDENTITY,
    CategoryName nvarchar(255) NOT NULL
);

-- Tạo bảng Events
CREATE TABLE Events (
    EventID int PRIMARY KEY NOT NULL IDENTITY,
    Title nvarchar(255) NOT NULL,
    Description text,
    StartTime datetime,
    EndTime datetime,
    Location nvarchar(255),
    CategoryID int,
    FOREIGN KEY (CategoryID) REFERENCES EventCategories(CategoryID)
);

-- Tạo bảng Users
CREATE TABLE Users (
    UserID int PRIMARY KEY NOT NULL IDENTITY,
    Username nvarchar(255) NOT NULL,
    Password nvarchar(255) NOT NULL,
    Email nvarchar(255),
    Role nvarchar(50)
);

-- Tạo bảng Attendees
CREATE TABLE Attendees (
    AttendeeID int PRIMARY KEY NOT NULL IDENTITY,
    EventID int,
    UserID int,
    Name nvarchar(255),
    Email nvarchar(255),
    RegistrationTime datetime,
    FOREIGN KEY (EventID) REFERENCES Events(EventID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Chèn dữ liệu vào bảng EventCategories
INSERT INTO EventCategories (CategoryName) VALUES 
    ('Conference'),
    ('Seminar'),
    ('Workshop'),
    ('Networking Event'),
    ('Training');

-- Chèn dữ liệu vào bảng Events
INSERT INTO Events (Title, Description, StartTime, EndTime, Location, CategoryID) VALUES
    ('Annual Conference 2024', 'Annual conference for professionals in the industry.', '2024-05-15 09:00:00', '2024-05-17 17:00:00', 'Convention Center A', 1),
    ('Financial Planning Seminar', 'Learn about financial planning strategies.', '2024-04-20 14:00:00', '2024-04-20 18:00:00', 'Community Hall B', 2),
    ('Photography Workshop', 'Hands-on workshop for beginner photographers.', '2024-03-10 10:00:00', '2024-03-10 16:00:00', 'Studio XYZ', 3),
    ('Business Networking Event', 'Opportunity to network with professionals in the industry.', '2024-06-02 18:00:00', '2024-06-02 20:00:00', 'Restaurant ABC', 4),
    ('Software Development Training', 'Training session for software developers.', '2024-07-08 09:00:00', '2024-07-10 17:00:00', 'Training Center 123', 5);

-- Chèn dữ liệu vào bảng Users
INSERT INTO Users (Username, Password, Email, Role) VALUES
    ('john_doe', 'password123', 'john@example.com', 'Admin'),
    ('jane_smith', 'abc123', 'jane@example.com', 'User'),
    ('mike_jackson', 'pass456', 'mike@example.com', 'User'),
    ('sara_adams', 'sara123', 'sara@example.com', 'User'),
    ('admin', 'adminpass', 'admin@example.com', 'Admin');

-- Chèn dữ liệu vào bảng Attendees
INSERT INTO Attendees (EventID, UserID, Name, Email, RegistrationTime) VALUES
    (1, 2, 'Jane Smith', 'jane@example.com', '2024-05-10 08:30:00'),
    (2, 3, 'Mike Jackson', 'mike@example.com', '2024-04-18 13:45:00'),
    (3, 4, 'Sara Adams', 'sara@example.com', '2024-03-05 09:20:00'),
    (4, 5, 'Admin', 'admin@example.com', '2024-06-01 17:30:00'),
    (5, 2, 'Jane Smith', 'jane@example.com', '2024-07-01 11:10:00');
