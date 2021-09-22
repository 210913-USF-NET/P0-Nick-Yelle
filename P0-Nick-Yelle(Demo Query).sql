/*
DDL: Data Definition Language
*/

CREATE TABLE Breweries (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50)
);

ALTER TABLE Breweries
ALTER COLUMN Name VARCHAR(100) NOT NULL;

CREATE TABLE Brews (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL,
    Price INT,
    BreweryId INT FOREIGN KEY REFERENCES Breweries(Id) ON DELETE CASCADE NOT NULL
);

/*
DML: Data Manipulation Language
*/

INSERT INTO Breweries (Name, City, State) VALUES
('Night Shift Brewing', 'Boston', 'MA'),
('67 Degrees Brewing', 'Franklin', 'MA'),
('Lops Brewing', 'Woonsocket', 'RI'),
('Bog Iron Brewing', 'Norton', 'MA');

SELECT * FROM Breweries;

INSERT INTO Brews (Name, Price, BreweryId) VALUES
('Pumpkin Piescraper', 10, 1),
('Route 140', 8, 2),
('Lemonade Shandy', 12, 3),
('Off My Lawn', 10, 4);

SELECT * FROM Brews;