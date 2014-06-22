USE felicis;

DROP procedure IF EXISTS `Core_GetRoles`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetRoles`()
BEGIN
	SELECT 	
		ID,
		Name,
		DateCreated,
		CreatedBy
	FROM 
        role;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetRoleByID`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetRoleByID`(IN pID int)
BEGIN

	SELECT 	
		ID,
		Name,
		DateCreated,
		CreatedBy
	FROM 
        role
	WHERE
		ID = pID;

END$$

DELIMITER ;


USE felicis;
DROP procedure IF EXISTS `Core_CreateRole`;
    -- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreateRole`( pID int, pName varchar(45), pDateCreated datetime, pCreatedBy int)
BEGIN
	
	INSERT INTO role (
		Name,
		DateCreated,
		CreatedBy) VALUES ( pName, pDateCreated, pCreatedBy);

END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_UpdateRole`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdateRole`( pID int, pName varchar(45), pDateCreated datetime, pCreatedBy int)
BEGIN

	UPDATE
	    role
	SET 
        Name = pName,DateCreated = pDateCreated,CreatedBy = pCreatedBy
	WHERE ID = pID;

END$$

DELIMITER ;

USE felicis;

DROP procedure IF EXISTS `Core_GetRolesBy`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetRolesBy`(IN pID int)
BEGIN
	SELECT 	
		ID,
		Name,
		DateCreated,
		CreatedBy
	FROM 
        role
    WHERE
         = pID;
END$$

DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_DeleteRole`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeleteRole`(IN pID int)
BEGIN

	DELETE		
	FROM 
        menu
	WHERE
		ID = pID;

END$$


DELIMITER ;

USE felicis;
DROP procedure IF EXISTS `Core_GetRoleUserroleCount`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetRoleUserroleCount`(in pID int)
BEGIN

	SELECT 	
		COUNT(1) as count
	FROM 
        Userrole
	WHERE
		RoleID = pID;

END$$