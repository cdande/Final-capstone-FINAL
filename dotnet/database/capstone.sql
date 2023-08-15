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
--DROP TABLE users
--DROP TABLE game
--DROP TABLE [event]
--DROP TABLE [group]
--DROP TABLE member

USE final_capstone
GO


--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);
CREATE TABLE game
(
        game_id INT IDENTITY (1,1) NOT NULL,
        title VARCHAR(50) NOT NULL,
        duration INT NOT NULL,
        is_in_progress BOOLEAN NOT NULL,
        user_id INT NOT NULL,
        FOREIGN KEY (user_id) REFERENCES (users)


);
CREATE TABLE players 
(
        player_id INT IDENTITY (1,1) NOT NULL,
        username VARCHAR(50) NOT NULL,
        selected_character VARCHAR(10) NOT NULL,
        money INT NOT NULL,
        position INT NOT NULL,
        
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO