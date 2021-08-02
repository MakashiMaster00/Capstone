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
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE properties (
	property_id int IDENTITY(1,1) NOT NULL,
	landlord_id int NOT NULL,
	description varchar(500) NOT NULL,
	address_line_one varchar(50) NOT NULL,
	address_line_two varchar(50) NULL,
	state_abbreviation varchar(2) NOT NULL,
	city varchar(50) NOT NULL,
	zip_code int NOT NULL,
	price money NOT NUll,
	date_available datetime NOT NULL,
	available bit NOT NULL,
	beds int NOT NULL,
	baths decimal NOT NULL,
	CONSTRAINT PK_property_id PRIMARY KEY (property_id),
	CONSTRAINT FK_landlord_id FOREIGN KEY (landlord_id) REFERENCES users (user_id)
)
--TODO Photo table links to property id

--populate default data for users
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--populate default data for properties

GO