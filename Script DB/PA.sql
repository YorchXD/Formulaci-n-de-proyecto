-- ----------------------------
-- Procedure structure for crear_solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `crear_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `crear_solicitud`(
	in_estado VARCHAR(256),
  	in_fecha DATE,
	in_monto INTEGER,
	in_nombreEvento VARCHAR(256),
	in_fechaInicioEvento DATE,
  	in_fechaTerminoEvento DATE,
	in_encargado VARCHAR(256),
	in_lugarEvento VARCHAR(256),
	OUT out_id INTEGER
)
BEGIN
	INSERT INTO Solicitud(estado, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, encargado, lugarEvent)
	VALUES (in_estado, in_fecha ,in_monto, in_nombreEvento, in_fechaInicioEvento, in_fechaTerminoEvento, in_encargado, in_lugarEvento);
	SET out_id = LAST_INSERT_ID();
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for leertodos_categorias
-- ----------------------------
DROP PROCEDURE IF EXISTS `leertodos_categorias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `leertodos_categorias`()
BEGIN
	SELECT nombre
	FROM Categoria;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for agregar_categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `agregar_categoria`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `agregar_categoria`(
	in_refSolicitud Integer,
  	in_refCategoria VARCHAR(256)
)
BEGIN
	INSERT INTO SolCat(refSolicitud, refCategoria)
	VALUES (in_refSolicitud, in_refCategoria);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for categorias_seleccionadas
-- ----------------------------
DROP PROCEDURE IF EXISTS `categorias_seleccionadas`;
DELIMITER ;;
CREATE PROCEDURE `categorias_seleccionadas`(
	in_refSolicitud INTEGER)
BEGIN
	SELECT refCategoria
	FROM SolCat
	WHERE refSolicitud=in_refSolicitud;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for categorias_seleccionadas
-- ----------------------------
DROP PROCEDURE IF EXISTS `eliminar_categorias_seleccionadas`;
DELIMITER ;;
CREATE PROCEDURE `eliminar_categorias_seleccionadas`(
	in_refCategoria VARCHAR(256),
	in_refSolicitud INTEGER)
BEGIN
	DELETE 
	FROM SolCat
	WHERE refCategoria=in_refCategoria AND refSolicitud=in_refSolicitud;
END
;;
DELIMITER;



-- ----------------------------
-- Procedure structure for agregar_personas
-- ----------------------------
DROP PROCEDURE IF EXISTS `agregar_personas`;
DELIMITER ;;
CREATE PROCEDURE `agregar_personas`(
	in_nombre VARCHAR(256),
  	in_run VARCHAR(256)
)
BEGIN
	INSERT INTO Persona(nombre, run)
	VALUES (in_nombre, in_run);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for agregar_persol
-- ----------------------------
DROP PROCEDURE IF EXISTS `agregar_persol`;
DELIMITER ;;
CREATE PROCEDURE `agregar_persol`(
	in_refPersona VARCHAR(256),
  	in_refSolicitud Integer
)
BEGIN
	INSERT INTO PerSol(refPersona, refSolicitud)
	VALUES (in_refPersona, in_refSolicitud);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for leerpersonas_refSolicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `leerpersonas_refSolicitud`;
DELIMITER ;;
CREATE PROCEDURE `leerpersonas_refSolicitud`(
  	in_refSolicitud Integer
)
BEGIN
	SELECT Persona.nombre, Persona.run
	FROM Persona, PerSol
	WHERE PerSol.refSolicitud = in_refSolicitud AND PerSol.refPersona = Persona.run;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for iniciar_sesion
-- ----------------------------
DROP PROCEDURE IF EXISTS `iniciar_sesion`;
DELIMITER ;;
CREATE PROCEDURE `iniciar_sesion`(
  	in_usuario VARCHAR(256),
  	in_clave VARCHAR(256))
BEGIN
	SELECT id
	FROM Organizacion
	WHERE usuario = in_usuario AND clave = in_clave;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for leertodas_solicitudes_organizacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `leertodas_solicitudes_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leertodas_solicitudes_organizacion`(
	in_idOrganizacion INTEGER)
BEGIN
	SELECT id, estado, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, encargado, lugarEvent
	FROM Solicitud, OrgSol
	wHERE in_idOrganizacion=OrgSol.refOrganizacion AND OrgSol.refSolicitud = Solicitud.id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for crear_orgsol
-- ----------------------------
DROP PROCEDURE IF EXISTS `crear_orgsol`;
DELIMITER ;;
CREATE PROCEDURE `crear_orgsol`(
	in_refSolicitud Integer,
  	in_refOrganizacion Integer
)
BEGIN
	INSERT INTO OrgSol(refOrganizacion, refSolicitud)
	VALUES (in_refOrganizacion, in_refSolicitud);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for leertodos_solicitudes
-- ----------------------------
/*DROP PROCEDURE IF EXISTS `leertodos_solicitudes`;
DELIMITER ;;
CREATE PROCEDURE `leertodos_solicitudes`()
BEGIN
	SELECT id, estado, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, encargado, lugarEvent
	FROM Solicitud;
END
;;
DELIMITER ;*/