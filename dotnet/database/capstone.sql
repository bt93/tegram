USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1)NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE photos (
	photo_id int IDENTITY(1,1) NOT NULL,
	file_path varchar(200) NOT NULL,
	like_count int DEFAULT 0 NOT NULL,
	user_id int NOT NULL,
	CONSTRAINT PK_photo PRIMARY KEY (photo_id),
	CONSTRAINT FK_user FOREIGN KEY (user_id) REFERENCES users(user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Lace','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Porter','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Jason','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Seth','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO photos (file_path, user_id) VALUES ('C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\dogs_1280p_0.jpg', 1);
INSERT INTO photos (file_path, user_id) VALUES ('C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\3408.jpg', 2);
INSERT INTO photos (file_path, user_id) VALUES ('C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\dog-tales-img.jpg', 3);
INSERT INTO photos (file_path, user_id) VALUES ('C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\domestic-dog_thumb.jpg', 4);
INSERT INTO photos (file_path, user_id) VALUES ('C:\Users\Student\git\c-final-capstone-te-gram\dotnet\Capstone\photos\pearl_16x9.jpg', 5);
GO

select * from photos