use felicis;

CREATE TABLE `userrole` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL COMMENT 'user',
  `RoleID` int(11) DEFAULT NULL COMMENT 'role,foreign',
  PRIMARY KEY (`ID`),
  KEY `fk_userrole_role_idx` (`RoleID`),
  KEY `fk_userrole_user_idx` (`UserID`),
  CONSTRAINT `fk_userrole_role` FOREIGN KEY (`RoleID`) REFERENCES `role` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userrole_user` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
