USE Boardgames

--- Table: Categories
SET IDENTITY_INSERT Categories ON
INSERT INTO Categories (Id, [Name]) VALUES
(1, 'Abstract Games'),
(2, 'Children Games'),
(3, 'Customizable Games'),
(4, 'Family Games'),
(5, 'Party Games'),
(6, 'Strategy Games'),
(7, 'Thematic Games'),
(8, 'Wargames')
SET IDENTITY_INSERT Categories OFF

--- Table: Addresses
SET IDENTITY_INSERT Addresses ON
INSERT INTO Addresses (Id, StreetName, StreetNumber, Town, Country, ZIP) VALUES
(1, 'Sunset blvd.', 65, 'New York', 'USA', 10001),
(2, 'London str.', 123, 'New York', 'USA', 15685),
(3, 'Rue de Paris', 3, 'Paris', 'France', 47963),
(4, 'High Street', 8, 'Boston', 'USA', 68732),
(5, 'Chapman Ave', 15, 'Los Angeles', 'USA', 35746),
(6, 'Zaokopowa', 534, 'Warsaw', 'Poland', 10000),
(7, 'Gladeville Rd', 1, 'Nashville', 'USA', 12354),
(8, 'Liberty Str.', 54, 'Barre', 'USA', 93457),
(9, 'Park Ave', 15, 'Providence', 'USA', 12493),
(10, 'Mercedes strasse', 15, 'Gutweiler', 'Germany', 56317),
(11, 'Alexander Str.', 15, 'New Haven', 'USA', 23485),
(12, 'Bassett Str.', 12, 'Middletown', 'USA', 23498),
(13, 'Second Ave', 24, 'Pittsburgh', 'USA', 21348),
(14, 'Green Str.', 2, 'Meadville', 'USA', 46734),
(15, 'Cambridge Ave', 987, 'Phoenix ', 'USA', 38765)
SET IDENTITY_INSERT Addresses OFF

--- Table: Publishers
SET IDENTITY_INSERT Publishers ON
INSERT INTO Publishers (Id, [Name], AddressId, Website, Phone) VALUES
(1, 'Fantasy Flight Games', 5, 'www.fantasyflightgames.com', '+18553828880'),
(2, 'Z-Man Games', 9, 'www.zmangames.com/', '+12165461654'),
(3, 'Rio Grande Games', 11, 'www.riograndegames.com', '+16546135543'),
(4, 'Asmodee', 13, 'www.asmodee.com', '+18987354656'),
(5, 'Stonemaier Games', 1, 'www.stonemaiergames.com', '+18965478963'),
(6, 'Zczech Games Edition', 8, 'www.czechgames.com', '+17582356651'),
(7, 'Days of Wonder', 14, 'www.daysofwonder.com', '+15558889991'),
(8, 'Renegade Game Studios', 7, 'www.renegadegamestudios.com', '+15588899845'),
(9, 'IELLO', 12, 'www.iello.fr', '+18954631613'),
(10, 'Lookout Games', 10, 'www.lookout-spiele.de', '+10008200005'),
(11, 'CMON', 2, 'www.cmon.com', '+10046464654'),
(12, 'Ravensburger', 4, 'www.ravensburger.com', '+15446874646'),
(13, 'Stronghold Games', 3, 'www.strongholdgames.com', '+10465056486'),
(14, 'Gamewright', 15, 'www.gamewright.com', '+12345678905'),
(15, 'Portal Games', 6, 'www.portalgames.pl', '+13259541983')
SET IDENTITY_INSERT Publishers OFF

--- Table: PlayersRanges
SET IDENTITY_INSERT PlayersRanges ON
INSERT INTO PlayersRanges (Id, PlayersMin, PlayersMax) VALUES
(1, 2, 2),
(2, 2, 3),
(3, 2, 4),
(4, 2, 5),
(5, 3, 3),
(6, 3, 4),
(7, 3, 5),
(8, 4, 4),
(9, 4, 5),
(10, 5, 5)
SET IDENTITY_INSERT PlayersRanges OFF

--- Table: Boardgames
SET IDENTITY_INSERT Boardgames ON
INSERT INTO Boardgames (Id, [Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId) VALUES
(1, 'Beyond the Sun', 2021, 8.19, 6, 1, 1),
(2, 'Sumatra', 2021, 7.08, 4, 2, 2),
(3, 'Small World of Warcraft', 2021, 7.69, 4, 3, 3),
(4, 'Blue Skies', 2021, 6.53, 6, 4, 4),
(5, 'GOLD', 2022, 7.01, 4, 5, 5),
(6, 'Polis', 2022, 8.58, 8, 6, 6),
(7, 'Pan Am', 2022, 7.79, 6, 7, 7),
(8, 'Betrayal at Mystery Mansion', 2022, 6.89, 4, 8, 8),
(9, 'Marshmallow Test', 2022, 6.66, 4, 9, 9),
(10, 'Abandon All Artichokes', 2020, 7.12, 4, 10, 10),
(11, 'Glasgow', 2018, 7.37, 6, 11, 1),
(12, 'KeyForge: Mass Mutation', 2018, 8.27, 3, 12, 2),
(13, 'The Castles of Tuscany', 2018, 7.39, 6, 13, 3),
(14, 'Dragomino', 2018, 7.3, 2, 14, 4),
(15, 'Alma Mater', 2018, 7.68, 6, 15, 5),
(16, 'Santa Monica', 2018, 7.54, 4, 1, 6),
(17, 'Battle Line: Medieval', 2017, 7.73, 6, 2, 7),
(18, 'Mariposas', 2020, 7.2, 4, 3, 8),
(19, 'Kemet: Blood and Sand', 2021, 8.49, 6, 4, 9),
(20, 'Ride the Rails', 2020, 7.38, 6, 5, 10),
(21, 'Fort', 2020, 7.4, 6, 6, 1),
(22, 'My City', 2020, 7.87, 6, 7, 2),
(23, 'Unmatched: Cobble & Fog', 2020, 8.47, 6, 8, 3),
(24, 'Stellar', 2020, 7.6, 6, 9, 4),
(25, 'Kitara', 2020, 7.31, 4, 10, 5),
(26, 'Nidavellir', 2020, 7.95, 4, 11, 6),
(27, 'Dolina królików', 2019, 7.64, 4, 12, 7),
(28, 'Undaunted: North Africa', 2020, 8.09, 8, 13, 8),
(29, 'Verdun 1916: Steel Inferno', 2020, 8.6, 8, 14, 9),
(30, 'The Fox in the Forest Duet', 2020, 7.29, 4, 15, 10),
(31, 'Azul: Summer Pavilion', 2019, 7.83, 1, 1, 1),
(32, 'Kitchen Rush (Revised Edition)', 2019, 7.73, 4, 2, 5),
(33, 'Aristocracy', 2019, 6.63, 4, 3, 9),
(34, 'Tajuto', 2019, 6.73, 4, 4, 3),
(35, 'SPELL', 2020, 8.36, 1, 5, 7),
(36, 'Godspeed', 2020, 7.32, 6, 6, 1),
(37, 'Ankh: Gods of Egypt', 2021, 7.2, 6, 7, 2),
(38, 'Miyabi', 2019, 7.55, 4, 8, 3),
(39, 'Rune Stones', 2019, 7.32, 4, 9, 4),
(40, 'Brief Border Wars', 2020, 7.54, 8, 10, 5),
(41, 'Caylus 1303', 2019, 7.63, 6, 11, 6),
(42, 'Funkoverse Strategy Game', 2019, 7.43, 3, 12, 7),
(43, 'Butterfly', 2019, 6.67, 4, 13, 8),
(44, 'Pictures', 2019, 7.23, 4, 14, 9),
(45, 'Lost Cities: Auf Schatzsuche', 2019, 6.52, 4, 15, 10)
SET IDENTITY_INSERT Boardgames OFF

--- Table: Creators
SET IDENTITY_INSERT Creators ON
INSERT INTO Creators(Id, FirstName, LastName, Email) VALUES
(1, 'Uwe', 'Rosenberg', 'uwe@rosenberg.net'),
(2, 'Bruno', 'Cathala', 'bruno@cathala.com'),
(3, 'Matt', 'Leacock', 'matt@leacock.net'),
(4, 'Emerson', 'Matsuuchi', 'emerson@matsuuchi.com'),
(5, 'Corey', 'Konieczka', 'corey@konieczka.com'),
(6, 'Alexander', 'Pfister', 'alexander@pfister.com'),
(7, 'Jamey', 'Stegmaier', 'jamey@stegmaier.com')
SET IDENTITY_INSERT Creators OFF

--- Table: CreatorsBoardgames
INSERT INTO CreatorsBoardgames (CreatorId, BoardgameId) VALUES 
(1, 1),
(1, 5),
(1, 8),
(1, 12),
(1, 15),
(1, 19),
(1, 22),
(1, 26),
(1, 29),
(1, 33),
(1, 36),
(1, 40),
(1, 43),
(2, 2),
(2, 6),
(2, 9),
(2, 13),
(2, 16),
(2, 20),
(2, 23),
(2, 27),
(2, 30),
(2, 34),
(2, 37),
(2, 41),
(2, 44),
(3, 3),
(3, 7),
(3, 10),
(3, 14),
(3, 17),
(3, 21),
(3, 24),
(3, 28),
(3, 31),
(3, 35),
(3, 38),
(3, 42),
(3, 45),
(4, 1),
(4, 4),
(4, 8),
(4, 11),
(4, 15),
(4, 18),
(4, 22),
(4, 29),
(4, 36),
(4, 43),
(4, 28),
(4, 35),
(4, 42),
(6, 3),
(6, 6),
(6, 10),
(6, 13),
(6, 17),
(6, 20),
(6, 24),
(6, 27),
(6, 31),
(6, 34),
(6, 38),
(6, 41),
(6, 45),
(6, 4),
(6, 7),
(6, 11),
(6, 14),
(6, 18),
(6, 21)