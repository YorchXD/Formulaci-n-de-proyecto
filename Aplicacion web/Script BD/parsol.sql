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

 Date: 22/09/2021 22:39:15
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for parsol
-- ----------------------------
DROP TABLE IF EXISTS `parsol`;
CREATE TABLE `parsol`  (
  `refParticipante` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `refSolicitud` int NOT NULL,
  PRIMARY KEY (`refParticipante`, `refSolicitud`) USING BTREE,
  INDEX `refSolicitud`(`refSolicitud`) USING BTREE,
  INDEX `refParticipante`(`refParticipante`) USING BTREE,
  CONSTRAINT `parsol_ibfk_2` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `persol_ibfk_1` FOREIGN KEY (`refParticipante`) REFERENCES `participante` (`run`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of parsol
-- ----------------------------
INSERT INTO `parsol` VALUES ('17820883-7', 58);
INSERT INTO `parsol` VALUES ('17824523-6', 15);
INSERT INTO `parsol` VALUES ('17824523-6', 20);
INSERT INTO `parsol` VALUES ('17824523-6', 21);
INSERT INTO `parsol` VALUES ('17824523-6', 22);
INSERT INTO `parsol` VALUES ('17824523-6', 23);
INSERT INTO `parsol` VALUES ('17824523-6', 24);
INSERT INTO `parsol` VALUES ('17824523-6', 25);
INSERT INTO `parsol` VALUES ('17824523-6', 26);
INSERT INTO `parsol` VALUES ('17824523-6', 29);
INSERT INTO `parsol` VALUES ('17824523-6', 54);
INSERT INTO `parsol` VALUES ('17981314-9', 63);
INSERT INTO `parsol` VALUES ('19043138-K', 15);
INSERT INTO `parsol` VALUES ('19043138-K', 20);
INSERT INTO `parsol` VALUES ('19043138-K', 22);
INSERT INTO `parsol` VALUES ('19043138-K', 23);
INSERT INTO `parsol` VALUES ('19043138-K', 24);
INSERT INTO `parsol` VALUES ('19043138-K', 26);
INSERT INTO `parsol` VALUES ('19043138-K', 58);

-- ----------------------------
-- Triggers structure for table parsol
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_parsol_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_parsol_after_insert` AFTER INSERT ON `parsol` FOR EACH ROW BEGIN
	/*Obtiene el valor del estadoEdicion. 1 implica que se puede editar los datos del participante y 0 significa que no se puede editar*/
	SET @estadoEdicion = (SELECT estadoEdicion
	FROM participante
	WHERE run = NEW.refParticipante);
	
	/*Obtiene la cantidad de solicitudes que estan asociadas al participante*/
	SET @cantSolicitudesParticipante = (SELECT count(*)
	FROM parsol
	WHERE refParticipante = NEW.refParticipante);
	
	IF @cantSolicitudesParticipante = 2 AND @estadoEdicion= 1 THEN
		UPDATE participante
		SET estadoEdicion = 0
		WHERE run = NEW.refParticipante;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table parsol
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_parsol_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_parsol_after_delete` AFTER DELETE ON `parsol` FOR EACH ROW BEGIN
	/*Obtiene el valor del estadoEdicion. 1 implica que se puede editar los datos del participante y 0 significa que no se puede editar*/
	SET @estadoEdicion = (SELECT estadoEdicion
	FROM participante
	WHERE run = OLD.refParticipante);
	
	/*Obtiene la cantidad de solicitudes que estan asociadas al participante*/
	SET @cantSolicitudesParticipante = (SELECT count(*)
	FROM parsol
	WHERE refParticipante = OLD.refParticipante);
	
	/*Si el participante solo se encuentra asociado solo a una solicitud despues de desvincularlo de la solicitud actual, se habilita la posibilidad de editar los datos del participante, y solo se puede modificar el campo nombre*/
	IF @cantSolicitudesParticipante = 1 AND @estadoEdicion = 0 THEN
		UPDATE participante
		SET estadoEdicion = 1
		WHERE run = OLD.refParticipante;	
	/*En el caso de que el participante ya no se encuentre asociado a una solicitud, se procede a eliminarse el registro del participante*/
	ELSEIF @cantSolicitudesParticipante = 0 THEN
		DELETE FROM participante
		WHERE run = OLD.refParticipante;
	END IF;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
