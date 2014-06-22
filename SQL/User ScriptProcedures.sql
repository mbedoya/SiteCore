USE felicis;

DROP procedure IF EXISTS `Core_GetUsers`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetUsers`()
BEGIN
	SELECT 	
		ID,
		FirstName,
		LastName,
		Email,
		Password,
		DateCreated,
		CreatedBy
	FROM 
        user;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetUserByID`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetUserByID`(IN pID int)
BEGIN

	SELECT 	
		ID,
		FirstName,
		LastName,
		Email,
		Password,
		DateCreated,
		CreatedBy
	FROM 
        user
	WHERE
		ID = pID;

END$$

DELIMITER ;


USE felicis;
DROP procedure IF EXISTS `Core_CreateUser`;
    -- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreateUser`( pID int, pFirstName varchar(30), pLastName varchar(30), pEmail varchar(45), pPassword varchar(20), pDateCreated datetime, pCreatedBy int)
BEGIN
	
	INSERT INTO user (
		FirstName,
		LastName,
		Email,
		Password,
		DateCreated,
		CreatedBy) VALUES ( pFirstName, pLastName, pEmail, pPassword, pDateCreated, pCreatedBy);

END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_UpdateUser`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdateUser`( pID int, pFirstName varchar(30), pLastName varchar(30), pEmail varchar(45), pPassword varchar(20), pDateCreated datetime, pCreatedBy int)
BEGIN

	UPDATE
	    user
	SET 
        FirstName = pFirstName,LastName = pLastName,Email = pEmail,Password = pPassword,DateCreated = pDateCreated,CreatedBy = pCreatedBy
	WHERE ID = pID;

END$$

DELIMITER ;

USE felicis;

DROP procedure IF EXISTS `Core_GetUsersBy`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetUsersBy`(IN pID int)
BEGIN
	SELECT 	
		ID,
		FirstName,
		LastName,
		Email,
		Password,
		DateCreated,
		CreatedBy
	FROM 
        user
    WHERE
         = pID;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_DeleteUser`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeleteUser`(IN pID int)
BEGIN

	DELETE		
	FROM 
        menu
	WHERE
		ID = pID;

END$$


DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetUserUserCount`;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetUserUserCount`(in pID int)
BEGIN

	SELECT 	
		COUNT(1) as count
	FROM 
        User
	WHERE
		CreatedBy = pID;

END$$
DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetUserRoleCount`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetUserRoleCount`(in pID int)
BEGIN

	SELECT 	
		COUNT(1) as count
	FROM 
        Role
	WHERE
		UserID = pID;

END$$