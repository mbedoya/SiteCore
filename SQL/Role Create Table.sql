use felicis;

CREATE TABLE `role` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `DateCreated` datetime DEFAULT NULL COMMENT 'readonly',
  `CreatedBy` int(11) DEFAULT NULL COMMENT 'user,readonly',
  PRIMARY KEY (`ID`),
  KEY `fk_role_creator_idx` (`CreatedBy`),
  CONSTRAINT `fk_role_creator` FOREIGN KEY (`CreatedBy`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

