DROP PROCEDURE IF EXISTS `leer_organizaciones`;
DELIMITER ;;
CREATE PROCEDURE `leer_organizaciones`(
)
BEGIN
	SELECT id, tipo
	FROM Organizacion;
END
;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `crear_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `crear_organizacion`(
	in_tipo VARCHAR(256),
	in_usuario VARCHAR(256),
	in_clave VARCHAR(256),
	in_email VARCHAR(256),
	in_estado VARCHAR(256)
)
BEGIN
	SELECT id, tipo
	FROM Organizacion;
END
;;
DELIMITER ;