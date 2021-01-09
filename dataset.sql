INSERT INTO `State` (`StateId`, `StateName`, `Abbreviation`, `RegisteredVoters`)
VALUES
	(1,'North Carolina','NC',300456),
	(2,'South Carolina','SC',220456),
	(3,'Texas','TX',450456);



INSERT INTO `Voter` (`VoterId`, `StateId`, `EarlyVote`, `VoteType`, `ValidVote`, `SSN`)
VALUES
	(1,'3',1,'In-Person',1,123322323),
	(2,'3',1,'In-Person',1,123322324),
	(3,'3',1,'Mail-In',1,123322325),
	(4,'2',1,'Mail-In',1,123322425),
	(5,'2',1,'Mail-In',1,123222428),
	(6,'2',1,'Mail-In',0,223222428),
	(7,'2',1,'Mail-In',0,323222428),
	(8,'2',1,'Mail-In',0,333222428),
	(9,'1',1,'Mail-In',0,433222428),
	(10,'1',1,'Mail-In',0,443222428),
	(11,'1',1,'Mail-In',0,444222428),
	(12,'1',0,'In-Person',0,123329999),
	(13,'1',0,'In-Person',0,123369999),
	(14,'1',0,'In-Person',0,123369990),
	(15,'1',0,'In-Person',0,223369990),
	(16,'1',0,'In-Person',0,223869990),
	(17,'1',0,'In-Person',0,223689990),
	(18,'1',0,'In-Person',0,723689990),
	(19,'1',1,'In-Person',0,724689990),
	(20,'1',1,'In-Person',1,774689990),
	(21,'1',1,'In-Person',1,679749012),
	(22,'1',1,'In-Person',1,112305749),
	(23,'1',1,'In-Person',1,716475197),
	(24,'1',1,'In-Person',1,602759055),
	(25,'1',1,'In-Person',1,565136544),
	(26,'1',1,'In-Person',1,660744719),
	(27,'1',1,'In-Person',1,610833259),
	(28,'1',1,'In-Person',1,878245560),
	(29,'1',1,'In-Person',1,533457706);