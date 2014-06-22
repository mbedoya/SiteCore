CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) DEFAULT NULL,
  `LastName` varchar(30) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL COMMENT 'password',
  `DateCreated` datetime DEFAULT NULL COMMENT 'readonly',
  `CreatedBy` int(11) DEFAULT NULL COMMENT 'user,readonly',
  PRIMARY KEY (`ID`),
  KEY `fk_user_user_idx` (`CreatedBy`),
  CONSTRAINT `fk_user_user` FOREIGN KEY (`CreatedBy`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;