CREATE DATABASE DepoComputersDB;
USE DepoComputersDB;

CREATE TABLE organizations 
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	inn VARCHAR(12) NOT NULL CHECK (inn LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
	uraddress VARCHAR(255) NOT NULL,
	factaddress VARCHAR(255) NOT NULL
);

INSERT INTO organizations (name, inn, uraddress, factaddress) VALUES
('test', '123456229999', 'test ur address', 'test fact address'), 
('test2', '123456789997', 'test2 ur address', 'test2 fact address');

CREATE TABLE workers 
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	firstname VARCHAR(255) NOT NULL,
	lastname VARCHAR(255) NOT NULL,
	patronymic VARCHAR(255) NOT NULL,
	birthday DATE NOT NULL CHECK (birthday < GETDATE()),
	seriapass VARCHAR(4) NOT NULL CHECK (seriapass LIKE '%[0-9][0-9][0-9][0-9]%'),
	numberpass VARCHAR(6) NOT NULL CHECK (numberpass LIKE '%[0-9][0-9][0-9][0-9][0-9][0-9]%'),
);

INSERT INTO workers (firstname, lastname, patronymic, birthday, seriapass, numberpass) VALUES
('test worker 1', 'test worker 1', 'test worker 1', '1990-12-12', '1234', '432124'), 
('test worker 2', 'test worker 2', 'test worker 2', '1990-12-12', '1234', '411114');