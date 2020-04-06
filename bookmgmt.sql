CREATE DATABASE BookManagement

USE BookManagement

CREATE TABLE [dbo].[Author](
	Id int PRIMARY KEY IDENTITY(1,1),
	AuthorName VARCHAR(200) NOT NULL,
	Email VARCHAR(200) 
)
Go

INSERT INTO Author VALUES('author 1','author1@gmail.com');
INSERT INTO Author VALUES('author 2','author2@gmail.com');
INSERT INTO Author VALUES('author 3','author3@gmail.com');
INSERT INTO Author VALUES('author 4','author4@gmail.com');
INSERT INTO Author VALUES('author 5','author5@gmail.com');

CREATE TABLE [dbo].[Publisher](
	Id int PRIMARY KEY IDENTITY(1,1),
	PublisherName VARCHAR(200) NOT NULL,
	Email NVARCHAR(100) 
)
Go

INSERT INTO Publisher VALUES('publisher 1','publisher1@gmail.com');
INSERT INTO Publisher VALUES('publisher 2','publisher2@gmail.com');
INSERT INTO Publisher VALUES('publisher 3','publisher3@gmail.com');
INSERT INTO Publisher VALUES('publisher 4','publisher4@gmail.com');
INSERT INTO Publisher VALUES('publisher 5','publisher5@gmail.com');


CREATE TABLE [dbo].[BookCategory](
	Id int PRIMARY KEY IDENTITY(1,1),
	Category VARCHAR(200) NOT NULL
)
Go

INSERT INTO BookCategory VALUES('Fiction');
INSERT INTO BookCategory VALUES('Action');
INSERT INTO BookCategory VALUES('Drama');
INSERT INTO BookCategory VALUES('Thriller');
INSERT INTO BookCategory VALUES('Romantic');


CREATE TABLE [dbo].[Book](
	Isbn VARCHAR(25) PRIMARY KEY,
	BookId int UNIQUE NOT NULL,
	BookName VARCHAR(100) NOT NULL,
	BookDescription VARCHAR(1000),
	BookCategoryId INT NOT NULL,
	Price money NOT NULL,
	AuthorId int NOT NULL,
	PulisherId int NOT NULL,
	Quantity int NOT NULL
)
GO


--ALTER TABLE Book ALTER COLUMN Isbn VARCHAR(20);
--ALTER TABLE Book ADD PRIMARY KEY (Isbn)

INSERT INTO Book VALUES('978-3-16-148410-0', 1, 'Origin', 'Nice book', 4, 200, 1, 2,5);
INSERT INTO Book VALUES('278-3-16-148410-0', 2, 'Book1', 'Nice book', 1, 300, 2, 1,10);
INSERT INTO Book VALUES('378-3-16-148410-0', 3, 'Book2', 'Nice book', 2, 400, 3, 2,15);
INSERT INTO Book VALUES('478-3-16-148410-0', 4, 'Book3', 'Nice book', 3, 500, 4, 1,25);
INSERT INTO Book VALUES('678-3-16-148410-0', 5, 'Book4', 'Nice book', 1, 200, 2, 3,15);
INSERT INTO Book VALUES('778-3-16-148410-0', 6, 'Book5', 'Nice book', 2, 100, 1, 5,25);
INSERT INTO Book VALUES('878-3-16-148410-0', 7, 'Book6', 'Nice book', 3, 600, 3, 1,35);
INSERT INTO Book VALUES('128-3-16-148410-0', 8, 'Book7', 'Nice book', 4, 700, 4, 2,35);
INSERT INTO Book VALUES('178-3-16-148410-0', 9, 'Book8', 'Nice book', 5, 800, 5, 3,75);

SELECT * FROM Book

ALTER TABLE Book
ADD CONSTRAINT FK_BookCategory_Book
FOREIGN KEY (BookCategoryId)
REFERENCES BookCategory(Id)

ALTER TABLE Book
ADD CONSTRAINT FK_Author_Book
FOREIGN KEY (AuthorId)
REFERENCES Author(Id)

ALTER TABLE Book
ADD CONSTRAINT FK_Publisher_Book
FOREIGN KEY (PulisherId)
REFERENCES Publisher(Id)

--CREATE TABLE [dbo].[MemberType](
--	Id int PRIMARY KEY IDENTITY(1,1),
--	Type VARCHAR(200) NOT NULL,
--	Duration int NOT NULL
--)Go

--ALTER TABLE MemberType
--ADD CONSTRAINT CHK_Duration
--CHECK (Duration>0)

--CREATE TABLE [dbo].[Member](
--	Id int PRIMARY KEY IDENTITY(1,1),
--	MemberName VARCHAR(100) NOT NULL,
--	MemberAddress VARCHAR(1000) NOT NULL,
--	Email VARCHAR(256),
--	MemberTypeId int NOT NULL
--)Go

--ALTER TABLE [Member]
--ADD CONSTRAINT FK_MemberType_Member
--FOREIGN KEY (MemberTypeId)
--REFERENCES MemberType(Id)

CREATE TABLE [dbo].[Roles](
	Id INT PRIMARY KEY IDENTITY(1,1),
	RoleName VARCHAR(100) NOT NULL
)
Go

CREATE TABLE [dbo].[Users](
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(200) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Password VARCHAR(30) NOT NULL
)
Go

CREATE TABLE [dbo].[UserRoles] (
  Id INT PRIMARY KEY IDENTITY(1,1),
  UserId INTEGER NOT NULL,
  RoleId INTEGER NOT NULL,
  UNIQUE (userId, roleId),
  FOREIGN KEY (userId) references Users(Id),
  FOREIGN KEY (roleId) references Roles(Id)
)
Go

INSERT INTO Users VALUES('Ankit','ankit@gmail.com','12345');

SELECT * FROM Users