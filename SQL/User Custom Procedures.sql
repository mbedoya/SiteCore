use felicis;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckUser`(IN pEmail varchar(45), pPassword varchar(45))
BEGIN

	SELECT 
		`user`.`ID`,
		`user`.`FirstName`,
		`user`.`LastName`,
		`user`.`Email`,
		`user`.`Password`,
		`user`.`DateCreated`,
		`user`.`CreatedBy`
	FROM 
        user
	WHERE
		Email = pEmail
		AND Password = pPassword;

END$$

DELIMITER ;