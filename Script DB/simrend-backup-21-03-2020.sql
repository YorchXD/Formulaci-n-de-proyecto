-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-03-2020 a las 06:01:44
-- Versión del servidor: 10.1.36-MariaDB
-- Versión de PHP: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `simrend`
--
CREATE DATABASE IF NOT EXISTS `simrend` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `simrend`;

DELIMITER;;
--
-- Procedimientos
--
DROP PROCEDURE IF EXISTS `actualizar_proceso_resolucion_decGastos`;
DELIMITER ;;
CREATE PROCEDURE `actualizar_proceso_resolucion_decGastos` (`in_proceso` INTEGER, `in_id_procesoFondo` INTEGER, `in_id_proceso_actual` INTEGER)  BEGIN
	CASE 
			WHEN in_proceso = '2' THEN UPDATE procesofondo SET refResolucion = in_id_proceso_actual where procesoFondo.id = in_id_procesoFondo;
			WHEN in_proceso = '3' THEN UPDATE procesofondo SET refDeclaracionGastos = in_id_proceso_actual where procesoFondo.id = in_id_procesoFondo;
	END CASE;
END;;
DELIMITER ;


DROP PROCEDURE IF EXISTS `actualizar_estado_proceso`;
DELIMITER ;;
CREATE PROCEDURE `actualizar_estado_proceso` (`in_id_proceso` INTEGER, `in_estado` INTEGER)  BEGIN
  UPDATE procesofondo SET estado = in_estado where procesoFondo.id=in_id_proceso;
END;;
DELIMITER ;





DROP PROCEDURE IF EXISTS `actualizar_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `actualizar_solicitud` (`in_refSolicitud` INTEGER, `in_fecha` DATE, `in_monto` INTEGER, `in_nombreEvento` VARCHAR(256), `in_fechaInicioEvento` DATE, `in_fechaTerminoEvento` DATE, `in_runEncargado` VARCHAR(256), `in_lugarEvento` VARCHAR(256), `in_tipoActividad` VARCHAR(256), `in_fechaCreacionPDF` DATE)  BEGIN
	UPDATE Solicitud
	SET fechaCreacion=in_fecha, monto=in_monto, nomEvent=in_nombreEvento, 
		fecIniEvent = in_fechaInicioEvento, fecTerEvent = in_fechaTerminoEvento, runEncargado = runEncargado, 
		lugarEvent = in_lugarEvento, tipoActividad = in_tipoActividad, fechaCreacionPDF = in_fechaCreacionPDF
	WHERE id=in_refSolicitud;	
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `agregar_categoria`;
DELIMITER ;;
CREATE PROCEDURE `agregar_categoria` (`in_refSolicitud` INTEGER, `in_refCategoria` VARCHAR(256))  BEGIN
	INSERT INTO SolCat(refSolicitud, refCategoria)
	VALUES (in_refSolicitud, in_refCategoria);
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `agregar_persol`;
DELIMITER ;;
CREATE PROCEDURE `agregar_persol` (`in_refPersona` VARCHAR(256), `in_refSolicitud` INTEGER)  BEGIN
	INSERT INTO PerSol(refPersona, refSolicitud)
	VALUES (in_refPersona, in_refSolicitud);
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `agregar_personas`;
DELIMITER ;;
CREATE PROCEDURE `agregar_personas` (`in_nombre` VARCHAR(256), `in_run` VARCHAR(256))  BEGIN
	INSERT INTO Persona(nombre, run)
	VALUES (in_nombre, in_run);
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `cambiar_clave`;
DELIMITER ;;
CREATE PROCEDURE `cambiar_clave` (`in_correo` VARCHAR(256), `in_clave` VARCHAR(256))  BEGIN
	UPDATE Organizacion
	SET clave=in_clave
	WHERE email=in_correo;	
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `cambiar_estado_responsable`;
DELIMITER ;;
CREATE PROCEDURE `cambiar_estado_responsable` (`in_refResponsable` VARCHAR(256), `in_estado` VARCHAR(256), `out_nombre` VARCHAR(256))  BEGIN
	UPDATE Responsable
	SET estado=in_estado
	WHERE run=in_refResponsable;	
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `categorias_seleccionadas`;
DELIMITER ;;
CREATE PROCEDURE `categorias_seleccionadas` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT refCategoria
	FROM SolCat
	WHERE refSolicitud=in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `crear_proceso_fondo`;
DELIMITER ;;
CREATE PROCEDURE `crear_proceso_fondo` (`in_refSolicitud` INTEGER, `in_refOrganizacion` INTEGER, `in_estado` INTEGER)  BEGIN
	INSERT INTO procesoFondo(refOrganizacion, refSolicitud, estado)
	VALUES (in_refOrganizacion, in_refSolicitud, in_estado);
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `crear_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `crear_solicitud` (`in_fecha` DATE, `in_monto` INTEGER, `in_nombreEvento` VARCHAR(256), `in_fechaInicioEvento` DATE, `in_fechaTerminoEvento` DATE, `in_runEncargado` VARCHAR(256), `in_lugarEvento` VARCHAR(256), `in_tipoActividad` VARCHAR(256), `in_fechaCreacionPDF` DATE, OUT `out_id` INTEGER)  BEGIN
	INSERT INTO Solicitud(fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent, tipoActividad, fechaCreacionPDF)
	VALUES (in_fecha ,in_monto, in_nombreEvento, in_fechaInicioEvento, in_fechaTerminoEvento, in_runEncargado, in_lugarEvento, in_tipoActividad, in_fechaCreacionPDF);
	SET out_id = LAST_INSERT_ID();
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `crear_resolucion`;
DELIMITER ;;
CREATE PROCEDURE `crear_resolucion` (`in_idResolucion` INTEGER, `in_anio` INTEGER, `in_copiaDocumento` VARCHAR(256), OUT `out_id` INTEGER)  BEGIN
	INSERT INTO Solicitud(numero, anio, copiaDoc)
	VALUES (in_idResolucion ,in_anio, in_copiaDocumento);
	SET out_id = LAST_INSERT_ID();
END;;
DELIMITER ;






DROP PROCEDURE IF EXISTS `eliminar_categorias_seleccionadas`;
DELIMITER ;;
CREATE PROCEDURE `eliminar_categorias_seleccionadas` (`in_refCategoria` VARCHAR(256), `in_refSolicitud` INTEGER)  BEGIN
	DELETE 
	FROM SolCat
	WHERE refCategoria=in_refCategoria AND refSolicitud=in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `eliminar_categoria_seleccionada`;
DELIMITER ;;
CREATE PROCEDURE `eliminar_categoria_seleccionada` (`in_refCategoria` VARCHAR(256), `in_refSolicitud` INTEGER)  BEGIN
	DELETE 
	FROM SolCat
	WHERE refCategoria=in_refCategoria AND refSolicitud=in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `eliminar_persona_seleccionada`;
DELIMITER ;;
CREATE PROCEDURE `eliminar_persona_seleccionada` (`in_refPersona` VARCHAR(256), `in_refSolicitud` INTEGER)  BEGIN
	DELETE 
	FROM PerSol
	WHERE refPersona=in_refPersona AND refSolicitud=in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `iniciar_sesion`;
DELIMITER ;;
CREATE PROCEDURE `iniciar_sesion` (`in_usuario` VARCHAR(256), `in_clave` VARCHAR(256))  BEGIN
	SELECT id
	FROM Organizacion
	WHERE usuario = in_usuario AND clave = in_clave;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leerpersonas_refSolicitud`;
DELIMITER ;;
CREATE PROCEDURE `leerpersonas_refSolicitud` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT Persona.nombre, Persona.run
	FROM Persona, PerSol
	WHERE PerSol.refSolicitud = in_refSolicitud AND PerSol.refPersona = Persona.run;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leertodas_solicitudes_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leertodas_solicitudes_organizacion` (`in_idOrganizacion` INTEGER)  BEGIN
	SELECT id, estado, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent
	FROM Solicitud, procesoFondo
	WHERE in_idOrganizacion=procesoFondo.refOrganizacion AND procesoFondo.refSolicitud = Solicitud.id;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leertodos_categorias`;
DELIMITER ;;
CREATE PROCEDURE `leertodos_categorias` ()  BEGIN
	SELECT nombre
	FROM Categoria;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_CAA`;
DELIMITER ;;
CREATE PROCEDURE `leer_CAA` (`in_refOrganizacion` INTEGER)  BEGIN
	SELECT nomDirCarrera, carrera, sexoDirCarrera, cargo
	FROM CAA
	WHERE CAA.refOrganizacion = in_refOrganizacion;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_Correo`;
DELIMITER ;;
CREATE PROCEDURE `leer_Correo` (`in_email` VARCHAR(256))  BEGIN
	SELECT email
	FROM Organizacion
	WHERE email = in_email;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_Estado_Proceso`;
DELIMITER ;;
CREATE PROCEDURE `leer_Estado_Proceso` (`in_id_proceso` INTEGER, `in_proceso` INTEGER)  BEGIN
	CASE
			WHEN in_proceso = '1' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refSolicitud;
			WHEN in_proceso = '2' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refResolucion;
			WHEN in_proceso = '3' THEN SELECT estado FROM procesofondo WHERE in_id_proceso = procesofondo.refDeclaracionGastos;
		END CASE;
												
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_Federacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_Federacion` (`in_refOrganizacion` INTEGER)  BEGIN
	SELECT nomDirDAAE, campus, sexoDirDAAE, cargo, nombreFederacion
	FROM Federacion
	WHERE Federacion.refOrganizacion = in_refOrganizacion;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_id_proceso`;
DELIMITER ;;
CREATE PROCEDURE `leer_id_proceso` (`in_refSolicitud` INTEGER, `in_refResolucion` INTEGER, `in_refDeclaracionGastos` INTEGER, OUT `out_id` INTEGER)  BEGIN
	CASE
			WHEN in_refSolicitud != '-1' THEN  SELECT out_id =idFondo FROM procesofondo WHERE in_refSolicitud = procesofondo.refSolicitud;
			WHEN in_refResolucion != '-1' THEN SELECT out_id =idFondo FROM procesofondo WHERE in_refResolucion = procesofondo.refResolucion;
			WHEN in_refDeclaracionGastos != '-1' THEN SELECT out_id =idFondo FROM procesofondo WHERE in_refDeclaracionGastos = procesofondo.refDeclaracionGastos;
	END CASE;
												
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_organizacion` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT Organizacion.id, Organizacion.tipo
	FROM procesoFondo, Organizacion
	WHERE in_refSolicitud = procesoFondo.refSolicitud AND procesoFondo.refOrganizacion = Organizacion.id;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `leer_responsables_organizacion`;
DELIMITER ;;
CREATE PROCEDURE `leer_responsables_organizacion` (`in_refOrganizacion` INTEGER)  BEGIN
	SELECT Responsable.run, Responsable.nombre, Responsable.matricula, Responsable.estado, Responsable.cargo, Responsable.sexo
	FROM RespOrganizacion, Responsable
	WHERE in_refOrganizacion=RespOrganizacion.refOrganizacion AND RespOrganizacion.refResponsable= Responsable.run;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `obtener_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `obtener_solicitud` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT id, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent
	FROM Solicitud
	WHERE id = in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `obtener_solicitud_completa`;
DELIMITER ;;
CREATE PROCEDURE `obtener_solicitud_completa` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT id, fechaCreacion, monto, nomEvent, fecIniEvent, fecTerEvent, runEncargado, lugarEvent, tipoActividad, fechaCreacionPDF
	FROM Solicitud
	WHERE id = in_refSolicitud;
END;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `responsable_solicitud`;
DELIMITER ;;
CREATE PROCEDURE `responsable_solicitud` (`in_refSolicitud` INTEGER)  BEGIN
	SELECT Responsable.run, Responsable.nombre, Responsable.matricula, Responsable.cargo
	FROM Solicitud, Responsable
	WHERE in_refSolicitud = Solicitud.id AND Solicitud.runEncargado = Responsable.run;
END;;
DELIMITER ;


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `caa`
--

DROP TABLE IF EXISTS `caa`;
CREATE TABLE IF NOT EXISTS `caa` (
  `nomDirCarrera` varchar(256) NOT NULL,
  `carrera` varchar(256) NOT NULL,
  `sexoDirCarrera` varchar(256) NOT NULL,
  `cargo` varchar(256) NOT NULL,
  `refOrganizacion` int(11) NOT NULL,
  PRIMARY KEY (`refOrganizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `caa`
--

INSERT INTO `caa` (`nomDirCarrera`, `carrera`, `sexoDirCarrera`, `cargo`, `refOrganizacion`) VALUES
('Ruth Garrido', 'Ingeniería Civil en Computación', 'Femenino', 'Directora de Escuela', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

DROP TABLE IF EXISTS `categoria`;
CREATE TABLE IF NOT EXISTS `categoria` (
  `nombre` varchar(256) NOT NULL,
  PRIMARY KEY (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`nombre`) VALUES
('Alimentación'),
('Alojamiento'),
('Artículos de oficina'),
('Inscripción'),
('Pasajes');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `docper`
--

DROP TABLE IF EXISTS `docper`;
CREATE TABLE IF NOT EXISTS `docper` (
  `refDocumento` varchar(256) NOT NULL,
  `refPersona` varchar(256) NOT NULL,
  KEY `refPersona` (`refPersona`),
  KEY `refDocumento` (`refDocumento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documento`
--

DROP TABLE IF EXISTS `documento`;
CREATE TABLE IF NOT EXISTS `documento` (
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
  KEY `refRendicion` (`refRendicion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `federacion`
--

DROP TABLE IF EXISTS `federacion`;
CREATE TABLE IF NOT EXISTS `federacion` (
  `nomDirDAAE` varchar(256) NOT NULL,
  `campus` varchar(256) NOT NULL,
  `sexoDirDAAE` varchar(256) NOT NULL,
  `cargo` varchar(256) NOT NULL,
  `nombreFederacion` varchar(256) NOT NULL,
  `refOrganizacion` int(11) NOT NULL,
  PRIMARY KEY (`refOrganizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `federacion`
--

INSERT INTO `federacion` (`nomDirDAAE`, `campus`, `sexoDirDAAE`, `cargo`, `nombreFederacion`, `refOrganizacion`) VALUES
('Juanita Peres', 'Curicó', 'Femenino', 'Directora del DAAE', 'Fedeut', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `organizacion`
--

DROP TABLE IF EXISTS `organizacion`;
CREATE TABLE IF NOT EXISTS `organizacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(256) NOT NULL,
  `usuario` varchar(256) NOT NULL,
  `clave` varchar(256) NOT NULL,
  `email` varchar(256) NOT NULL,
  `estado` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `organizacion`
--

INSERT INTO `organizacion` (`id`, `tipo`, `usuario`, `clave`, `email`, `estado`) VALUES
(1, 'CAA', 'caaicc', 'caaicc2018', 'caaicc2016@gmail.com', 'Habilitado'),
(2, 'Federación', 'fedeut', 'fedeut2018', 'federacion2018@gmail.com', 'Habilitado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persol`
--

DROP TABLE IF EXISTS `persol`;
CREATE TABLE IF NOT EXISTS `persol` (
  `refPersona` varchar(256) NOT NULL,
  `refSolicitud` int(11) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refPersona` (`refPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `persol`
--

INSERT INTO `persol` (`refPersona`, `refSolicitud`) VALUES
('178245236', 9),
('17.824.523-6', 25),
('17.820.883-7', 25),
('12.296.649-6', 25),
('18.165.443-0', 26),
('17.981.314-9', 27),
('18.594.887-0', 27),
('19.299.415-2', 27),
('20.090.232-7', 27),
('19.862.538-8', 27),
('19.865.856-1', 27),
('17.542.034-7', 27),
('17.981.314-9', 30),
('18.594.887-0', 30),
('19.299.415-2', 30),
('19.862.538-8', 30),
('19.865.856-1', 30),
('17.542.034-7', 30),
('20.090.232-7', 30),
('17.981.314-9', 32),
('18.594.887-0', 32),
('19.299.415-2', 32),
('20.090.232-7', 32),
('19.862.538-8', 32),
('19.865.856-1', 32),
('17.542.034-7', 32);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

DROP TABLE IF EXISTS `persona`;
CREATE TABLE IF NOT EXISTS `persona` (
  `nombre` varchar(256) NOT NULL,
  `run` varchar(256) NOT NULL,
  PRIMARY KEY (`run`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`nombre`, `run`) VALUES
('Patricia Manriquez', '12.296.649-6'),
('Erik Andrés Regla Torres', '17.542.034-7'),
('Daniela Paredes', '17.820.883-7'),
('Yorch Sepúlveda', '17.824.523-6'),
('Matías Ignacio Erenchun Marquéz', '17.981.314-9'),
('Juan', '178245236'),
('Fabian Olivares', '18.165.443-0'),
('Daniel Eduardo Pavez Bravo', '18.594.887-0'),
('Victor Alejandro Reyes Medina', '19.299.415-2'),
('Ignacio Andrés Martínez Hernández', '19.862.538-8'),
('Nicolás Antonio Piña Navarro', '19.865.856-1'),
('Carlos Daniel Ríos Moya', '20.090.232-7');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesofondo`
--

DROP TABLE IF EXISTS `procesofondo`;
CREATE TABLE IF NOT EXISTS `procesofondo` (
  `idFondo` int(11) NOT NULL AUTO_INCREMENT,
  `refSolicitud` int(11) DEFAULT NULL,
  `refResolucion` int(11) DEFAULT NULL,
  `refDeclaracionGastos` int(11) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL,
  `refOrganizacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`idFondo`),
  KEY `ref_resolucion` (`refResolucion`) USING BTREE,
  KEY `refOrganizacion` (`refOrganizacion`),
  KEY `refDeclaracionGastos` (`refDeclaracionGastos`),
  KEY `refSolicitud` (`refSolicitud`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `procesofondo`
--

INSERT INTO `procesofondo` (`idFondo`, `refSolicitud`, `refResolucion`, `refDeclaracionGastos`, `estado`, `refOrganizacion`) VALUES
(2, 2, NULL, NULL, 2, 2),
(3, 3, NULL, NULL, 1, 2),
(4, 4, NULL, NULL, 1, 1),
(5, 5, NULL, NULL, 2, 1),
(6, 6, NULL, NULL, 2, 1),
(7, 7, NULL, NULL, 1, 1),
(8, 8, NULL, NULL, 2, 1),
(9, 9, NULL, NULL, 2, 1),
(10, 10, NULL, NULL, 1, 1),
(11, 11, NULL, NULL, 1, 2),
(12, 12, NULL, NULL, 1, 2),
(13, 13, NULL, NULL, 1, 1),
(14, 14, NULL, NULL, 1, 1),
(15, 15, NULL, NULL, 1, 1),
(16, 16, NULL, NULL, 1, 1),
(17, 17, NULL, NULL, 1, 1),
(18, 19, NULL, NULL, 1, 1),
(19, 19, NULL, NULL, 1, 1),
(20, 20, NULL, NULL, 1, 1),
(21, 21, NULL, NULL, 1, 1),
(22, 22, NULL, NULL, 1, 1),
(23, 23, NULL, NULL, 1, 1),
(24, 24, NULL, NULL, 1, 1),
(25, 25, NULL, NULL, 1, 1),
(26, 26, NULL, NULL, 1, 1),
(27, 27, NULL, NULL, 1, 1),
(29, 29, NULL, NULL, 1, 1),
(30, 30, NULL, NULL, 1, 1),
(31, 31, NULL, NULL, 1, 1),
(32, 32, NULL, NULL, 1, 1),
(33, 33, NULL, NULL, 1, 1),
(34, 34, NULL, NULL, 1, 1),
(35, 35, NULL, NULL, 1, 1),
(36, 36, NULL, NULL, 1, 1),
(37, 37, NULL, NULL, 1, 1),
(38, 38, NULL, NULL, 1, 1),
(39, 39, NULL, NULL, 1, 1),
(40, 40, NULL, NULL, 1, 1),
(41, 41, NULL, NULL, 1, 1),
(42, 42, NULL, NULL, 1, 1),
(43, 43, NULL, NULL, 1, 1),
(44, 44, NULL, NULL, 1, 1),
(45, 45, NULL, NULL, 1, 1),
(46, 46, NULL, NULL, 1, 1),
(47, 47, NULL, NULL, 1, 1),
(52, 48, NULL, NULL, 1, 1),
(53, 49, NULL, NULL, 1, 1),
(54, 50, NULL, NULL, 1, 1),
(55, 51, NULL, NULL, 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rendicion`
--

DROP TABLE IF EXISTS `rendicion`;
CREATE TABLE IF NOT EXISTS `rendicion` (
  `emailResponsable` varchar(256) NOT NULL,
  `runResponsable` varchar(256) NOT NULL,
  `unidad` varchar(256) NOT NULL,
  `responsable` varchar(256) NOT NULL,
  `estado` varchar(256) NOT NULL,
  `montoSolicitado` int(11) NOT NULL,
  `totalRedido` int(11) NOT NULL,
  `fonoAnexo` int(11) NOT NULL,
  `nombreJefe` varchar(256) NOT NULL,
  `diasDisponible` int(11) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `resolucion`
--

DROP TABLE IF EXISTS `resolucion`;
CREATE TABLE IF NOT EXISTS `resolucion` (
  `numero` int(11) NOT NULL,
  `anio` date NOT NULL,
  `copiaDoc` varchar(256) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`),
  KEY `numero` (`numero`),
  KEY `anio` (`anio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `run` varchar(256) NOT NULL,
  `nombre` varchar(256) NOT NULL,
  `matricula` int(11) NOT NULL,
  `estado` varchar(256) NOT NULL,
  `cargo` varchar(256) NOT NULL,
  `sexo` varchar(256) NOT NULL,
  `estadoCargo` varchar(256) NOT NULL,
  PRIMARY KEY (`run`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `responsable`
--

INSERT INTO `responsable` (`run`, `nombre`, `matricula`, `estado`, `cargo`, `sexo`, `estadoCargo`) VALUES
('17.820.883-7', 'Daniela Paredes', 2009407826, 'Desabilitado', 'Secretaria de finanzas', 'Femenino', 'Habilitad'),
('17.824.523-6', 'Yorch Sepúlveda', 2011407070, 'Habilitada', 'Presidente', 'Masculino', 'Habilitad'),
('18.801.120-9', 'Maria Soledad Gonzalez', 2013437888, 'Habilitado', 'Presidenta', 'Femenino', 'Habilitad'),
('19.552.303-7', 'Jorge Carrasco', 2016468073, 'Habilitado', 'Secretario de finanzas', 'Masculino', 'Habilitad');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `resporganizacion`
--

DROP TABLE IF EXISTS `resporganizacion`;
CREATE TABLE IF NOT EXISTS `resporganizacion` (
  `refOrganizacion` int(11) NOT NULL,
  `refResponsable` varchar(256) NOT NULL,
  KEY `refResponsable` (`refResponsable`),
  KEY `refOrganizacion` (`refOrganizacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `resporganizacion`
--

INSERT INTO `resporganizacion` (`refOrganizacion`, `refResponsable`) VALUES
(1, '17.824.523-6'),
(1, '17.820.883-7'),
(2, '18.801.120-9'),
(2, '19.552.303-7');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `solcat`
--

DROP TABLE IF EXISTS `solcat`;
CREATE TABLE IF NOT EXISTS `solcat` (
  `refSolicitud` int(11) NOT NULL,
  `refCategoria` varchar(256) NOT NULL,
  KEY `refSolicitud` (`refSolicitud`),
  KEY `refCategoria` (`refCategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `solcat`
--

INSERT INTO `solcat` (`refSolicitud`, `refCategoria`) VALUES
(2, 'Alimentación'),
(2, 'Pasajes'),
(3, 'Pasajes'),
(3, 'Alimentación'),
(4, 'Pasajes'),
(4, 'Alimentación'),
(5, 'Alimentación'),
(5, 'Pasajes'),
(6, 'Alimentación'),
(6, 'Pasajes'),
(9, 'Alimentación'),
(10, 'Alimentación'),
(11, 'Alimentación'),
(12, 'Alimentación'),
(13, 'Alojamiento'),
(14, 'Alimentación'),
(15, 'Alimentación'),
(15, 'Pasajes'),
(16, 'Alimentación'),
(20, 'Alimentación'),
(21, 'Alimentación'),
(22, 'Alimentación'),
(23, 'Alojamiento'),
(23, 'Artículos de oficina'),
(24, 'Alimentación'),
(24, 'Alimentación'),
(24, 'Alimentación'),
(24, 'Alimentación'),
(24, 'Alojamiento'),
(24, 'Alojamiento'),
(24, 'Alimentación'),
(25, 'Alimentación'),
(25, 'Alojamiento'),
(25, 'Artículos de oficina'),
(26, 'Alimentación'),
(26, 'Pasajes'),
(27, 'Alimentación'),
(27, 'Pasajes'),
(27, 'Alojamiento'),
(27, 'Inscripción'),
(29, 'Alimentación'),
(30, 'Alimentación'),
(30, 'Inscripción'),
(30, 'Pasajes'),
(30, 'Alojamiento'),
(31, 'Alimentación'),
(31, 'Alojamiento'),
(31, 'Pasajes'),
(31, 'Inscripción'),
(32, 'Alimentación'),
(32, 'Pasajes'),
(32, 'Alojamiento'),
(32, 'Inscripción'),
(33, 'Alimentación'),
(33, 'Inscripción'),
(33, 'Alojamiento'),
(33, 'Pasajes'),
(34, 'Alimentación'),
(34, 'Artículos de oficina'),
(35, 'Alimentación'),
(35, 'Pasajes'),
(36, 'Alimentación'),
(36, 'Inscripción'),
(39, 'Alimentación'),
(39, 'Pasajes'),
(40, 'Alimentación'),
(40, 'Pasajes'),
(41, 'Alimentación'),
(41, 'Pasajes'),
(42, 'Pasajes'),
(43, 'Alojamiento'),
(44, 'Alimentación'),
(45, 'Alimentación'),
(46, 'Inscripción'),
(47, 'Pasajes'),
(48, 'Alimentación'),
(49, 'Alimentación'),
(50, 'Alimentación'),
(51, 'Alimentación');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `solicitud`
--

DROP TABLE IF EXISTS `solicitud`;
CREATE TABLE IF NOT EXISTS `solicitud` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fechaCreacion` date NOT NULL,
  `monto` int(11) NOT NULL,
  `nomEvent` varchar(256) NOT NULL,
  `fecIniEvent` date NOT NULL,
  `fecTerEvent` date NOT NULL,
  `runEncargado` varchar(256) NOT NULL,
  `lugarEvent` varchar(256) NOT NULL,
  `tipoActividad` varchar(256) NOT NULL,
  `fechaCreacionPDF` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `solicitud`
--

INSERT INTO `solicitud` (`id`, `fechaCreacion`, `monto`, `nomEvent`, `fecIniEvent`, `fecTerEvent`, `runEncargado`, `lugarEvent`, `tipoActividad`, `fechaCreacionPDF`) VALUES
(2, '2018-12-25', 120000, 'Fiesta Navideña', '2018-12-20', '2018-12-20', '19.552.303-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(3, '2018-12-25', 120000, 'Fiesta final de semestre', '2019-01-03', '2019-01-03', '18.801.120-9', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(4, '2020-01-31', 150000, 'YO20000', '2020-01-31', '2020-01-31', '17.820.883-7', 'UTALCA', 'Masiva', '2020-01-23'),
(5, '2018-12-25', 120000, 'Fiesta final de semestre', '2019-01-03', '2019-01-03', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '2020-01-28'),
(6, '2018-12-25', 50000, 'Guerra de bandas', '2018-12-28', '2018-12-28', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '2020-01-28'),
(7, '2019-01-03', 50000, 'Fiesta final de semestre', '2019-01-10', '2019-01-10', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '2020-01-28'),
(8, '2019-01-03', 120000, 'Guerra de bandas', '2019-01-24', '2019-01-24', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '2020-01-26'),
(9, '2019-01-03', 150000, 'Fiesta Navideña', '2019-01-24', '2019-01-24', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '2020-01-30'),
(10, '2019-02-13', 150000, 'Mechoneo 2019', '2019-03-14', '2019-03-14', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(11, '2019-03-27', 1500000, 'Mechoneo 2019', '2019-04-04', '2019-04-04', '18.801.120-9', 'Manzanares', 'Masiva', '1972-01-01'),
(12, '2019-03-27', 500000, 'Dia del alumno', '2019-04-17', '2019-04-17', '19.552.303-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(13, '2019-03-27', 150000, 'Mechoneo 2019', '2019-04-04', '2019-04-04', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(14, '2019-03-27', 30000, 'Campeonato 3 vs 3', '2019-04-16', '2019-04-16', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(15, '2019-03-27', 50000, 'Competencia de programación', '2019-03-29', '2019-03-29', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(16, '2019-03-28', 150000, 'Fiesta Navideña', '2019-12-19', '2019-12-19', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(17, '2019-03-28', 25000, 'Campeonato de cubo', '2019-04-25', '2019-04-25', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(18, '2019-03-29', 150000, 'Compartir mechones', '2019-03-29', '2019-03-29', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(19, '2019-03-29', 150000, 'Guerra de bandas', '2019-03-29', '2019-03-29', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(20, '2019-03-29', 150000, 'Guerra de bandas', '2019-03-29', '2019-03-29', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(21, '2019-03-29', 8234672, 'Campeonato de cubo', '2019-03-29', '2019-03-29', '17.820.883-7', 'Utalca', 'Masiva', '1972-01-01'),
(22, '2019-03-29', 1500000, 'Fiesta final de semestre', '2019-03-29', '2019-03-29', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(23, '2019-06-15', 50000, 'Charla de google', '2019-06-27', '2019-06-27', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(24, '2019-06-20', 50000, 'Campeonato de cubo', '2019-06-27', '2019-06-27', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(25, '2019-06-20', 50000, 'Fiesta Navideña', '2019-06-27', '2019-06-27', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(26, '2019-06-20', 50000, 'Charla de google', '2019-06-27', '2019-06-27', '17.820.883-7', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(27, '2019-07-15', 382000, 'Competencia ACM-ICPC', '2019-07-05', '2019-07-06', '17.824.523-6', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(29, '2019-07-15', 20000, 'Charla de google', '2019-07-19', '2019-07-19', '17.824.523-6', 'Universidad de Talca, Campus Curicó, Los Niches', 'Masiva', '1972-01-01'),
(30, '2019-07-16', 381990, 'Competencia ACM-ICPC', '2019-07-05', '2019-07-06', '17.820.883-7', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(31, '2019-07-17', 382000, 'Competencia ACM-ICPC', '2019-07-18', '2019-07-18', '17.824.523-6', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(32, '2019-07-17', 381990, 'Competencia ACM-ICPC', '2019-07-05', '2019-07-06', '17.824.523-6', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(33, '2019-10-20', 50000, 'jcc', '2019-10-25', '2019-10-27', '17.820.883-7', 'Conce', 'Masiva', '1972-01-01'),
(34, '2019-10-20', 500000, 'nueva jcc', '2019-10-22', '2019-10-24', '17.820.883-7', 'Conce', 'Masiva', '1972-01-01'),
(35, '2019-10-20', 350000, 'Aniversario de carrera', '2019-10-31', '2019-10-31', '17.824.523-6', 'Utalca', 'Masiva', '1972-01-01'),
(36, '2019-10-29', 150000, 'Competencia ACM-ICPC', '2019-11-01', '2019-11-03', '17.820.883-7', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(37, '2020-01-23', 150000, 'Mechoneo 2020', '2020-04-02', '2020-04-02', '17.820.883-7', 'Universidad de Talca, campus Curicó', 'Masiva', '1972-01-01'),
(38, '2020-01-23', 200000, 'Muffincup2020', '2020-04-16', '2020-04-16', '17.824.523-6', 'Universidad de Talca, campus Curicó', 'Masiva', '1972-01-01'),
(39, '2020-01-23', 250000, 'Aniversario de carrera', '2020-10-29', '2020-10-29', '17.820.883-7', 'Universidad de Talca, campus Curicó', 'Masiva', '1972-01-01'),
(40, '2020-01-23', 550000, 'jcc 2020', '2020-11-06', '2020-11-06', '17.824.523-6', 'Universidad del Desarrollo, Campus Rector Ernesto Silva Bafalluy, San Carlos de Apoquindo, Las Condes, Santiago.', 'Masiva', '1972-01-01'),
(41, '2020-01-23', 150000, 'Mechoneo 2020', '2020-01-24', '2020-01-24', '17.820.883-7', 'Universidad de Talca, campus Curicó', 'Masiva', '1972-01-01'),
(42, '2020-01-23', 100000, 'Inicio de clases', '2020-03-02', '2020-03-02', '17.824.523-6', 'Universidad de Talca', 'Masiva', '1972-01-01'),
(43, '2020-01-23', 15000, 'Hola', '2020-01-23', '2020-01-23', '17.820.883-7', 'utalca', 'Masiva', '1972-01-01'),
(44, '2020-01-23', 50000, 'Fiestas patrias 2020', '2020-09-17', '2020-09-17', '17.824.523-6', 'Utalca', 'Masiva', '1972-01-01'),
(45, '2020-01-23', 150000, 'Mechoneo 2020', '2020-04-16', '2020-04-16', '17.820.883-7', 'Universidad de Talca, campus Curicó', 'Masiva', '1972-01-01'),
(46, '2020-01-23', 15236452, 'Yo', '2020-01-31', '2020-01-31', '17.824.523-6', 'Yo', 'Masiva', '0000-00-00'),
(47, '2020-01-23', 150000, 'yo 2', '2020-01-31', '2020-01-31', '17.824.523-6', 'Utalca', 'Masiva', '2020-01-23'),
(48, '2020-01-26', 150000, 'Mila', '2020-01-31', '2020-01-31', '17.820.883-7', 'Talca', 'Masiva', '2020-01-26'),
(49, '2020-01-26', 150000, 'Mila2', '2020-02-05', '2020-02-05', '17.824.523-6', 'Talca', 'Masiva', '2020-01-26'),
(50, '2020-01-26', 150000, 'Mila 3', '2020-02-06', '2020-02-06', '17.820.883-7', 'Talca', 'Masiva', '2020-01-26'),
(51, '2020-01-26', 150000, 'Mila 10', '2020-02-08', '2020-02-08', '17.820.883-7', 'Talca', 'Masiva', '2020-01-26');

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `caa`
--
ALTER TABLE `caa`
  ADD CONSTRAINT `caa_ibfk_1` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`);

--
-- Filtros para la tabla `docper`
--
ALTER TABLE `docper`
  ADD CONSTRAINT `docper_ibfk_1` FOREIGN KEY (`refPersona`) REFERENCES `persona` (`run`),
  ADD CONSTRAINT `docper_ibfk_2` FOREIGN KEY (`refDocumento`) REFERENCES `documento` (`numDoc`);

--
-- Filtros para la tabla `documento`
--
ALTER TABLE `documento`
  ADD CONSTRAINT `documento_ibfk_1` FOREIGN KEY (`refCategoria`) REFERENCES `categoria` (`nombre`),
  ADD CONSTRAINT `documento_ibfk_2` FOREIGN KEY (`refRendicion`) REFERENCES `rendicion` (`id`);

--
-- Filtros para la tabla `federacion`
--
ALTER TABLE `federacion`
  ADD CONSTRAINT `federacion_ibfk_1` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`);

--
-- Filtros para la tabla `persol`
--
ALTER TABLE `persol`
  ADD CONSTRAINT `persol_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  ADD CONSTRAINT `persol_ibfk_2` FOREIGN KEY (`refPersona`) REFERENCES `persona` (`run`);

--
-- Filtros para la tabla `procesofondo`
--
ALTER TABLE `procesofondo`
  ADD CONSTRAINT `refDeclaracionGastos` FOREIGN KEY (`refDeclaracionGastos`) REFERENCES `rendicion` (`id`),
  ADD CONSTRAINT `refOrganizacion` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`),
  ADD CONSTRAINT `refResolucion` FOREIGN KEY (`refResolucion`) REFERENCES `resolucion` (`id`),
  ADD CONSTRAINT `refSolicitud` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`);

--
-- Filtros para la tabla `resporganizacion`
--
ALTER TABLE `resporganizacion`
  ADD CONSTRAINT `resporganizacion_ibfk_1` FOREIGN KEY (`refResponsable`) REFERENCES `responsable` (`run`),
  ADD CONSTRAINT `resporganizacion_ibfk_2` FOREIGN KEY (`refOrganizacion`) REFERENCES `organizacion` (`id`);

--
-- Filtros para la tabla `solcat`
--
ALTER TABLE `solcat`
  ADD CONSTRAINT `solcat_ibfk_1` FOREIGN KEY (`refSolicitud`) REFERENCES `solicitud` (`id`),
  ADD CONSTRAINT `solcat_ibfk_2` FOREIGN KEY (`refCategoria`) REFERENCES `categoria` (`nombre`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
