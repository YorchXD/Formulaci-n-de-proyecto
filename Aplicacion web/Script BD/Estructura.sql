/*
 Navicat Premium Data Transfer

 Source Server         : MySQL
 Source Server Type    : MySQL
 Source Server Version : 100136
 Source Host           : localhost:3306
 Source Schema         : simrend2

 Target Server Type    : MySQL
 Target Server Version : 100136
 File Encoding         : 65001

 Date: 24/02/2021 02:42:16
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for categoria
-- ----------------------------
DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for declaraciondegastos
-- ----------------------------
DROP TABLE IF EXISTS `declaraciondegastos`;
CREATE TABLE `declaraciondegastos`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `fechaLimite` date NOT NULL,
  `totalDocumentacion` int NOT NULL DEFAULT 0,
  `totalRendido` int NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for documento
-- ----------------------------
DROP TABLE IF EXISTS `documento`;
CREATE TABLE `documento`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigoDocumento` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `proveedor` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `fecha` date NOT NULL,
  `monto` int NOT NULL,
  `descripcion` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `tipo` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `copiaDoc` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `refCategoria` int NOT NULL,
  `refParticipante` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `refDeclaracionDeGastos` int NOT NULL,
  `estado` int NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refCategoria`(`refCategoria`) USING BTREE,
  INDEX `refDeclaracionDeGastos`(`refDeclaracionDeGastos`) USING BTREE,
  INDEX `documento_ibfk_3`(`refParticipante`) USING BTREE,
  CONSTRAINT `documento_ibfk_1` FOREIGN KEY (`refCategoria`) REFERENCES `categoria` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `documento_ibfk_2` FOREIGN KEY (`refDeclaracionDeGastos`) REFERENCES `declaraciondegastos` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `documento_ibfk_3` FOREIGN KEY (`refParticipante`) REFERENCES `participante` (`run`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for modulo
-- ----------------------------
DROP TABLE IF EXISTS `modulo`;
CREATE TABLE `modulo`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for operaciones
-- ----------------------------
DROP TABLE IF EXISTS `operaciones`;
CREATE TABLE `operaciones`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `idModulo` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refModulo_O`(`idModulo`) USING BTREE,
  CONSTRAINT `refModulo_O` FOREIGN KEY (`idModulo`) REFERENCES `modulo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for organizacion_estudiantil
-- ----------------------------
DROP TABLE IF EXISTS `organizacion_estudiantil`;
CREATE TABLE `organizacion_estudiantil`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `campus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `tipo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for parsol
-- ----------------------------
DROP TABLE IF EXISTS `parsol`;
CREATE TABLE `parsol`  (
  `refParticipante` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `refSolicitud` int NOT NULL,
  INDEX `refSolicitud`(`refSolicitud`) USING BTREE,
  INDEX `refParticipante`(`refParticipante`) USING BTREE,
  CONSTRAINT `parsol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `parsol_ibfk_2` FOREIGN KEY (`refParticipante`) REFERENCES `participante` (`run`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for participante
-- ----------------------------
DROP TABLE IF EXISTS `participante`;
CREATE TABLE `participante`  (
  `nombre` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `run` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`run`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for procesofondo
-- ----------------------------
DROP TABLE IF EXISTS `procesofondo`;
CREATE TABLE `procesofondo`  (
  `idFondo` int NOT NULL AUTO_INCREMENT,
  `refSolicitud` int NULL DEFAULT NULL,
  `refResolucion` int NULL DEFAULT NULL,
  `refDeclaracionGastos` int NULL DEFAULT NULL,
  `estado` int NULL DEFAULT NULL,
  `refOrganizacion` int NULL DEFAULT NULL,
  `estadoFinal` varchar(7) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT 'Abierta',
  `refUsuarioRepresentante` int NULL DEFAULT NULL,
  `refUsuarioDirector` int NULL DEFAULT NULL,
  PRIMARY KEY (`idFondo`) USING BTREE,
  INDEX `ref_resolucion`(`refResolucion`) USING BTREE,
  INDEX `refOrganizacion`(`refOrganizacion`) USING BTREE,
  INDEX `refDeclaracionGastos`(`refDeclaracionGastos`) USING BTREE,
  INDEX `refSolicitud`(`refSolicitud`) USING BTREE,
  INDEX `procesofondo_ibfk_5`(`refUsuarioRepresentante`) USING BTREE,
  INDEX `procesofondo_ibfk_6`(`refUsuarioDirector`) USING BTREE,
  CONSTRAINT `procesofondo_ibfk_1` FOREIGN KEY (`refDeclaracionGastos`) REFERENCES `declaraciondegastos` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_2` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_3` FOREIGN KEY (`refResolucion`) REFERENCES `resolucion` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_4` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_5` FOREIGN KEY (`refUsuarioRepresentante`) REFERENCES `usuario_representante` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_6` FOREIGN KEY (`refUsuarioDirector`) REFERENCES `usuario_director` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 61 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for resolucion
-- ----------------------------
DROP TABLE IF EXISTS `resolucion`;
CREATE TABLE `resolucion`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `numero` int NOT NULL,
  `anio` int NOT NULL,
  `copiaDoc` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `numero`(`numero`) USING BTREE,
  INDEX `anio`(`anio`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 41 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for rol
-- ----------------------------
DROP TABLE IF EXISTS `rol`;
CREATE TABLE `rol`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for rol_operacion
-- ----------------------------
DROP TABLE IF EXISTS `rol_operacion`;
CREATE TABLE `rol_operacion`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `idRol` int NOT NULL,
  `idOperacion` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refRol_RO`(`idRol`) USING BTREE,
  INDEX `refOperacion_RO`(`idOperacion`) USING BTREE,
  CONSTRAINT `refOperacion_RO` FOREIGN KEY (`idOperacion`) REFERENCES `operaciones` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `refRol_RO` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for solcat
-- ----------------------------
DROP TABLE IF EXISTS `solcat`;
CREATE TABLE `solcat`  (
  `refSolicitud` int NOT NULL,
  `refCategoria` int NOT NULL,
  INDEX `refSolicitud`(`refSolicitud`) USING BTREE,
  INDEX `refCategoria`(`refCategoria`) USING BTREE,
  CONSTRAINT `solcat_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `solcat_ibfk_2` FOREIGN KEY (`refCategoria`) REFERENCES `categoria` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for solicitud
-- ----------------------------
DROP TABLE IF EXISTS `solicitud`;
CREATE TABLE `solicitud`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `fechaCreacion` date NOT NULL,
  `monto` int NOT NULL,
  `nomEvent` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `fecIniEvent` date NOT NULL,
  `fecTerEvent` date NOT NULL,
  `lugarEvent` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `tipoActividad` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `fechaCreacionPDF` date NOT NULL,
  `fechaModificacion` date NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 59 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for usuario_director
-- ----------------------------
DROP TABLE IF EXISTS `usuario_director`;
CREATE TABLE `usuario_director`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `clave` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sexo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `campus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombreInstitucion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cargo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idRol` int NOT NULL,
  `idOrganizacionEstudiantil` int NULL DEFAULT NULL,
  `fonoAnexo` int NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refRol_UD`(`idRol`) USING BTREE,
  INDEX `refIdOrganizacionEstudiantil_UD`(`idOrganizacionEstudiantil`) USING BTREE,
  CONSTRAINT `refIdOrganizacionEstudiantil_UD` FOREIGN KEY (`idOrganizacionEstudiantil`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `refRol_UD` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Table structure for usuario_representante
-- ----------------------------
DROP TABLE IF EXISTS `usuario_representante`;
CREATE TABLE `usuario_representante`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `clave` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `run` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sexo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `matricula` int NOT NULL,
  `carrera` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `idRol` int NOT NULL,
  `idOrganizacionEstudiantil` int NOT NULL,
  `crearProceso` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'Habilitado',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refRol_UR`(`idRol`) USING BTREE,
  INDEX `refOrganizacionEstudiantil_UR`(`idOrganizacionEstudiantil`) USING BTREE,
  CONSTRAINT `refOrganizacionEstudiantil_UR` FOREIGN KEY (`idOrganizacionEstudiantil`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `refRol_UR` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Procedure structure for Actualizar_documento
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_documento`;
delimiter ;;
CREATE PROCEDURE `Actualizar_documento`(`in_id` INTEGER, `in_codigoDocumento` VARCHAR(256), `in_proveedor` VARCHAR(256), `in_fechaDocumento` DATE, `in_monto` INTEGER, `in_descripcionDocumento` VARCHAR(256), `in_tipoDocumento` VARCHAR(256), `in_copiaDoc` VARCHAR(256), `in_refCategoria` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	SET @validar = (SELECT COUNT(id)
	FROM documento
	WHERE documento.codigoDocumento = in_codigoDocumento AND documento.proveedor = in_proveedor AND documento.id != in_id);
	
	IF @validar = 0 THEN
		UPDATE documento
		SET codigoDocumento=in_codigoDocumento,
				proveedor=in_proveedor,
				fecha=in_fechaDocumento,
				monto=in_monto,
				descripcion=in_descripcionDocumento,
				tipo=in_tipoDocumento,
				copiaDoc=in_copiaDoc,
				refCategoria=in_refCategoria
		WHERE id=in_id;	
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -2;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_Estado_Proceso
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Estado_Proceso`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Estado_Proceso`(`in_estado` INTEGER, `in_refProceso` INTEGER, `in_nombreProceso` TEXT)
BEGIN
	if(in_nombreProceso='Solicitud') THEN
		UPDATE procesofondo
		SET estado = in_estado
		WHERE refSolicitud=in_refProceso;
	ELSEIF(in_nombreProceso='Resolución') THEN
		UPDATE procesofondo
		SET estado = in_estado
		WHERE refResolucion=in_refProceso;
	ELSE
		UPDATE procesofondo
		SET estado = in_estado
		WHERE refDeclaracionGastos=in_refProceso;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_Resolucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Resolucion`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Resolucion`(`in_anioResolucion` INTEGER, `in_numeroResolucion` INTEGER, `in_id` INTEGER, `in_ruta` TEXT, OUT `out_respuesta` INTEGER)
BEGIN
	SET @validar = (SELECT COUNT(id)
	FROM resolucion
	WHERE resolucion.anio=in_anioResolucion AND resolucion.numero=in_numeroResolucion AND id != in_id);
	
	IF @validar = 0 THEN
		UPDATE resolucion
		SET resolucion.anio = in_anioResolucion,
				resolucion.numero = in_numeroResolucion,
				resolucion.copiaDoc = in_ruta
		WHERE resolucion.id = in_id;
		
		SET out_respuesta = 1;
	ELSE
		SET out_respuesta = -2;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Agregar_categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `Agregar_categoria`;
delimiter ;;
CREATE PROCEDURE `Agregar_categoria`(`in_refSolicitud` INTEGER, `in_refCategoria` INTEGER)
BEGIN
	INSERT INTO SolCat(refSolicitud, refCategoria)
	VALUES (in_refSolicitud, in_refCategoria);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Agregar_Parsol
-- ----------------------------
DROP PROCEDURE IF EXISTS `Agregar_Parsol`;
delimiter ;;
CREATE PROCEDURE `Agregar_Parsol`(`in_refParticipante` VARCHAR(256), `in_refSolicitud` INTEGER)
BEGIN
	INSERT INTO ParSol(refParticipante, refSolicitud)
	VALUES (in_refParticipante, in_refSolicitud);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Agregar_Participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Agregar_Participante`;
delimiter ;;
CREATE PROCEDURE `Agregar_Participante`(`in_nombre` VARCHAR(256), `in_run` VARCHAR(256))
BEGIN
	INSERT INTO Participante(nombre, run)
	VALUES (in_nombre, in_run);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_declaracion_gastos
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_declaracion_gastos`;
delimiter ;;
CREATE PROCEDURE `Crear_declaracion_gastos`(`in_refSolicitud` INTEGER, OUT `out_id_declaracion_gastos` INTEGER)
BEGIN
		/*Obtiene los datos principales para la declaracion de gastos*/
		SELECT @fechaLimite:= DATE_ADD(fecTerEvent,INTERVAL 20 DAY)
		FROM solicitud
		WHERE solicitud.id = in_refSolicitud;
		
		/*Crea la declaracion de gastos*/
		INSERT INTO declaraciondegastos (fechaLimite) 
		VALUES (@fechaLimite);
		SET out_id_declaracion_gastos = LAST_INSERT_ID();
		
		/*Inserta el id de la nueva declaracion de gastos en la tabla proceso fondos*/
		UPDATE procesofondo
		SET procesofondo.refDeclaracionGastos = out_id_declaracion_gastos
		WHERE procesofondo.refSolicitud = in_refSolicitud;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_documento
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_documento`;
delimiter ;;
CREATE PROCEDURE `Crear_documento`(`in_codigoDocumento` VARCHAR(256), `in_proveedor` VARCHAR(256), `in_fechaDocumento` DATE, `in_monto` INTEGER, `in_descripcionDocumento` VARCHAR(256), `in_tipoDocumento` VARCHAR(256), `in_copiaDoc` VARCHAR(256), `in_refCategoria` INTEGER, `in_refParticipante` VARCHAR(256), `in_refDeclaracionGastos` INTEGER, OUT `out_id` INTEGER)
BEGIN
	SET @validar = (SELECT COUNT(id)
	FROM documento
	WHERE documento.codigoDocumento = in_codigoDocumento AND documento.proveedor = in_proveedor);
	
	IF @validar = 0 THEN
		/*Crea documento*/
		INSERT INTO documento(codigoDocumento, proveedor, fecha, monto, descripcion, tipo, copiaDoc, refCategoria, refParticipante, refDeclaracionDeGastos)
		VALUES (in_codigoDocumento ,in_proveedor, in_fechaDocumento, in_monto, in_descripcionDocumento, in_tipoDocumento, in_copiaDoc, in_refCategoria, in_refParticipante, in_refDeclaracionGastos);
		SET out_id = LAST_INSERT_ID();
	ELSE
		SET out_id = -2;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_proceso_fondo
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_proceso_fondo`;
delimiter ;;
CREATE PROCEDURE `Crear_proceso_fondo`(`in_refSolicitud` INTEGER, `in_refOrganizacion` INTEGER, `in_estado` INTEGER, `in_refResponsable` INTEGER, OUT `out_id` INTEGER)
BEGIN

	SET @idDirector = (select usuario_director.id
												from usuario_representante
												join organizacion_estudiantil on organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
												join usuario_director on usuario_director.idOrganizacionEstudiantil = organizacion_estudiantil.id and usuario_director.estado='Habilitado'
												where usuario_representante.id = in_refResponsable
												ORDER BY usuario_director.id DESC
												limit 1);
												
	INSERT INTO procesoFondo(refOrganizacion, refSolicitud, estado, refUsuarioRepresentante, refUsuarioDirector)
	VALUES (in_refOrganizacion, in_refSolicitud, in_estado, in_refResponsable, @idDirector);
	SET out_id = LAST_INSERT_ID();
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_resolucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_resolucion`;
delimiter ;;
CREATE PROCEDURE `Crear_resolucion`(`in_anioResolucion` INTEGER, `in_numeroResolucion` INTEGER, `in_refSolicitud` INTEGER, `in_ruta` TEXT, OUT `out_id_resolucion` INTEGER, OUT `out_id_declaracion_gastos` INTEGER)
BEGIN
	SET @validar = (SELECT COUNT(id)
	FROM resolucion
	WHERE resolucion.anio=in_anioResolucion AND resolucion.numero=in_numeroResolucion);
	
	SET @validar2 = (SELECT COUNT(*)
	FROM procesofondo
	WHERE procesofondo.refSolicitud = in_refSolicitud and procesofondo.refResolucion IS NOT NULL);

	
	IF @validar = 0 AND @validar2 = 0 THEN
		/*Crea la resolucion*/
		INSERT INTO resolucion(resolucion.anio, resolucion.numero, resolucion.copiaDoc)
		VALUES (in_anioResolucion, in_numeroResolucion, in_ruta);
		SET out_id_resolucion = LAST_INSERT_ID();
		
		/*Inserta el id de la resolucion recien creada en la tabla proceso fondo*/
		UPDATE procesofondo
		SET procesofondo.refResolucion = out_id_resolucion,
				procesofondo.estado = 3
		WHERE procesofondo.refSolicitud = in_refSolicitud;
		
		/*Crea la declaracion de gastos con la informacion basica*/
		/*SELECT @fechaTerminoEvento := solicitud.fecTerEvent, @refResponsable := solicitud.refResponsable, @refUsuarioDirector := solicitud.refUsuarioDirector, @fechaLimite := DATE_ADD(@fechaTerminoEvento,INTERVAL 20 DAY)
		FROM procesofondo
		JOIN resolucion on resolucion.id = procesofondo.refResolucion and resolucion.id = out_id
		JOIN solicitud on solicitud.id = procesofondo.refSolicitud;*/
		
		/*Llama a la funcion que inserta los datos basicos de la declaracion de gastos correspondiente*/
		CALL Crear_declaracion_gastos(in_refSolicitud, out_id_declaracion_gastos);		
		
	ELSE
		SET out_id_resolucion = -2;
		SET out_id_declaracion_gastos = -2;
	END IF;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_solicitud`;
delimiter ;;
CREATE PROCEDURE `Crear_solicitud`(`in_fecha` DATE, `in_monto` INTEGER, `in_nombreEvento` VARCHAR(256), `in_fechaInicioEvento` DATE, `in_fechaTerminoEvento` DATE, `in_lugarEvento` VARCHAR(256), `in_tipoActividad` VARCHAR(256), `in_fechaCreacionPDF` DATE, OUT `out_id` INTEGER, `in_fechaModificacion` DATE)
BEGIN

	INSERT INTO Solicitud(fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, lugarEvent, tipoActividad, fechaCreacionPDF, fechaModificacion)
	VALUES (in_fecha ,in_monto, in_nombreEvento, in_fechaInicioEvento, in_fechaTerminoEvento, in_lugarEvento, in_tipoActividad, in_fechaCreacionPDF, in_fechaModificacion);
	SET out_id = LAST_INSERT_ID();
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_categoria_seleccionada
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_categoria_seleccionada`;
delimiter ;;
CREATE PROCEDURE `Eliminar_categoria_seleccionada`(`in_refCategoria` INTEGER, `in_refSolicitud` INTEGER)
BEGIN
	DELETE 
	FROM SolCat
	WHERE refCategoria=in_refCategoria AND refSolicitud=in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_documento
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_documento`;
delimiter ;;
CREATE PROCEDURE `Eliminar_documento`(`in_id` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	DELETE FROM documento
	WHERE documento.id = in_id and documento.estado=0;
	
	SET @cantDocumento = (select COUNT(*) FROM documento WHERE documento.id = in_id);
	IF @cantDocumento = 0 THEN
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -2;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Participante`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Participante`(`in_refParticipante` VARCHAR(256), `in_refSolicitud` INTEGER)
BEGIN
	DELETE 
	FROM ParSol
	WHERE refParticipante=in_refParticipante AND refSolicitud=in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_resolucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_resolucion`;
delimiter ;;
CREATE PROCEDURE `Eliminar_resolucion`(`in_id` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	DELETE FROM resolucion
	WHERE resolucion.id = in_id;
	
	SET @cantResolucion = (select COUNT(*) FROM resolucion WHERE resolucion.id = in_id);
	IF @cantResolucion = 0 THEN
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -2;
	END IF;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_solicitud`;
delimiter ;;
CREATE PROCEDURE `Eliminar_solicitud`(`in_id` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	DELETE FROM solicitud
	WHERE solicitud.id = in_id;
	
	SET @cantSolicitud = (select COUNT(*) FROM solicitud WHERE solicitud.id = in_id);
	IF @cantSolicitud = 0 THEN
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -2;
	END IF;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for iniciar_sesion
-- ----------------------------
DROP PROCEDURE IF EXISTS `iniciar_sesion`;
delimiter ;;
CREATE PROCEDURE `iniciar_sesion`(IN `in_email` VARCHAR(256), IN `in_clave` VARCHAR(256), in_tipoUsuario VARCHAR(256))
BEGIN
	IF in_tipoUsuario='Director' THEN
     SELECT usuario_director.*, organizacion_estudiantil.nombre AS 'nombreOrganizacion'
	   FROM usuario_director
		 JOIN organizacion_estudiantil on idOrganizacionEstudiantil = organizacion_estudiantil.id
	   WHERE usuario_director.email = in_email AND usuario_director.clave = in_clave AND usuario_director.estado = 'Habilitado';
  ELSE
	   SELECT usuario_representante.*, organizacion_estudiantil.nombre AS 'nombreOrganizacion'
	   FROM usuario_representante
		 JOIN organizacion_estudiantil on idOrganizacionEstudiantil = organizacion_estudiantil.id
	   WHERE usuario_representante.email = in_email AND usuario_representante.clave = in_clave AND usuario_representante.estado = 'Habilitado';
END IF;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leertodas_Solicitudes_Organizacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leertodas_Solicitudes_Organizacion`;
delimiter ;;
CREATE PROCEDURE `Leertodas_Solicitudes_Organizacion`(`in_idOrganizacion` INTEGER)
BEGIN
	select Solicitud.id, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, refResponsable, nombre, lugarEvent
	from Solicitud
	join Usuario_representante on usuario_representante.id = solicitud.refResponsable
	join procesofondo on ProcesoFondo.refSolicitud = Solicitud.id
	where in_idOrganizacion=procesoFondo.refOrganizacion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Categorias
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Categorias`;
delimiter ;;
CREATE PROCEDURE `Leer_Categorias`()
BEGIN
	select *
	from categoria;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Categorias_Seleccionadas
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Categorias_Seleccionadas`;
delimiter ;;
CREATE PROCEDURE `Leer_Categorias_Seleccionadas`(`in_refSolicitud` INTEGER)
BEGIN
	SELECT categoria.*
	FROM categoria
	JOIN solcat ON solcat.refCategoria=categoria.id
	WHERE refSolicitud=in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Declaracion_Gastos
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Declaracion_Gastos`;
delimiter ;;
CREATE PROCEDURE `Leer_Declaracion_Gastos`(`in_refDeclaracionGastos` INTEGER)
BEGIN
	SELECT *
	FROM declaraciondegastos
	WHERE id = in_refDeclaracionGastos;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Direccion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Direccion`;
delimiter ;;
CREATE PROCEDURE `Leer_Direccion`(`in_refSolicitud` INTEGER)
BEGIN
	SELECT usuario_director.nombre, usuario_director.cargo, usuario_director.sexo, usuario_director.nombreInstitucion, usuario_director.fonoAnexo
	FROM usuario_director
	JOIN procesofondo ON procesofondo.refUsuarioDirector = usuario_director.id
	JOIN solicitud ON solicitud.id = procesofondo.refSolicitud AND solicitud.id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_documentos_DG
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_documentos_DG`;
delimiter ;;
CREATE PROCEDURE `Leer_documentos_DG`(`in_refDeclaracionGastos` INTEGER)
BEGIN
	SELECT id, codigoDocumento, proveedor, fecha, monto, descripcion, tipo, copiaDoc, refCategoria, IFNULL(refParticipante,'-1') AS 'refParticipante', refDeclaracionDeGastos, estado
	FROM documento
	WHERE documento.refDeclaracionDeGastos = in_refDeclaracionGastos;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Modulo
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Modulo`;
delimiter ;;
CREATE PROCEDURE `Leer_Modulo`(IN `in_idModulo` Integer)
BEGIN
	SELECT *
	FROM modulo
	WHERE modulo.id = in_idModulo;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Operacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Operacion`;
delimiter ;;
CREATE PROCEDURE `Leer_Operacion`(IN `in_idOperacion` Integer)
BEGIN
	SELECT *
	FROM operaciones
	WHERE operaciones.id = in_idOperacion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Organizacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Organizacion`;
delimiter ;;
CREATE PROCEDURE `Leer_Organizacion`(`in_refSolicitud` INTEGER)
BEGIN
	SELECT organizacion_estudiantil.nombre, organizacion_estudiantil.tipo
	FROM organizacion_estudiantil
	JOIN procesofondo on procesofondo.refOrganizacion=organizacion_estudiantil.id
	JOIN solicitud on solicitud.id = procesofondo.refSolicitud
	WHERE solicitud.id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Participante`;
delimiter ;;
CREATE PROCEDURE `Leer_Participante`(`in_refParticipante` INTEGER)
BEGIN
	SELECT *
	FROM participante
	WHERE run = in_refParticipante;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Participantes
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Participantes`;
delimiter ;;
CREATE PROCEDURE `Leer_Participantes`(`in_refSolicitud` INTEGER)
BEGIN
	SELECT Participante.*
	FROM Participante
	JOIN ParSol ON parsol.refParticipante = participante.run
	WHERE ParSol.refSolicitud = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Procesos_Organizacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Procesos_Organizacion`;
delimiter ;;
CREATE PROCEDURE `Leer_Procesos_Organizacion`(`in_idOrganizacion` INTEGER)
BEGIN
	select idFondo, refSolicitud, IFNULL(refResolucion,-1) as 'refResolucion', IFNULL(refDeclaracionGastos,-1) as 'refDeclaracionGastos', estado, refOrganizacion, estadoFinal, refUsuarioRepresentante as 'refResponsable', refUsuarioDirector
	from procesoFondo
	where procesoFondo.refOrganizacion=in_idOrganizacion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Representantes
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Representantes`;
delimiter ;;
CREATE PROCEDURE `Leer_Representantes`(IN `in_idOrganizacion` Integer)
BEGIN
select representante.id, representante.nombre, representante.run, representante.sexo, representante.matricula, representante.carrera, representante.idRol, rol.nombre as 'nombreRol', representante.crearProceso
from usuario_representante as representante
join rol on rol.id = representante.idRol
where idOrganizacionEstudiantil= in_idOrganizacion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Representantes_Habilitados
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Representantes_Habilitados`;
delimiter ;;
CREATE PROCEDURE `Leer_Representantes_Habilitados`(IN `in_idOrganizacion` Integer)
BEGIN
select representante.id, representante.nombre, representante.run, representante.sexo, representante.matricula, representante.carrera, representante.idRol, rol.nombre as 'nombreRol', representante.crearProceso
from usuario_representante as representante
join rol on rol.id = representante.idRol
where idOrganizacionEstudiantil= in_idOrganizacion and estado='Habilitado';
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Resolucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Resolucion`;
delimiter ;;
CREATE PROCEDURE `Leer_Resolucion`(`in_id` INTEGER)
BEGIN
	SELECT resolucion.*, procesofondo.estado
	FROM resolucion
	JOIN procesofondo on procesofondo.refResolucion = resolucion.id
	WHERE resolucion.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Responsable
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Responsable`;
delimiter ;;
CREATE PROCEDURE `Leer_Responsable`(`in_refResponsable` INTEGER)
BEGIN
	SELECT usuario_representante.id, usuario_representante.nombre, run, rol.nombre as "cargo", carrera, matricula, email
	FROM usuario_representante
	JOIN rol  on rol.id = usuario_representante.idRol
	WHERE usuario_representante.id = in_refResponsable;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Rol_Operacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Rol_Operacion`;
delimiter ;;
CREATE PROCEDURE `Leer_Rol_Operacion`(IN `in_idRolUsuario` Integer, IN `in_idOperacion` Integer)
BEGIN
	SELECT *
	FROM rol_operacion
	WHERE rol_operacion.idRol = in_idRolUsuario AND rol_operacion.idOperacion = in_idOperacion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Solicitud`;
delimiter ;;
CREATE PROCEDURE `Leer_Solicitud`(`in_refSolicitud` INTEGER)
BEGIN
	SELECT solicitud.*, procesofondo.idFondo, procesofondo.estado
	FROM solicitud
	JOIN procesofondo on procesofondo.refSolicitud = solicitud.id
	WHERE solicitud.id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Modificar_crearProceso_usuario_representante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Modificar_crearProceso_usuario_representante`;
delimiter ;;
CREATE PROCEDURE `Modificar_crearProceso_usuario_representante`(`in_refResponsable` VARCHAR(256), `in_estado` VARCHAR(256))
BEGIN
	UPDATE usuario_representante
	SET crearProceso=in_estado
	WHERE id=in_refResponsable;	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Modificar_responsable_proceso
-- ----------------------------
DROP PROCEDURE IF EXISTS `Modificar_responsable_proceso`;
delimiter ;;
CREATE PROCEDURE `Modificar_responsable_proceso`(`in_refSolicitud` INTEGER, `in_refResponsable` INTEGER)
BEGIN
	UPDATE procesofondo
	SET refUsuarioRepresentante=in_refResponsable
	WHERE refSolicitud=in_refSolicitud;	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Modificar_seleccion_documento
-- ----------------------------
DROP PROCEDURE IF EXISTS `Modificar_seleccion_documento`;
delimiter ;;
CREATE PROCEDURE `Modificar_seleccion_documento`(`in_idDocumento` INTEGER, `in_estado` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	UPDATE documento
	SET estado=in_estado
	WHERE id=in_idDocumento;	
	SET out_validacion = 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Modificar_solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `Modificar_solicitud`;
delimiter ;;
CREATE PROCEDURE `Modificar_solicitud`(`in_monto` INTEGER, `in_nombreEvento` VARCHAR(256), `in_fechaInicioEvento` DATE, `in_fechaTerminoEvento` DATE,  `in_lugarEvento` VARCHAR(256), `in_tipoActividad` VARCHAR(256), `in_fechaCreacionPDF` DATE, `in_fechaModificacion` DATE, `in_id` INTEGER)
BEGIN
	UPDATE solicitud
	SET monto=in_monto,
			nomEvent = in_nombreEvento,
			fecIniEvent = in_fechaInicioEvento,
			fecTerEvent = in_fechaTerminoEvento,
			lugarEvent = in_lugarEvento,
			tipoActividad = in_tipoActividad,
			fechaCreacionPDF = in_fechaCreacionPDF,
			fechaModificacion = in_fechaModificacion
	WHERE id=in_id;	
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table documento
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_documento_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_documento_after_insert` AFTER INSERT ON `documento` FOR EACH ROW BEGIN
	/*Aumenta el monto del totalDocumentacion en la tabla declaraciondegastos*/
	SET @totalDocumentacion = (SELECT declaraciondegastos.totalDocumentacion
	FROM declaraciondegastos
	WHERE declaraciondegastos.id = NEW.refDeclaracionDeGastos);
	
	UPDATE declaraciondegastos
	SET declaraciondegastos.totalDocumentacion = @totalDocumentacion + NEW.monto
	WHERE declaraciondegastos.id = NEW.refDeclaracionDeGastos;

	/*Modifica el estado del proceso a 4 cuando el estado es 3 y se ingresa el primer documento*/
	SET @cantDocumentos = (SELECT COUNT(id)
	FROM documento
	WHERE documento.refDeclaracionDeGastos = NEW.refDeclaracionDeGastos);
	
	SET @estadoProceso = (SELECT procesofondo.estado
	FROM procesofondo
	WHERE procesofondo.refDeclaracionGastos = NEW.refDeclaracionDeGastos);
	
	IF @cantDocumentos = 1 AND @estadoProceso= 3 THEN
		UPDATE procesofondo
		SET procesofondo.estado = 4
		WHERE procesofondo.refDeclaracionGastos = NEW.refDeclaracionDeGastos;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table documento
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_documento_after_update`;
delimiter ;;
CREATE TRIGGER `TR_documento_after_update` AFTER UPDATE ON `documento` FOR EACH ROW BEGIN
	IF NEW.estado != OLD.estado THEN
			SET @montoDocumento = OLD.monto;
			
			IF NEW.estado = 0 THEN
				SET @montoDocumento = @montoDocumento*-1;
			END IF;
		
			UPDATE declaraciondegastos
			SET declaraciondegastos.totalRendido = declaraciondegastos.totalRendido + @montoDocumento
			WHERE declaraciondegastos.id = OLD.refDeclaracionDeGastos;
	
	ELSE
			UPDATE declaraciondegastos
			SET declaraciondegastos.totalRendido = declaraciondegastos.totalRendido - OLD.monto + NEW.monto
			WHERE declaraciondegastos.id = OLD.refDeclaracionDeGastos;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table documento
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_documento_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_documento_after_delete` AFTER DELETE ON `documento` FOR EACH ROW BEGIN

	/*Disminuye el monto del totalDocumentacion en la tabla declaraciondegastos*/
	SET @totalDocumentacion = (SELECT declaraciondegastos.totalDocumentacion
	FROM declaraciondegastos
	WHERE declaraciondegastos.id = OLD.refDeclaracionDeGastos);
	
	UPDATE declaraciondegastos
	SET declaraciondegastos.totalDocumentacion = @totalDocumentacion - OLD.monto
	WHERE declaraciondegastos.id = OLD.refDeclaracionDeGastos;

	/*Modifica el estado del proceso a 4 cuando el estado es 3 y se ingresa el primer documento*/
	SET @cantDocumentos = (SELECT COUNT(id)
	FROM documento
	WHERE documento.refDeclaracionDeGastos = OLD.refDeclaracionDeGastos);
	
	SET @estadoProceso = (SELECT procesofondo.estado
	FROM procesofondo
	WHERE procesofondo.refDeclaracionGastos = OLD.refDeclaracionDeGastos);
	
	IF @cantDocumentos = 0 AND @estadoProceso = 4 THEN
		UPDATE procesofondo
		SET procesofondo.estado = 3
		WHERE procesofondo.refDeclaracionGastos = OLD.refDeclaracionDeGastos;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table resolucion
-- ----------------------------
DROP TRIGGER IF EXISTS `resolucion_ad_1`;
delimiter ;;
CREATE TRIGGER `resolucion_ad_1` AFTER DELETE ON `resolucion` FOR EACH ROW UPDATE procesofondo 
SET estado = 2
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
