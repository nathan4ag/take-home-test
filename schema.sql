CREATE TABLE VotingInformation.`State` (
  `StateId` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `StateName` varchar(30) NOT NULL,
  `Abbreviation` varchar(2) NOT NULL,
  `RegisteredVoters` int(6) DEFAULT NULL,
  PRIMARY KEY (`StateId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE VotingInformation.`Voter` (
  `VoterId` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `StateId` varchar(30) NOT NULL,
  `EarlyVote` tinyint(1) DEFAULT '0',
  `VoteType` varchar(30) DEFAULT NULL,
  `ValidVote` tinyint(1) DEFAULT '0',
  `SSN` int(9) DEFAULT NULL,
  PRIMARY KEY (`VoterId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;