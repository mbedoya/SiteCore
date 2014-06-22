CREATE TABLE `menu` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `URL` varchar(100) DEFAULT NULL,
  `MenuOrder` tinyint(4) DEFAULT NULL,
  `MenuID` int(11) DEFAULT NULL COMMENT 'menu,foreign',
  PRIMARY KEY (`ID`),
  KEY `fk_menu_menu_idx` (`MenuID`),
  CONSTRAINT `fk_menu_menu` FOREIGN KEY (`MenuID`) REFERENCES `menu` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
