USE master
GO

----------------------------------------------------- CREATE DATABASE -----------------------------------------------------

IF EXISTS(select * from sys.databases where name='HeThongQuanLyCongTacKhaoThi')
	DROP DATABASE HeThongQuanLyCongTacKhaoThi
GO
CREATE DATABASE HeThongQuanLyCongTacKhaoThi
GO
USE HeThongQuanLyCongTacKhaoThi
GO

CREATE TABLE ACTION(
	ID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL,
	ActionCode INT NOT NULL
)
GO

CREATE TABLE PERMISSION(
	ID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30) DEFAULT 1 NOT NULL
)
GO

CREATE TABLE PERMISSION_DETAIL(
	ActionID INT,
	PermissionID INT,
	Licensed BIT DEFAULT 1 NOT NULL,	-- 1: Active, 0: Disable

	FOREIGN KEY (ActionID) REFERENCES ACTION(ID),
	FOREIGN KEY (PermissionID) REFERENCES dbo.PERMISSION(ID),
	PRIMARY KEY(ActionID, PermissionID)
)
GO

CREATE TABLE CLASS(
	ID VARCHAR(15) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	StudentCount INT DEFAULT 0 NOT NULL
)
GO

CREATE TABLE ACCOUNT(
	Username VARCHAR(30) PRIMARY KEY,
	Password VARCHAR(50) DEFAULT 'c4ca4238a0b923820dcc509a6f75849b' NOT NULL, -- default pass: '1'
	ID VARCHAR(10),	-- Null for admin
	Name NVARCHAR(50) NOT NULL,
	Gender BIT NOT NULL DEFAULT 1, -- 1: Male, 2: Female
	ClassID VARCHAR(15),	-- Null for admin, teacher
	Birthday DATE NOT NULL,
	Address NVARCHAR(100), -- Null for admin

	FOREIGN KEY(ClassID) REFERENCES dbo.CLASS(ID)
)
GO

CREATE TABLE ACCOUNT_PERMISSION(
	Username VARCHAR(30),
	PermissionID INT,
	Licensed BIT DEFAULT 1 NOT NULL,

	FOREIGN KEY (Username) REFERENCES dbo.ACCOUNT(Username),
	FOREIGN KEY (PermissionID) REFERENCES dbo.PERMISSION(ID)
)
GO

CREATE TABLE SUBJECT(
	ID VARCHAR(10) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	AssiduousScorePercent DECIMAL(4, 2) DEFAULT 10/100 CHECK(AssiduousScorePercent BETWEEN 0 AND 100) NOT NULL,
	FrequentScorePercent DECIMAL(4, 2) DEFAULT 20/100 CHECK(FrequentScorePercent BETWEEN 0 AND 100) NOT NULL,
	MiddleScorePercent DECIMAL(4, 2) DEFAULT 20/100 CHECK(MiddleScorePercent BETWEEN 0 AND 100) NOT NULL,
	FinalScorePercent DECIMAL(4, 2) DEFAULT 50/100 CHECK(FinalScorePercent BETWEEN 0 AND 100) NOT NULL,
	CreditCount INT NOT NULL
)
GO

CREATE TABLE SUBJECT_TEACHER(
	Username VARCHAR(30),
	SubjectID VARCHAR(10),
	ClassID VARCHAR(15),

	FOREIGN KEY (Username) REFERENCES dbo.ACCOUNT(Username),
	FOREIGN KEY (SubjectID) REFERENCES dbo.SUBJECT(ID),
	FOREIGN KEY (ClassID) REFERENCES dbo.CLASS(ID),

	PRIMARY KEY(Username, SubjectID, ClassID)
)
GO

CREATE TABLE SCORE(
	ID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(20) NOT NULL
	-- Điểm chuyên cần, điểm thường xuyên, điểm giữa môn học, điểm kết thúc môn học
)
GO

CREATE TABLE QUESTION_BANK(
	ID INT IDENTITY PRIMARY KEY,
	SubjectID VARCHAR(10) NOT NULL,
	Content NVARCHAR(500) NOT NULL,
	IsMultipleChoice BIT DEFAULT 1 NOT NULL,

	FOREIGN KEY (SubjectID) REFERENCES dbo.SUBJECT(ID)
)
GO

CREATE TABLE ANSWER_BANK(
	ID INT IDENTITY PRIMARY KEY,
	QuestionID INT NOT NULL,
	Content NVARCHAR(500) NOT NULL,
	IsCorrect BIT DEFAULT 0 NOT NULL, -- 1: Correct, 0: Wrong

	FOREIGN KEY (QuestionID) REFERENCES dbo.QUESTION_BANK(ID)
)
GO

CREATE TABLE EXAM(
	ID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE EXAM_DETAIL(
	ExamID INT NOT NULL,
	QuestionID INT NOT NULL,

	FOREIGN KEY (ExamID) REFERENCES dbo.EXAM(ID),
	FOREIGN KEY (QuestionID) REFERENCES dbo.QUESTION_BANK(ID),

	PRIMARY KEY (ExamID, QuestionID)
)
GO

CREATE TABLE STUDENT_ANSWER(
	ID INT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) NOT NULL,
	ExamID INT NOT NULL,

	FOREIGN KEY (ExamID) REFERENCES dbo.EXAM(ID)
)
GO

CREATE TABLE STUDENT_ANSWER_DETAIL(
	ID INT IDENTITY PRIMARY KEY,
	Student_AnswerID INT NOT NULL,
	QuestionID INT NOT NULL,
	AnswerID INT,
	EssayPath NVARCHAR(300) DEFAULT NULL,
	Mark DECIMAL(4, 2) DEFAULT NULL

	FOREIGN KEY (Student_AnswerID) REFERENCES dbo.STUDENT_ANSWER(ID),
	FOREIGN KEY (QuestionID) REFERENCES dbo.QUESTION_BANK(ID),
	FOREIGN KEY (AnswerID) REFERENCES dbo.ANSWER_BANK(ID),
	
	-- If AnswerID is null, EssayPath and Mark won't null
)
GO

CREATE TABLE RESULT(
	ID INT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) NOT NULL,
	SubjectID VARCHAR(10) NOT NULL,
	ScoreID INT NOT NULL,
	ExamID INT NOT NULL,
	Student_AnswerID INT NOT NULL,
	Mark DECIMAL(4, 2) CHECK(Mark BETWEEN 0 AND 10) NOT NULL,
	Time TINYINT DEFAULT 1 NOT NULL,

	FOREIGN KEY (Username) REFERENCES dbo.ACCOUNT(Username),
	FOREIGN KEY (SubjectID) REFERENCES dbo.SUBJECT(ID),
	FOREIGN KEY (ScoreID) REFERENCES dbo.SCORE(ID),
	FOREIGN KEY (ExamID) REFERENCES dbo.EXAM(ID),
	FOREIGN KEY (Student_AnswerID) REFERENCES dbo.STUDENT_ANSWER(ID)
)
GO

----------------------------------------------------- END CREATE DATABASE -----------------------------------------------------

----------------------------------------------------- CREATE PROCEDURE -----------------------------------------------------

CREATE PROC proc_GetAllPermissions
AS
BEGIN
	SELECT Name, Permissions = STUFF((SELECT ', ' + dbo.ACTION.Name
								FROM (dbo.PERMISSION_DETAIL pd2 INNER JOIN dbo.ACTION ON ACTION.ID = pd2.ActionID)
								WHERE pd2.PermissionID = pd1.PermissionID FOR XML PATH('')), 1, 1, '')
	FROM dbo.PERMISSION_DETAIL pd1 INNER JOIN dbo.PERMISSION ON PERMISSION.ID = pd1.PermissionID
	GROUP BY Name, pd1.PermissionID
END
GO

CREATE PROC proc_GetAllUserPermissions
AS
BEGIN
	SELECT ACCOUNT.Username, PERMISSION.Name, Permissions = STUFF((SELECT ', ' + dbo.ACTION.Name
								FROM (dbo.PERMISSION_DETAIL pd2 INNER JOIN dbo.ACTION ON ACTION.ID = pd2.ActionID)
								WHERE pd2.PermissionID = pd1.PermissionID FOR XML PATH('')), 1, 1, '')
	FROM dbo.ACCOUNT_PERMISSION INNER JOIN dbo.PERMISSION_DETAIL pd1 ON pd1.PermissionID = ACCOUNT_PERMISSION.PermissionID
								INNER JOIN dbo.PERMISSION ON PERMISSION.ID = pd1.PermissionID
								INNER JOIN dbo.ACCOUNT ON ACCOUNT.Username = ACCOUNT_PERMISSION.Username
	GROUP BY ACCOUNT.Username, PERMISSION.Name, pd1.PermissionID
	ORDER BY PERMISSION.Name
END
GO

CREATE PROC proc_GetUserPermission
@Username VARCHAR(30)
AS
BEGIN
	SELECT ACCOUNT.Username, PERMISSION.Name, Permissions = STUFF((SELECT ', ' + dbo.ACTION.Name
								FROM (dbo.PERMISSION_DETAIL pd2 INNER JOIN dbo.ACTION ON ACTION.ID = pd2.ActionID)
								WHERE pd2.PermissionID = pd1.PermissionID FOR XML PATH('')), 1, 1, '')
	FROM dbo.ACCOUNT_PERMISSION INNER JOIN dbo.PERMISSION_DETAIL pd1 ON pd1.PermissionID = ACCOUNT_PERMISSION.PermissionID
								INNER JOIN dbo.PERMISSION ON PERMISSION.ID = pd1.PermissionID
								INNER JOIN dbo.ACCOUNT ON ACCOUNT.Username = ACCOUNT_PERMISSION.Username
	WHERE dbo.ACCOUNT.Username = @Username
	GROUP BY ACCOUNT.Username, PERMISSION.Name, pd1.PermissionID
END
GO


-- Get all multiple choice questions and correct answers by exam id
CREATE PROC proc_GetAllMCQuestsAndCorrectAnssByExamID
@ExamID INT
AS
BEGIN
    SELECT ExamID, QUESTION_BANK.ID [QuestionID], QUESTION_BANK.Content [Question], ANSWER_BANK.ID [AnswerID], ANSWER_BANK.Content [CorrectAnswer]
	FROM dbo.EXAM_DETAIL INNER JOIN dbo.QUESTION_BANK ON QUESTION_BANK.ID = EXAM_DETAIL.QuestionID
						INNER JOIN dbo.ANSWER_BANK ON ANSWER_BANK.QuestionID = QUESTION_BANK.ID
	WHERE ExamID = @ExamID AND IsMultipleChoice = 1 AND IsCorrect = 1
END
GO


-- Get all multiple choice questions and answers of student by exam id
CREATE PROC proc_GetAllMCQuestsAndAnssOfStudentByExamID
@Username VARCHAR(30),
@ExamID INT
AS
BEGIN
	SELECT ExamID, ANSWER_BANK.QuestionID, QUESTION_BANK.Content, AnswerID, ANSWER_BANK.Content, IsCorrect
	FROM dbo.STUDENT_ANSWER INNER JOIN dbo.STUDENT_ANSWER_DETAIL ON STUDENT_ANSWER_DETAIL.Student_AnswerID = STUDENT_ANSWER.ID
							INNER JOIN dbo.QUESTION_BANK ON QUESTION_BANK.ID = STUDENT_ANSWER_DETAIL.QuestionID
							INNER JOIN dbo.ANSWER_BANK ON ANSWER_BANK.ID = STUDENT_ANSWER_DETAIL.AnswerID
	WHERE Username = @Username AND ExamID = @ExamID AND IsMultipleChoice = 1
END
GO




----------------------------------------------------- END CREATE PROCEDURE -----------------------------------------------------

----------------------------------------------------- CREATE FUNCTION -----------------------------------------------------

-- Get correct answer count of multiple choice question of student by exam id
CREATE FUNCTION ufn_GetCorrectAnsCountOfMCQuestOfStudentByExamID(@Username VARCHAR(30), @ExamID INT)
RETURNS TINYINT
AS
BEGIN
	DECLARE @correctAnsCount TINYINT

    SELECT @correctAnsCount = SUM(CAST(IsCorrect AS TINYINT))
	FROM dbo.STUDENT_ANSWER INNER JOIN dbo.STUDENT_ANSWER_DETAIL ON STUDENT_ANSWER_DETAIL.Student_AnswerID = STUDENT_ANSWER.ID
							INNER JOIN dbo.QUESTION_BANK ON QUESTION_BANK.ID = STUDENT_ANSWER_DETAIL.QuestionID
							INNER JOIN dbo.ANSWER_BANK ON ANSWER_BANK.ID = STUDENT_ANSWER_DETAIL.AnswerID
	WHERE Username = @Username AND ExamID = @ExamID AND IsMultipleChoice = 1

	RETURN @correctAnsCount
END
GO


-- Get multiple choice question count of examid
CREATE FUNCTION ufn_GetMCQuestCountByExamID(@ExamID INT)
RETURNS TINYINT
AS
BEGIN
    DECLARE @ansCount TINYINT

	SELECT @ansCount = COUNT(*)
	FROM dbo.EXAM_DETAIL INNER JOIN dbo.QUESTION_BANK ON QUESTION_BANK.ID = EXAM_DETAIL.QuestionID
	WHERE ExamID = @ExamID AND IsMultipleChoice = 1

	RETURN @ansCount
END
GO

----------------------------------------------------- END CREATE FUNCTION -----------------------------------------------------

----------------------------------------------------- CREATE TRIGGER -----------------------------------------------------

-- Insert, delete, update student will update student count in class
CREATE TRIGGER trg_UpdateStudentCountOfClass
ON dbo.ACCOUNT
FOR INSERT, DELETE, UPDATE
AS
BEGIN
	UPDATE dbo.CLASS
	SET StudentCount = StudentCount + 1
	WHERE ID IN (SELECT Inserted.ClassID FROM Inserted)

	UPDATE dbo.CLASS
	SET StudentCount = StudentCount - 1
	WHERE ID IN (SELECT Deleted.ClassID FROM Deleted)
END
GO

----------------------------------------------------- END CREATE TRIGGER -----------------------------------------------------

----------------------------------------------------- INSERT DATA -----------------------------------------------------

------- ACTION DATA
INSERT INTO dbo.ACTION(Name, ActionCode) VALUES(N'Thêm', 100)
INSERT INTO dbo.ACTION(Name, ActionCode) VALUES(N'Sửa', 101)
INSERT INTO dbo.ACTION(Name, ActionCode) VALUES(N'Xóa', 102)
INSERT INTO dbo.ACTION(Name, ActionCode) VALUES(N'Xem', 103)


------- PERMISSION DATA
INSERT INTO dbo.PERMISSION (Name) VALUES(N'Quản trị viên')
INSERT INTO dbo.PERMISSION (Name) VALUES(N'Giảng viên')
INSERT INTO dbo.PERMISSION (Name) VALUES(N'Sinh viên')


------- PERMISSION_DETAIL DATA
-- Admin can insert, update, delete and view
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(1, 1)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(2, 1)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(3, 1)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(4, 1)
-- Teacher can insert, update, delete and view
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(1, 2)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(2, 2)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(3, 2)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(4, 2)
-- Student only update and view
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(2, 3)
INSERT INTO dbo.PERMISSION_DETAIL(ActionID, PermissionID) VALUES(4, 3)


------- CLASS DATA
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN1A', N'Đại học công nghệ 1A')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN1B', N'Đại học công nghệ 1B')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN1C', N'Đại học công nghệ 1C')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN1D', N'Đại học công nghệ 1D')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN2A', N'Đại học công nghệ 2A')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN2B', N'Đại học công nghệ 2B')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN3A', N'Đại học công nghệ 3A')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN3B', N'Đại học công nghệ 3B')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN3C', N'Đại học công nghệ 3C')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN4A', N'Đại học công nghệ 4A')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHCN4B', N'Đại học công nghệ 4B')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHVT1', N'Đại học viễn thông 1')
INSERT INTO dbo.CLASS(ID, Name) VALUES('DHVT2', N'Đại học viễn thông 2')


------- ACCOUNT DATA
INSERT INTO dbo.ACCOUNT(Username, Name, Gender, Birthday) VALUES('admin', N'ADMIN', 1, '1999-09-27')

INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, Birthday, Address) VALUES('lehien', 'GV001', N'Lê Thị Hiền', 0, '1983-10-10', N'Nghệ An')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, Birthday, Address) VALUES('vanhoan', 'GV002', N'Nguyễn Văn Hoàn', 1, '1968-09-27', N'Nghệ An')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, Birthday, Address) VALUES('legiang', 'GV003', N'Lê Thị Giang', 0, '1983-03-10', N'Nghệ An')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, Birthday, Address) VALUES('dotuan', 'GV004', N'Đỗ Văn Tuấn', 1, '1985-08-20', N'Nghệ An')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, Birthday, Address) VALUES('trantam', 'GV005', N'Trần Minh Tâm', 1, '1985-02-25', N'Nghệ An')

INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('htthinh1999', '17DC027', N'Huỳnh Tấn Thịnh', 1, 'DHCN4A', '1999-09-27', N'Khánh Hòa')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('ducbac', '17DC003', N'Đinh Đức Bắc', 1, 'DHCN4A', '1998-01-02', N'Quảng Trị')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('thongnguyen', '17DC021', N'Nguyễn Minh Thông', 1, 'DHCN4A', '1999-06-19', N'Bình Thuận')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('shuuan', '17DC001', N'Hoàng Phước An', 1, 'DHCN4A', '1999-10-13', N'Quảng Trị')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('ngochuynh', '17DC041', N'Huỳnh Thị Ngọc', 0, 'DHCN4B', '1999-05-14', N'Khánh Hòa')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('copsilvery', '17DC056', N'Nguyễn Duy Đạt', 1, 'DHCN4B', '1998-03-12', N'Hà Nội')
INSERT INTO dbo.ACCOUNT(Username, ID, Name, Gender, ClassID, Birthday, Address) VALUES('vtvduc', '17DC033', N'Cao Viết Đức', 1, 'DHCN4B', '1997-05-04', N'Phú Yên')

------- ACCOUNT_PERMISSION DATA
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('admin', 1)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('lehien', 2)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('vanhoan', 2)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('legiang', 2)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('dotuan', 2)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('trantam', 2)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('htthinh1999', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('ducbac', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('thongnguyen', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('shuuan', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('ngochuynh', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('copsilvery', 3)
INSERT INTO dbo.ACCOUNT_PERMISSION(Username, PermissionID) VALUES('vtvduc', 3)


------- SUBJECT DATA
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('CC4206', N'Nhập môn lập trình', 3)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DH4202', N'Kỹ thuật lập trình', 3)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DH4203', N'Cấu trúc dữ liệu & giải thuật', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('TC4209', N'Lập trình hướng đối tượng', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DC4204', N'Cơ sở dữ liệu', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DC4106', N'Kiến trúc máy tính', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DT4208', N'Lập trình JAVA', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DT4315', N'Công Nghệ Phần Mềm', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DT4205', N'SQL Server', 4)
INSERT INTO dbo.SUBJECT(ID, Name, CreditCount) VALUES('DT4301', N'Mạng máy tính', 4)


------- SUBJECT_TEACHER DATA
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('trantam', 'CC4206', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('dotuan', 'DH4202', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('lehien', 'DH4203', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('dotuan', 'TC4209', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('legiang', 'DC4204', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('vanhoan', 'DC4106', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('legiang', 'DT4208', 'DHCN4A')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('trantam', 'CC4206', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('dotuan', 'DH4202', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('lehien', 'DH4203', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('dotuan', 'TC4209', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('legiang', 'DC4204', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('vanhoan', 'DC4106', 'DHCN4B')
INSERT INTO dbo.SUBJECT_TEACHER(Username, SubjectID, ClassID) VALUES ('legiang', 'DT4208', 'DHCN4B')


------- QUESTION_BANK & ANSWER_BANK DATA
INSERT INTO dbo.QUESTION_BANK(SubjectID, Content, IsMultipleChoice) VALUES('CC4206', N'Xâu định dạng nào dưới đây dùng để in ra một số nguyên?', 1)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(1, N'%u', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(1, N'%e', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(1, N'%d', 1)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(1, N'%p', 0)

INSERT INTO dbo.QUESTION_BANK(SubjectID, Content, IsMultipleChoice) VALUES('CC4206', N'Dữ liệu kí tự bao gồm?', 1)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(2, N'Các kí tự số chữ số', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(2, N'Các kí tự số chữ cái', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(2, N'Các kí tự đặc biệt', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(2, N'Cả a, b và c', 1)

INSERT INTO dbo.QUESTION_BANK(SubjectID, Content, IsMultipleChoice) VALUES('CC4206', N'Viết chương trình tính tổng 2 số nguyên dương bằng C++?', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(3, N'#include<iostream>
using namespace std;
int main(){
	int a, b;
	
	do{
		cout<<"Nhập 2 số nguyên dương (a>0, b>0): "
		cin>>a>>b;
	}while(a<=0 || b<=0);
	cout<<"Tổng 2 số: "<<a+b<<endl;
	return 0;
}', 1)

INSERT INTO dbo.QUESTION_BANK(SubjectID, Content, IsMultipleChoice) VALUES('CC4206', N'Viết chương trình tính hiệu 2 số nguyên không âm bằng C++?', 0)
INSERT INTO dbo.ANSWER_BANK(QuestionID, Content, IsCorrect) VALUES(4, N'#include<iostream>
using namespace std;
int main(){
	int a, b;
	
	do{
		cout<<"Nhập 2 số nguyên không âm (a>=0, b>=0): "
		cin>>a>>b;
	}while(a<0 || b<0);
	cout<<"Hiệu 2 số: "<<a-b<<endl;
	return 0;
}', 1)


------- EXAM DATA
INSERT INTO dbo.EXAM(Name) VALUES(N'Đề thi "Nhập môn lập trình" số 1')
INSERT INTO dbo.EXAM(Name) VALUES(N'Đề thi "Nhập môn lập trình" số 2')
INSERT INTO dbo.EXAM(Name) VALUES(N'Đề thi "Nhập môn lập trình" số 3')
INSERT INTO dbo.EXAM(Name) VALUES(N'Đề thi "Nhập môn lập trình" số 4')


------- EXAM_DETAIL DATA
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(1, 1)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(1, 3)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(2, 1)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(2, 4)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(3, 2)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(3, 3)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(4, 2)
INSERT INTO dbo.EXAM_DETAIL(ExamID, QuestionID) VALUES(4, 4)


------- STUDENT_ANSWER & STUDENT_ANSWER_DETAIL DATA
INSERT INTO dbo.STUDENT_ANSWER(Username, ExamID) VALUES('htthinh1999', 1)
INSERT INTO dbo.STUDENT_ANSWER_DETAIL(Student_AnswerID, QuestionID, AnswerID, EssayPath, Mark) VALUES(1, 1, 3, NULL, NULL)

INSERT INTO dbo.STUDENT_ANSWER(Username, ExamID) VALUES('copsilvery', 2)
INSERT INTO dbo.STUDENT_ANSWER_DETAIL(Student_AnswerID, QuestionID, AnswerID, EssayPath, Mark) VALUES(2, 1, 1, NULL, NULL)

INSERT INTO dbo.STUDENT_ANSWER(Username, ExamID) VALUES('ducbac', 3)
INSERT INTO dbo.STUDENT_ANSWER_DETAIL(Student_AnswerID, QuestionID, AnswerID, EssayPath, Mark) VALUES(3, 2, 8, NULL, NULL)



----------------------------------------------------- END INSERT DATA -----------------------------------------------------


------- TEST PROCEDURE, FUNCTION

DECLARE @username1 VARCHAR(30) = 'admin'
DECLARE @username2 VARCHAR(30) = 'htthinh1999'
DECLARE @username3 VARCHAR(30) = 'copsilvery'
DECLARE @username4 VARCHAR(30) = 'ducbac'
DECLARE @examID1 INT = 1
DECLARE @examID2 INT = 2
DECLARE @examID3 INT = 3

EXEC dbo.proc_GetAllPermissions
EXEC dbo.proc_GetAllUserPermissions
EXEC dbo.proc_GetUserPermission @Username = @username1
EXEC dbo.proc_GetAllMCQuestsAndCorrectAnssByExamID @ExamID = 1
EXEC dbo.proc_GetAllMCQuestsAndAnssOfStudentByExamID @Username = @username2, @ExamID = 1
EXEC dbo.proc_GetAllMCQuestsAndCorrectAnssByExamID @ExamID = 2
EXEC dbo.proc_GetAllMCQuestsAndAnssOfStudentByExamID @Username = @username3, @ExamID = 2
EXEC dbo.proc_GetAllMCQuestsAndCorrectAnssByExamID @ExamID = 3
EXEC dbo.proc_GetAllMCQuestsAndAnssOfStudentByExamID @Username = @username4, @ExamID = 3

PRINT N'Số câu trả lời đúng của ' + @username2 + ': ' + CAST(dbo.ufn_GetResultOfMCQuestOfStudentByExamID(@username2, @examID1) AS NVARCHAR) + '/' + CAST(dbo.ufn_GetMCQuestCountByExamID(@examID1) AS NVARCHAR)
PRINT N'Số câu trả lời đúng của ' + @username3 + ': ' + CAST(dbo.ufn_GetResultOfMCQuestOfStudentByExamID(@username3, @examID2) AS NVARCHAR) + '/' + CAST(dbo.ufn_GetMCQuestCountByExamID(@examID2) AS NVARCHAR)
PRINT N'Số câu trả lời đúng của ' + @username4 + ': ' + CAST(dbo.ufn_GetResultOfMCQuestOfStudentByExamID(@username4, @examID3) AS NVARCHAR) + '/' + CAST(dbo.ufn_GetMCQuestCountByExamID(@examID3) AS NVARCHAR)
