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

 Date: 24/02/2021 02:41:48
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
-- Records of categoria
-- ----------------------------
INSERT INTO `categoria` VALUES (1, 'Alimentación');
INSERT INTO `categoria` VALUES (2, 'Alojamiento');
INSERT INTO `categoria` VALUES (3, 'Articulos de oficina');
INSERT INTO `categoria` VALUES (4, 'Inscripción');
INSERT INTO `categoria` VALUES (5, 'Pasajes');

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
-- Records of declaraciondegastos
-- ----------------------------
INSERT INTO `declaraciondegastos` VALUES (1, '2020-12-16', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (2, '2020-10-14', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (3, '2021-01-19', 867044, 730402);
INSERT INTO `declaraciondegastos` VALUES (4, '2020-10-13', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (5, '2020-09-30', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (6, '2020-10-15', 0, 0);

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
-- Records of documento
-- ----------------------------
INSERT INTO `documento` VALUES (14, '133hola', 'Yorch', '2020-12-25', 365218, 'Prueba verano febrero', 'Factura', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\54\\DeclaracionGastos\\17824523-6\\1.jpg', 2, '17824523-6', 3, 1);
INSERT INTO `documento` VALUES (15, '133jghghd', 'Yorch', '2020-12-26', 136582, 'Prueba verano febrero 2', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\54\\DeclaracionGastos\\17824523-6\\2.jpg', 2, '17824523-6', 3, 0);
INSERT INTO `documento` VALUES (16, '13346h', 'Yorch', '2020-12-26', 365214, 'Prueba verano febrero modifica y elimina', 'Factura', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\54\\DeclaracionGastos\\-1\\1.pdf', 2, NULL, 3, 1);

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
-- Records of modulo
-- ----------------------------
INSERT INTO `modulo` VALUES (1, 'Solicitud');
INSERT INTO `modulo` VALUES (2, 'Resolución');
INSERT INTO `modulo` VALUES (3, 'Declaración de gastos');

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
-- Records of operaciones
-- ----------------------------
INSERT INTO `operaciones` VALUES (1, 'Agregar', 1);
INSERT INTO `operaciones` VALUES (2, 'Leer', 1);
INSERT INTO `operaciones` VALUES (3, 'Actualizar', 1);
INSERT INTO `operaciones` VALUES (4, 'Eliminar', 1);
INSERT INTO `operaciones` VALUES (5, 'Agregar', 2);
INSERT INTO `operaciones` VALUES (6, 'Leer', 2);
INSERT INTO `operaciones` VALUES (7, 'Actuaizar', 2);
INSERT INTO `operaciones` VALUES (8, 'Eliminar', 2);
INSERT INTO `operaciones` VALUES (9, 'Agregar', 3);
INSERT INTO `operaciones` VALUES (10, 'Leer', 3);
INSERT INTO `operaciones` VALUES (11, 'Acualizar', 3);
INSERT INTO `operaciones` VALUES (12, 'Eliminar', 3);

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
-- Records of organizacion_estudiantil
-- ----------------------------
INSERT INTO `organizacion_estudiantil` VALUES (1, 'CAAICC', 'caaicc2016@gmail.com', 'Curicó', 'Habiltado', 'CAA');
INSERT INTO `organizacion_estudiantil` VALUES (2, 'FEDEUT', 'fedeutcuricó@gmail.com', 'Curicó', 'Habilitado', 'FEDERACION');

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
-- Records of parsol
-- ----------------------------
INSERT INTO `parsol` VALUES ('17824523-6', 20);
INSERT INTO `parsol` VALUES ('19043138-K', 20);
INSERT INTO `parsol` VALUES ('17824523-6', 21);
INSERT INTO `parsol` VALUES ('17824523-6', 22);
INSERT INTO `parsol` VALUES ('19043138-K', 22);
INSERT INTO `parsol` VALUES ('17824523-6', 23);
INSERT INTO `parsol` VALUES ('19043138-K', 23);
INSERT INTO `parsol` VALUES ('17824523-6', 24);
INSERT INTO `parsol` VALUES ('19043138-K', 24);
INSERT INTO `parsol` VALUES ('17824523-6', 25);
INSERT INTO `parsol` VALUES ('19043138-K', 26);
INSERT INTO `parsol` VALUES ('17824523-6', 29);
INSERT INTO `parsol` VALUES ('17824523-6', 54);
INSERT INTO `parsol` VALUES ('17820883-7', 58);
INSERT INTO `parsol` VALUES ('17824523-6', 58);
INSERT INTO `parsol` VALUES ('19043138-K', 58);

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
-- Records of participante
-- ----------------------------
INSERT INTO `participante` VALUES ('Patricia Manríquez', '12296649-6');
INSERT INTO `participante` VALUES ('Daniela Paredes', '17820883-7');
INSERT INTO `participante` VALUES ('Yorch Sepúlveda', '17824523-6');
INSERT INTO `participante` VALUES ('Gregory Sepúlveda', '19043138-K');

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
-- Records of procesofondo
-- ----------------------------
INSERT INTO `procesofondo` VALUES (6, 6, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (7, 7, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (8, 8, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (9, 9, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (10, 10, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (11, 11, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (12, 12, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (13, 13, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (14, 14, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (15, 15, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (16, 16, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (17, 17, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (18, 18, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (19, 19, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (20, 20, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (21, 21, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (22, 22, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (23, 23, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (24, 24, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (25, 25, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (26, 26, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (27, 27, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (28, 28, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (29, 29, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (30, 30, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (31, 31, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (32, 32, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (33, 33, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (34, 34, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (35, 35, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (36, 36, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (37, 37, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (38, 38, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (39, 39, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (40, 40, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (41, 41, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (42, 42, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (43, 43, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (46, 46, 40, 6, 3, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (47, 47, NULL, NULL, 2, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (48, 48, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (49, 49, 39, 5, 3, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (50, 50, NULL, NULL, 2, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (51, 51, 38, 4, 3, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (52, 52, 32, 2, 3, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (53, 53, 31, 1, 3, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (54, 54, 37, 3, 4, 1, 'Abierta', 2, 1);
INSERT INTO `procesofondo` VALUES (57, 57, NULL, NULL, 1, 1, 'Abierta', 1, 1);
INSERT INTO `procesofondo` VALUES (60, 58, NULL, NULL, 2, 1, 'Abierta', 1, 1);

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
-- Records of resolucion
-- ----------------------------
INSERT INTO `resolucion` VALUES (31, 202012, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\53\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (32, 202013, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\52\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (37, 236420, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\54\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (38, 365, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\51\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (39, 2136, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\49\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (40, 325, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\46\\Resolucion\\Resolucion.pdf');

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
-- Records of rol
-- ----------------------------
INSERT INTO `rol` VALUES (1, 'Administrador');
INSERT INTO `rol` VALUES (2, 'Director(a)');
INSERT INTO `rol` VALUES (3, 'Presidente');
INSERT INTO `rol` VALUES (4, 'Secretario(a) de finanzas');

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
-- Records of rol_operacion
-- ----------------------------
INSERT INTO `rol_operacion` VALUES (1, 2, 2);
INSERT INTO `rol_operacion` VALUES (2, 2, 6);
INSERT INTO `rol_operacion` VALUES (3, 2, 10);
INSERT INTO `rol_operacion` VALUES (4, 3, 1);
INSERT INTO `rol_operacion` VALUES (5, 3, 2);
INSERT INTO `rol_operacion` VALUES (6, 3, 3);
INSERT INTO `rol_operacion` VALUES (7, 3, 4);
INSERT INTO `rol_operacion` VALUES (8, 3, 5);
INSERT INTO `rol_operacion` VALUES (9, 3, 6);
INSERT INTO `rol_operacion` VALUES (10, 3, 7);
INSERT INTO `rol_operacion` VALUES (11, 3, 8);
INSERT INTO `rol_operacion` VALUES (12, 3, 9);
INSERT INTO `rol_operacion` VALUES (13, 3, 10);
INSERT INTO `rol_operacion` VALUES (14, 3, 11);
INSERT INTO `rol_operacion` VALUES (15, 3, 12);
INSERT INTO `rol_operacion` VALUES (16, 4, 1);
INSERT INTO `rol_operacion` VALUES (17, 4, 2);
INSERT INTO `rol_operacion` VALUES (18, 4, 3);
INSERT INTO `rol_operacion` VALUES (19, 4, 4);
INSERT INTO `rol_operacion` VALUES (20, 4, 5);
INSERT INTO `rol_operacion` VALUES (21, 4, 6);
INSERT INTO `rol_operacion` VALUES (22, 4, 7);
INSERT INTO `rol_operacion` VALUES (23, 4, 8);
INSERT INTO `rol_operacion` VALUES (24, 4, 9);
INSERT INTO `rol_operacion` VALUES (25, 4, 10);
INSERT INTO `rol_operacion` VALUES (26, 4, 11);
INSERT INTO `rol_operacion` VALUES (27, 4, 12);

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
-- Records of solcat
-- ----------------------------
INSERT INTO `solcat` VALUES (6, 3);
INSERT INTO `solcat` VALUES (7, 3);
INSERT INTO `solcat` VALUES (7, 5);
INSERT INTO `solcat` VALUES (7, 2);
INSERT INTO `solcat` VALUES (8, 2);
INSERT INTO `solcat` VALUES (8, 3);
INSERT INTO `solcat` VALUES (8, 3);
INSERT INTO `solcat` VALUES (8, 3);
INSERT INTO `solcat` VALUES (9, 2);
INSERT INTO `solcat` VALUES (14, 2);
INSERT INTO `solcat` VALUES (14, 4);
INSERT INTO `solcat` VALUES (15, 3);
INSERT INTO `solcat` VALUES (16, 2);
INSERT INTO `solcat` VALUES (17, 1);
INSERT INTO `solcat` VALUES (17, 3);
INSERT INTO `solcat` VALUES (18, 2);
INSERT INTO `solcat` VALUES (19, 1);
INSERT INTO `solcat` VALUES (20, 2);
INSERT INTO `solcat` VALUES (21, 3);
INSERT INTO `solcat` VALUES (22, 1);
INSERT INTO `solcat` VALUES (23, 1);
INSERT INTO `solcat` VALUES (24, 1);
INSERT INTO `solcat` VALUES (25, 2);
INSERT INTO `solcat` VALUES (25, 5);
INSERT INTO `solcat` VALUES (26, 1);
INSERT INTO `solcat` VALUES (27, 2);
INSERT INTO `solcat` VALUES (28, 2);
INSERT INTO `solcat` VALUES (29, 2);
INSERT INTO `solcat` VALUES (29, 4);
INSERT INTO `solcat` VALUES (30, 1);
INSERT INTO `solcat` VALUES (31, 3);
INSERT INTO `solcat` VALUES (32, 2);
INSERT INTO `solcat` VALUES (33, 2);
INSERT INTO `solcat` VALUES (34, 2);
INSERT INTO `solcat` VALUES (35, 2);
INSERT INTO `solcat` VALUES (36, 1);
INSERT INTO `solcat` VALUES (37, 2);
INSERT INTO `solcat` VALUES (38, 1);
INSERT INTO `solcat` VALUES (39, 1);
INSERT INTO `solcat` VALUES (40, 1);
INSERT INTO `solcat` VALUES (41, 2);
INSERT INTO `solcat` VALUES (42, 1);
INSERT INTO `solcat` VALUES (43, 3);
INSERT INTO `solcat` VALUES (46, 1);
INSERT INTO `solcat` VALUES (47, 1);
INSERT INTO `solcat` VALUES (48, 1);
INSERT INTO `solcat` VALUES (49, 1);
INSERT INTO `solcat` VALUES (50, 1);
INSERT INTO `solcat` VALUES (51, 1);
INSERT INTO `solcat` VALUES (52, 1);
INSERT INTO `solcat` VALUES (53, 2);
INSERT INTO `solcat` VALUES (10, 4);
INSERT INTO `solcat` VALUES (54, 2);
INSERT INTO `solcat` VALUES (58, 4);
INSERT INTO `solcat` VALUES (58, 5);
INSERT INTO `solcat` VALUES (58, 1);
INSERT INTO `solcat` VALUES (58, 2);

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
-- Records of solicitud
-- ----------------------------
INSERT INTO `solicitud` VALUES (6, '2020-08-12', 1214515, 'Yjsfksdfj', '2020-08-26', '2020-08-27', 'UTALCA', 'Masiva', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (7, '2020-08-12', 325469, 'lxkzjcñlzxk', '2020-08-25', '2020-08-25', 'kjdshflkdfjh', 'Masiva', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (8, '2020-08-12', 34345, 'gfjkl', '2020-08-27', '2020-08-27', 'casa', 'Masiva', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (9, '2020-08-12', 234567, 'fguyr', '2020-08-21', '2020-08-21', 'casa', 'Masiva', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (10, '2020-08-12', 0, 'Prueba Actualización', '2020-08-29', '2020-09-25', 'casa', 'Masiva', '2020-09-13', '2020-09-13');
INSERT INTO `solicitud` VALUES (11, '2020-08-12', 45678, 'sdfgsdhsdfh', '2020-08-27', '2020-08-20', 'casa', 'Grupal', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (12, '2020-08-12', 1321554, 'ljkdfhlsdkfjh', '2020-08-21', '2020-08-26', 'sldkfjsdfkl', 'Masiva', '2020-08-12', '2020-08-12');
INSERT INTO `solicitud` VALUES (13, '2020-08-13', 4564321, 'lkjñflksdjfñslkdj', '2020-08-13', '2020-08-19', 'sdl.kjfsdkfj', 'Masiva', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (14, '2020-08-13', 654321, 'ljkñflkdjg', '2020-08-29', '2020-08-31', 'sdf.sdklfjdsf', 'Masiva', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (15, '2020-08-13', 23456, 'zxcvbdsf', '2020-08-26', '2020-08-28', 'dsdfasdf', 'Masiva', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (16, '2020-08-13', 23456, 'zxcvbdsf', '2020-08-26', '2020-08-28', 'dsdfasdf', 'Masiva', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (17, '2020-08-13', 132154, 'Prueba eliminacion y agregacion persona', '2020-08-18', '2020-08-19', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (18, '2020-08-13', 321354, 'Prueba 3 agregar y eliminar participante', '2020-08-26', '2020-08-26', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (19, '2020-08-13', 1235465, 'Prueba 4', '2020-08-28', '2020-08-28', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (20, '2020-08-13', 21545456, 'Prueba 6', '2020-08-28', '2020-08-28', 'sdlfjsdflksdj', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (21, '2020-08-13', 2313513, 'Prueba 7', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (22, '2020-08-13', 21354315, 'Prueba 9', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (23, '2020-08-13', 1351315, 'Prueba 11', '2020-08-21', '2020-08-21', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (24, '2020-08-13', 161515, 'Prueba 15', '2020-08-20', '2020-08-20', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (25, '2020-08-13', 3181135, 'Prueba eliminar participante 1', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (26, '2020-08-13', 1321456, 'Prueba eliminar participante 2', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (27, '2020-08-16', 215216654, 'Prueba domingo', '2020-08-26', '2020-08-27', 'Casa', 'Grupal', '2020-08-16', '2020-08-16');
INSERT INTO `solicitud` VALUES (28, '2020-08-16', 1235465, 'Prueba 2 Domingo', '2020-08-27', '2020-08-27', 'Casa', 'Grupal', '2020-08-16', '2020-08-16');
INSERT INTO `solicitud` VALUES (29, '2020-08-16', 125456, 'Prueba 4', '2020-08-20', '2020-08-20', 'casa', 'Grupal', '2020-08-16', '2020-08-16');
INSERT INTO `solicitud` VALUES (30, '2020-09-09', 150, 'Prueba 1 09-2020 ', '2020-09-10', '2020-09-10', 'Universidad de Talca', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (31, '2020-09-09', 126563, 'Prueba 2 09-2020', '2020-09-11', '2020-09-11', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (32, '2020-09-09', 1520, 'Prueba 4 09-2020', '2020-09-25', '2020-09-25', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (33, '2020-09-09', 0, 'aburrido', '2020-09-10', '2020-09-10', 'casa', 'Masiva', '2020-09-13', '2020-09-13');
INSERT INTO `solicitud` VALUES (34, '2020-09-09', 15225, 'aburrido 2', '2020-09-23', '2020-09-23', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (35, '2020-09-09', 456234, 'ldskjfhskdfhj', '2020-09-24', '2020-09-24', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (36, '2020-09-09', 126545, 'prueba 20siempre', '2020-09-24', '2020-09-24', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (37, '2020-09-09', 2456, 'miri', '2020-09-24', '2020-09-24', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (38, '2020-09-09', 12354, 'hLA', '2020-09-23', '2020-09-23', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (39, '2020-09-09', 13545, 'prubea jquery nuevo', '2020-09-24', '2020-09-24', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (40, '2020-09-09', 321546, 'jquery 2', '2020-09-17', '2020-09-17', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (41, '2020-09-09', 123456, 'jquery prueba 4', '2020-09-16', '2020-09-16', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (42, '2020-09-09', 1234654, 'prueba 5', '2020-09-23', '2020-09-23', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (43, '2020-09-09', 1236545, 'prueba 6', '2020-09-23', '2020-09-23', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (46, '2020-09-09', 32145, 'prueba 21', '2020-09-25', '2020-09-25', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (47, '2020-09-09', 21515321, 'prueba 22', '2020-09-18', '2020-09-18', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (48, '2020-09-09', 3215654, 'prueba casi definitiva', '2020-09-18', '2020-09-18', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (49, '2020-09-09', 321545, 'prueba casi definitiva 2', '2020-09-10', '2020-09-10', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (50, '2020-09-09', 321545, 'prueba casi casi 3', '2020-09-10', '2020-09-10', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (51, '2020-09-09', 321545, 'prueba casi casi 2', '2020-09-23', '2020-09-23', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (52, '2020-09-09', 321545, 'prueba casi definitiva', '2020-09-24', '2020-09-24', 'casa', 'Masiva', '2020-09-09', '2020-09-09');
INSERT INTO `solicitud` VALUES (53, '2020-09-09', 150000, 'Holi', '2020-11-26', '2020-11-26', 'Holi', 'Masiva', '2020-11-25', '2020-11-25');
INSERT INTO `solicitud` VALUES (54, '2020-12-22', 316543513, 'evento navidad', '2020-12-24', '2020-12-30', 'casa 2', 'Grupal', '2020-12-27', '2020-12-27');
INSERT INTO `solicitud` VALUES (57, '2021-01-13', 130000, 'cumpleaños', '2021-01-15', '2021-01-13', 'Mi casa', 'Masiva', '2021-01-13', '2021-01-13');
INSERT INTO `solicitud` VALUES (58, '2021-02-14', 132456, '2021 verano', '2021-02-17', '2021-02-17', 'mi casa', 'Grupal', '2021-02-14', '2021-02-14');

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
-- Records of usuario_director
-- ----------------------------
INSERT INTO `usuario_director` VALUES (1, 'rgarrido@utalca.cl', 'Ruth', 'Ruth Garrido', 'Femenino', 'Curicó', 'Ingeniería Civil en Computación', 'Directora de escuela', 'Habilitado', 2, 1, 0);
INSERT INTO `usuario_director` VALUES (2, 'jperez@utalca.cl', 'Juanita', 'Juanita Perez', 'Femenino', 'Curicó', 'DAAE', 'Directora del DAAE', 'Habilitado', 2, 2, 0);

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
-- Records of usuario_representante
-- ----------------------------
INSERT INTO `usuario_representante` VALUES (1, 'yosepulveda11@alumnos.utalca.cl', 'Yorch', 'Yorch Sepúlveda', '17824523-6', 'Masculino', 2011407070, 'Ingeniería Civil en Computación', 'Habilitado', 3, 1, 'Desabilitado');
INSERT INTO `usuario_representante` VALUES (2, 'dparedes09@alumnos.utalca.cl', 'Daniela', 'Daniela Paredes', '17820883-7', 'Femenino', 2009407826, 'Ingeniería Civil en Computación', 'Habilitado', 4, 1, 'Desabilitado');
INSERT INTO `usuario_representante` VALUES (3, 'mgonzales13@alumnos.utalca.cl', 'Maria', 'Maria Soledad Gonzalez', '18801120-9', 'Femenino', 2013437888, 'Ingeniería Civil en Obras Civiles', 'Habilitado', 3, 2, 'Habilitado');
INSERT INTO `usuario_representante` VALUES (4, 'jcarrasco@alumnos.utalca.cl', 'Jorge', 'Jorge Carrasco', '19552307-7', 'Masculino', 2016468073, 'Ingeniería Civil de Minas', 'Habilitado', 4, 2, 'Habilitado');

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
