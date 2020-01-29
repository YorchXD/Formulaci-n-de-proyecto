DROP PROCEDURE IF EXISTS `crear_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `crear_solicitud`(
  	in_fecha DATE,
	in_monto INTEGER,
	in_nombreEvento VARCHAR(256),
	in_fechaInicioEvento DATE,
  	in_fechaTerminoEvento DATE,
	in_runEncargado VARCHAR(256),
	in_lugarEvento VARCHAR(256),
	in_tipoActividad VARCHAR(256),
	in_fechaCreacionPDF DATE,
	OUT out_id INTEGER
)
BEGIN
	INSERT INTO Solicitud(fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent, tipoActividad, fechaCreacionPDF)
	VALUES (in_estado, in_fecha ,in_monto, in_nombreEvento, in_fechaInicioEvento, in_fechaTerminoEvento, in_runEncargado, in_lugarEvento, in_tipoActividad, in_fechaCreacionPDF);
	SET out_id = LAST_INSERT_ID();
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leertodos_categorias`;
DELIMITER ;;
CREATE PROCEDURE `leertodos_categorias`()
BEGIN
	SELECT nombre
	FROM Categoria;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `agregar_categoria`;
DELIMITER ;;
CREATE PROCEDURE `agregar_categoria`(
	in_refSolicitud Integer,
  	in_refCategoria VARCHAR(256)
)
BEGIN
	INSERT INTO SolCat(refSolicitud, refCategoria)
	VALUES (in_refSolicitud, in_refCategoria);
END
;;
DELIMITER ;

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
DELIMITER ;

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

DROP PROCEDURE IF EXISTS `leertodas_solicitudes_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leertodas_solicitudes_organizacion`(
	in_idOrganizacion INTEGER)
BEGIN
	SELECT id, estado, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent
	FROM Solicitud, procesoFondo
	WHERE in_idOrganizacion=procesoFondo.refOrganizacion AND procesoFondo.refSolicitud = Solicitud.id;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `crear_proceso_fondo`;
DELIMITER ;;
CREATE PROCEDURE `crear_proceso_fondo`(
	in_refSolicitud Integer,
  	in_refOrganizacion Integer,
  	in_estado Integer
)
BEGIN
	INSERT INTO procesoFondo(refOrganizacion, refSolicitud, estado)
	VALUES (in_refOrganizacion, in_refSolicitud, in_estado);
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_responsables_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_responsables_organizacion`(
	in_refOrganizacion INTEGER)
BEGIN
	SELECT Responsable.run, Responsable.nombre, Responsable.matricula, Responsable.estado, Responsable.cargo, Responsable.sexo
	FROM RespOrganizacion, Responsable
	WHERE in_refOrganizacion=RespOrganizacion.refOrganizacion AND RespOrganizacion.refResponsable= Responsable.run;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `cambiar_estado_responsable`;
DELIMITER ;;
CREATE PROCEDURE `cambiar_estado_responsable`(
	in_refResponsable VARCHAR(256),
	in_estado VARCHAR(256), 
	out_nombre VARCHAR(256))
BEGIN
	UPDATE Responsable
	SET estado=in_estado
	WHERE run=in_refResponsable;	
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `obtener_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `obtener_solicitud`(
	in_refSolicitud Integer)
BEGIN
	SELECT id, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent
	FROM Solicitud
	WHERE id = in_refSolicitud;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `responsable_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `responsable_solicitud`(
	in_refSolicitud Integer)
BEGIN
	SELECT Responsable.run, Responsable.nombre, Responsable.matricula, Responsable.cargo
	FROM Solicitud, Responsable
	WHERE in_refSolicitud = Solicitud.id AND Solicitud.runEncargado = Responsable.run;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_organizacion`(
	in_refSolicitud Integer)
BEGIN
	SELECT Organizacion.id, Organizacion.tipo
	FROM procesoFondo, Organizacion
	WHERE in_refSolicitud = procesoFondo.refSolicitud AND procesoFondo.refOrganizacion = Organizacion.id;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_CAA`;
DELIMITER ;;
CREATE PROCEDURE `leer_CAA`(
	in_refOrganizacion Integer)
BEGIN
	SELECT nomDirCarrera, carrera, sexoDirCarrera, cargo
	FROM CAA
	WHERE CAA.refOrganizacion = in_refOrganizacion;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_Federacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_Federacion`(
	in_refOrganizacion Integer)
BEGIN
	SELECT nomDirDAAE, campus, sexoDirDAAE, cargo, nombreFederacion
	FROM Federacion
	WHERE Federacion.refOrganizacion = in_refOrganizacion;
END
;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `leer_Correo`;
DELIMITER ;;
CREATE PROCEDURE `leer_Correo`(
	in_email VARCHAR(256))
BEGIN
	SELECT email
	FROM Organizacion
	WHERE email = in_email;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `cambiar_clave`;
DELIMITER ;;
CREATE PROCEDURE `cambiar_clave`(
	in_correo VARCHAR(256),
	in_clave VARCHAR(256))
BEGIN
	UPDATE Organizacion
	SET clave=in_clave
	WHERE email=in_correo;	
END
;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `actualizar_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `actualizar_solicitud`(
	in_refSolicitud Integer,
  	in_fecha DATE,
	in_monto INTEGER,
	in_nombreEvento VARCHAR(256),
	in_fechaInicioEvento DATE,
  	in_fechaTerminoEvento DATE,
	in_runEncargado VARCHAR(256),
	in_lugarEvento VARCHAR(256),
	in_tipoActividad VARCHAR(256),
	in_fechaCreacionPDF DATE)
BEGIN
	UPDATE Solicitud
	SET fechaCreacion=in_fecha, monto=in_monto, nomEvent=in_nombreEvento, 
		fecIniEvent = in_fechaInicioEvento, fecTerEvent = in_fechaTerminoEvento, runEncargado = runEncargado, 
		lugarEvent = in_lugarEvento, tipoActividad = in_tipoActividad, fechaCreacionPDF = in_fechaCreacionPDF
	WHERE id=in_refSolicitud;	
END
;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `obtener_solicitud_completa`;
DELIMITER ;;
CREATE PROCEDURE `obtener_solicitud_completa`(
	in_refSolicitud Integer)
BEGIN
	SELECT id, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent, tipoActividad, fechaCreacionPDF
	FROM Solicitud
	WHERE id = in_refSolicitud;
END
;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `actualizar_estado_proceso`;
DELIMITER ;;
CREATE PROCEDURE `actualizar_estado_proceso`(
	in_proceso Integer,
	in_id_proceso Integer,
  in_estado Integer)
BEGIN
	CASE 
			WHEN in_proceso = '1' THEN UPDATE procesofondo SET estado = in_estado where procesoFondo.refSolicitud = in_id_proceso;
			WHEN in_proceso = '2' THEN UPDATE procesofondo SET estado = in_estado where procesoFondo.refResolucion = in_id_proceso;
			WHEN in_proceso = '3' THEN UPDATE procesofondo SET estado = in_estado where procesoFondo.refDeclaracionGastos = in_id_proceso;
	END CASE;
END
;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_Estado_Proceso`;
DELIMITER ;;
CREATE PROCEDURE `leer_Estado_Proceso`(
	in_id_proceso Integer,
	in_proceso Integer)
BEGIN
	CASE
			WHEN in_proceso = '1' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refSolicitud;
			WHEN in_proceso = '2' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refResolucion;
			WHEN in_proceso = '3' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refDeclaracionGastos;
		END CASE;
												
END
;;
DELIMITER ;





agregar si es  un fondo por rendir(reembolso) o una rendicion


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