CREATE TABLE `page` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Content` varchar(5000) DEFAULT NULL,
  `FeaturedImage` varchar(45) DEFAULT NULL COMMENT 'image',
  `MainImage` varchar(45) DEFAULT NULL COMMENT 'image',
  `Metakeywords` varchar(70) DEFAULT NULL,
  `MetaDescription` varchar(70) DEFAULT NULL,
  `Blog` bit(1) DEFAULT NULL,
  `DateCreated` datetime DEFAULT NULL COMMENT 'readonly',
  `DateModified` datetime DEFAULT NULL COMMENT 'readonly',
  `DateToPublish` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL COMMENT 'user,readonly',
  PRIMARY KEY (`ID`),
  KEY `fk_page_user_idx` (`CreatedBy`),
  CONSTRAINT `fk_page_user` FOREIGN KEY (`CreatedBy`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Store Pages';