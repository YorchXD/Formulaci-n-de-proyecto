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
DROP PROCEDURE IF EXISTS `crear_federacion`;
DELIMITER ;;
CREATE PROCEDURE `crear_federacion`(
	in_nomDirDAAE VARCHAR(256),
	in_campus VARCHAR(256),
	in_sexoDirDAAE VARCHAR(256),
	in_cargo VARCHAR(256),
	in_nombreFederacion VARCHAR(256),
	in_id INTEGER
)
BEGIN
	INSERT INTO `Federacion` VALUES
	(in_nomDirDAAE, in_campus, in_sexoDirDAAE, in_cargo, in_nombreFederacion, in_id);
END
;;
DELIMITER ;

/****************************CAAs*/
DROP PROCEDURE IF EXISTS `crear_caa`;
DELIMITER ;;
CREATE PROCEDURE `crear_caa`(
	in_nomDirCarrera VARCHAR(256),
	in_carrera VARCHAR(256),
	in_sexoDirCarrera VARCHAR(256),
	in_cargo VARCHAR(256),
	in_id INTEGER
)
BEGIN
	INSERT INTO `CAA` VALUES
	(in_nomDirCarrera, in_carrera, in_sexoDirCarrera, in_cargo, in_id);
END
;;
DELIMITER ;