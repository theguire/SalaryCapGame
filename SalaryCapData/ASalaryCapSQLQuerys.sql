INSERT INTO
	Owners( [FirstName], [LastName], [Email], [ImageUrl], DateCreated, DateModified )
VALUES 
	('Meredith','Alonso','Alexander@mail.com', '/images/owners/19thY8RLKX9M.jpg', GETDATE(), GETDATE() ),
	('Arturo','GytiS','Alexander@mail.com', '/images/owners/23thSIMNQPRO.jpg', GETDATE(), GETDATE()  ),
	('Homer','Simpson','Alexander@mail.com', '/images/owners/2th.jpg', GETDATE(), GETDATE()  ),
	('Guy','Goober','Alexander@mail.com', '/images/owners/5th.jpg', GETDATE(), GETDATE()  ),
	('Goober','Gober','Alexander@mail.com', '/images/owners/7th.jpg', GETDATE(), GETDATE()  );

SELECT * FROM Owners


INSERT INTO	
	Leagues( [Name], OwnerId, DateCreated, DateModified )
VALUES
	('Funky2', 1,  GETDATE(), GETDATE()  ),
	('Peaknuckles', 2, GETDATE(), GETDATE()  ),
	('Gold Metal', 3, GETDATE(), GETDATE()  ),
	('Selver Metal', 3, GETDATE(), GETDATE()  ),
	('Bronze Metal', 3, GETDATE(), GETDATE()  ),
	('Funky1', 1, GETDATE(), GETDATE()  ),
	('Holy Molies', 4, GETDATE(), GETDATE()  );

SELECT * FROM Leagues


INSERT INTO
	Franchises( [Name], [LeagueId], [OwnerId], DateCreated, DateModified )
VALUES
	('Team1', 1, 1, GETDATE(), GETDATE() ),
	('Team2', 3, 1, GETDATE(), GETDATE() ),
	('Team3', 2, 1, GETDATE(), GETDATE() ),
	('Team4', 4, 2, GETDATE(), GETDATE() ),
	('Team5', 4, 4, GETDATE(), GETDATE() ),
	('Team6', 4, 4, GETDATE(), GETDATE() ),
	('Team6', 2, 3, GETDATE(), GETDATE() ),
	('Team7', 5, 1, GETDATE(), GETDATE() ),
	('Team8', 4, 2, GETDATE(), GETDATE() ),
	('Team9', 3, 5, GETDATE(), GETDATE() ),
	('Team9', 3, 1, GETDATE(), GETDATE() )

SELECT * FROM Franchises



