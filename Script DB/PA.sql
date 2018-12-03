Delimiter $$

/*Consulta*/
DROP PROCEDURE IF EXISTS leertodos_solicitudes  $$
CREATE PROCEDURE leertodos_solicitudes ()
BEGIN
	SELECT id, estado, fecha, monto, nombreEvento, fechaEvento, encargado, lugarEvento
	FROM Solicitud;
END
$$


/*Crear*/
DROP PROCEDURE IF EXISTS crear_solicitud $$
CREATE PROCEDURE crear_solicitud
(
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
$$