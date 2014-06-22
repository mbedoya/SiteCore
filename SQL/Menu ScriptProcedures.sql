USE felicis;

DROP procedure IF EXISTS `Core_GetMenus`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetMenus`()
BEGIN
	SELECT 	
		ID,
		Name,
		URL,
		MenuOrder,
		MenuID
	FROM 
        menu;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetMenuByID`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetMenuByID`(IN pID int)
BEGIN

	SELECT 	
		ID,
		Name,
		URL,
		MenuOrder,
		MenuID
	FROM 
        menu
	WHERE
		ID = pID;

END$$

DELIMITER ;


USE felicis;
DROP procedure IF EXISTS `Core_CreateMenu`;
    -- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreateMenu`( pID int, pName varchar(50), pURL varchar(100), pMenuOrder mediumint, pMenuID int)
BEGIN
	
	INSERT INTO menu (
		Name,
		URL,
		MenuOrder,
		MenuID) VALUES ( pName, pURL, pMenuOrder, pMenuID);

END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_UpdateMenu`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdateMenu`( pID int, pName varchar(50), pURL varchar(100), pMenuOrder mediumint, pMenuID int)
BEGIN

	UPDATE
	    menu
	SET 
        Name = pName,URL = pURL,MenuOrder = pMenuOrder,MenuID = pMenuID
	WHERE ID = pID;

END$$

DELIMITER ;

USE felicis;

DROP procedure IF EXISTS `Core_GetMenusByMenu`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetMenusByMenu`(IN pID int)
BEGIN
	SELECT 	
		ID,
		Name,
		URL,
		MenuOrder,
		MenuID
	FROM 
        menu
    WHERE
        MenuID = pID;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_DeleteMenu`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeleteMenu`(IN pID int)
BEGIN

	DELETE		
	FROM 
        menu
	WHERE
		ID = pID;

END$$


DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetMenuMenuCount`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetMenuMenuCount`(in pID int)
BEGIN

	SELECT 	
		COUNT(1) as count
	FROM 
        Menu
	WHERE
		MenuID = pID;

END$$