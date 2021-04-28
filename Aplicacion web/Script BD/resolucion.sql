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

 Date: 12/04/2021 22:13:33
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

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
-- Triggers structure for table resolucion
-- ----------------------------
DROP TRIGGER IF EXISTS `resolucion_ad_1`;
delimiter ;;
CREATE TRIGGER `resolucion_ad_1` AFTER DELETE ON `resolucion` FOR EACH ROW UPDATE procesofondo 
SET estado = 2
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
