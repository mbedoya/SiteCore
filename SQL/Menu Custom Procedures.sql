
USE felicis;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetParentMenus`()
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
		MenuID IS NULL
	ORDER BY
		MenuOrder;
END$$
DELIMITER ;