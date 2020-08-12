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
	user_bio varchar (200),
	user_photo_path varchar (200),
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE photos (
	photo_id int IDENTITY(1,1) NOT NULL,
	file_path varchar(200) NOT NULL,
	like_count int DEFAULT 0 NOT NULL,
	caption varchar(200),
	user_id int NOT NULL,
	CONSTRAINT PK_photo PRIMARY KEY (photo_id),
	CONSTRAINT FK_user FOREIGN KEY (user_id) REFERENCES users(user_id)
)
CREATE TABLE comments (
	comment_id int IDENTITY(1,1) NOT NULL,
	user_id int not null,
	contents varchar(200),
	photo_id int NOT NULL,
	CONSTRAINT PK_comment PRIMARY KEY (comment_id),
	CONSTRAINT FK_photo_comment FOREIGN KEY (photo_id) REFERENCES photos(photo_id),
	CONSTRAINT FK_User_comment FOREIGN KEY(user_id) REFERENCES users(user_id)
)
CREATE TABLE like_photo (
	like_photo_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	photo_id int NOT NULL,
	CONSTRAINT PK_like_photo PRIMARY KEY (like_photo_id),
	CONSTRAINT FK_user_like FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_photo_like FOREIGN KEY (photo_id) REFERENCES photos(photo_id)
)
CREATE TABLE favorite_photo (
	favorite_photo_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	photo_id int NOT NULL,
	CONSTRAINT PK_favorite_photo PRIMARY KEY (favorite_photo_id),
	CONSTRAINT FK_user_favorite FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_photo_favorite FOREIGN KEY (photo_id) REFERENCES photos(photo_id)
)

--populate default data


INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a person');
INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('Lace','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a guy');
INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('Porter','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a bro');
INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('Jason','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a lady');
INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('Seth','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a dude');
INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('Val','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Im a man');

INSERT INTO users (username, password_hash, salt, user_role, user_bio) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'Im a pisces');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596548892/TE-Gram/pearl_16x9_tqkcko.jpg', 1, 'There is literally no better creature on earth.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596548892/TE-Gram/3408_xxawqk.jpg', 2, 'Cats rule, dogs drool! ....wait.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596548892/TE-Gram/dogs_1280p_0_ofuwsx.jpg', 3, 'Dogs for the win!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596548895/TE-Gram/domestic-dog_thumb_yacyjk.jpg', 4, 'At what point do dogs stop being awesome.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596548892/TE-Gram/dogs_1280p_0_ofuwsx.jpg', 4, 'This is a dog. How do I know? Because it is awesome.');


INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549818/TE-Gram/TEworkplacePhoto01_ijjkfl.jpg', 6, 'Look at him shred!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549847/TE-Gram/TEworkplacePhoto02_tvoubo.jpg', 6, 'Ohhh, a Blue Snowball microphone!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549876/TE-Gram/TEworkplacePhoto03_jxhqpd.jpg', 6, 'Hi, kitty cat!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549962/TE-Gram/TEworkplacePhoto04_akg4dc.jpg', 6, 'Nominated for "Best Lit Workspace in TE"!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549942/TE-Gram/TEworkplacePhoto05_i6qofg.jpg', 6, 'Solid funko-pop. Fallout for the win!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549918/TE-Gram/TEworkplacePhoto06_prwc8s.jpg', 6, 'The look of a man trying to get the darn camera to work.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549943/TE-Gram/TEworkplacePhoto07_h1oyoq.jpg', 6, 'Sigh. I should have moved the trashcan.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549813/TE-Gram/TEworkplacePhoto08_a5mujf.jpg', 6, 'Two more monitors and he would be able to read the Matrix.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549853/TE-Gram/TEworkplacePhoto09_gg56dq.jpg', 6, 'Is that... Yep. A dedicated cat drawer.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549856/TE-Gram/TEworkplacePhoto10_txpocn.jpg', 6, 'GO BROWNIES!!!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549880/TE-Gram/TEworkplacePhoto11_t00vnj.jpg', 6, 'The importance of staying hydrated can not be overstated.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549961/TE-Gram/TEworkplacePhoto12_hf6obs.jpg', 6, 'Look at that monitor mount!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549876/TE-Gram/TEworkplacePhoto13_kjb9az.jpg', 6, 'Go, Bobcats!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549728/TE-Gram/TEworkplacePhoto14_icubge.jpg', 6, 'That looks like a heavy duty desktop in the background!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549781/TE-Gram/TEworkplacePhoto15_k56p8v.jpg', 6, 'Ready to develop software and chew bubblegum. And I am all out of gum.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549742/TE-Gram/TEworkplacePhoto16_m3kz0t.jpg', 6, 'Nobody "Dad-jokes" as well as Ed.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549764/TE-Gram/TEworkplacePhoto17_hrf4de.jpg', 6, 'JOELO! Nice penguin.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549791/TE-Gram/TEworkplacePhoto18_t5weuz.jpg', 6, 'OH! IO!');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549813/TE-Gram/TEworkplacePhoto19_msw98r.png', 6, 'It can be difficult remote learning from the jungle, but I make it work.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549798/TE-Gram/TEworkplacePhoto20_mopxyq.jpg', 6, 'Perspective shift can be an absolutely terrifying thing.');
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549843/TE-Gram/TEworkplacePhoto21_l4cehq.jpg', 6, 'Winner of the "most screens" award. Thanks, Mike!');


INSERT INTO like_photo (user_id, photo_id) VALUES (6, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (4, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (2, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (6, 12);
INSERT INTO like_photo (user_id, photo_id) VALUES (6, 8);
INSERT INTO like_photo (user_id, photo_id) VALUES (2, 3);
INSERT INTO like_photo (user_id, photo_id) VALUES (2, 2);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 2);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 3);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 10);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 7);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 14);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 15);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 12);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 11);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 21);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 19);


-- dummy data: Comments.

INSERT INTO comments (user_id, contents, photo_id) VALUES (3, 'Hahaha! You really should have!', 12);
INSERT INTO comments (user_id, contents, photo_id) VALUES (4, 'Yeah, man, thats a mess!', 12);
INSERT INTO comments (user_id, contents, photo_id) VALUES (1, 'What, were you born in a barn?', 12);
INSERT INTO comments (user_id, contents, photo_id) VALUES (5, 'Eh, Ive seen worse.', 12);

--Dummy Data: Favorited Photos

INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 12);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 1);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 18);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 20);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 7);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 3);
INSERT INTO favorite_photo (user_id, photo_id) VALUES (6, 4);

--Create a stored procedure to delete photos
GO

CREATE PROCEDURE deletePhoto 
@photo_id int 
AS
BEGIN TRANSACTION
DELETE FROM favorite_photo where photo_id = @photo_id
DELETE FROM like_photo where photo_id = @photo_id
DELETE FROM comments where photo_id = @photo_id
DELETE FROM photos where photo_id = @photo_id
COMMIT TRANSACTION;

GO


--Create a stored procedure to Delete User
GO

CREATE PROCEDURE deleteUser
@user_id int 
AS
BEGIN TRANSACTION
--Select * from photos where user_id = 1
--for each entry that matches above, we need to delete the photo
DELETE FROM favorite_photo where user_id = @user_id
DELETE FROM like_photo where user_id = @user_id
DELETE FROM comments where user_id = @user_id
DELETE FROM users where user_id = @user_id
Commit TRANSACTION;

GO

--Create a stored procedure to paginate photos
CREATE PROCEDURE photosByPage
@PageNumber INT,
@RowsPerPage INT
AS
BEGIN TRANSACTION
SELECT file_path, caption, users.user_id, users.username, (SELECT COUNT(*) from like_photo where like_photo.photo_id = photos.photo_id) as number_of_likes, photos.photo_id from photos JOIN users on users.user_id = photos.user_id
ORDER BY photo_id desc
OFFSET (@PageNumber -1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
COMMIT TRANSACTION;

GO




