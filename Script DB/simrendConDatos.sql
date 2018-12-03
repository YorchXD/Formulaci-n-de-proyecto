/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : simrend

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2018-11-29 02:18:26
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for caa
-- ----------------------------
DROP TABLE IF EXISTS `caa`;
CREATE TABLE `caa` (
  `nomDirCarrera` varchar(256) NOT NULL,
  `carrera` varchar(256) NOT NULL,
  `refOrganizacion` int(11) NOT NULL,
  `sexoDirCarrera` varchar(20) NOT NULL,
  PRIMARY KEY (`refOrganizacion`),
  CONSTRAINT `caa_ibfk_1` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of caa
-- ----------------------------


-- ----------------------------
-- Table structure for caasol
-- ----------------------------
DROP TABLE IF EXISTS `caasol`;
CREATE TABLE `caasol` (
  `refCAA` int(11) NOT NULL,
  `refSolicitud` int(11) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refCAA` (`refCAA`),
  CONSTRAINT `caasol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  CONSTRAINT `caasol_ibfk_2` FOREIGN KEY (`refCAA`) REFERENCES `caa` (`refOrganizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of caasol
-- ----------------------------

-- ----------------------------
-- Table structure for categoría
-- ----------------------------
DROP TABLE IF EXISTS `categoría`;
CREATE TABLE `categoría` (
  `nombre` varchar(256) NOT NULL,
  PRIMARY KEY (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of categoría
-- ----------------------------

-- ----------------------------
-- Table structure for docper
-- ----------------------------
DROP TABLE IF EXISTS `docper`;
CREATE TABLE `docper` (
  `refDocumento` varchar(256) NOT NULL,
  `refPersona` int(11) NOT NULL,
  KEY `refPersona` (`refPersona`),
  KEY `refDocumento` (`refDocumento`),
  CONSTRAINT `docper_ibfk_1` FOREIGN KEY (`refPersona`) REFERENCES `persona` (`matricula`),
  CONSTRAINT `docper_ibfk_2` FOREIGN KEY (`refDocumento`) REFERENCES `documento` (`numDoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of docper
-- ----------------------------

-- ----------------------------
-- Table structure for documento
-- ----------------------------
DROP TABLE IF EXISTS `documento`;
CREATE TABLE `documento` (
  `fecha` date NOT NULL,
  `numDoc` varchar(256) NOT NULL,
  `tipo` varchar(256) NOT NULL,
  `monto` int(11) NOT NULL,
  `descripion` varchar(256) NOT NULL,
  `copiaDoc` varchar(256) NOT NULL,
  `refRendicion` int(11) NOT NULL,
  `refCategoria` varchar(256) NOT NULL,
  PRIMARY KEY (`numDoc`),
  KEY `refCategoria` (`refCategoria`),
  KEY `refRendicion` (`refRendicion`),
  CONSTRAINT `documento_ibfk_1` FOREIGN KEY (`refCategoria`) REFERENCES `categoría` (`nombre`),
  CONSTRAINT `documento_ibfk_2` FOREIGN KEY (`refRendicion`) REFERENCES `rendicion` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of documento
-- ----------------------------

-- ----------------------------
-- Table structure for federacion
-- ----------------------------
DROP TABLE IF EXISTS `federacion`;
CREATE TABLE `federacion` (
  `refOrganizacion` int(11) NOT NULL,
  `campus` varchar(256) NOT NULL,
  `nomDirDAAE` varchar(256) NOT NULL,
  `sexoDirDAAE` varchar(20) NOT NULL,
  PRIMARY KEY (`refOrganizacion`),
  CONSTRAINT `federacion_ibfk_1` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of federacion
-- ----------------------------


-- ----------------------------
-- Table structure for fedsol
-- ----------------------------
DROP TABLE IF EXISTS `fedsol`;
CREATE TABLE `fedsol` (
  `refFederacion` int(11) NOT NULL,
  `refSolicitud` int(11) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refFederacion` (`refFederacion`),
  CONSTRAINT `fedsol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  CONSTRAINT `fedsol_ibfk_2` FOREIGN KEY (`refFederacion`) REFERENCES `federacion` (`refOrganizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of fedsol
-- ----------------------------

-- ----------------------------
-- Table structure for organizacion
-- ----------------------------
DROP TABLE IF EXISTS `organizacion`;
CREATE TABLE `organizacion` (
  `nomPresidente` varchar(256) NOT NULL,
  `runPesidente` varchar(256) NOT NULL,
  `matPresidente` int(11) NOT NULL,
  `sexoPresidente` varchar(25) NOT NULL,
  `nomSecFinza` varchar(256) NOT NULL,
  `runSecFinza` varchar(256) NOT NULL,
  `matSecFinza` int(11) NOT NULL,
  `sexoSecFinza` varchar(25) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of organizacion
-- ----------------------------

-- ----------------------------
-- Table structure for persol
-- ----------------------------
DROP TABLE IF EXISTS `persol`;
CREATE TABLE `persol` (
  `refPersona` int(11) NOT NULL,
  `refSolicitud` int(11) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refPersona` (`refPersona`),
  CONSTRAINT `persol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  CONSTRAINT `persol_ibfk_2` FOREIGN KEY (`refPersona`) REFERENCES `persona` (`matricula`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of persol
-- ----------------------------

-- ----------------------------
-- Table structure for persona
-- ----------------------------
DROP TABLE IF EXISTS `persona`;
CREATE TABLE `persona` (
  `nombre` varchar(256) NOT NULL,
  `matricula` int(11) NOT NULL,
  PRIMARY KEY (`matricula`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of persona
-- ----------------------------

-- ----------------------------
-- Table structure for rendicion
-- ----------------------------
DROP TABLE IF EXISTS `rendicion`;
CREATE TABLE `rendicion` (
  `emailResponsable` varchar(256) NOT NULL,
  `runResponsable` varchar(256) NOT NULL,
  `unidad` varchar(256) NOT NULL,
  `responsable` varchar(256) NOT NULL,
  `estado` varchar(256) NOT NULL,
  `montoSolicitado` int(11) NOT NULL,
  `refResolucion` int(11) NOT NULL,
  `totalRedido` int(11) NOT NULL,
  `fonoAnexo` int(11) NOT NULL,
  `nombreJefe` varchar(256) NOT NULL,
  `diasDisponible` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `refResolucion` (`refResolucion`),
  CONSTRAINT `rendicion_ibfk_1` FOREIGN KEY (`refResolucion`) REFERENCES `resolucion` (`numero`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of rendicion
-- ----------------------------

-- ----------------------------
-- Table structure for resolucion
-- ----------------------------
DROP TABLE IF EXISTS `resolucion`;
CREATE TABLE `resolucion` (
  `numero` int(11) NOT NULL,
  `anio` date NOT NULL,
  `copiaDoc` varchar(256) NOT NULL,
  `refSolicitud` int(11) NOT NULL,
  PRIMARY KEY (`numero`,`anio`),
  KEY `refSolicitud` (`refSolicitud`),
  CONSTRAINT `resolucion_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of resolucion
-- ----------------------------

-- ----------------------------
-- Table structure for solcat
-- ----------------------------
DROP TABLE IF EXISTS `solcat`;
CREATE TABLE `solcat` (
  `refSolicitud` int(11) NOT NULL,
  `refCategoria` varchar(256) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refCategoria` (`refCategoria`),
  CONSTRAINT `solcat_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  CONSTRAINT `solcat_ibfk_2` FOREIGN KEY (`refCategoria`) REFERENCES `categoría` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of solcat
-- ----------------------------

-- ----------------------------
-- Table structure for solicitud
-- ----------------------------
DROP TABLE IF EXISTS `solicitud`;
CREATE TABLE `solicitud` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `estado` varchar(256) NOT NULL,
  `fecha` date NOT NULL,
  `monto` int(11) NOT NULL,
  `nomEvent` varchar(256) NOT NULL,
  `fecEvent` date NOT NULL,
  `encargado` varchar(256) NOT NULL,
  `lugarEvent` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of solicitud
-- ----------------------------

-- ----------------------------
-- Procedure structure for crear_solicitud
-- ----------------------------
DROP PROCEDURE IF EXISTS `crear_solicitud`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `crear_solicitud`(
	in_estado VARCHAR(256),
    in_fecha DATE,
  	in_monto INTEGER,
  	in_nombreEvento VARCHAR(256),
	in_fechaEvento DATE,
	in_encargado VARCHAR(256),
	in_lugarEvento VARCHAR(256)
)
BEGIN
	INSERT INTO Solicitud(estado, fecha, monto, nomEvent, fecEvent, encargado, lugarEvent)
	VALUES (in_estado, in_fecha ,in_monto, in_nombreEvento, in_fechaEvento, in_encargado, in_lugarEvento);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for leertodos_solicitudes
-- ----------------------------
DROP PROCEDURE IF EXISTS `leertodos_solicitudes`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `leertodos_solicitudes`()
BEGIN
	SELECT id, estado, fecha, monto, nomEvent, fecEvent, encargado, lugarEvent
	FROM Solicitud;
END
;;
DELIMITER ;
