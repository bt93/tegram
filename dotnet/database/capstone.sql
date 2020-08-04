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
	caption varchar(200),
	user_id int NOT NULL,
	CONSTRAINT PK_photo PRIMARY KEY (photo_id),
	CONSTRAINT FK_user FOREIGN KEY (user_id) REFERENCES users(user_id)
)
CREATE TABLE comments (
	comment_id int IDENTITY(1,1) NOT NULL,
	contents varchar(200),
	like_count int DEFAULT 0 NOT NULL,
	photo_id int NOT NULL,
	CONSTRAINT PK_comment PRIMARY KEY (comment_id),
	CONSTRAINT FK_photo FOREIGN KEY (photo_id) REFERENCES photos(photo_id)
)
CREATE TABLE like_photo (
	like_photo_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	photo_id int NOT NULL,
	CONSTRAINT PK_like_photo PRIMARY KEY (like_photo_id),
	CONSTRAINT FK_user_like FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_photo_like FOREIGN KEY (photo_id) REFERENCES photos(photo_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Lace','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Porter','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Jason','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Seth','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Val','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO photos (file_path, user_id) VALUES ('/v1596548892/TE-Gram/pearl_16x9_tqkcko.jpg', 1);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596548892/TE-Gram/3408_xxawqk.jpg', 2);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596548892/TE-Gram/dogs_1280p_0_ofuwsx.jpg', 3);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596548895/TE-Gram/domestic-dog_thumb_yacyjk.jpg', 4);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596548892/TE-Gram/dogs_1280p_0_ofuwsx.jpg', 4);

INSERT INTO photos (file_path, user_id) VALUES ('/v1596549728/TE-Gram/TEworkplacePhoto14_icubge.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549742/TE-Gram/TEworkplacePhoto16_m3kz0t.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549764/TE-Gram/TEworkplacePhoto17_hrf4de.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549781/TE-Gram/TEworkplacePhoto15_k56p8v.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549791/TE-Gram/TEworkplacePhoto18_t5weuz.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549798/TE-Gram/TEworkplacePhoto20_mopxyq.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549813/TE-Gram/TEworkplacePhoto08_a5mujf.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549813/TE-Gram/TEworkplacePhoto19_msw98r.png', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549818/TE-Gram/TEworkplacePhoto01_ijjkfl.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549843/TE-Gram/TEworkplacePhoto21_l4cehq.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549847/TE-Gram/TEworkplacePhoto02_tvoubo.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549853/TE-Gram/TEworkplacePhoto09_gg56dq.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549856/TE-Gram/TEworkplacePhoto10_txpocn.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549876/TE-Gram/TEworkplacePhoto13_kjb9az.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549876/TE-Gram/TEworkplacePhoto03_jxhqpd.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549918/TE-Gram/TEworkplacePhoto06_prwc8s.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549942/TE-Gram/TEworkplacePhoto05_i6qofg.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549943/TE-Gram/TEworkplacePhoto07_h1oyoq.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549961/TE-Gram/TEworkplacePhoto12_hf6obs.jpg', 6);
INSERT INTO photos (file_path, user_id) VALUES ('/v1596549962/TE-Gram/TEworkplacePhoto04_akg4dc.jpg', 6);
INSERT INTO photos (file_path, user_id, caption) VALUES ('/v1596549856/TE-Gram/TEworkplacePhoto10_txpocn.jpg', 6, 'Hello');

INSERT INTO like_photo (user_id, photo_id) VALUES (6, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (4, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (2, 13);
INSERT INTO like_photo (user_id, photo_id) VALUES (1, 13);

GO



