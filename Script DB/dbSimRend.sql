DROP DATABASE IF EXISTS SimRend;
CREATE DATABASE SimRend
    DEFAULT CHARACTER SET utf8
    DEFAULT COLLATE utf8_general_ci;

    
SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `Solicitud`;
DROP TABLE IF EXISTS `Persona`;
DROP TABLE IF EXISTS `Federacion`;
DROP TABLE IF EXISTS `CAA`;
DROP TABLE IF EXISTS `PerSol`;
DROP TABLE IF EXISTS `Categoria`;
DROP TABLE IF EXISTS `SolCat`;
DROP TABLE IF EXISTS `OrgSol`;
DROP TABLE IF EXISTS `Resolucion`;
DROP TABLE IF EXISTS `Rendicion`;
DROP TABLE IF EXISTS `Documento`;
DROP TABLE IF EXISTS `DocPer`;
DROP TABLE IF EXISTS `Responsable`;
DROP TABLE IF EXISTS `RespOrganizacion`;
DROP TABLE IF EXISTS `Organizacion`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `Solicitud` (
    `id` Integer NOT NULL AUTO_INCREMENT,
    `estado` VARCHAR(256) NOT NULL,
    `fechaCreacion` Date NOT NULL,
    `monto` Integer NOT NULL,
    `nomEvent` VARCHAR(256) NOT NULL,
    `fecIniEvent` Date NOT NULL,
    `fecTerEvent` Date NOT NULL,
    `runEncargado` VARCHAR(256) NOT NULL,
    `lugarEvent` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Persona` (
    `nombre` VARCHAR(256) NOT NULL,
    `run` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`run`)
);

CREATE TABLE `Federacion` (
    `nomDirDAAE` VARCHAR(256) NOT NULL,
    `campus` VARCHAR(256) NOT NULL,
    `sexoDirDAAE` VARCHAR(256) NOT NULL,
    `cargo` VARCHAR(256) NOT NULL,
    `nombreFederacion` VARCHAR(256) NOT NULL,
    `refOrganizacion` Integer NOT NULL,
    PRIMARY KEY (`refOrganizacion`)
);

CREATE TABLE `CAA` (
    `nomDirCarrera` VARCHAR(256) NOT NULL,
    `carrera` VARCHAR(256) NOT NULL,
    `sexoDirCarrera` VARCHAR(256) NOT NULL,
    `cargo` VARCHAR(256) NOT NULL,
    `refOrganizacion` Integer NOT NULL,
    PRIMARY KEY (`refOrganizacion`)
);

CREATE TABLE `PerSol` (
    `refPersona` VARCHAR(256) NOT NULL,
    `refSolicitud` Integer NOT NULL
);

CREATE TABLE `Categoria` (
    `nombre` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`nombre`)
);

CREATE TABLE `SolCat` (
    `refSolicitud` Integer NOT NULL,
    `refCategoria` VARCHAR(256) NOT NULL
);

CREATE TABLE `OrgSol` (
    `refOrganizacion` Integer NOT NULL,
    `refSolicitud` Integer NOT NULL
);

CREATE TABLE `Resolucion` (
    `numero` Integer NOT NULL,
    `anio` Date NOT NULL,
    `copiaDoc` VARCHAR(256) NOT NULL,
    `refSolicitud` Integer NOT NULL,
    PRIMARY KEY (`numero`, `anio`)
);

CREATE TABLE `Rendicion` (
    `emailResponsable` VARCHAR(256) NOT NULL,
    `runResponsable` VARCHAR(256) NOT NULL,
    `unidad` VARCHAR(256) NOT NULL,
    `responsable` VARCHAR(256) NOT NULL,
    `estado` VARCHAR(256) NOT NULL,
    `montoSolicitado` Integer NOT NULL,
    `refResolucion` Integer NOT NULL,
    `totalRedido` Integer NOT NULL,
    `fonoAnexo` Integer NOT NULL,
    `nombreJefe` VARCHAR(256) NOT NULL,
    `diasDisponible` Integer NOT NULL,
    `id` Integer NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Documento` (
    `fecha` Date NOT NULL,
    `numDoc` VARCHAR(256) NOT NULL,
    `tipo` VARCHAR(256) NOT NULL,
    `monto` Integer NOT NULL,
    `descripion` VARCHAR(256) NOT NULL,
    `copiaDoc` VARCHAR(256) NOT NULL,
    `refRendicion` Integer NOT NULL,
    `refCategoria` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`numDoc`)
);

CREATE TABLE `DocPer` (
    `refDocumento` VARCHAR(256) NOT NULL,
    `refPersona` VARCHAR(256) NOT NULL
);

CREATE TABLE `Responsable` (
    `run` VARCHAR(256) NOT NULL,
    `nombre` VARCHAR(256) NOT NULL,
    `matricula` Integer NOT NULL,
    `estado` VARCHAR(256) NOT NULL,
    `cargo` VARCHAR(256) NOT NULL,
    `sexo` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`run`)
);

CREATE TABLE `RespOrganizacion` (
    `refOrganizacion` Integer NOT NULL,
    `refResponsable` VARCHAR(256) NOT NULL
);

CREATE TABLE `Organizacion` (
    `id` Integer NOT NULL AUTO_INCREMENT,
    `tipo` VARCHAR(256) NOT NULL,
    `usuario` VARCHAR(256) NOT NULL,
    `clave` VARCHAR(256) NOT NULL,
    `email` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

ALTER TABLE `Federacion` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);
ALTER TABLE `CAA` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);
ALTER TABLE `PerSol` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `PerSol` ADD FOREIGN KEY (`refPersona`) REFERENCES `Persona`(`run`);
ALTER TABLE `SolCat` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `SolCat` ADD FOREIGN KEY (`refCategoria`) REFERENCES `Categoria`(`nombre`);
ALTER TABLE `OrgSol` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `OrgSol` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);
ALTER TABLE `Resolucion` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `Rendicion` ADD FOREIGN KEY (`refResolucion`) REFERENCES `Resolucion`(`numero`);
ALTER TABLE `Documento` ADD FOREIGN KEY (`refCategoria`) REFERENCES `Categoria`(`nombre`);
ALTER TABLE `Documento` ADD FOREIGN KEY (`refRendicion`) REFERENCES `Rendicion`(`id`);
ALTER TABLE `DocPer` ADD FOREIGN KEY (`refPersona`) REFERENCES `Persona`(`run`);
ALTER TABLE `DocPer` ADD FOREIGN KEY (`refDocumento`) REFERENCES `Documento`(`numDoc`);
ALTER TABLE `RespOrganizacion` ADD FOREIGN KEY (`refResponsable`) REFERENCES `Responsable`(`run`);
ALTER TABLE `RespOrganizacion` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);