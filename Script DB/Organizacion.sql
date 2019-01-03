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
	in_estado VARCHAR(256),
	OUT out_id INTEGER
)
BEGIN
	INSERT INTO `Organizacion` VALUES
	(in_tipo, in_usuario, in_clave, in_email, in_estado);
	SET out_id = LAST_INSERT_ID();
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `deshabilitar_habilitar_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `deshabilitar_habilitar_organizacion`(
	in_id INTEGER,
	in_estado VARCHAR(256)
)
BEGIN
	UPDATE Organizacion
	SET estado = in_estado
	WHERE id = in_id;
END
;;
DELIMITER ;

/****************************Federación*/


/****************************CAAs*/