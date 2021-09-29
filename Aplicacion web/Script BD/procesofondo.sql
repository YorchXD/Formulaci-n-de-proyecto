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

 Date: 23/09/2021 17:07:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for procesofondo
-- ----------------------------
DROP TABLE IF EXISTS `procesofondo`;
CREATE TABLE `procesofondo`  (
  `idFondo` int NOT NULL AUTO_INCREMENT,
  `refSolicitud` int NULL DEFAULT NULL,
  `refResolucion` int NULL DEFAULT NULL,
  `refDeclaracionGastos` int NULL DEFAULT NULL,
  `estado` int NOT NULL,
  `refOrganizacion` int NOT NULL,
  `estadoFinal` varchar(7) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT 'Abierto',
  `refUsuarioRepresentante` int NOT NULL,
  `refUsuarioDirector` int NULL DEFAULT NULL,
  `refUsuarioVicerector` int NULL DEFAULT NULL,
  PRIMARY KEY (`idFondo`) USING BTREE,
  INDEX `ref_resolucion`(`refResolucion`) USING BTREE,
  INDEX `refOrganizacion`(`refOrganizacion`) USING BTREE,
  INDEX `refDeclaracionGastos`(`refDeclaracionGastos`) USING BTREE,
  INDEX `refSolicitud`(`refSolicitud`) USING BTREE,
  INDEX `procesofondo_ibfk_5`(`refUsuarioRepresentante`) USING BTREE,
  INDEX `procesofondo_ibfk_6`(`refUsuarioDirector`) USING BTREE,
  INDEX `procesofondo_ibk_7`(`refUsuarioVicerector`) USING BTREE,
  INDEX `procesofondo_ibfk_8`(`estado`) USING BTREE,
  CONSTRAINT `procesofondo_ibfk_1` FOREIGN KEY (`refDeclaracionGastos`) REFERENCES `declaraciondegastos` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_2` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_3` FOREIGN KEY (`refResolucion`) REFERENCES `resolucion` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_4` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_5` FOREIGN KEY (`refUsuarioRepresentante`) REFERENCES `usuario_representante` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_6` FOREIGN KEY (`refUsuarioDirector`) REFERENCES `usuario_director` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_8` FOREIGN KEY (`estado`) REFERENCES `estadoproceso` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibk_7` FOREIGN KEY (`refUsuarioVicerector`) REFERENCES `usuario_vicerector` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 71 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of procesofondo
-- ----------------------------
INSERT INTO `procesofondo` VALUES (15, 15, 46, 12, 6, 1, 'Cerrado', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (16, 16, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (18, 18, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (19, 19, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (20, 20, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (21, 21, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (22, 22, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (23, 23, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (24, 24, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (25, 25, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (26, 26, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (27, 27, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (28, 28, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (29, 29, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (30, 30, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (31, 31, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (32, 32, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (33, 33, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (34, 34, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (35, 35, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (36, 36, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (37, 37, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (38, 38, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (39, 39, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (40, 40, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (41, 41, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (42, 42, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (43, 43, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (46, 46, 40, 6, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (47, 47, NULL, NULL, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (48, 48, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (49, 49, 39, 5, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (50, 50, NULL, NULL, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (51, 51, 38, 4, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (54, 54, 37, 3, 5, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (62, 60, NULL, NULL, 2, 2, 'Abierto', 7, NULL, 6);
INSERT INTO `procesofondo` VALUES (67, 64, 47, 13, 5, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (70, 67, 48, 14, 2, 1, 'Abierto', 1, 1, NULL);

-- ----------------------------
-- Triggers structure for table procesofondo
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_procesoFondo_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_procesoFondo_after_insert` AFTER INSERT ON `procesofondo` FOR EACH ROW BEGIN
		/*Obtiene el id de la organizacion para saber si se deshabilita la eliminacion de la organizacion estudiantil*/
    SET @idUsuarioDirector = NEW.refUsuarioDirector;
		SET @idUsuarioVicerector = NEW.refUsuarioVicerector;
		SET @idUsuarioRepresentante = NEW.refUsuarioRepresentante;
		
		IF @idUsuarioDirector IS NOT NULL THEN
			/*Obtiene la cantidad de procesos asociados el director*/
			SET @cantProscesosAsociadosDirector = (	SELECT COUNT(*)
																			FROM procesoFondo
																			WHERE refUsuarioDirector=@idUsuarioDirector);

			/*Actualiza el estadoEliminacion del proceso del fondo que pertenece el proceso*/
			UPDATE usuario_director 
			SET estadoEliminacion = 'DESHABILITADO'
			WHERE id = @idUsuarioDirector AND @cantProscesosAsociadosDirector=1 AND estadoEliminacion = 'HABILITADO'; 
		
		ELSE
			/*Obtiene la cantidad de procesos asociados el vicerector*/
			SET @cantProscesosAsociadosVicerector = (	SELECT COUNT(*)
																			FROM procesoFondo
																			WHERE refUsuarioVicerector=@idUsuarioVicerector);

			/*Actualiza el estadoEliminacion del proceso del fondo que pertenece el proceso*/
			UPDATE usuario_vicerector 
			SET estadoEliminacion = 'DESHABILITADO'
			WHERE id = @idUsuarioVicerector AND @cantProscesosAsociadosVicerector=1 AND estadoEliminacion = 'HABILITADO'; 
		
		END IF;
		
		/*Obtiene la cantidad de procesos asociados el representante*/
		SET @cantProscesosAsociadosRepresentante = (	SELECT COUNT(*)
																									FROM procesoFondo
																									WHERE refUsuarioRepresentante=@idUsuarioRepresentante);
		
		UPDATE usuario_representante 
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idUsuarioRepresentante AND @cantProscesosAsociadosRepresentante=1 AND estadoEliminacion = 'Habilitado'; 
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table procesofondo
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_procesoFondo_after_update`;
delimiter ;;
CREATE TRIGGER `TR_procesoFondo_after_update` AFTER UPDATE ON `procesofondo` FOR EACH ROW BEGIN
		/*Obtiene el id deL usuario representante para saber si se habilita la eliminacion*/
		SET @idUsuarioRepresentante = OLD.refUsuarioRepresentante;
		/*Obtiene la cantidad de procesos asociados*/
		SET @cantProscesosAsociadosRepresentante = (	SELECT COUNT(*)
																		FROM procesoFondo
																		WHERE refUsuarioRepresentante=@idUsuarioRepresentante);
		/*Actualiza el estadoEliminacion del usuario representante*/		
		UPDATE usuario_representante 
		SET estadoEliminacion = 'Habilitado'
		WHERE id = @idUsuarioRepresentante AND @cantProscesosAsociadosRepresentante=0 AND estadoEliminacion = 'Deshabilitado'; 
		
		/*Obtiene el id deL usuario representante para saber si se deshabilita la eliminacion*/
		SET @idUsuarioRepresentante = NEW.refUsuarioRepresentante;
		/*Obtiene la cantidad de procesos asociados*/
		SET @cantProscesosAsociadosRepresentante = (	SELECT COUNT(*)
																		FROM procesoFondo
																		WHERE refUsuarioRepresentante=@idUsuarioRepresentante);
		/*Actualiza el estadoEliminacion del proceso del fondo que pertenece el proceso*/
		UPDATE usuario_representante 
		SET estadoEliminacion = 'Deshabilitado'
		WHERE id = @idUsuarioRepresentante AND @cantProscesosAsociadosRepresentante=1 AND estadoEliminacion = 'Habilitado';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table procesofondo
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_procesoFondo_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_procesoFondo_after_delete` AFTER DELETE ON `procesofondo` FOR EACH ROW BEGIN
		/*Obtiene el id deL usuario director o vicerector y representante para saber si se habilita la eliminacion*/
		/*Obtiene la cantidad de procesos asociados del representante*/
		
		SET @idUsuarioRepresentante = OLD.refUsuarioRepresentante;
		SET @cantProscesosAsociadosRepresentante = (	SELECT COUNT(*)
																		FROM procesoFondo
																		WHERE refUsuarioRepresentante=@idUsuarioRepresentante);
		UPDATE usuario_representante 
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idUsuarioRepresentante AND @cantProscesosAsociadosRepresentante=0 AND estadoEliminacion = 'DESHABILITADO'; 
		
		
    SET @idUsuarioDirector = OLD.refUsuarioDirector;
		SET @idUsuarioVicerector = OLD.refUsuarioVicerector;
		
		
		IF !ISNULL(@idUsuarioDirector) THEN
			/*Obtiene la cantidad de procesos asociados del director*/
			SET @cantProscesosAsociadosDirector = (	SELECT COUNT(*)
																			FROM procesoFondo
																			WHERE refUsuarioDirector=@idUsuarioDirector);
			
			/*Actualiza el estadoEliminacion del usuario director*/
			UPDATE usuario_director 
			SET estadoEliminacion = 'HABILITADO'
			WHERE id = @idUsuarioDirector AND @cantProscesosAsociadosDirector=0 AND estadoEliminacion = 'DESHABILITADO'; 
			
		ELSE
			/*Obtiene la cantidad de procesos asociados del vicerector*/
			SET @cantProscesosAsociadosVicerector = (	SELECT COUNT(*)
																			FROM procesoFondo
																			WHERE refUsuarioVicerector=@idUsuarioVicerector);
			
			/*Actualiza el estadoEliminacion del usuario vicerector*/
			UPDATE usuario_vicerector 
			SET estadoEliminacion = 'HABILITADO'
			WHERE id = @idUsuarioVicerector AND @cantProscesosAsociadosVicerector=0 AND estadoEliminacion = 'DESHABILITADO'; 
		
			/*SELECT 'Salio trigger eliminar proceso fondo';*/
		END IF;
		
		
		
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
