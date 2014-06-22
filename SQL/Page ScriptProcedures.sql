USE felicis;

DROP procedure IF EXISTS `Core_GetPages`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPages`()
BEGIN
	SELECT 	
		ID,
		Name,
		Content,
		FeaturedImage,
		MainImage,
		Metakeywords,
		MetaDescription,
		Blog,
		DateCreated,
		DateModified,
		DateToPublish,
		CreatedBy
	FROM 
        page;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetPageByID`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPageByID`(IN pID int)
BEGIN

	SELECT 	
		ID,
		Name,
		Content,
		FeaturedImage,
		MainImage,
		Metakeywords,
		MetaDescription,
		Blog,
		DateCreated,
		DateModified,
		DateToPublish,
		CreatedBy
	FROM 
        page
	WHERE
		ID = pID;

END$$

DELIMITER ;


USE felicis;
DROP procedure IF EXISTS `Core_CreatePage`;
    -- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreatePage`( pID int, pName varchar(100), pContent varchar(5000), pFeaturedImage varchar(45), pMainImage varchar(45), pMetakeywords varchar(70), pMetaDescription varchar(70), pBlog bit, pDateCreated datetime, pDateModified datetime, pDateToPublish datetime, pCreatedBy int)
BEGIN
	
	INSERT INTO page (
		Name,
		Content,
		FeaturedImage,
		MainImage,
		Metakeywords,
		MetaDescription,
		Blog,
		DateCreated,
		DateModified,
		DateToPublish,
		CreatedBy) VALUES ( pName, pContent, pFeaturedImage, pMainImage, pMetakeywords, pMetaDescription, pBlog, pDateCreated, pDateModified, pDateToPublish, pCreatedBy);

END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_UpdatePage`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdatePage`( pID int, pName varchar(100), pContent varchar(5000), pFeaturedImage varchar(45), pMainImage varchar(45), pMetakeywords varchar(70), pMetaDescription varchar(70), pBlog bit, pDateCreated datetime, pDateModified datetime, pDateToPublish datetime, pCreatedBy int)
BEGIN

	UPDATE
	    page
	SET 
        Name = pName,Content = pContent,FeaturedImage = pFeaturedImage,MainImage = pMainImage,Metakeywords = pMetakeywords,MetaDescription = pMetaDescription,Blog = pBlog,DateCreated = pDateCreated,DateModified = pDateModified,DateToPublish = pDateToPublish,CreatedBy = pCreatedBy
	WHERE ID = pID;

END$$

DELIMITER ;

USE felicis;

DROP procedure IF EXISTS `Core_GetPagesBy`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPagesBy`(IN pID int)
BEGIN
	SELECT 	
		ID,
		Name,
		Content,
		FeaturedImage,
		MainImage,
		Metakeywords,
		MetaDescription,
		Blog,
		DateCreated,
		DateModified,
		DateToPublish,
		CreatedBy
	FROM 
        page
    WHERE
         = pID;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_DeletePage`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeletePage`(IN pID int)
BEGIN

	DELETE		
	FROM 
        menu
	WHERE
		ID = pID;

END$$


DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetPageCount`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPageCount`(in pID int)
BEGIN

	SELECT 	
		COUNT(1) as count
	FROM 
        
	WHERE
		PageID = pID;

END$$