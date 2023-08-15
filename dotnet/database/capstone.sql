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
--DROP TABLE games
--DROP TABLE players
--DROP TABLE stocks
--DROP TABLE player_stock
--DROP TABLE player_game

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
CREATE TABLE games
(
        game_id INT IDENTITY (1,1) NOT NULL,
        title VARCHAR(50) NOT NULL,
        is_in_progress BIT NOT NULL,
        max_turns INT NOT NULL,
        current_turn INT NOT NULL,
        user_id INT NOT NULL,
        CONSTRAINT game_id PRIMARY KEY (game_id),
        FOREIGN KEY (user_id) REFERENCES users (user_id)


);
CREATE TABLE players 
(
        player_id INT IDENTITY (1,1) NOT NULL,
        username VARCHAR(50) NOT NULL,
        selected_character VARCHAR(10) NOT NULL,
        money INT NOT NULL,
        player_position INT NOT NULL,
        is_rolled BIT NOT NULL,
        is_turn BIT NOT NULL,
        CONSTRAINT player_id PRIMARY KEY (player_id)
        
);

CREATE TABLE stocks 
(
        stock_id INT IDENTITY (1,1) NOT NULL,
        stock_name VARCHAR(20) NOT NULL,
        price INT NOT NULL,
        fee INT NOT NULL,
        CONSTRAINT stock_id PRIMARY KEY (stock_id)
);

CREATE TABLE player_stock
(
        player_id INT NOT NULL,
        stock_id INT NOT NULL,
        FOREIGN KEY (player_id) REFERENCES players (player_id),
        FOREIGN KEY (stock_id) REFERENCES stocks (stock_id)
);
CREATE TABLE player_game
(
	player_id INT NOT NULL,
	game_id INT NOT NULL,
	FOREIGN KEY (player_id) REFERENCES players (player_id),
	FOREIGN KEY (game_id) REFERENCES games (game_id)
)



--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO