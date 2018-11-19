SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `Solicitud`;
DROP TABLE IF EXISTS `Persona`;
DROP TABLE IF EXISTS `Organizacion`;
DROP TABLE IF EXISTS `CAA`;
DROP TABLE IF EXISTS `PerSol`;
DROP TABLE IF EXISTS `Categoría`;
DROP TABLE IF EXISTS `SolCat`;
DROP TABLE IF EXISTS `FedSol`;
DROP TABLE IF EXISTS `CAASol`;
DROP TABLE IF EXISTS `Resolucion`;
DROP TABLE IF EXISTS `Rendicion`;
DROP TABLE IF EXISTS `Documento`;
DROP TABLE IF EXISTS `DocPer`;
DROP TABLE IF EXISTS `Federacion`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `Solicitud` (
    `id` Integer NOT NULL AUTO_INCREMENT,
    `estado` VARCHAR(256) NOT NULL,
    `fecha` Date NOT NULL,
    `monto` Integer NOT NULL,
    `nomEvent` VARCHAR(256) NOT NULL,
    `fecEvent` Date NOT NULL,
    `encargado` VARCHAR(256) NOT NULL,
    `lugarEvent` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `Persona` (
    `nombre` VARCHAR(256) NOT NULL,
    `matricula` Integer NOT NULL,
    PRIMARY KEY (`matricula`)
);

CREATE TABLE `Organizacion` (
    `nomPresidente` VARCHAR(256) NOT NULL,
    `runPesidente` VARCHAR(256) NOT NULL,
    `matPresidente` Integer NOT NULL,
    `sexoPresidente` VARCHAR(25) NOT NULL,
    `nomSecFinza` VARCHAR(256) NOT NULL,
    `runSecFinza` VARCHAR(256) NOT NULL,
    `matSecFinza` Integer NOT NULL,
    `sexoSecFinza` VARCHAR(25) NOT NULL,
    `id` Integer NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`id`)
);

CREATE TABLE `CAA` (
    `nomDirCarrera` VARCHAR(256) NOT NULL,
    `carrera` VARCHAR(256) NOT NULL,
    `refOrganizacion` Integer NOT NULL,
    `sexoDirCarrera` VARCHAR(20) NOT NULL,
    PRIMARY KEY (`refOrganizacion`)
);

CREATE TABLE `PerSol` (
    `refPersona` Integer NOT NULL,
    `refSolicitud` Integer NOT NULL
);

CREATE TABLE `Categoría` (
    `nombre` VARCHAR(256) NOT NULL,
    PRIMARY KEY (`nombre`)
);

CREATE TABLE `SolCat` (
    `refSolicitud` Integer NOT NULL,
    `refCategoria` VARCHAR(256) NOT NULL
);

CREATE TABLE `FedSol` (
    `refFederacion` Integer NOT NULL,
    `refSolicitud` Integer NOT NULL
);

CREATE TABLE `CAASol` (
    `refCAA` Integer NOT NULL,
    `refSolicitud` Integer NOT NULL
);

CREATE TABLE `Resolucion` (
    `numero` Integer NOT NULL,
    `anio` Date NOT NULL,
    `copiaDoc` VARCHAR(256) NOT NULL,
    `refSolicitud` Integer NOT NULL,
    PRIMARY KEY (`numero`)
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
    `id` Integer NOT NULL,
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
    `refPersona` Integer NOT NULL
);

CREATE TABLE `Federacion` (
    `refOrganizacion` Integer NOT NULL,
    `campus` VARCHAR(256) NOT NULL,
    `nomDirDAAE` VARCHAR(256) NOT NULL,
    `sexoDirDAAE` VARCHAR(20) NOT NULL,
    PRIMARY KEY (`refOrganizacion`)
);

ALTER TABLE `CAA` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);
ALTER TABLE `PerSol` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `PerSol` ADD FOREIGN KEY (`refPersona`) REFERENCES `Persona`(`matricula`);
ALTER TABLE `SolCat` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `SolCat` ADD FOREIGN KEY (`refCategoria`) REFERENCES `Categoría`(`nombre`);
ALTER TABLE `FedSol` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `FedSol` ADD FOREIGN KEY (`refFederacion`) REFERENCES `Federacion`(`refOrganizacion`);
ALTER TABLE `CAASol` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `CAASol` ADD FOREIGN KEY (`refCAA`) REFERENCES `CAA`(`refOrganizacion`);
ALTER TABLE `Resolucion` ADD FOREIGN KEY (`refSolicitud`) REFERENCES `Solicitud`(`id`);
ALTER TABLE `Rendicion` ADD FOREIGN KEY (`refResolucion`) REFERENCES `Resolucion`(`numero`);
ALTER TABLE `Documento` ADD FOREIGN KEY (`refCategoria`) REFERENCES `Categoría`(`nombre`);
ALTER TABLE `Documento` ADD FOREIGN KEY (`refRendicion`) REFERENCES `Rendicion`(`id`);
ALTER TABLE `DocPer` ADD FOREIGN KEY (`refPersona`) REFERENCES `Persona`(`matricula`);
ALTER TABLE `DocPer` ADD FOREIGN KEY (`refDocumento`) REFERENCES `Documento`(`numDoc`);
ALTER TABLE `Federacion` ADD FOREIGN KEY (`refOrganizacion`) REFERENCES `Organizacion`(`id`);