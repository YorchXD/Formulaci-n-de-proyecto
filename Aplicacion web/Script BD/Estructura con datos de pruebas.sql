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

 Date: 29/08/2021 01:14:53
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for campus
-- ----------------------------
DROP TABLE IF EXISTS `campus`;
CREATE TABLE `campus`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of campus
-- ----------------------------
INSERT INTO `campus` VALUES (1, 'Curicó', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `campus` VALUES (2, 'Talca', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `campus` VALUES (3, 'Linares', 'HABILITADO', 'HABILITADO');
INSERT INTO `campus` VALUES (4, 'Colchagua', 'HABILITADO', 'HABILITADO');
INSERT INTO `campus` VALUES (5, 'Santiago', 'HABILITADO', 'HABILITADO');

-- ----------------------------
-- Table structure for categoria
-- ----------------------------
DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `estadoEliminacion` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of categoria
-- ----------------------------
INSERT INTO `categoria` VALUES (1, 'Alimentación', 'DESHABILITADO');
INSERT INTO `categoria` VALUES (2, 'Alojamiento', 'DESHABILITADO');
INSERT INTO `categoria` VALUES (3, 'Articulos de oficina', 'DESHABILITADO');
INSERT INTO `categoria` VALUES (4, 'Inscripción', 'DESHABILITADO');
INSERT INTO `categoria` VALUES (5, 'Pasajes', 'DESHABILITADO');
INSERT INTO `categoria` VALUES (10, 'Artículos de oficina', 'HABILITADO');

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
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of declaraciondegastos
-- ----------------------------
INSERT INTO `declaraciondegastos` VALUES (1, '2020-12-16', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (3, '2021-01-19', 345345, 0);
INSERT INTO `declaraciondegastos` VALUES (4, '2020-10-13', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (5, '2020-09-30', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (6, '2020-10-15', 0, 0);
INSERT INTO `declaraciondegastos` VALUES (11, '2021-03-10', 1352308, 1352308);
INSERT INTO `declaraciondegastos` VALUES (12, '2020-09-17', 24180, 22790);

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
) ENGINE = InnoDB AUTO_INCREMENT = 62 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of documento
-- ----------------------------
INSERT INTO `documento` VALUES (29, 'srtyj', 'sdfgs', '2020-12-25', 345345, 'sdfsfsfs', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\54\\DeclaracionGastos\\17824523-6\\1.pdf', 2, '17824523-6', 3, 0);
INSERT INTO `documento` VALUES (48, 'sñldkfj4yu40', 'El cura', '2020-08-28', 1390, 'Bebidas', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\-1\\1.pdf', 3, NULL, 12, 0);
INSERT INTO `documento` VALUES (49, 'dfhlkmed40954o', 'El cura', '2020-08-28', 720, 'Galletas', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\-1\\2.pdf', 3, NULL, 12, 1);
INSERT INTO `documento` VALUES (50, 'LKXCJÑLKXJ565432', 'Andimar', '2020-08-26', 4000, 'Pasajes', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\19043138-K\\1.pdf', 3, '19043138-K', 12, 1);
INSERT INTO `documento` VALUES (51, 'kdsñfk34567', 'Turbus', '2020-08-28', 5500, 'Pasajes', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\19043138-K\\2.pdf', 3, '19043138-K', 12, 1);
INSERT INTO `documento` VALUES (52, 'zmcvld', 'Restaurant', '2020-08-27', 1350, 'Comida', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\19043138-K\\3.pdf', 3, '19043138-K', 12, 1);
INSERT INTO `documento` VALUES (53, 'lkdfkjkl345678', 'Andimar', '2020-08-26', 4000, 'Pasajes', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\17824523-6\\1.pdf', 3, '17824523-6', 12, 1);
INSERT INTO `documento` VALUES (54, 'lkdjfkwk567', 'Turbus', '2020-08-28', 5500, 'Pasajes', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\17824523-6\\2.pdf', 3, '17824523-6', 12, 1);
INSERT INTO `documento` VALUES (55, 'dsfghu6', 'Restaurant', '2020-08-27', 1720, 'Comida', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\DeclaracionGastos\\17824523-6\\3.pdf', 3, '17824523-6', 12, 1);
INSERT INTO `documento` VALUES (56, 'ddzvfg', 'Yorch', '2021-02-18', 234332, 'SDFASDDFSAGFD', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\17820883-7\\1.pdf', 2, '17820883-7', 11, 1);
INSERT INTO `documento` VALUES (57, '74y4mdkgi', 'Daniela', '2021-02-17', 34254, 'asgafdgdf', 'Factura', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\17820883-7\\2.pdf', 1, '17820883-7', 11, 1);
INSERT INTO `documento` VALUES (58, 'adfsdfg67654rgh', 'Yorch', '2021-02-17', 43566, 'zxcvdgadf', 'Factura', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\17820883-7\\3.pdf', 5, '17820883-7', 11, 1);
INSERT INTO `documento` VALUES (59, 'adfggnbrrt456789plkj', 'Yorch', '2021-02-17', 35632, 'afgadfg', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\-1\\1.pdf', 2, NULL, 11, 1);
INSERT INTO `documento` VALUES (60, 'sfdshgjklk6rfgbnmm', 'Utalca', '2021-02-17', 254524, 'fadgdafg', 'Factura', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\-1\\2.pdf', 4, NULL, 11, 1);
INSERT INTO `documento` VALUES (61, 'adfghgj324246', 'Yorch', '2021-02-18', 750000, 'asdasd', 'Boleta', 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\DeclaracionGastos\\19043138-K\\1.pdf', 2, '19043138-K', 11, 1);

-- ----------------------------
-- Table structure for institucion
-- ----------------------------
DROP TABLE IF EXISTS `institucion`;
CREATE TABLE `institucion`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `abreviacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'HABILITADO',
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of institucion
-- ----------------------------
INSERT INTO `institucion` VALUES (1, 'Ingeniería Civil en Computación', 'ICC', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `institucion` VALUES (2, 'Ingeniería Civil de Minas', 'ICM', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `institucion` VALUES (3, 'Ingeniería Civil en Obras Civiles', 'ICOC', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `institucion` VALUES (4, 'Dirección de Apoyo a Actividades Estudiantiles', 'DAAE', 'HABILITADO', 'DESHABILITADO');

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
-- Table structure for oe_vicerector
-- ----------------------------
DROP TABLE IF EXISTS `oe_vicerector`;
CREATE TABLE `oe_vicerector`  (
  `refOE` int NOT NULL,
  `refUsuarioVicerector` int NOT NULL,
  INDEX `oe_vicerrector_ibfk_1`(`refOE`) USING BTREE,
  INDEX `oe_vicerrector_ibfk_2`(`refUsuarioVicerector`) USING BTREE,
  CONSTRAINT `oe_vicerector_ibfk_1` FOREIGN KEY (`refOE`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `oe_vicerector_ibfk_2` FOREIGN KEY (`refUsuarioVicerector`) REFERENCES `usuario_vicerector` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of oe_vicerector
-- ----------------------------
INSERT INTO `oe_vicerector` VALUES (2, 4);
INSERT INTO `oe_vicerector` VALUES (2, 6);
INSERT INTO `oe_vicerector` VALUES (4, 6);

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
  `refCampus` int NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'Habilitado',
  `refTipoOE` int NOT NULL,
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  `refInstitucion` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `organizacion_estudiantil_ibfk_1`(`refTipoOE`) USING BTREE,
  INDEX `organizacion_estudiantil_ibfk_3`(`refInstitucion`) USING BTREE,
  INDEX `organizacion_estudiantil_ibfk_2`(`refCampus`) USING BTREE,
  CONSTRAINT `organizacion_estudiantil_ibfk_1` FOREIGN KEY (`refTipoOE`) REFERENCES `tipooe` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `organizacion_estudiantil_ibfk_2` FOREIGN KEY (`refCampus`) REFERENCES `campus` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `organizacion_estudiantil_ibfk_3` FOREIGN KEY (`refInstitucion`) REFERENCES `institucion` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of organizacion_estudiantil
-- ----------------------------
INSERT INTO `organizacion_estudiantil` VALUES (1, 'CAAICC', 'caaicc2016@gmail.com', 1, 'Habilitado', 1, 'DESHABILITADO', 1);
INSERT INTO `organizacion_estudiantil` VALUES (2, 'FEDEUT', 'fedeutcuricó@gmail.com', 1, 'Habilitado', 2, 'DESHABILITADO', 4);
INSERT INTO `organizacion_estudiantil` VALUES (3, 'CAAICC', 'caaicctalca@gamil.com', 2, 'Habilitado', 1, 'HABILITADO', 1);
INSERT INTO `organizacion_estudiantil` VALUES (4, 'FEUTAL', 'feutaltalca@gmail.com', 2, 'Habilitado', 2, 'DESHABILITADO', 4);

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
  CONSTRAINT `parsol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `parsol_ibfk_2` FOREIGN KEY (`refParticipante`) REFERENCES `participante` (`run`) ON DELETE RESTRICT ON UPDATE RESTRICT
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
INSERT INTO `parsol` VALUES ('19043138-K', 15);
INSERT INTO `parsol` VALUES ('19043138-K', 20);
INSERT INTO `parsol` VALUES ('19043138-K', 22);
INSERT INTO `parsol` VALUES ('19043138-K', 23);
INSERT INTO `parsol` VALUES ('19043138-K', 24);
INSERT INTO `parsol` VALUES ('19043138-K', 26);
INSERT INTO `parsol` VALUES ('19043138-K', 58);

-- ----------------------------
-- Table structure for participante
-- ----------------------------
DROP TABLE IF EXISTS `participante`;
CREATE TABLE `participante`  (
  `nombre` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `run` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `estadoEdicion` int NOT NULL DEFAULT 1,
  PRIMARY KEY (`run`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of participante
-- ----------------------------
INSERT INTO `participante` VALUES ('Patricia Manríquez', '12296649-6', 1);
INSERT INTO `participante` VALUES ('Daniela Paredes', '17820883-7', 1);
INSERT INTO `participante` VALUES ('Yorch Sepúlveda', '17824523-6', 0);
INSERT INTO `participante` VALUES ('Gregory Sepúlveda', '19043138-K', 0);

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
  CONSTRAINT `procesofondo_ibfk_1` FOREIGN KEY (`refDeclaracionGastos`) REFERENCES `declaraciondegastos` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_2` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_3` FOREIGN KEY (`refResolucion`) REFERENCES `resolucion` (`id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_4` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_5` FOREIGN KEY (`refUsuarioRepresentante`) REFERENCES `usuario_representante` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibfk_6` FOREIGN KEY (`refUsuarioDirector`) REFERENCES `usuario_director` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `procesofondo_ibk_7` FOREIGN KEY (`refUsuarioVicerector`) REFERENCES `usuario_vicerector` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 69 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

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
INSERT INTO `procesofondo` VALUES (53, 53, 31, 1, 2, 1, 'Abierto', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (54, 54, 37, 3, 2, 1, 'Abierto', 2, 1, NULL);
INSERT INTO `procesofondo` VALUES (57, 57, NULL, NULL, 2, 1, 'Cerrado', 1, 1, NULL);
INSERT INTO `procesofondo` VALUES (60, 58, 45, 11, 4, 1, 'Abierto', 1, 1, NULL);

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
) ENGINE = InnoDB AUTO_INCREMENT = 47 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of resolucion
-- ----------------------------
INSERT INTO `resolucion` VALUES (31, 202012, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\53\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (37, 236420, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\54\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (38, 365, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\51\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (39, 2136, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\49\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (40, 325, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\46\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (45, 2056452, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2021\\58\\Resolucion\\Resolucion.pdf');
INSERT INTO `resolucion` VALUES (46, 32451321, 2020, 'D:\\Repositorios\\Formulación de proyecto\\Aplicacion web\\SimRend\\SimRend\\wwwroot\\Procesos\\CAAICC\\2020\\15\\Resolucion\\Resolucion.pdf');

-- ----------------------------
-- Table structure for rol
-- ----------------------------
DROP TABLE IF EXISTS `rol`;
CREATE TABLE `rol`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of rol
-- ----------------------------
INSERT INTO `rol` VALUES (1, 'Administrador');
INSERT INTO `rol` VALUES (2, 'Director(a)');
INSERT INTO `rol` VALUES (3, 'Presidente');
INSERT INTO `rol` VALUES (4, 'Secretario(a) de finanzas');
INSERT INTO `rol` VALUES (5, 'Vicerrector(a)');

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
INSERT INTO `solcat` VALUES (15, 3);
INSERT INTO `solcat` VALUES (16, 2);
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
INSERT INTO `solcat` VALUES (53, 2);
INSERT INTO `solcat` VALUES (54, 2);
INSERT INTO `solcat` VALUES (58, 4);
INSERT INTO `solcat` VALUES (58, 1);
INSERT INTO `solcat` VALUES (58, 2);
INSERT INTO `solcat` VALUES (58, 5);

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
) ENGINE = InnoDB AUTO_INCREMENT = 68 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of solicitud
-- ----------------------------
INSERT INTO `solicitud` VALUES (15, '2020-08-13', 23456, 'zxcvbdsf', '2020-08-26', '2020-08-28', 'dsdfasdf', 'Grupal', '2021-04-18', '2021-04-18');
INSERT INTO `solicitud` VALUES (16, '2020-08-13', 23456, 'zxcvbdsf', '2020-08-26', '2020-08-28', 'dsdfasdf', 'Masiva', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (18, '2020-08-13', 321354, 'Prueba 3 agregar y eliminar participante', '2020-08-26', '2020-08-26', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (19, '2020-08-13', 1235465, 'Prueba 4', '2020-08-28', '2020-08-28', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (20, '2020-08-13', 21545456, 'Prueba 6', '2020-08-28', '2020-08-28', 'sdlfjsdflksdj', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (21, '2020-08-13', 2313513, 'Prueba 7', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (22, '2020-08-13', 21354315, 'Prueba 9', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (23, '2020-08-13', 1351315, 'Prueba 11', '2020-08-21', '2020-08-21', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (24, '2020-08-13', 161515, 'Prueba 15', '2020-08-20', '2020-08-20', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (25, '2020-08-13', 3181135, 'Prueba eliminar participante 1', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2020-08-13', '2020-08-13');
INSERT INTO `solicitud` VALUES (26, '2020-08-13', 1321456, 'Prueba eliminar participante 2', '2020-08-27', '2020-08-27', 'Utalca', 'Grupal', '2021-07-25', '2021-07-25');
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
INSERT INTO `solicitud` VALUES (53, '2020-09-09', 150000, 'Holi', '2020-11-26', '2020-11-26', 'Holi', 'Masiva', '2020-11-25', '2020-11-25');
INSERT INTO `solicitud` VALUES (54, '2020-12-22', 316543513, 'evento navidad', '2020-12-24', '2020-12-30', 'casa 2', 'Grupal', '2020-12-27', '2020-12-27');
INSERT INTO `solicitud` VALUES (57, '2021-01-13', 130000, 'cumpleaños', '2021-01-15', '2021-01-13', 'Mi casa', 'Grupal', '2021-03-22', '2021-03-22');
INSERT INTO `solicitud` VALUES (58, '2021-02-14', 1324565, '2021 verano', '2021-02-17', '2021-02-18', 'mi casa', 'Grupal', '2021-04-09', '2021-04-09');

-- ----------------------------
-- Table structure for tipooe
-- ----------------------------
DROP TABLE IF EXISTS `tipooe`;
CREATE TABLE `tipooe`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombreExtendido` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of tipooe
-- ----------------------------
INSERT INTO `tipooe` VALUES (1, 'CAA', 'Centro de alumnos', 'HABILITADO', 'HABILITADO');
INSERT INTO `tipooe` VALUES (2, 'FEDERACIÓN', 'Federación de estudiantes', 'HABILITADO', 'DESHABILITADO');
INSERT INTO `tipooe` VALUES (3, 'GI', 'Grupo intermedio', 'HABILITADO', 'DESHABILITADO');

-- ----------------------------
-- Table structure for usuario_administrador
-- ----------------------------
DROP TABLE IF EXISTS `usuario_administrador`;
CREATE TABLE `usuario_administrador`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sexo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `clave` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  `refCampus` int NOT NULL,
  `refRol` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `email`(`email`) USING BTREE,
  INDEX `refCampus`(`refCampus`) USING BTREE,
  INDEX `refRol`(`refRol`) USING BTREE,
  CONSTRAINT `usuario_administrador_ibfk_1` FOREIGN KEY (`refCampus`) REFERENCES `campus` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `usuario_administrador_ibfk_2` FOREIGN KEY (`refRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of usuario_administrador
-- ----------------------------
INSERT INTO `usuario_administrador` VALUES (1, 'admin', 'Masculino', 'admin@utalca.cl', '12345', 'DESHABILITADO', 1, 1);

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
  `refInstitucion` int NOT NULL,
  `cargo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'Habilitado',
  `idRol` int NOT NULL,
  `idOrganizacionEstudiantil` int NULL DEFAULT NULL,
  `fonoAnexo` int NOT NULL DEFAULT 0,
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refRol_UD`(`idRol`) USING BTREE,
  INDEX `usuario_director_ibfk_1`(`idOrganizacionEstudiantil`) USING BTREE,
  INDEX `usuario_director_ibfk_2`(`refInstitucion`) USING BTREE,
  CONSTRAINT `usuario_director_ibfk_1` FOREIGN KEY (`idOrganizacionEstudiantil`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `usuario_director_ibfk_2` FOREIGN KEY (`refInstitucion`) REFERENCES `institucion` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `usuario_director_ibfk_3` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of usuario_director
-- ----------------------------
INSERT INTO `usuario_director` VALUES (1, 'rgarrido@utalca.cl', 'Ruth', 'Ruth Garrido', 'Femenino', 1, 'Directora de escuela', 'Deshabilitado', 2, 1, 0, 'DESHABILITADO');
INSERT INTO `usuario_director` VALUES (2, 'yosepulveda@utalca.cl', '12345', 'Yorch Sepúlveda', 'Masculino', 1, 'Director de escuela', 'Habilitado', 2, 1, 12345, 'HABILITADO');

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
  `refInstitucion` int NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'Habilitado',
  `idRol` int NOT NULL,
  `idOrganizacionEstudiantil` int NOT NULL,
  `crearProceso` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'Habilitado',
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `refRol_UR`(`idRol`) USING BTREE,
  INDEX `refOrganizacionEstudiantil_UR`(`idOrganizacionEstudiantil`) USING BTREE,
  INDEX `usuario_representante_ibfk_1`(`refInstitucion`) USING BTREE,
  CONSTRAINT `usuario_representante_ibfk_1` FOREIGN KEY (`refInstitucion`) REFERENCES `institucion` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `usuario_representante_ibfk_2` FOREIGN KEY (`idOrganizacionEstudiantil`) REFERENCES `organizacion_estudiantil` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `usuario_representante_ibfk_3` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of usuario_representante
-- ----------------------------
INSERT INTO `usuario_representante` VALUES (1, 'yosepulveda11@alumnos.utalca.cl', 'Yorch', 'Yorch Sepúlveda', '17824523-6', 'Masculino', 2011407070, 1, 'Habilitado', 3, 1, 'Deshabilitado', 'DESHABILITADO');
INSERT INTO `usuario_representante` VALUES (2, 'dparedes09@alumnos.utalca.cl', 'Daniela', 'Daniela Paredes', '17820883-7', 'Femenino', 2009407826, 1, 'Habilitado', 4, 1, 'Deshabilitado', 'DESHABILITADO');
INSERT INTO `usuario_representante` VALUES (7, 'mgonzales13@alumnos.utalca.cl', '123', 'Maria Soledad Gonzalez', '18801120-9', 'Femenino', 2013437888, 3, 'Habilitado', 3, 2, 'Habilitado', 'HABILITADO');

-- ----------------------------
-- Table structure for usuario_vicerector
-- ----------------------------
DROP TABLE IF EXISTS `usuario_vicerector`;
CREATE TABLE `usuario_vicerector`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `clave` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nombre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sexo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `refInstitucion` int NOT NULL,
  `cargo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estado` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'Habilitado',
  `fonoAnexo` int NOT NULL,
  `estadoEliminacion` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'HABILITADO',
  `refRol` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `usuario_vicerrector_ibfk_1`(`refInstitucion`) USING BTREE,
  INDEX `usuario_vicerector_ibfk_2`(`refRol`) USING BTREE,
  CONSTRAINT `usuario_vicerector_ibfk_1` FOREIGN KEY (`refInstitucion`) REFERENCES `institucion` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `usuario_vicerector_ibfk_2` FOREIGN KEY (`refRol`) REFERENCES `rol` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of usuario_vicerector
-- ----------------------------
INSERT INTO `usuario_vicerector` VALUES (4, 'pcaballero@utalca.cl', '12345', 'Paula Caballero', 'Femenino', 4, 'Vicerrectora de desarrollo estudiantil', 'Deshabilitado', 12345, 'HABILITADO', 5);
INSERT INTO `usuario_vicerector` VALUES (6, 'yosepulveda@utalca.cl', '12345', 'Yorch Sepúlveda Manríquez', 'Masculino', 4, 'Vicerector de actividades académicas', 'Habilitado', 12345, 'HABILITADO', 5);

-- ----------------------------
-- Procedure structure for Actualizar_Campus
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Campus`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Campus`(`in_id` INTEGER, `in_nombre` VARCHAR(256))
BEGIN
	UPDATE campus
	SET campus.nombre = in_nombre
	WHERE campus.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_Categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Categoria`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Categoria`(`in_id` INTEGER, `in_nombre` VARCHAR(256))
BEGIN
	UPDATE categoria
	SET categoria.nombre = in_nombre
	WHERE categoria.id = in_id;
END
;;
delimiter ;

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
	IF(in_nombreProceso='Solicitud') THEN
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
		
		IF(in_estado=6) THEN
			UPDATE procesofondo
			SET estadoFinal = "Cerrado"
			WHERE refDeclaracionGastos=in_refProceso;
		END IF;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_Institucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Institucion`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Institucion`(`in_id` INTEGER, `in_abreviacion` VARCHAR(256), `in_nombre` VARCHAR(256))
BEGIN
	UPDATE institucion
	SET institucion.abreviacion = in_abreviacion,
			institucion.nombre = in_nombre
	WHERE institucion.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_OE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_OE`;
delimiter ;;
CREATE PROCEDURE `Actualizar_OE`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_campus` INTEGER, `in_tipoOE` INTEGER, `in_id` INTEGER, `in_idInstitucion` INTEGER)
BEGIN
	UPDATE organizacion_estudiantil
	SET nombre = in_nombre,
			email = in_email,
			refCampus = in_campus,
			refTipoOE = in_tipoOE,
			refInstitucion = in_idInstitucion
	WHERE id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_Participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_Participante`;
delimiter ;;
CREATE PROCEDURE `Actualizar_Participante`(`in_nombre` VARCHAR(256), `in_run` VARCHAR(256), `in_idSolicitud` INTEGER, `in_fechaModificacion` DATE, OUT `out_validacion` INTEGER)
BEGIN
	UPDATE participante
	SET nombre = in_nombre
	WHERE participante.run = in_run;
	
	UPDATE solicitud
	SET fechaModificacion = in_fechaModificacion,
			fechaCreacionPDF = in_fechaModificacion
	WHERE id = in_idSolicitud;
	
	SET out_validacion = 1;
	
	
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
-- Procedure structure for Actualizar_TipoOE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_TipoOE`;
delimiter ;;
CREATE PROCEDURE `Actualizar_TipoOE`(`in_id` INTEGER, `in_nombre` VARCHAR(256), `in_nombreExtendido` VARCHAR(256))
BEGIN
	UPDATE tipooe
	SET tipooe.nombre = in_nombre,
			tipooe.nombreExtendido = in_nombreExtendido
	WHERE tipooe.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_UsuarioAdministrador
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_UsuarioAdministrador`;
delimiter ;;
CREATE PROCEDURE `Actualizar_UsuarioAdministrador`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_refCampus` INTEGER,`in_id` INTEGER)
BEGIN

	UPDATE usuario_administrador
	SET nombre = in_nombre,
			email = in_email,
			sexo = in_sexo,
			refCampus = in_refCampus
	WHERE id = in_id;

	IF !ISNULL(in_clave) THEN
		BEGIN
			UPDATE usuario_administrador
			SET clave = in_clave
			WHERE id = in_id;
		END;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_UsuarioDirector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_UsuarioDirector`;
delimiter ;;
CREATE PROCEDURE `Actualizar_UsuarioDirector`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_cargo` VARCHAR(256),`in_fonoAnexo` INTEGER, `in_id` INTEGER)
BEGIN

	UPDATE usuario_director
	SET nombre = in_nombre,
			email = in_email,
			sexo = in_sexo,
			cargo = in_cargo,
			fonoAnexo = in_fonoAnexo
	WHERE id = in_id;

	IF !ISNULL(in_clave) THEN
		BEGIN
			UPDATE usuario_director
			SET clave = in_clave
			WHERE id = in_id;
		END;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_UsuarioRepresentante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_UsuarioRepresentante`;
delimiter ;;
CREATE PROCEDURE `Actualizar_UsuarioRepresentante`(`in_id` INTEGER, `in_nombre` VARCHAR(256), `in_run` VARCHAR(256), `in_matricula` INTEGER,`in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_idInstitucion` INTEGER)
BEGIN

	UPDATE usuario_representante
	SET nombre = in_nombre,
			run = in_run,
			matricula = in_matricula,
			email = in_email,
			sexo = in_sexo
	WHERE id = in_id;

	IF !ISNULL(in_clave) THEN
		BEGIN
			UPDATE usuario_representante
			SET clave = in_clave
			WHERE id = in_id;
		END;
	END IF;
	
	SET @nombreTipoOE = (SELECT tipooe.nombre
	FROM usuario_representante
	JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
	JOIN tipooe ON tipooe.id = organizacion_estudiantil.refTipoOE
	WHERE usuario_representante.id = in_id);
	
	IF(@nombreTipoOE!='CAA') THEN
		BEGIN
			UPDATE usuario_representante
			SET refInstitucion = in_idInstitucion
			WHERE id = in_id;
		END;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Actualizar_UsuarioVicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Actualizar_UsuarioVicerector`;
delimiter ;;
CREATE PROCEDURE `Actualizar_UsuarioVicerector`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_cargo` VARCHAR(256),`in_fonoAnexo` INTEGER, `in_id` INTEGER)
BEGIN

	UPDATE usuario_vicerector
	SET nombre = in_nombre,
			email = in_email,
			sexo = in_sexo,
			cargo = in_cargo,
			fonoAnexo = in_fonoAnexo
	WHERE id = in_id;

	IF !ISNULL(in_clave) THEN
		BEGIN
			UPDATE usuario_vicerector
			SET clave = in_clave
			WHERE id = in_id;
		END;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Agregar_categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `Agregar_categoria`;
delimiter ;;
CREATE PROCEDURE `Agregar_categoria`(`in_refSolicitud` INTEGER, `in_refCategoria` INTEGER, `in_fechaModificacion` DATE)
BEGIN
	INSERT INTO SolCat(refSolicitud, refCategoria)
	VALUES (in_refSolicitud, in_refCategoria);
	
	UPDATE solicitud
	SET fechaModificacion = in_fechaModificacion,
			fechaCreacionPDF = in_fechaModificacion
	WHERE id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Agregar_Parsol
-- ----------------------------
DROP PROCEDURE IF EXISTS `Agregar_Parsol`;
delimiter ;;
CREATE PROCEDURE `Agregar_Parsol`(`in_refParticipante` VARCHAR(256), `in_refSolicitud` INTEGER, `in_fechaModificacion` DATE)
BEGIN
	INSERT INTO ParSol(refParticipante, refSolicitud)
	VALUES (in_refParticipante, in_refSolicitud);
	
	UPDATE solicitud
	SET fechaModificacion = in_fechaModificacion,
			fechaCreacionPDF = in_fechaModificacion
	where id = in_refSolicitud;
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
-- Procedure structure for CambiarEstado_Director
-- ----------------------------
DROP PROCEDURE IF EXISTS `CambiarEstado_Director`;
delimiter ;;
CREATE PROCEDURE `CambiarEstado_Director`(IN `in_id` INTEGER,IN `in_estado` VARCHAR(255))
BEGIN
	SET @idOE = (SELECT idOrganizacionEstudiantil FROM usuario_director WHERE id = in_id);
	
	UPDATE usuario_director
	SET estado = 'Deshabilitado'
	WHERE estado = 'Habilitado' AND idOrganizacionEstudiantil = @idOE;
	
	UPDATE usuario_director
	SET estado = in_estado
	WHERE id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CambiarEstado_Representante
-- ----------------------------
DROP PROCEDURE IF EXISTS `CambiarEstado_Representante`;
delimiter ;;
CREATE PROCEDURE `CambiarEstado_Representante`(IN `in_id` INTEGER,IN `in_estado` VARCHAR(255))
BEGIN
	/*Desabilita al representante al representante actual que tiene el mismo rol que el usuario que se quiere habilitar*/
	SET @idOE = (SELECT idOrganizacionEstudiantil FROM usuario_representante WHERE id = in_id);
	SET @idRol = (SELECT idRol FROM usuario_representante WHERE id = in_id);
	
	UPDATE usuario_representante
	SET estado = 'Deshabilitado'
	WHERE estado = 'Habilitado' AND idRol = @idRol AND idOrganizacionEstudiantil = @idOE;
	
	/*Se habilita al nuevo representante*/
	UPDATE usuario_representante
	SET estado = in_estado
	WHERE id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CambiarEstado_Vicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `CambiarEstado_Vicerector`;
delimiter ;;
CREATE PROCEDURE `CambiarEstado_Vicerector`(IN `in_id` INTEGER,IN `in_estado` VARCHAR(255))
BEGIN
	Update usuario_vicerector
	SET estado = 'Deshabilitado'
	WHERE estado = 'Habilitado';

	UPDATE usuario_vicerector
	SET estado = in_estado
	WHERE id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_Campus
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_Campus`;
delimiter ;;
CREATE PROCEDURE `Crear_Campus`(`in_nombre` VARCHAR(256))
BEGIN
	INSERT INTO campus(nombre)
	VALUES (in_nombre);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_Categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_Categoria`;
delimiter ;;
CREATE PROCEDURE `Crear_Categoria`(`in_nombre` VARCHAR(256))
BEGIN
	INSERT INTO categoria(nombre)
	VALUES (in_nombre);
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
-- Procedure structure for Crear_Institucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_Institucion`;
delimiter ;;
CREATE PROCEDURE `Crear_Institucion`(`in_abreviacion` VARCHAR(255), `in_nombre` VARCHAR(255))
BEGIN

	INSERT INTO institucion(abreviacion, nombre)
	VALUES (in_abreviacion ,in_nombre);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_OE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_OE`;
delimiter ;;
CREATE PROCEDURE `Crear_OE`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_campus` INTEGER, `in_tipoOE` INTEGER, `in_idInstitucion` INTEGER)
BEGIN

	INSERT INTO organizacion_estudiantil(nombre, email, refCampus, refTipoOE, refInstitucion)
	VALUES (in_nombre ,in_email, in_campus, in_tipoOE, in_idInstitucion);
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

	/*SET @idDirector = (select usuario_director.id
												from usuario_representante
												join organizacion_estudiantil on organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
												join usuario_director on usuario_director.idOrganizacionEstudiantil = organizacion_estudiantil.id and usuario_director.estado='Habilitado'
												where usuario_representante.id = in_refResponsable
												ORDER BY usuario_director.id DESC
												limit 1);
												
	INSERT INTO procesoFondo(refOrganizacion, refSolicitud, estado, refUsuarioRepresentante, refUsuarioDirector)
	VALUES (in_refOrganizacion, in_refSolicitud, in_estado, in_refResponsable, @idDirector);
	SET out_id = LAST_INSERT_ID();*/
	
	
	SET @tipoOE = (SELECT tipooe.nombre
								FROM usuario_representante
								JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
								JOIN tipooe ON tipooe.id = organizacion_estudiantil.refTipoOE
								WHERE usuario_representante.id = @refRepresentante);


	IF @tipoOE = 'CAA' THEN
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
		
	ELSE
		SET @idVicerector = (	select usuario_vicerector.id
													from usuario_representante
													join oe_vicerector ON oe_vicerector.refOE = usuario_representante.idOrganizacionEstudiantil
													join usuario_vicerector on usuario_vicerector.id = oe_vicerector.refUsuarioVicerector and usuario_vicerector.estado='Habilitado'
													where usuario_representante.id = in_refResponsable
													ORDER BY usuario_vicerector.id DESC
													limit 1);
	
		
		INSERT INTO procesoFondo(refOrganizacion, refSolicitud, estado, refUsuarioRepresentante, refUsuarioVicerector)
		VALUES (in_refOrganizacion, in_refSolicitud, in_estado, in_refResponsable, @idVicerector);
		SET out_id = LAST_INSERT_ID();
		
	END IF;
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
-- Procedure structure for Crear_TipoOE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_TipoOE`;
delimiter ;;
CREATE PROCEDURE `Crear_TipoOE`(`in_nombre` VARCHAR(255), `in_nombreExtendido` VARCHAR(255))
BEGIN

	INSERT INTO tipooe(nombre, nombreExtendido)
	VALUES (in_nombre ,in_nombreExtendido);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_UsuarioAdministrador
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_UsuarioAdministrador`;
delimiter ;;
CREATE PROCEDURE `Crear_UsuarioAdministrador`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_campus` INTEGER)
BEGIN

	SET @idRol = (SELECT id FROM rol WHERE nombre = 'Administrador');

	INSERT INTO usuario_administrador(nombre, email, clave, sexo, refCampus, refRol)
	VALUES (in_nombre ,in_email, in_clave, in_sexo, in_campus, @idRol);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_UsuarioDirector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_UsuarioDirector`;
delimiter ;;
CREATE PROCEDURE `Crear_UsuarioDirector`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_cargo` VARCHAR(256),`in_fonoAnexo` INTEGER, `in_idOE` INTEGER)
BEGIN

	/*Se busca a un usuario director que se encuentre con estado habilitado y se deshabilita*/
	UPDATE usuario_director
	SET estado = 'Deshabilitado'
	WHERE idOrganizacionEstudiantil = in_idOE AND estado = 'Habilitado';

	SET @idInstitucion = (SELECT refInstitucion FROM organizacion_estudiantil WHERE id = in_idOE);
	SET @idRol = (SELECT id FROM rol WHERE nombre = 'Director(a)');

	INSERT INTO usuario_director(nombre, email, clave, sexo, refInstitucion, cargo, idRol, idOrganizacionEstudiantil, fonoAnexo)
	VALUES (in_nombre ,in_email, in_clave, in_sexo, @idInstitucion, in_cargo, @idRol, in_idOE, in_fonoAnexo);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_UsuarioRepresentante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_UsuarioRepresentante`;
delimiter ;;
CREATE PROCEDURE `Crear_UsuarioRepresentante`(`in_nombre` VARCHAR(256), `in_run` VARCHAR(256), `in_matricula` INTEGER,`in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_idRol` INTEGER, `in_idOE` INTEGER, `in_idInstitucion` INTEGER)
BEGIN

	/*Se busca a un usuario director que se encuentre con estado habilitado y se deshabilita*/
	UPDATE usuario_representante
	SET estado = 'Deshabilitado'
	WHERE idOrganizacionEstudiantil = in_idOE AND estado = 'Habilitado' AND idRol = in_idRol;

	INSERT INTO usuario_representante(nombre, run, matricula, email, clave, sexo, refInstitucion, idRol, idOrganizacionEstudiantil)
	VALUES (in_nombre, in_run, in_matricula ,in_email, in_clave, in_sexo, in_idInstitucion, in_idRol, in_idOE);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Crear_UsuarioVicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Crear_UsuarioVicerector`;
delimiter ;;
CREATE PROCEDURE `Crear_UsuarioVicerector`(`in_nombre` VARCHAR(256), `in_email` VARCHAR(256), `in_clave` VARCHAR(256), `in_sexo` VARCHAR(256), `in_cargo` VARCHAR(256),`in_fonoAnexo` INTEGER)
BEGIN

	/*Se busca a un usuario vicerector que se encuentre con estado habilitado y se deshabilita*/
	UPDATE usuario_vicerector
	SET estado = 'Deshabilitado'
	WHERE estado = 'Habilitado';

	SET @idInstitucion = (SELECT id FROM institucion WHERE abreviacion = 'DAAE');
	SET @idRol = (SELECT id FROM rol WHERE nombre = 'Vicerrector(a)');

	INSERT INTO usuario_vicerector(nombre, email, clave, sexo, refInstitucion, cargo, refRol, fonoAnexo)
	VALUES (in_nombre ,in_email, in_clave, in_sexo, @idInstitucion, in_cargo, @idRol, in_fonoAnexo);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Administrador
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Administrador`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Administrador`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM usuario_administrador
	WHERE usuario_administrador.id = in_id AND usuario_administrador.estadoEliminacion='HABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Campus
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Campus`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Campus`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM campus
	WHERE campus.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Categoria
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Categoria`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Categoria`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM Categoria
	WHERE categoria.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_categoria_seleccionada
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_categoria_seleccionada`;
delimiter ;;
CREATE PROCEDURE `Eliminar_categoria_seleccionada`(`in_refCategoria` INTEGER, `in_refSolicitud` INTEGER, `in_fechaModificacion` DATE)
BEGIN
	DELETE 
	FROM SolCat
	WHERE refCategoria=in_refCategoria AND refSolicitud=in_refSolicitud;
	
	UPDATE solicitud
	SET fechaModificacion = in_fechaModificacion,
			fechaCreacionPDF = in_fechaModificacion
	WHERE id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Director
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Director`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Director`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM usuario_director
	WHERE usuario_director.id = in_id AND usuario_director.estadoEliminacion='HABILITADO';
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
-- Procedure structure for Eliminar_documentos_declaracion_gastos
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_documentos_declaracion_gastos`;
delimiter ;;
CREATE PROCEDURE `Eliminar_documentos_declaracion_gastos`(`in_idDeclaracionGastos` INTEGER, OUT `out_validacion` INTEGER)
BEGIN
	DELETE FROM documento
	WHERE refDeclaracionDeGastos = in_idDeclaracionGastos;
	
	SET @cantDocumentos = (select COUNT(*) FROM documento  WHERE refDeclaracionDeGastos = in_idDeclaracionGastos);
	IF @cantDocumentos = 0 THEN
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -1;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_documentos_participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_documentos_participante`;
delimiter ;;
CREATE PROCEDURE `Eliminar_documentos_participante`(`in_idDeclaracionGastos` INTEGER, `in_idParticipante` VARCHAR(256), OUT `out_validacion` INTEGER)
BEGIN
	IF in_idParticipante IS NULL THEN
		DELETE FROM documento
		WHERE refDeclaracionDeGastos = in_idDeclaracionGastos and refParticipante IS NULL;
	ELSE
		DELETE FROM documento
		WHERE refDeclaracionDeGastos = in_idDeclaracionGastos and refParticipante=in_idParticipante;
	END IF;
	
	
	SET @cantDocumentos = (select COUNT(*) FROM documento  WHERE refDeclaracionDeGastos = in_idDeclaracionGastos AND refParticipante=in_idParticipante);
	IF @cantDocumentos = 0 THEN
		SET out_validacion = 1;
	ELSE
		SET out_validacion = -1;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Institucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Institucion`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Institucion`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM institucion
	WHERE institucion.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_OE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_OE`;
delimiter ;;
CREATE PROCEDURE `Eliminar_OE`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM organizacion_estudiantil
	WHERE organizacion_estudiantil.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Participante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Participante`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Participante`(`in_refParticipante` VARCHAR(256), `in_refSolicitud` INTEGER, `in_fechaModificacion` DATE)
BEGIN
	DELETE 
	FROM ParSol
	WHERE refParticipante=in_refParticipante AND refSolicitud=in_refSolicitud;
	
	UPDATE solicitud
	SET fechaModificacion = in_fechaModificacion,
			fechaCreacionPDF = in_fechaModificacion
	WHERE id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Representante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Representante`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Representante`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM usuario_representante
	WHERE usuario_representante.id = in_id AND usuario_representanteestadoEliminacion='HABILITADO';
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
	

	SET @idRepresentante = (SELECT procesofondo.refUsuarioRepresentante
	FROM procesofondo
	WHERE procesofondo.refSolicitud = in_id);

	DELETE FROM procesofondo
	WHERE procesofondo.refSolicitud = in_id;
	
	SET @cantProcesosAbiertos = (SELECT COUNT(*)
	FROM procesofondo
	WHERE procesofondo.refUsuarioRepresentante = @idRepresentante AND procesofondo.estadoFinal = 'Abierto');
	
	IF @cantProcesosAbiertos = 0 THEN
		UPDATE usuario_representante
		SET crearProceso = 'Habilitado'
		WHERE id = @idRepresentante;
	END IF;

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
-- Procedure structure for Eliminar_TipoOE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_TipoOE`;
delimiter ;;
CREATE PROCEDURE `Eliminar_TipoOE`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM tipooe
	WHERE tipooe.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Eliminar_Vicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Eliminar_Vicerector`;
delimiter ;;
CREATE PROCEDURE `Eliminar_Vicerector`(`in_id` INTEGER)
BEGIN
	DELETE 
	FROM usuario_vicerector
	WHERE usuario_vicerector.id = in_id AND usuario_vicerector.estadoEliminacion='HABILITADO' AND usuario_vicerector.estado = 'Deshabilitado';
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
     SELECT usuario_director.*,rol.nombre AS 'nombreRol'
	   FROM usuario_director
		 JOIN rol on rol.id = usuario_director.idRol
	   WHERE usuario_director.email = in_email AND usuario_director.clave = in_clave AND usuario_director.estado = 'Habilitado';
	ELSEIF in_tipoUsuario = 'Vicerector' THEN
		 SELECT usuario_vicerector.id, usuario_vicerector.nombre, usuario_vicerector.email, usuario_vicerector.clave, usuario_vicerector.refRol as "idRol",rol.nombre AS 'nombreRol'
	   FROM usuario_vicerector
		 JOIN rol on rol.id = usuario_vicerector.refRol
	   WHERE usuario_vicerector.email = in_email AND usuario_vicerector.clave = in_clave AND usuario_vicerector.estado = 'Habilitado';
	ELSEIF in_tipoUsuario = 'Administrador' THEN
		 SELECT usuario_administrador.id, usuario_administrador.nombre, usuario_administrador.email, usuario_administrador.clave, usuario_administrador.refRol as "idRol",rol.nombre AS 'nombreRol'
	   FROM usuario_administrador
		 JOIN rol on rol.id = usuario_administrador.refRol
	   WHERE usuario_administrador.email = in_email AND usuario_administrador.clave = in_clave;
  ELSE
	   SELECT usuario_representante.*, rol.nombre AS 'nombreRol'
	   FROM usuario_representante
		 JOIN rol on rol.id = usuario_representante.idRol
	   WHERE usuario_representante.email = in_email AND usuario_representante.clave = in_clave AND usuario_representante.estado = 'Habilitado';
END IF;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Anios_Procesos_Organizacion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Anios_Procesos_Organizacion`;
delimiter ;;
CREATE PROCEDURE `Leer_Anios_Procesos_Organizacion`(`in_idOrganizacion` INTEGER)
BEGIN
	SELECT DISTINCT YEAR(fechaCreacion) as 'anios'
	FROM solicitud
	JOIN procesofondo ON procesofondo.refSolicitud = solicitud.id
	WHERE procesofondo.refOrganizacion = in_idOrganizacion
	ORDER BY YEAR(fechaCreacion) DESC;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Campus
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Campus`;
delimiter ;;
CREATE PROCEDURE `Leer_Campus`()
BEGIN
	SELECT *
	FROM campus;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_CampusRepresentantes
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_CampusRepresentantes`;
delimiter ;;
CREATE PROCEDURE `Leer_CampusRepresentantes`()
BEGIN
	SELECT DISTINCT(campus.id), campus.nombre
	FROM campus
	JOIN organizacion_estudiantil on organizacion_estudiantil.refCampus = campus.id
	JOIN usuario_representante on usuario_representante.idOrganizacionEstudiantil = organizacion_estudiantil.id;
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
	SELECT usuario_director.id, usuario_director.nombre, sexo, usuario_director.email, usuario_director.refInstitucion, institucion.nombre AS 'nombreInstitucion', institucion.abreviacion AS 'abreviacionInstitucion', cargo, usuario_director.estado, idOrganizacionEstudiantil, organizacion_estudiantil.nombre AS 'nombreOE', fonoAnexo, usuario_director.estadoEliminacion, campus.id AS 'idCampus', campus.nombre AS 'nombreCampus',
	usuario_director.idRol, rol.nombre AS 'nombreRol'
	FROM usuario_director
	JOIN procesofondo ON procesofondo.refUsuarioDirector = usuario_director.id
	JOIN institucion ON institucion.id = refInstitucion
	JOIN organizacion_estudiantil ON organizacion_estudiantil.id = idOrganizacionEstudiantil
	JOIN campus ON campus.id = organizacion_estudiantil.refCampus
	JOIN rol ON rol.id = usuario_director.idRol
	WHERE procesofondo.refSolicitud = in_refSolicitud;





	/*SELECT usuario_director.nombre, usuario_director.cargo, usuario_director.sexo, institucion.nombre as 'nombreInstitucion', usuario_director.fonoAnexo
	FROM usuario_director
	JOIN procesofondo ON procesofondo.refUsuarioDirector = usuario_director.id
	JOIN institucion ON institucion.id = usuario_director.refInstitucion
	JOIN solicitud ON solicitud.id = procesofondo.refSolicitud AND solicitud.id = in_refSolicitud;*/
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
-- Procedure structure for Leer_estado_proceso
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_estado_proceso`;
delimiter ;;
CREATE PROCEDURE `Leer_estado_proceso`(`in_idProceso` INTEGER)
BEGIN
	SELECT estado, estadoFinal
	FROM procesofondo
	WHERE idFondo = in_idProceso;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Institucion
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Institucion`;
delimiter ;;
CREATE PROCEDURE `Leer_Institucion`()
BEGIN
	SELECT *
	FROM institucion;
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
-- Procedure structure for Leer_OE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_OE`;
delimiter ;;
CREATE PROCEDURE `Leer_OE`(in_id INTEGER)
BEGIN
	SELECT *
	FROM organizacion_estudiantil
	WHERE organizacion_estudiantil.id = in_id;
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
	SELECT organizacion_estudiantil.nombre, tipooe.nombre as 'tipo'
	FROM organizacion_estudiantil
	JOIN procesofondo on procesofondo.refOrganizacion=organizacion_estudiantil.id
	JOIN solicitud on solicitud.id = procesofondo.refSolicitud
	JOIN tipooe on tipooe.id = organizacion_estudiantil.refTipoOE
	WHERE solicitud.id = in_refSolicitud;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Organizaciones
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Organizaciones`;
delimiter ;;
CREATE PROCEDURE `Leer_Organizaciones`()
BEGIN
	SELECT organizacion_estudiantil.*, campus.nombre as 'campus', tipooe.nombre as 'tipo', institucion.abreviacion, institucion.nombre as 'nombreInstitucion'
	FROM organizacion_estudiantil
	JOIN tipooe on tipooe.id = organizacion_estudiantil.refTipoOE
	JOIN campus on campus.id = organizacion_estudiantil.refCampus
	JOIN institucion on institucion.id = organizacion_estudiantil.refInstitucion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_OrganizacionesCampus
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_OrganizacionesCampus`;
delimiter ;;
CREATE PROCEDURE `Leer_OrganizacionesCampus`(in_idCampus INTEGER)
BEGIN
	SELECT organizacion_estudiantil.*, campus.nombre as 'campus', tipooe.nombre as 'tipo', institucion.abreviacion, institucion.nombre as 'nombreInstitucion'
	FROM organizacion_estudiantil
	JOIN tipooe on tipooe.id = organizacion_estudiantil.refTipoOE
	JOIN campus on campus.id = organizacion_estudiantil.refCampus
	JOIN institucion on institucion.id = organizacion_estudiantil.refInstitucion
	WHERE organizacion_estudiantil.refCampus = in_idCampus;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Organizaciones_Vicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Organizaciones_Vicerector`;
delimiter ;;
CREATE PROCEDURE `Leer_Organizaciones_Vicerector`()
BEGIN
	SELECT organizacion_estudiantil.*, campus.nombre AS 'campus', tipooe.nombre AS 'tipo', institucion.abreviacion, institucion.nombre AS 'nombreInstitucion'
	FROM organizacion_estudiantil
	JOIN tipooe ON tipooe.id = organizacion_estudiantil.refTipoOE AND tipooe.nombre!='CAA'
	JOIN campus ON campus.id = organizacion_estudiantil.refCampus
	JOIN institucion ON institucion.id = organizacion_estudiantil.refInstitucion;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_Organizacion_Usuario
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_Organizacion_Usuario`;
delimiter ;;
CREATE PROCEDURE `Leer_Organizacion_Usuario`(IN `in_refUsuario` INTEGER, in_tipoUsuario VARCHAR(256))
BEGIN
	IF in_tipoUsuario='Director' THEN
     SELECT usuario_director.idOrganizacionEstudiantil, organizacion_estudiantil.nombre AS 'nombreOrganizacion'
	   FROM usuario_director
		 JOIN organizacion_estudiantil on idOrganizacionEstudiantil = organizacion_estudiantil.id
	   WHERE usuario_director.id=in_refUsuario;
	ELSEIF in_tipoUsuario='Vicerector' THEN
		SELECT organizacion_estudiantil.id AS 'idOrganizacionEstudiantil', organizacion_estudiantil.nombre AS 'nombreOrganizacion'
		FROM organizacion_estudiantil
		JOIN oe_vicerector ON oe_vicerector.refOE = organizacion_estudiantil.id
		JOIN usuario_vicerector ON usuario_vicerector.id = oe_vicerector.refUsuarioVicerector
		WHERE usuario_vicerector.id = in_refUsuario;
  ELSE
	   SELECT usuario_representante.idOrganizacionEstudiantil, organizacion_estudiantil.nombre AS 'nombreOrganizacion'
	   FROM usuario_representante
		 JOIN organizacion_estudiantil on idOrganizacionEstudiantil = organizacion_estudiantil.id
	   WHERE usuario_representante.id=in_refUsuario;
END IF;

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
CREATE PROCEDURE `Leer_Procesos_Organizacion`(`in_idOrganizacion` INTEGER, `in_anio` INTEGER, `in_tipoProceso` TEXT)
BEGIN
	IF in_tipoProceso='Todos' THEN
		SELECT idFondo, refSolicitud, IFNULL(refResolucion,-1) as 'refResolucion', IFNULL(refDeclaracionGastos,-1) as 'refDeclaracionGastos', estado, refOrganizacion, estadoFinal, refUsuarioRepresentante as 'refResponsable', refUsuarioDirector, Solicitud.*
		FROM procesoFondo
		JOIN solicitud on solicitud.id = procesofondo.refSolicitud AND YEAR(solicitud.fechaCreacion) = in_anio
		WHERE procesoFondo.refOrganizacion=in_idOrganizacion;
	
	ELSEIF in_tipoProceso = 'Abiertos' THEN
		SELECT idFondo, refSolicitud, IFNULL(refResolucion,-1) as 'refResolucion', IFNULL(refDeclaracionGastos,-1) as 'refDeclaracionGastos', estado, refOrganizacion, estadoFinal, refUsuarioRepresentante as 'refResponsable', refUsuarioDirector, Solicitud.*
		FROM procesoFondo
		JOIN solicitud on solicitud.id = procesofondo.refSolicitud AND YEAR(solicitud.fechaCreacion) = in_anio
		WHERE procesoFondo.refOrganizacion=in_idOrganizacion AND procesofondo.estadoFinal = 'Abierto';
	
	ELSE
		SELECT idFondo, refSolicitud, IFNULL(refResolucion,-1) as 'refResolucion', IFNULL(refDeclaracionGastos,-1) as 'refDeclaracionGastos', estado, refOrganizacion, estadoFinal, refUsuarioRepresentante as 'refResponsable', refUsuarioDirector, Solicitud.*
		FROM procesoFondo
		JOIN solicitud on solicitud.id = procesofondo.refSolicitud AND YEAR(solicitud.fechaCreacion) = in_anio
		WHERE procesoFondo.refOrganizacion=in_idOrganizacion AND procesofondo.estadoFinal = 'Cerrado';
	END IF;





	
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
-- Procedure structure for Leer_RolesRepresentantes
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_RolesRepresentantes`;
delimiter ;;
CREATE PROCEDURE `Leer_RolesRepresentantes`()
BEGIN
	SELECT *
	FROM rol
	WHERE ROL.nombre<>'Administrador' AND  rol.nombre<>'Director(a)';
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
-- Procedure structure for Leer_TipoOE
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_TipoOE`;
delimiter ;;
CREATE PROCEDURE `Leer_TipoOE`()
BEGIN
	SELECT *
	FROM tipooe;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuarioAdministrador
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuarioAdministrador`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuarioAdministrador`(`in_id` INTEGER)
BEGIN
	SELECT usuario_administrador.id, usuario_administrador.nombre, usuario_administrador.sexo, usuario_administrador.email, usuario_administrador.estadoEliminacion, usuario_administrador.refCampus, campus.nombre AS 'nombreCampus', usuario_administrador.refRol, rol.nombre AS 'nombreRol'
	FROM usuario_administrador
	JOIN campus ON campus.id = usuario_administrador.refCampus
	JOIN rol ON rol.id = usuario_administrador.refRol
	WHERE usuario_administrador.id = in_id;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuarioDirector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuarioDirector`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuarioDirector`(`in_id` INTEGER)
BEGIN
	SELECT usuario_director.id, usuario_director.nombre, sexo, usuario_director.email, usuario_director.refInstitucion, institucion.nombre AS 'nombreInstitucion', institucion.abreviacion AS 'abreviacionInstitucion', cargo, usuario_director.estado, idOrganizacionEstudiantil, organizacion_estudiantil.nombre AS 'nombreOE', fonoAnexo, usuario_director.estadoEliminacion, campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', usuario_director.idRol, rol.nombre AS 'nombreRol'
	FROM usuario_director
	JOIN institucion ON institucion.id = refInstitucion
	JOIN organizacion_estudiantil ON organizacion_estudiantil.id = idOrganizacionEstudiantil
	JOIN campus ON campus.id = organizacion_estudiantil.refCampus
	JOIN rol ON rol.id = usuario_director.idRol
	WHERE usuario_director.id = in_id;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuarioRepresentante
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuarioRepresentante`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuarioRepresentante`(`in_idRepresentante` INTEGER)
BEGIN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE usuario_representante.id = in_idRepresentante;

	/*SELECT usuario_representante.id, usuario_representante.nombre, run, rol.nombre as "cargo", institucion.nombre as 'carrera', matricula, email
	FROM usuario_representante
	JOIN rol  on rol.id = usuario_representante.idRol
	JOIN institucion on institucion.id = usuario_representante.refInstitucion
	WHERE usuario_representante.id = in_refResponsable;*/
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuariosAdministradores
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuariosAdministradores`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuariosAdministradores`()
BEGIN
	SELECT usuario_administrador.id, usuario_administrador.nombre, usuario_administrador.sexo,usuario_administrador.email, usuario_administrador.estadoEliminacion, usuario_administrador.refCampus, campus.nombre AS 'nombreCampus', usuario_administrador.refRol, rol.nombre AS 'nombreRol'
	FROM usuario_administrador
	JOIN campus ON campus.id = usuario_administrador.refCampus
	JOIN rol ON rol.id = usuario_administrador.refRol;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuariosDirectores
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuariosDirectores`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuariosDirectores`()
BEGIN
	SELECT usuario_director.id, usuario_director.nombre, sexo, usuario_director.email, usuario_director.refInstitucion, institucion.nombre AS 'nombreInstitucion', institucion.abreviacion AS 'abreviacionInstitucion', cargo, usuario_director.estado, idOrganizacionEstudiantil, organizacion_estudiantil.nombre AS 'nombreOE', fonoAnexo, usuario_director.estadoEliminacion, campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', usuario_director.idRol, rol.nombre AS 'nombreRol'
	FROM usuario_director
	JOIN institucion ON institucion.id = refInstitucion
	JOIN organizacion_estudiantil ON organizacion_estudiantil.id = idOrganizacionEstudiantil
	JOIN campus ON campus.id = organizacion_estudiantil.refCampus
	JOIN rol ON rol.id = usuario_director.idRol;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuariosRepresentantes
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuariosRepresentantes`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuariosRepresentantes`(`in_idCampus` INTEGER, `in_idOE` INTEGER, `in_idRol` INTEGER)
BEGIN
		
	IF in_idOE = 0 && in_idCampus = 0 && in_idRol = 0 THEN 
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol;
	
	ELSEIF in_idOE>0 && in_idCampus=0 && in_idRol=0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE organizacion_estudiantil.id = in_idOE;
	
	ELSEIF in_idOE=0 && in_idCampus>0 && in_idRol=0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE campus.id = in_idCampus;
	
	ELSEIF in_idOE=0 && in_idCampus=0 && in_idRol>0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE rol.id = in_idRol;
	
	ELSEIF in_idOE>0 && in_idCampus>0 && in_idRol=0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE organizacion_estudiantil.id = in_idOE AND campus.id = in_idCampus;
	
	ELSEIF in_idOE>0 && in_idCampus=0 && in_idRol>0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE organizacion_estudiantil.id = in_idOE AND rol.id = in_idRol;
	
	ELSEIF in_idOE=0 && in_idCampus>0 && in_idRol>0 THEN
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE campus.id = in_idCampus AND rol.id = in_idRol;
		 
	ELSE
		SELECT usuario_representante.*, institucion.nombre as 'nombreInstitucion', institucion.abreviacion  AS 'abreviacionInstitucion', organizacion_estudiantil.nombre AS 'nombreOE', rol.nombre AS 'nombreRol', campus.id AS 'idCampus', campus.nombre AS 'nombreCampus', organizacion_estudiantil.refInstitucion as 'idInstitucionOE', institucionOE.nombre AS 'nombreInstitucionOE', institucionOE.abreviacion as 'abreviacionInstitucionOE'
		FROM usuario_representante
		JOIN institucion ON institucion.id = usuario_representante.refInstitucion
		JOIN organizacion_estudiantil ON organizacion_estudiantil.id = usuario_representante.idOrganizacionEstudiantil
		JOIN institucion AS institucionOE ON institucionOE.id = organizacion_estudiantil.refInstitucion
		JOIN campus ON campus.id = organizacion_estudiantil.refCampus
		JOIN rol ON rol.id = usuario_representante.idRol
		WHERE organizacion_estudiantil.id = in_idOE AND campus.id = in_idCampus AND rol.id = in_idRol;
	END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuariosVicerectores
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuariosVicerectores`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuariosVicerectores`()
BEGIN
	SELECT usuario_vicerector.id, usuario_vicerector.nombre, sexo, usuario_vicerector.email, usuario_vicerector.refInstitucion, institucion.nombre AS 'nombreInstitucion', institucion.abreviacion AS 'abreviacionInstitucion', cargo, usuario_vicerector.estado, usuario_vicerector.estadoEliminacion, usuario_vicerector.refRol AS 'idRol', rol.nombre AS 'nombreRol', usuario_vicerector.fonoAnexo
	FROM usuario_vicerector
	JOIN institucion ON institucion.id = usuario_vicerector.refInstitucion
	JOIN rol ON rol.id = usuario_vicerector.refRol;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for Leer_UsuarioVicerector
-- ----------------------------
DROP PROCEDURE IF EXISTS `Leer_UsuarioVicerector`;
delimiter ;;
CREATE PROCEDURE `Leer_UsuarioVicerector`(`in_id` INTEGER)
BEGIN
	SELECT usuario_vicerector.id, usuario_vicerector.nombre, sexo, usuario_vicerector.email, usuario_vicerector.refInstitucion, institucion.nombre AS 'nombreInstitucion', institucion.abreviacion AS 'abreviacionInstitucion', cargo, usuario_vicerector.estado, fonoAnexo, usuario_vicerector.estadoEliminacion, usuario_vicerector.refRol, rol.nombre AS 'nombreRol'
	FROM usuario_vicerector
	JOIN institucion ON institucion.id = refInstitucion
	JOIN rol ON rol.id = usuario_vicerector.refRol
	WHERE usuario_vicerector.id = in_id;
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
	
	IF OLD.estado = 1 THEN
		UPDATE declaraciondegastos
		SET declaraciondegastos.totalRendido = declaraciondegastos.totalRendido - OLD.monto
		WHERE declaraciondegastos.id = OLD.refDeclaracionDeGastos;
	END IF;

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
-- Triggers structure for table organizacion_estudiantil
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_organizacion_estudiantil_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_organizacion_estudiantil_after_insert` AFTER INSERT ON `organizacion_estudiantil` FOR EACH ROW BEGIN
		/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
    SET @idCampus = NEW.refCampus;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantCampusAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refCampus=@idCampus);
		/*Actualiza el estadoEliminacion del campus que pertenece la organizacion estudiantil*/
		UPDATE campus
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idCampus AND @cantCampusAsociados = 1 AND estadoEliminacion = 'HABILITADO';
		
		/*Obtiene el id del tipo de OE para saber si se deshabilita la eliminacion del tipoOE*/
		SET @idTipoOE = NEW.refTipoOE;
		/*Obtiene la cantidad de tipos de OE asociados a las organizaciones estudiantiles*/
		SET @cantTipoOEAsociados1 = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refTipoOE=@idTipoOE);
		/*Actualiza el estadoEliminacion del tipos de OE que pertenece la organizacion estudiantil*/
		UPDATE tipooe
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idTipoOE AND @cantTipoOEAsociados1=1 AND estadoEliminacion = 'HABILITADO';
		
		/*Obtiene la referencia de la institucion a la que pertenece organizacion estudiantil*/
		SET @idInstitucion = NEW.refInstitucion;
		/*Obtiene la cantidad de O.E. que tienen asociada la institucion*/
		SET @cantTipoOEAsociados2 = (SELECT COUNT(*)
																FROM  organizacion_estudiantil
																WHERE refInstitucion = @idInstitucion);
		/*Tras agregar a una O.E., se procede a verificar si es el primero que se agrego con la institucion y el atributo estadoEliminacion de la tabla INSTITUCION se encuentra en HABILITADO, se procede a colocar en DESHABILITADO*/															
		UPDATE institucion
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idInstitucion AND @cantTipoOEAsociados2 = 1 AND estadoEliminacion = 'HABILITADO';

END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table organizacion_estudiantil
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_organizacion_estudiantil_after_update`;
delimiter ;;
CREATE TRIGGER `TR_organizacion_estudiantil_after_update` AFTER UPDATE ON `organizacion_estudiantil` FOR EACH ROW BEGIN
		/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
    SET @idCampus = NEW.refCampus;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantCampusAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refCampus=@idCampus);
		/*Actualiza el estadoEliminacion del campus que pertenece la organizacion estudiantil*/
		UPDATE campus
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idCampus AND @cantCampusAsociados = 1 AND estadoEliminacion = 'HABILITADO';
		
		/*Obtiene el id del tipo de OE para saber si se deshabilita la eliminacion del tipoOE*/
		SET @idTipoOE = NEW.refTipoOE;
		/*Obtiene la cantidad de tipos de OE asociados a las organizaciones estudiantiles*/
		SET @cantTipoOEAsociados1 = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refTipoOE=@idTipoOE);
		/*Actualiza el estadoEliminacion del tipos de OE que pertenece la organizacion estudiantil*/
		UPDATE tipooe
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idTipoOE AND @cantTipoOEAsociados1=1 AND estadoEliminacion = 'HABILITADO';
		
		/*Obtiene el id de la institucion  para saber si se deshabilita la eliminacion del tipoOE*/
		SET @idInstitucion = NEW.refInstitucion;
		/*Obtiene la cantidad de tipos de OE asociados a las organizaciones estudiantiles*/
		SET @cantInstitucionAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refInstitucion=@idInstitucion);
		/*Actualiza el estadoEliminacion de la institucion que pertenece la organizacion estudiantil*/
		UPDATE institucion
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idInstitucion AND @cantInstitucionAsociados=1 AND estadoEliminacion = 'HABILITADO';
		
		
		
		
		
		/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
    SET @idCampus = OLD.refCampus;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantCampusAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refCampus=@idCampus);														
		/*Actualiza el estadoEliminacion del campus al que pertenece la organizacion estudiantil*/
		UPDATE campus
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idCampus AND @cantCampusAsociados=0 AND estadoEliminacion = 'DESHABILITADO'; 
		
		/*Obtiene el id del tipo de OE para saber si se deshabilita la eliminacion el tipo de OE*/
    SET @idTipoOE = OLD.refTipoOE;
		/*Obtiene la cantidad del tipo de OE asociados a las organizaciones estudiantiles*/
		SET @cantTipoOEAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refTipoOE=@idTipoOE);
		/*Actualiza el estadoEliminacion del tipo de OE que pertenece la organizacion estudiantil*/
		UPDATE tipooe
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idCampus AND @cantTipoOEAsociados=0 AND estadoEliminacion = 'DESHABILITADO';
		
		/*Obtiene el id de la institucion para saber si se deshabilita la eliminacion*/
    SET @idInstitucion = OLD.refInstitucion;
		/*Obtiene la cantidad de institucion asociados a las organizaciones estudiantiles*/
		SET @cantInstitucionAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refInstitucion=@idInstitucion);
		/*Actualiza el estadoEliminacion de la institucion a la que pertenece la organizacion estudiantil*/
		UPDATE institucion
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idInstitucion AND @cantInstitucionAsociados=0 AND estadoEliminacion = 'DESHABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table organizacion_estudiantil
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_organizacion_estudiantil_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_organizacion_estudiantil_after_delete` AFTER DELETE ON `organizacion_estudiantil` FOR EACH ROW BEGIN
		/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
    SET @idCampus = OLD.refCampus;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantCampusAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refCampus=@idCampus);														
		/*Actualiza el estadoEliminacion del campus al que pertenece la organizacion estudiantil*/
		UPDATE campus
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idCampus AND @cantCampusAsociados=0 AND estadoEliminacion = 'DESHABILITADO'; 
		
		/*Obtiene el id del tipo de OE para saber si se deshabilita la eliminacion el tipo de OE*/
    SET @idTipoOE = OLD.refTipoOE;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantTipoOEAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refTipoOE=@idTipoOE);
		/*Actualiza el estadoEliminacion del tipo de OE que pertenece la organizacion estudiantil*/
		UPDATE tipooe
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idCampus AND @cantTipoOEAsociados=0 AND estadoEliminacion = 'DESHABILITADO'; 
		
		/*Obtiene el id de la institucion para saber si se deshabilita la eliminacion*/
    SET @idInstitucion = OLD.refInstitucion;
		/*Obtiene la cantidad de institucion asociados a las organizaciones estudiantiles*/
		SET @cantInstitucionesAsociados = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refInstitucion=@idInstitucion);
		/*Actualiza el estadoEliminacion del tipo de OE que pertenece la organizacion estudiantil*/
		UPDATE institucion
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idInstitucion AND @cantInstitucionesAsociados=0 AND estadoEliminacion = 'DESHABILITADO'; 
END
;;
delimiter ;

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

-- ----------------------------
-- Triggers structure for table resolucion
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_resolucion_before_delete`;
delimiter ;;
CREATE TRIGGER `TR_resolucion_before_delete` BEFORE DELETE ON `resolucion` FOR EACH ROW BEGIN
    SET @idResolucion = OLD.id;
	
		/*Actualiza el estado del proceso del fondo que pertenece a la resolucion*/
		UPDATE procesofondo 
		SET estado = 2
		WHERE refResolucion = @idResolucion;
		
		/*Obtener id de la declaracion de gastos*/
		SET @idDeclaracionGastos = (SELECT refDeclaracionGastos
		FROM procesofondo
		WHERE procesofondo.refResolucion = @idResolucion);

		/*Tras obtener el id de la declaracion de gastos, se procede a eliminar*/
		DELETE FROM declaraciondegastos
		WHERE id = @idDeclaracionGastos;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table solcat
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_solcat_before_insert`;
delimiter ;;
CREATE TRIGGER `TR_solcat_before_insert` BEFORE INSERT ON `solcat` FOR EACH ROW BEGIN
  SET @repeticionesCategoria = (SELECT repeticiones.repeticiones
																FROM (SELECT categoriasUsadas.id, categoriasUsadas.nombre, IFNULL(count(categoriasUsadas.refCategoria), 0) AS repeticiones
																			FROM (SELECT *
																						FROM categoria
																						LEFT JOIN solcat ON solcat.refCategoria = categoria.id) AS categoriasUsadas
																			GROUP BY categoriasUsadas.refCategoria) AS repeticiones
																WHERE repeticiones.id=NEW.refCategoria); 


  IF @repeticionesCategoria = 0 THEN
      UPDATE categoria
			SET estadoEliminacion = 'DESHABILITADO'
			WHERE categoria.id = NEW.refCategoria;
  END IF ;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table solcat
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_solcat_before_delete`;
delimiter ;;
CREATE TRIGGER `TR_solcat_before_delete` BEFORE DELETE ON `solcat` FOR EACH ROW BEGIN
  SET @repeticionesCategoria = (SELECT repeticiones.repeticiones
																FROM (SELECT categoriasUsadas.id, categoriasUsadas.nombre, IFNULL(count(categoriasUsadas.refCategoria), 0) AS repeticiones
																			FROM (SELECT *
																						FROM categoria
																						LEFT JOIN solcat ON solcat.refCategoria = categoria.id) AS categoriasUsadas
																			GROUP BY categoriasUsadas.refCategoria) AS repeticiones
																WHERE repeticiones.id=OLD.refCategoria); 


  IF @repeticionesCategoria=1
    THEN
      UPDATE categoria
			SET estadoEliminacion = 'HABILITADO'
			WHERE categoria.id=OLD.refCategoria;
  END IF ;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table solicitud
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_solicitud_after_update`;
delimiter ;;
CREATE TRIGGER `TR_solicitud_after_update` AFTER UPDATE ON `solicitud` FOR EACH ROW BEGIN
    IF OLD.tipoActividad<>NEW.tipoActividad AND NEW.tipoActividad="Masiva" THEN
        DELETE FROM parsol
				WHERE parsol.refSolicitud=OLD.id;
    END IF;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_administrador
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_administrador_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_usuario_administrador_after_insert` AFTER INSERT ON `usuario_administrador` FOR EACH ROW BEGIN
	/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
	SET @idCampus = NEW.refCampus;
	/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
	SET @cantCampusAsociados = (	SELECT COUNT(*)
																	FROM usuario_administrador
																	WHERE refCampus=@idCampus);
	/*Actualiza el estadoEliminacion del campus que pertenece la organizacion estudiantil*/
	UPDATE campus
	SET estadoEliminacion = 'DESHABILITADO'
	WHERE id = @idCampus AND @cantCampusAsociados = 1 AND estadoEliminacion = 'HABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_administrador
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_administrador_after_update`;
delimiter ;;
CREATE TRIGGER `TR_usuario_administrador_after_update` AFTER UPDATE ON `usuario_administrador` FOR EACH ROW BEGIN
	/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
	SET @idCampus = NEW.refCampus;
	/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
	SET @cantCampusAsociados = (	SELECT COUNT(*)
																	FROM usuario_administrador
																	WHERE refCampus=@idCampus);
	/*Actualiza el estadoEliminacion del campus que pertenece la organizacion estudiantil*/
	UPDATE campus
	SET estadoEliminacion = 'DESHABILITADO'
	WHERE id = @idCampus AND @cantCampusAsociados = 1 AND estadoEliminacion = 'HABILITADO';
	
	
	
	/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
	SET @idCampus = OLD.refCampus;
	/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
	SET @cantCampusAsociadosOE = (	SELECT COUNT(*)
																	FROM organizacion_estudiantil
																	WHERE refCampus=@idCampus);		
																	
	/*Obtiene la cantidad de campus asociados a los usuarios administrador*/
	SET @cantCampusAsociadosUA = (	SELECT COUNT(*)
																	FROM usuario_administrador
																	WHERE refCampus=@idCampus);														
	/*Actualiza el estadoEliminacion del campus al que pertenece la organizacion estudiantil*/
	UPDATE campus
	SET estadoEliminacion = 'HABILITADO'
	WHERE id = @idCampus AND @cantCampusAsociadosOE=0 AND @cantCampusAsociadosUA = 0 AND estadoEliminacion = 'DESHABILITADO'; 

END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_administrador
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_administrador_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_usuario_administrador_after_delete` AFTER DELETE ON `usuario_administrador` FOR EACH ROW BEGIN
		/*Obtiene el id del campus para saber si se deshabilita la eliminacion el campus*/
    SET @idCampus = OLD.refCampus;
		/*Obtiene la cantidad de campus asociados a las organizaciones estudiantiles*/
		SET @cantCampusAsociadosOE = (	SELECT COUNT(*)
																		FROM organizacion_estudiantil
																		WHERE refCampus=@idCampus);		
																		
		/*Obtiene la cantidad de campus asociados a los usuarios administrador*/
		SET @cantCampusAsociadosUA = (	SELECT COUNT(*)
																		FROM usuario_administrador
																		WHERE refCampus=@idCampus);														
		/*Actualiza el estadoEliminacion del campus al que pertenece la organizacion estudiantil*/
		UPDATE campus
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idCampus AND @cantCampusAsociadosOE=0 AND @cantCampusAsociadosUA = 0 AND estadoEliminacion = 'DESHABILITADO'; 
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_director
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_director_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_usuario_director_after_insert` AFTER INSERT ON `usuario_director` FOR EACH ROW BEGIN
	/*Obtiene la referencia de la organizacion estudiantil a la que pertenece el usuario director*/
		SET @idOrganizacionEstudiantil = NEW.idOrganizacionEstudiantil;
		/*Obtiene la cantidad de representantes que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioDirector = (SELECT COUNT(*)
																FROM  usuario_director
																WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Tras agregar a un usuario director, se procede a verificar si es el primero que se agrego con la organizacion estudiantil y el atributo estadoEliminacion de la tabla ORGANIZACION_ESTUDIANTIL se encuentra en HABILITADO, se procede a colocar en DESHABILITADO*/	
		UPDATE organizacion_estudiantil
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idOrganizacionEstudiantil AND @cantUsuarioDirector = 1 AND estadoEliminacion = 'HABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_director
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_director_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_usuario_director_after_delete` AFTER DELETE ON `usuario_director` FOR EACH ROW BEGIN
		/*Obtiene la referencia de la organizacion estudiantil a la que pertenecia el usuario director*/
		SET @idOrganizacionEstudiantil = OLD.idOrganizacionEstudiantil;
		/*Obtiene la cantidad de directores que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioDirector = (SELECT COUNT(*)
																FROM  usuario_director
																WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Obtiene la cantidad de representantes que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioRepresentante = (SELECT COUNT(*)
																		FROM  usuario_representante
																		WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Se tras la eliminacion de un director, se procede a verificar existen usuarios directores y respresntantes que tengan asociada la organizacion estudiantil a la que pertenecia el usuario director recien eliminado. En caso de que no existan usuarios asociados a la organizacion estudiantil se procede a habilitar la posibilidad de eliminar la organizacion estudiantil*/															
		UPDATE organizacion_estudiantil
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idOrganizacionEstudiantil AND @cantUsuarioDirector = 0 AND @cantUsuarioRepresentante = 0 AND estadoEliminacion = 'DESHABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_representante
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuarioRepresentante_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_usuarioRepresentante_after_insert` AFTER INSERT ON `usuario_representante` FOR EACH ROW BEGIN
		/*Obtiene la referencia de la organizacion estudiantil a la que pertenece el usuario representante*/
		SET @idOrganizacionEstudiantil = NEW.idOrganizacionEstudiantil;
		/*Obtiene la cantidad de representantes que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioRepresentante = (SELECT COUNT(*)
																FROM  usuario_representante
																WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Tras agregar a un representante, se procede a verificar si es el primero que se agrego con la organizacion estudiantil y el atributo estadoEliminacion de la tabla ORGANIZACION_ESTUDIANTIL se encuentra en HABILITADO, se procede a colocar en DESHABILITADO*/	
		UPDATE organizacion_estudiantil
		SET estadoEliminacion = 'DESHABILITADO'
		WHERE id = @idOrganizacionEstudiantil AND @cantUsuarioRepresentante = 1 AND estadoEliminacion = 'HABILITADO';

END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_representante
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuarioRepresentante_after_delete`;
delimiter ;;
CREATE TRIGGER `TR_usuarioRepresentante_after_delete` AFTER DELETE ON `usuario_representante` FOR EACH ROW BEGIN
		/*Obtiene la referencia de la organizacion estudiantil a la que pertenecia el usuario director*/
		SET @idOrganizacionEstudiantil = OLD.idOrganizacionEstudiantil;
		/*Obtiene la cantidad de directores que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioDirector = (SELECT COUNT(*)
																FROM  usuario_director
																WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Obtiene la cantidad de representantes que tienen asociada la organizacion estudiantil*/
		SET @cantUsuarioRepresentante = (SELECT COUNT(*)
																		FROM  usuario_representante
																		WHERE idOrganizacionEstudiantil = @idOrganizacionEstudiantil);
		/*Se tras la eliminacion de un director, se procede a verificar existen usuarios directores y respresntantes que tengan asociada la organizacion estudiantil a la que pertenecia el usuario director recien eliminado. En caso de que no existan usuarios asociados a la organizacion estudiantil se procede a habilitar la posibilidad de eliminar la organizacion estudiantil*/															
		UPDATE organizacion_estudiantil
		SET estadoEliminacion = 'HABILITADO'
		WHERE id = @idOrganizacionEstudiantil AND @cantUsuarioDirector = 0 AND @cantUsuarioRepresentante = 0 AND estadoEliminacion = 'DESHABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_vicerector
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_vicerector_after_insert`;
delimiter ;;
CREATE TRIGGER `TR_usuario_vicerector_after_insert` AFTER INSERT ON `usuario_vicerector` FOR EACH ROW BEGIN
		INSERT INTO oe_vicerector
		SELECT organizacion_estudiantil.id, NEW.id
		FROM organizacion_estudiantil
		JOIN tipooe ON tipooe.id = organizacion_estudiantil.refTipoOE AND tipooe.nombre!='CAA'
		WHERE organizacion_estudiantil.estado='Habilitado';
		
		/*Despues de haber asociado al nuevo vicerrector con las organizaciones estudiantiles habilitadas, se procede a deshabilitar la posibilidad de que una organziacion estudiantil se elimine*/
		UPDATE organizacion_estudiantil
		JOIN (SELECT *, count(refOE) AS 'cantidad'
					FROM oe_vicerector
					GROUP BY oe_vicerector.refOE) AS oe ON oe.refOE = organizacion_estudiantil.id AND 
																									oe.refUsuarioVicerector = NEW.id AND
																									oe.cantidad = 1 AND 
																									organizacion_estudiantil.estado = 'Habilitado' AND
																									organizacion_estudiantil.estadoEliminacion = 'HABILITADO' 		SET organizacion_estudiantil.estadoEliminacion = 'DESHABILITADO';
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table usuario_vicerector
-- ----------------------------
DROP TRIGGER IF EXISTS `TR_usuario_vicerector_before_delete`;
delimiter ;;
CREATE TRIGGER `TR_usuario_vicerector_before_delete` BEFORE DELETE ON `usuario_vicerector` FOR EACH ROW BEGIN
	/*Antes de eliminar al usuario vicerrector, se debe habilitar la posibilidad de eliminacion de la oranizacion estudiantil siempre y cuando este solamente asociado al vicerrector a eliminar*/
		UPDATE organizacion_estudiantil
		JOIN (SELECT *, count(refOE) AS 'cantidad'
					FROM oe_vicerector
					GROUP BY oe_vicerector.refOE) AS oe ON oe.refOE = organizacion_estudiantil.id AND 
																									oe.refUsuarioVicerector = OLD.id AND
																									oe.cantidad = 1 AND 
																									organizacion_estudiantil.estado = 'Habilitado' AND
																									organizacion_estudiantil.estadoEliminacion = 'DESHABILITADO' 		SET organizacion_estudiantil.estadoEliminacion = 'HABILITADO';
																								
		/*Se procede a eliminar todas las asociaciones entre la organizacion estudiantil y el vicerrector*/
		DELETE FROM oe_vicerector
		WHERE oe_vicerector.refUsuarioVicerector = OLD.id;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
