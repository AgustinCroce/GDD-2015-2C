USE GD2C2015;
GO

SET LANGUAGE Spanish

/*********************************** CREACIÓN DEL SCHEMA **************************************/
IF NOT EXISTS
(
  SELECT  schema_name
  FROM    information_schema.schemata
  WHERE   schema_name = 'TS'
)

BEGIN
  EXEC sp_executesql N'CREATE SCHEMA "TS" AUTHORIZATION gd'
END


/********************************** BORRADO DE TABLAS **************************************/

IF OBJECT_ID('TS.Butaca_Pasaje', 'U') IS NOT NULL
  DROP TABLE "TS".Butaca_Pasaje
GO

IF OBJECT_ID('TS.Encomienda_Compra', 'U') IS NOT NULL
  DROP TABLE "TS".Encomienda_Compra
GO

IF OBJECT_ID('TS.Encomienda_Cancelacion', 'U') IS NOT NULL
  DROP TABLE "TS".Encomienda_Cancelacion
GO

IF OBJECT_ID('TS.Pasaje_Compra', 'U') IS NOT NULL
  DROP TABLE "TS".Pasaje_Compra
GO

IF OBJECT_ID('TS.Pasaje_Cancelacion', 'U') IS NOT NULL
  DROP TABLE "TS".Pasaje_Cancelacion
GO

IF OBJECT_ID('TS.Cancelacion_Compra', 'U') IS NOT NULL
  DROP TABLE "TS".Cancelacion_Compra
GO

IF OBJECT_ID('TS.Compra', 'U') IS NOT NULL
  DROP TABLE "TS".Compra
GO

IF OBJECT_ID('TS.Milla', 'U') IS NOT NULL
  DROP TABLE "TS".Milla
GO

IF OBJECT_ID('TS.Encomienda', 'U') IS NOT NULL
  DROP TABLE "TS".Encomienda
GO

IF OBJECT_ID('TS.Pasaje', 'U') IS NOT NULL
  DROP TABLE "TS".Pasaje
GO

IF OBJECT_ID('TS.Viaje', 'U') IS NOT NULL
  DROP TABLE "TS".Viaje
GO

IF OBJECT_ID('TS.Ruta', 'U') IS NOT NULL
  DROP TABLE "TS".Ruta
GO

IF OBJECT_ID('TS.Tarjeta', 'U') IS NOT NULL
  DROP TABLE "TS".Tarjeta
GO

IF OBJECT_ID('TS.Butaca', 'U') IS NOT NULL
  DROP TABLE "TS".Butaca
GO

IF OBJECT_ID('TS.Auditoria_Fuera_De_Servicio', 'U') IS NOT NULL
  DROP TABLE "TS".Auditoria_Fuera_De_Servicio
GO

IF OBJECT_ID('TS.Ciudad', 'U') IS NOT NULL
  DROP TABLE "TS".Ciudad
GO

IF OBJECT_ID('TS.Tipo_Tarjeta', 'U') IS NOT NULL
  DROP TABLE "TS".Tipo_Tarjeta
GO

IF OBJECT_ID('TS.Aeronave', 'U') IS NOT NULL
  DROP TABLE "TS".Aeronave
GO

IF OBJECT_ID('TS.Canje', 'U') IS NOT NULL
  DROP TABLE "TS".Canje
GO

IF OBJECT_ID('TS.Rol_Funcionalidad', 'U') IS NOT NULL
  DROP TABLE "TS".Rol_Funcionalidad
GO

IF OBJECT_ID('TS.Funcionalidad', 'U') IS NOT NULL
  DROP TABLE "TS".Funcionalidad
GO

IF OBJECT_ID('TS.Rol_Usuario', 'U') IS NOT NULL
  DROP TABLE "TS".Rol_Usuario
GO

IF OBJECT_ID('TS.Rol', 'U') IS NOT NULL
  DROP TABLE "TS".Rol
GO

IF OBJECT_ID('TS.Usuario', 'U') IS NOT NULL
  DROP TABLE "TS".Usuario
GO

IF OBJECT_ID('TS.Cliente', 'U') IS NOT NULL
  DROP TABLE "TS".Cliente
GO

IF OBJECT_ID('TS.Producto', 'U') IS NOT NULL
  DROP TABLE "TS".Producto
GO

DROP TABLE #RutasxEncomienda
DROP TABLE #RutasxPasaje

/********************************** CREACIÓN DE TABLAS **************************************/

CREATE TABLE "TS".Funcionalidad
(
  Func_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(12,1),
  Func_Nombre NVARCHAR(255), 
  Func_Borrado BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE "TS".Rol
(
  Rol_Nombre NVARCHAR(255) PRIMARY KEY,
  Rol_Estado NVARCHAR(255) CHECK (Rol_Estado IN('Habilitado', 'Deshabilitado')),
  Rol_Borrado BIT NOT NULL DEFAULT 0
);

CREATE TABLE "TS".Rol_Funcionalidad
(
  Rol_Nombre NVARCHAR(255) NOT NULL REFERENCES "TS".Rol(Rol_Nombre),
  Func_Cod NUMERIC(18,0) NOT NULL REFERENCES "TS".Funcionalidad(Func_Cod),
  PRIMARY KEY(Rol_Nombre, Func_Cod)
);

CREATE TABLE "TS".Usuario
(
  Usr_Username NVARCHAR(255) PRIMARY KEY,
  Usr_Password NVARCHAR(255) NOT NULL,
  Usr_Intentos_Login INT DEFAULT 0,
  Usr_Borrado BIT NOT NULL DEFAULT 0,
  Usr_Estado NVARCHAR(255) DEFAULT 'Habilitado' NOT NULL CHECK (Usr_Estado IN('Habilitado', 'Deshabilitado'))
);

CREATE TABLE "TS".Rol_Usuario
(
  Rol_Nombre NVARCHAR(255) REFERENCES "TS".Rol(Rol_Nombre),
  Usr_Username NVARCHAR(255) REFERENCES "TS".Usuario(Usr_Username),
  Rol_Usuario_Borrado BIT NOT NULL DEFAULT 0,
  PRIMARY KEY(Rol_Nombre, Usr_Username)
);

CREATE TABLE "TS".Cliente
(
  Cli_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Nombre NVARCHAR(255) NOT NULL,
  Cli_Direccion NVARCHAR(255) NOT NULL,
  Cli_Tel NVARCHAR(255) NOT NULL,
  Cli_Mail NVARCHAR(255),
  Cli_Fecha_Nacimiento DATE NOT NULL,
  Cli_DNI NVARCHAR(255) NOT NULL
);

CREATE TABLE "TS".Producto
(
  Prod_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Prod_Nombre NVARCHAR(255) NOT NULL,
  Prod_Stock INT DEFAULT 0,
  Prod_Valor INT DEFAULT 0
);

CREATE TABLE "TS".Canje
(
  Canje_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Prod_Cod NUMERIC(18,0) REFERENCES "TS".Producto(Prod_Cod),
  Canje_Cantidad_Prod INT DEFAULT 1,
  Canje_Fecha DATE NOT NULL,
  Canje_Total INT DEFAULT 0
);

CREATE TABLE "TS".Aeronave
(
  Aero_Num NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Aero_Fecha_De_Alta DATE NOT NULL,
  Aero_Modelo NVARCHAR(255) NOT NULL,
  Aero_Matricula NVARCHAR(255) NOT NULL,
  Aero_Fabricante NVARCHAR(255) NOT NULL,
  Aero_Servicio NVARCHAR(255) NOT NULL,
  Aero_Baja_Fuera_De_Servicio BIT NOT NULL DEFAULT 0,
  Aero_Baja_Vida_Util BIT NOT NULL DEFAULT 0,
  Aero_Fecha_Fuera_De_Servicio DATE,
  Aero_Fecha_Reinicio_De_Servicio DATE,
  Aero_Fecha_Baja_Definitiva DATE,
  Aero_Cantidad_Kg_Disponibles NUMERIC(18,0) NOT NULL,
  Aero_Borrado BIT NOT NULL DEFAULT 0
);

CREATE TABLE "TS".Tipo_Tarjeta
(
  TipoTar_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  TipoTar_Nombre NVARCHAR(255) NOT NULL,
  TipoTar_Cuotas INT DEFAULT 0
);

CREATE TABLE "TS".Ciudad
(
  Ciudad_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(12,1),
  Ciudad_Nombre NVARCHAR(255),
  Ciudad_Borrada BIT NOT NULL DEFAULT 0
);

CREATE TABLE "TS".Auditoria_Fuera_De_Servicio
(
  AudFS_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Aero_Num NUMERIC(18,0) REFERENCES "TS".Aeronave(Aero_Num),
  AudFS_Fecha_Inicio DATE NOT NULL,
  AudFS_Fecha_Fin DATE NOT NULL
);

CREATE TABLE "TS".Butaca
(
  But_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Aero_Num NUMERIC(18,0) REFERENCES "TS".Aeronave(Aero_Num),
  But_Numero NUMERIC(18,0) NOT NULL,
  But_Piso NUMERIC(18,0) NOT NULL,
  But_Tipo NVARCHAR(255) NOT NULL,
  But_Borrada BIT NOT NULL DEFAULT 0
);

CREATE TABLE "TS".Tarjeta
(
  Tar_Numero NUMERIC(18,0) PRIMARY KEY,
  Tar_Fecha_Vencimiento NUMERIC(4,0) NOT NULL,
  Tar_Codigo_Seguridad NUMERIC(18,0) NOT NULL,
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  TipoTar_Cod NUMERIC(18,0) REFERENCES "TS".Tipo_Tarjeta(TipoTar_Cod)
);

CREATE TABLE "TS".Ruta
(
  Ruta_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Ruta_Codigo NUMERIC(18,0) NOT NULL,
  Ruta_Ciudad_Origen NUMERIC(18,0) REFERENCES "TS".Ciudad(Ciudad_Cod),
  Ruta_Ciudad_Destino NUMERIC(18,0) REFERENCES "TS".Ciudad(Ciudad_Cod),
  Ruta_Precio_Base_Kg NUMERIC(18,2) NOT NULL DEFAULT 0,
  Ruta_Precio_Base_Pasaje NUMERIC(18,2) NOT NULL DEFAULT 0,
  Ruta_Servicio NVARCHAR(255) NOT NULL,
  Ruta_Borrada BIT NOT NULL DEFAULT 0
);

CREATE TABLE "TS".Viaje
(
  Viaj_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Viaj_Kgs_Disponibles NUMERIC(18,0) DEFAULT 0,
  Viaj_Butacas_Disponibles NUMERIC(18,0) DEFAULT 0,
  Fecha_Salida DATETIME NOT NULL,
  Fecha_Llegada DATETIME,
  Fecha_Llegada_Estimada DATETIME NOT NULL,
  Aero_Num NUMERIC(18,0) REFERENCES "TS".Aeronave(Aero_Num),
  Ruta_Cod NUMERIC(18,0) REFERENCES "TS".Ruta(Ruta_Cod)
);

CREATE TABLE "TS".Pasaje
(
  Pas_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Viaj_Cod NUMERIC(18,0) REFERENCES "TS".Viaje(Viaj_Cod),
  But_Cod NUMERIC(18,0) REFERENCES "TS".Butaca(But_Cod),
  Pas_Fecha_Compra DATE NOT NULL,
  Pas_Precio NUMERIC(18,2) NOT NULL
);

CREATE TABLE "TS".Encomienda
(
  Enc_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Viaj_Cod NUMERIC(18,0) REFERENCES "TS".Viaje(Viaj_Cod),
  Enc_Kg NUMERIC(18,0) NOT NULL,
  Enc_Fecha_Compra DATE NOT NULL,
  Enc_Precio NUMERIC(18,2) NOT NULL
);

CREATE TABLE "TS".Milla
(
  Mil_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Enc_Cod NUMERIC(18,0) REFERENCES "TS".Encomienda(Enc_Cod),
  Pas_Cod NUMERIC(18,0) REFERENCES "TS".Pasaje(Pas_Cod),
  Mil_Fecha DATE NOT NULL,
  Mil_Cantidad NUMERIC(18,0) NOT NULL
);

CREATE TABLE "TS".Compra
(
  Com_PNR NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Com_Forma_Pago NVARCHAR(255) CHECK (Com_Forma_Pago IN('Tarjeta', 'Efectivo')),
  Tar_Numero NUMERIC(18,0) REFERENCES "TS".Tarjeta(Tar_Numero),
  Com_Fecha DATE NOT NULL
);

CREATE TABLE "TS".Cancelacion_Compra
(
  Can_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Can_Fecha DATE NOT NULL,
  Com_PNR NUMERIC(18,0) REFERENCES "TS".Compra(Com_PNR),
  Can_Motivo NVARCHAR(255)
);

CREATE TABLE "TS".Butaca_Pasaje
(
  But_Cod NUMERIC(18,0) REFERENCES "TS".Butaca(But_Cod),
  Pas_Cod NUMERIC(18,0) REFERENCES "TS".Pasaje(Pas_Cod),
  PRIMARY KEY(But_Cod, Pas_Cod)
);

CREATE TABLE "TS".Pasaje_Compra
(
  Pas_Cod NUMERIC(18,0) REFERENCES "TS".Pasaje(Pas_Cod),
  Com_PNR NUMERIC(18,0) REFERENCES "TS".Compra(Com_PNR),
  PRIMARY KEY(Pas_Cod, Com_PNR)
);

CREATE TABLE "TS".Pasaje_Cancelacion
(
  Can_Cod NUMERIC(18,0) REFERENCES "TS".Cancelacion_Compra(Can_Cod),
  Pas_Cod NUMERIC(18,0) REFERENCES "TS".Pasaje(Pas_Cod),
  PRIMARY KEY(Pas_Cod, Can_Cod)
);

CREATE TABLE "TS".Encomienda_Cancelacion
(
  Can_Cod NUMERIC(18,0) REFERENCES "TS".Cancelacion_Compra(Can_Cod),
  Enc_Cod NUMERIC(18,0) REFERENCES "TS".Encomienda(Enc_Cod), 
  PRIMARY KEY(Enc_Cod, Can_Cod)
);

CREATE TABLE "TS".Encomienda_Compra
(
  Com_PNR NUMERIC(18,0) REFERENCES "TS".Compra(Com_PNR),
  Enc_Cod NUMERIC(18,0) REFERENCES "TS".Encomienda(Enc_Cod),
  PRIMARY KEY(Enc_Cod, Com_PNR)
);

/************************************ FN Y PRODCEDURES *********************************************/
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'spRealizarLogin' 
)
   DROP PROCEDURE "TS".spRealizarLogin
GO

CREATE PROCEDURE "TS".spRealizarLogin 
  @Username NVARCHAR (255), 
  @Password NVARCHAR (255)
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @Nro_fallo int = 0
  DECLARE @ValorRetorno int
  
  IF (SELECT COUNT(*) FROM [GD2C2015].[TS].[Usuario] WHERE Usr_Username = @Username AND Usr_Password = @Password AND Usr_Estado = 'Habilitado') = 1
    BEGIN
       SET @Nro_fallo = 0
       SET @ValorRetorno = 0
    END
  ELSE 
    BEGIN
      IF (SELECT COUNT(*) FROM [GD2C2015].[TS].[Usuario] WHERE Usr_Username = @Username) = 1
      BEGIN
        IF (SELECT COUNT(*) FROM [GD2C2015].[TS].[Usuario] WHERE Usr_Username = @Username AND Usr_Password = @Password AND Usr_Estado = 'Deshabilitado') = 1
        BEGIN
          SET @ValorRetorno = 3
        END
        ELSE
        BEGIN
          SET @Nro_fallo = (SELECT TOP 1 Usr_Intentos_Login
            FROM [GD2C2015].[TS].[Usuario]
            WHERE Usr_Username = @Username) + 1
          SET @ValorRetorno = 1
        END
      END
      ELSE
      BEGIN
        SET @ValorRetorno = 2
      END
      
    END
  
  IF(@Nro_fallo = 3)
    BEGIN
      UPDATE [GD2C2015].[TS].[Usuario] SET Usr_Intentos_Login = @Nro_fallo, Usr_Estado = 'Deshabilitado' WHERE Usr_Username = @Username
    END
  ELSE
    BEGIN
      UPDATE [GD2C2015].[TS].[Usuario] SET Usr_Intentos_Login = @Nro_fallo WHERE Usr_Username = @Username
    END
  
  RETURN(@ValorRetorno)
END
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'spCrearRol' 
)
   DROP PROCEDURE "TS".spCrearRol
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'spEditarRol' 
)
   DROP PROCEDURE "TS".spEditarRol
GO

IF EXISTS (
	SELECT * 
	FROM sys.types 
	WHERE is_table_type = 1 AND name = 'ListaNumeric'
)
	DROP TYPE "TS".ListaNumeric
GO

CREATE TYPE "TS".ListaNumeric AS Table (
    number Numeric(18,0)
);
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'fnValidarCreacionRol' 
)
   DROP FUNCTION "TS".fnValidarCreacionRol
GO

CREATE FUNCTION "TS".fnValidarCreacionRol(
	@Rol_Nombre NVARCHAR(255) 
	)
	RETURNS INT
AS
BEGIN
	IF (SELECT COUNT(*) FROM [GD2C2015].[TS].[Rol] WHERE Rol_Nombre = @Rol_Nombre ) >= 1
	BEGIN
		RETURN(1)
	END
	
	RETURN(0)
END
GO

CREATE PROCEDURE "TS".spCrearRol
	@Rol_Nombre varchar(255),
	@Rol_Estado varchar(255),
	@Lista_Funcionalidades As "TS".ListaNumeric READONLY
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Validacion INT = "TS".fnValidarCreacionRol(@Rol_Nombre)
	
	IF(@Validacion = 0)
	BEGIN
	INSERT INTO [GD2C2015].[TS].[Rol](Rol_Nombre, Rol_Estado)
	VALUES (@Rol_Nombre, @Rol_Estado)
	
	INSERT INTO [GD2C2015].[TS].[Rol_Funcionalidad](Rol_Nombre, Func_Cod)
	SELECT @Rol_Nombre, number FROM @Lista_Funcionalidades
	END
	
	RETURN @Validacion
END
GO

CREATE PROCEDURE "TS".spEditarRol
	@Rol_Pk     varchar(255),
	@Rol_Nombre varchar(255),
	@Rol_Estado varchar(255),
	@Lista_Funcionalidades As "TS".ListaNumeric READONLY
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE [GD2C2015].[TS].[Rol_Funcionalidad]
	WHERE Rol_Nombre = @Rol_Pk
	
	UPDATE [GD2C2015].[TS].[Rol]
	SET Rol_Nombre = @Rol_Nombre, Rol_Estado = @Rol_Estado
	WHERE Rol_Nombre = @Rol_Pk
	
	INSERT INTO [GD2C2015].[TS].[Rol_Funcionalidad](Rol_Nombre, Func_Cod)
	SELECT @Rol_Nombre, number FROM @Lista_Funcionalidades
END
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'spDeshabilitarRol' 
)
   DROP PROCEDURE "TS".spDeshabilitarRol
GO

CREATE PROCEDURE "TS".spDeshabilitarRol
	@Rol_Pk varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [GD2C2015].[TS].[Rol]
	SET Rol_Estado = 'Deshabilitado'
	WHERE Rol_Nombre = @Rol_Pk
END
GO

IF OBJECT_ID (N'TS.spHabilitarUsuario') IS NOT NULL
   DROP PROCEDURE "TS".spHabilitarUsuario
GO

CREATE PROCEDURE "TS".spHabilitarUsuario
	@Usr_Username varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD2C2015].[TS].[Usuario]
	SET Usr_Estado = 'Habilitado'
	WHERE Usr_Username = @Usr_Username

END
GO

IF OBJECT_ID (N'TS.spDeshabilitarUsuario') IS NOT NULL
   DROP PROCEDURE "TS".spDeshabilitarUsuario
GO

CREATE PROCEDURE "TS".spDeshabilitarUsuario
	@Usr_Username varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD2C2015].[TS].[Usuario]
	SET Usr_Estado = 'Deshabilitado'
	WHERE Usr_Username = @Usr_Username

END
GO

IF OBJECT_ID (N'TS.spConsultarViaje') IS NOT NULL
   DROP PROCEDURE "TS".spConsultarViaje
GO

CREATE PROCEDURE "TS".spConsultarViaje
	@CiudadOrigen varchar(255),
	@CiudadDestino varchar(255),
	@AeroNum Numeric(18,0)
AS
BEGIN
	DECLARE @Cantidad INT
	SET @Cantidad = (SELECT COUNT(*)
						FROM TS.Viaje as V, TS.Ruta as R
						WHERE V.Ruta_Cod = R.Ruta_Cod AND R.Ruta_Ciudad_Origen = @CiudadOrigen
						AND R.Ruta_Ciudad_Destino = @CiudadDestino AND V.Aero_Num = @AeroNum AND V.Fecha_Llegada = NULL)
	RETURN @Cantidad
END
GO

IF OBJECT_ID (N'TS.spRegistrarLlegada') IS NOT NULL
   DROP PROCEDURE "TS".spRegistrarLlegada
GO

CREATE PROCEDURE "TS".spRegistrarLlegada
	@ViajeCod Numeric(18,0),
	@Llegada Datetime
AS
BEGIN
	UPDATE TS.Viaje
	SET Fecha_Llegada = @Llegada
	WHERE Viaj_Cod = @ViajeCod
END
GO

IF OBJECT_ID (N'TS.spRegistrarLlegadaUnica') IS NOT NULL
   DROP PROCEDURE "TS".spRegistrarLlegadaUnica
GO

CREATE PROCEDURE "TS".spRegistrarLlegadaUnica
	@CiudadOrigen varchar(255),
	@CiudadDestino varchar(255),
	@AeroNum Numeric(18,0),
	@Llegada Datetime
AS
BEGIN
	DECLARE @ViajeCod Numeric(18,0)
	SET @ViajeCod = (SELECT V.Viaj_Cod
						FROM TS.Viaje as V, TS.Ruta as R
						WHERE V.Ruta_Cod = R.Ruta_Cod AND R.Ruta_Ciudad_Origen = @CiudadOrigen
						AND R.Ruta_Ciudad_Destino = @CiudadDestino AND V.Aero_Num = @AeroNum AND V.Fecha_Llegada = NULL)
	EXEC TS.spRegistrarLlegada @ViajeCod, @Llegada
END
GO

IF OBJECT_ID (N'TS.trCompraPasaje') IS NOT NULL
   DROP TRIGGER "TS".trCompraPasaje
GO

CREATE TRIGGER "TS".trCompraPasaje ON "TS".Pasaje_Compra AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) >= 1
	BEGIN
		INSERT INTO "TS".Milla(Cli_Cod, Pas_Cod, Mil_Fecha, Mil_Cantidad)
		SELECT P.Cli_Cod, P.Pas_Cod, P.Pas_Fecha_Compra, P.Pas_Precio / 10
		FROM "TS".Pasaje as P , inserted as I
		WHERE P.Pas_Cod = I.Pas_Cod
	END

	IF (SELECT COUNT(*) FROM deleted) >= 1
	BEGIN
		DELETE
		FROM "TS".Milla
		WHERE Pas_Cod IN (SELECT D.Pas_Cod FROM deleted as D)
	END

END

IF OBJECT_ID (N'TS.trCompraEncomienda') IS NOT NULL
   DROP TRIGGER "TS".trCompraEncomienda
GO

CREATE TRIGGER "TS".trCompraEncomienda ON "TS".Encomienda_Compra AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) >= 1
	BEGIN
		INSERT INTO "TS".Milla(Cli_Cod, Enc_Cod, Mil_Fecha, Mil_Cantidad)
		SELECT E.Cli_Cod, E.Enc_Cod, E.Enc_Fecha_Compra, E.Enc_Precio / 10
		FROM "TS".Encomienda as E , inserted as I
		WHERE E.Enc_Cod = I.Enc_Cod
	END

	IF (SELECT COUNT(*) FROM deleted) >= 1
	BEGIN
		DELETE
		FROM "TS".Milla
		WHERE Enc_Cod IN (SELECT D.Enc_Cod FROM deleted as D)
	END

END

IF OBJECT_ID (N'TS.trCancelacionPasaje') IS NOT NULL
   DROP TRIGGER "TS".CancelacionPasaje
GO

CREATE TRIGGER "TS".CancelacionPasaje ON "TS".Pasaje_Cancelacion AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) >= 1
	BEGIN
		DELETE
		FROM "TS".Milla
		WHERE Pas_Cod IN (SELECT I.Pas_Cod FROM inserted as I)
	END

	IF (SELECT COUNT(*) FROM deleted) >= 1
	BEGIN
		INSERT INTO "TS".Milla(Cli_Cod, Pas_Cod, Mil_Fecha, Mil_Cantidad)
		SELECT P.Cli_Cod, P.Pas_Cod, P.Pas_Fecha_Compra, P.Pas_Precio / 10
		FROM "TS".Pasaje as P , deleted as D
		WHERE P.Pas_Cod = D.Pas_Cod
	END

END

IF OBJECT_ID (N'TS.trCancelacionEncomienda') IS NOT NULL
   DROP TRIGGER "TS".CancelacionEncomienda
GO

CREATE TRIGGER "TS".CancelacionEncomienda ON "TS".Encomienda_Cancelacion AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) >= 1
	BEGIN
		DELETE
		FROM "TS".Milla
		WHERE Enc_Cod IN (SELECT I.Enc_Cod FROM inserted as I)
	END

	IF (SELECT COUNT(*) FROM deleted) >= 1
	BEGIN
		INSERT INTO "TS".Milla(Cli_Cod, Enc_Cod, Mil_Fecha, Mil_Cantidad)
		SELECT E.Cli_Cod, E.Enc_Cod, E.Enc_Fecha_Compra, E.Enc_Precio / 10
		FROM "TS".Encomienda as E , deleted as D
		WHERE E.Enc_Cod = D.Enc_Cod
	END

END

IF OBJECT_ID (N'TS.fnConsultarSaldoMillas') IS NOT NULL
   DROP FUNCTION "TS".fnConsultarSaldoMillas
GO

CREATE FUNCTION "TS".fnConsultarSaldoMillas(
  @Hoy DATE,
  @Cli_Cod NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	DECLARE @Millas INT;
	DECLARE @Canjes INT;
	DECLARE @Saldo INT;

	IF (SELECT COUNT(*) FROM "TS".Cliente WHERE Cli_Cod = @Cli_Cod) = 0
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN

		SET @Millas= (SELECT SUM(Mil_Cantidad)
						FROM "TS".Milla
						WHERE Cli_Cod = @Cli_Cod AND DATEDIFF(DAY, Mil_Fecha, @Hoy) <= 365
						GROUP BY Cli_Cod);
		SET @Canjes = (SELECT SUM(Canje_Total)
						FROM "TS".Canje
						WHERE Cli_Cod = @Cli_Cod AND DATEDIFF(DAY, Canje_Fecha, @Hoy) <= 365
						GROUP BY Cli_Cod)
		SET @Saldo = @Millas - @Canjes
		
		IF @Saldo <= 0
		BEGIN
			RETURN 0
		END
	END
	RETURN @Saldo
END
GO

IF OBJECT_ID (N'TS.fnConsultarButacas') IS NOT NULL
   DROP FUNCTION "TS".fnConsultarButacas
GO

CREATE FUNCTION "TS".fnConsultarButacas(
  @Viaj_Cod NUMERIC(18,0),
  @Cantidad INT)
RETURNS INT
AS
BEGIN
	DECLARE @Butacas INT
	DECLARE @Retorno INT

	SET @Retorno = 1
	SET @Butacas = (SELECT Viaj_Butacas_Disponibles FROM TS.Viaje WHERE Viaj_Cod = @Viaj_Cod) 
	 
	IF (@Butacas >= @Cantidad)
	BEGIN
		SET @Retorno = 0
	END

	RETURN @Retorno
END
GO

IF OBJECT_ID (N'TS.fnConsultarKgs') IS NOT NULL
   DROP FUNCTION "TS".fnConsultarKgs
GO

CREATE FUNCTION "TS".fnConsultarKgs(
  @Viaj_Cod NUMERIC(18,0),
  @Kgs INT)
RETURNS INT
AS
BEGIN
	DECLARE @KgsDisponibles INT
	DECLARE @Retorno INT
	
	SET @Retorno = 1	
	SET @KgsDisponibles = (SELECT Viaj_Kgs_Disponibles FROM TS.Viaje WHERE Viaj_Cod = @Viaj_Cod) 
	 
	IF (@KgsDisponibles >= @Kgs)
	BEGIN
		SET @Retorno = 0
	END

	RETURN @Retorno
END
GO


IF OBJECT_ID (N'TS.spRegistrarCanje') IS NOT NULL
   DROP PROCEDURE "TS".spRegistrarCanje
GO

CREATE PROCEDURE "TS".spRegistrarCanje
  @Cli_Cod NUMERIC(18,0),
  @Cli_DNI NVARCHAR(255),
  @Prod_Cod NUMERIC(18,0),
  @Canje_Cantidad_Prod INT,
  @Canje_Fecha DATE
AS
BEGIN
	DECLARE @Saldo INT;
	SET @Saldo = "TS".fnConsultarSaldoMillas(@Canje_Fecha, @Cli_Cod);

	IF(SELECT Prod_Stock FROM "TS".Producto WHERE Prod_Cod = @Prod_Cod) < @Canje_Cantidad_Prod
	BEGIN
		RETURN -2
	END

	IF(SELECT COUNT(*) FROM "TS".Cliente WHERE Cli_Cod = @Cli_Cod AND Cli_DNI = @Cli_DNI) = 0
	BEGIN
		RETURN -1
	END

	IF(@Saldo = 0 )
	BEGIN
		RETURN @Saldo
	END
	ELSE
	BEGIN
		DECLARE @Costo INT;
		SET @Costo = (SELECT Prod_Valor FROM "TS".Producto WHERE Prod_Cod = @Prod_Cod)

		INSERT INTO "TS".Canje(Cli_Cod, Prod_Cod, Canje_Cantidad_Prod, Canje_Fecha, Canje_Total)
		VALUES(@Cli_Cod, @Prod_Cod, @Canje_Cantidad_Prod, @Canje_Fecha, @Costo * @Canje_Cantidad_Prod)
		
		UPDATE "TS".Producto
		SET Prod_Stock = Prod_Stock - @Canje_Cantidad_Prod
		WHERE Prod_Cod = @Prod_Cod
		
		RETURN 0
	END
END
GO

IF OBJECT_ID (N'TS.spEditarCliente') IS NOT NULL
   DROP PROCEDURE "TS".spEditarCliente
GO

CREATE PROCEDURE "TS".spEditarCliente
  @Cli_Cod NUMERIC(18,0),
  @Cli_Nombre NVARCHAR(255),
  @Cli_Direccion NVARCHAR(255),
  @Cli_Tel NVARCHAR(255),
  @Cli_Mail NVARCHAR(255),
  @Cli_Fecha_Nacimiento DATE,
  @Cli_DNI NVARCHAR(255)
AS
BEGIN
	DECLARE @CantDni INT
	SET @CantDni = (SELECT COUNT(*) FROM TS.Cliente WHERE Cli_DNI = @Cli_DNI AND Cli_Cod != @Cli_Cod)

	IF @CantDni > 0 
	BEGIN
		RETURN -1
	END

	UPDATE TS.Cliente
	SET Cli_DNI = @Cli_DNI, Cli_Direccion = @Cli_Direccion, Cli_Nombre = @Cli_Nombre, 
		Cli_Tel = @Cli_Tel, Cli_Mail = @Cli_Mail, Cli_Fecha_Nacimiento = @Cli_Fecha_Nacimiento
	WHERE Cli_Cod = @Cli_Cod

	RETURN 0
END
GO

IF OBJECT_ID (N'TS.spCrearCliente') IS NOT NULL
   DROP PROCEDURE "TS".spCrearCliente
GO

CREATE PROCEDURE "TS".spCrearCliente
  @Cli_Nombre NVARCHAR(255),
  @Cli_Direccion NVARCHAR(255),
  @Cli_Tel NVARCHAR(255),
  @Cli_Mail NVARCHAR(255),
  @Cli_Fecha_Nacimiento DATE,
  @Cli_DNI NVARCHAR(255)
AS
BEGIN
	DECLARE @CantDni INT
	SET @CantDni = (SELECT COUNT(*) FROM TS.Cliente WHERE Cli_DNI = @Cli_DNI)

	IF @CantDni > 0 
	BEGIN
		RETURN -1
	END

	INSERT INTO TS.Cliente(Cli_DNI, Cli_Direccion, Cli_Nombre, Cli_Tel, Cli_Mail, Cli_Fecha_Nacimiento)
	VALUES(@Cli_DNI, @Cli_Direccion, @Cli_Nombre, @Cli_Tel, @Cli_Mail, @Cli_Fecha_Nacimiento)

	RETURN 0
END
GO

IF OBJECT_ID (N'TS.spGenerarButacas') IS NOT NULL
  DROP PROCEDURE "TS".spGenerarButacas
GO

CREATE PROCEDURE "TS".spGenerarButacas
  @AeronaveNum NUMERIC(18, 0),
  @cantidad INT,
  @tipo VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  DECLARE @Butacas INT
  SET @Butacas = @cantidad
  WHILE @Butacas <> 0
  BEGIN
    SET @Butacas = @Butacas - 1
    INSERT INTO "TS".Butaca(Aero_Num, But_Numero, But_Piso, But_Tipo)
    VALUES (@AeronaveNum, @Butacas, 1, @tipo)
  END
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spAltaAeronave') IS NOT NULL
  DROP PROCEDURE "TS".spAltaAeronave
GO

CREATE PROCEDURE "TS".spAltaAeronave
  @butacas_v INT,
  @butacas_p INT,
  @modelo VARCHAR(255),
  @matricula VARCHAR(255),
  @fabricante VARCHAR(255),
  @kg_disponibles NUMERIC(18,0),
  @servicio VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  DECLARE @StatusButacasV INT
  DECLARE @StatusButacasP INT
  SET @Status = 0
  INSERT INTO "TS".Aeronave(Aero_Matricula, Aero_Modelo, Aero_Cantidad_Kg_Disponibles, Aero_Fabricante, Aero_Servicio, Aero_Fecha_Fuera_De_Servicio, Aero_Fecha_Reinicio_De_Servicio, Aero_Fecha_Baja_Definitiva, Aero_Fecha_De_Alta)
  VALUES (@matricula, @modelo, @kg_disponibles, @fabricante, @servicio, NULL, NULL, NULL, GETDATE())
  DECLARE @AeronaveNum NUMERIC(18, 0)
  SET @AeronaveNum = (SELECT Aero_Num FROM [GD2C2015].[TS].[Aeronave] WHERE Aero_Matricula = @matricula AND Aero_Modelo = @modelo)
  EXEC "TS".spGenerarButacas @AeronaveNum, @butacas_p, 'Pasillo'
  EXEC "TS".spGenerarButacas @AeronaveNum, @butacas_v, 'Ventanilla'
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spBorrarAeronave') IS NOT NULL
  DROP PROCEDURE "TS".spBorrarAeronave
GO

CREATE PROCEDURE "TS".spBorrarAeronave
  @numero NUMERIC(18,0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Aeronave] SET Aero_Borrado = 1  WHERE Aero_Num = @numero
  UPDATE [GD2C2015].[TS].[Butaca] SET But_Borrada = 1  WHERE Aero_Num = @numero
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spModificarAeronave') IS NOT NULL
  DROP PROCEDURE "TS".spModificarAeronave
GO

CREATE PROCEDURE "TS".spModificarAeronave
  @modelo VARCHAR(255),
  @matricula VARCHAR(255),
  @fabricante VARCHAR(255),
  @kg_disponibles NUMERIC(18,0),
  @numero NUMERIC(18,0),
  @servicio VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Aeronave]
  SET
    Aero_Modelo = @modelo,
    Aero_Matricula = @matricula,
    Aero_Fabricante = @fabricante,
    Aero_Servicio = @servicio,
    Aero_Cantidad_Kg_Disponibles = @kg_disponibles
  WHERE Aero_Num = @numero
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spAltaCiudad') IS NOT NULL
  DROP PROCEDURE "TS".spAltaCiudad
GO

CREATE PROCEDURE "TS".spAltaCiudad
  @nombre VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  INSERT INTO "TS".Ciudad(Ciudad_Nombre)
  VALUES (@nombre)
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spBorrarCiudad') IS NOT NULL
  DROP PROCEDURE "TS".spBorrarCiudad
GO

CREATE PROCEDURE "TS".spBorrarCiudad
  @Codigo NUMERIC(18, 0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Ciudad] SET Ciudad_Borrada = 1  WHERE Ciudad_Cod = @Codigo
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spModificarCiudad') IS NOT NULL
  DROP PROCEDURE "TS".spModificarCiudad
GO

CREATE PROCEDURE "TS".spModificarCiudad
  @codigo NUMERIC(18, 0),
  @nombre VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Ciudad] SET Ciudad_Nombre = @nombre  WHERE Ciudad_Cod = @codigo
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spAltaRol') IS NOT NULL
  DROP PROCEDURE "TS".spAltaRol
GO

CREATE PROCEDURE "TS".spAltaRol
  @nombre VARCHAR(255),
  @estado VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  INSERT INTO "TS".Rol(Rol_Nombre, Rol_Estado)
  VALUES (@nombre, @estado)
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spBorrarRol') IS NOT NULL
  DROP PROCEDURE "TS".spBorrarRol
GO

CREATE PROCEDURE "TS".spBorrarRol
  @nombre VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Rol] SET Rol_Borrado = 1  WHERE Rol_Nombre = @nombre
  UPDATE [GD2C2015].[TS].[Rol_Usuario] SET Rol_Usuario_Borrado = 1 WHERE Rol_Nombre = @nombre
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spHabilitarRol') IS NOT NULL
  DROP PROCEDURE "TS".spHabilitarRol
GO

CREATE PROCEDURE "TS".spHabilitarRol
  @nombre VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Rol] SET Rol_Estado = 'Habilitado'  WHERE Rol_Nombre = @nombre
  UPDATE [GD2C2015].[TS].[Rol_Usuario] SET Rol_Usuario_Borrado = 0 WHERE Rol_Nombre = @nombre
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spDeshabilitarRol') IS NOT NULL
  DROP PROCEDURE "TS".spDeshabilitarRol
GO

CREATE PROCEDURE "TS".spDeshabilitarRol
  @nombre VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Rol] SET Rol_Estado = 'Deshabilitado'  WHERE Rol_Nombre = @nombre
  UPDATE [GD2C2015].[TS].[Rol_Usuario] SET Rol_Usuario_Borrado = 1 WHERE Rol_Nombre = @nombre
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spModificarRol') IS NOT NULL
  DROP PROCEDURE "TS".spModificarRol
GO

CREATE PROCEDURE "TS".spModificarRol
  @nombre VARCHAR(255),
  @estado VARCHAR(255)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  IF (@estado = 'Habilitado')
	EXEC "TS".spHabilitarRol @nombre
  ELSE IF (@Status = 'Deshabilitado')
	EXEC "TS".spDeshabilitarRol @nombre
  ELSE
	SET @Status = -1
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spAltaRuta') IS NOT NULL
  DROP PROCEDURE "TS".spAltaRuta
GO

CREATE PROCEDURE "TS".spAltaRuta
  @origen NUMERIC(18,0),
  @destino NUMERIC(18,0),
  @servicio VARCHAR(255),
  @codigo NUMERIC(18,0),
  @precio_kg NUMERIC(18,2),
  @precio_pasaje NUMERIC(18,2)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  INSERT INTO "TS".Ruta(Ruta_Codigo, Ruta_Precio_Base_Kg, Ruta_Precio_Base_Pasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Servicio) VALUES
    (@codigo, @precio_kg, @precio_pasaje, @origen, @destino, @servicio)
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spBorrarRuta') IS NOT NULL
  DROP PROCEDURE "TS".spBorrarRuta
GO

CREATE PROCEDURE "TS".spBorrarRuta
  @Codigo NUMERIC(18,0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Ruta] SET Ruta_Borrada = 1  WHERE Ruta_Cod = @Codigo
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spModificarRuta') IS NOT NULL
  DROP PROCEDURE "TS".spModificarRuta
GO

CREATE PROCEDURE "TS".spModificarRuta
  @origen NUMERIC(18,0),
  @destino NUMERIC(18,0),
  @servicio VARCHAR(255),
  @codigo NUMERIC(18,0),
  @codigo_unico NUMERIC(18,0),
  @precio_kg NUMERIC(18,2),
  @precio_pasaje NUMERIC(18,2)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Ruta]
  SET
    Ruta_Codigo = @codigo,
    Ruta_Ciudad_Origen = @origen,
    Ruta_Ciudad_Destino = @destino,
    Ruta_Precio_Base_Kg = @precio_kg,
    Ruta_Precio_Base_Pasaje = @precio_pasaje,
    Ruta_Servicio = @servicio
  WHERE Ruta_Cod = @codigo_unico
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spCrearTarjeta') IS NOT NULL
   DROP PROCEDURE "TS".spCrearTarjeta
GO

CREATE PROCEDURE "TS".spCrearTarjeta
  @Cli_Cod NUMERIC(18,0),
  @Tar_Numero NUMERIC(18,0),
  @Tar_Fecha_Vencimiento NUMERIC(4,0),
  @Tar_Codigo_Seguridad NUMERIC(18,0),
  @TipoTar_Cod NUMERIC(18,0)
AS
BEGIN
	DECLARE @CantTar INT
	SET @CantTar = (SELECT COUNT(*) FROM TS.Tarjeta WHERE Tar_Numero = @Tar_Numero)

	IF @CantTar > 0 
	BEGIN
		RETURN -1
	END

	INSERT INTO TS.Tarjeta(Cli_Cod, Tar_Numero, Tar_Codigo_Seguridad, Tar_Fecha_Vencimiento, TipoTar_Cod)
	VALUES(@Cli_Cod, @Tar_Numero, @Tar_Codigo_Seguridad, @Tar_Fecha_Vencimiento, @TipoTar_Cod)

	RETURN 0
END
GO

IF OBJECT_ID (N'TS.spEditarTarjeta') IS NOT NULL
   DROP PROCEDURE "TS".spEditarTarjeta
GO

CREATE PROCEDURE "TS".spEditarTarjeta
  @Tar_Numero NUMERIC(18,0),
  @Tar_Fecha_Vencimiento NUMERIC(4,0),
  @Tar_Codigo_Seguridad NUMERIC(18,0),
  @TipoTar_Cod NUMERIC(18,0)
AS
BEGIN
	UPDATE TS.Tarjeta
	SET Tar_Codigo_Seguridad = @Tar_Codigo_Seguridad, Tar_Fecha_Vencimiento = @Tar_Fecha_Vencimiento, TipoTar_Cod = @TipoTar_Cod
	WHERE Tar_Numero = @Tar_Numero

	RETURN 0
END
GO

/******************************* MIGRACION *********************************************/

SET IDENTITY_INSERT "TS".Funcionalidad ON

INSERT INTO "TS".Funcionalidad(Func_Cod, Func_Nombre) VALUES 
  (1, 'ABM de Rol'),
  (2, 'ABM de Usuario'),
  (3, 'ABM de Ciudades'),
  (4, 'ABM de Ruta Aerea'),
  (5, 'ABM de Aeronaves'),
  (6, 'Registrar Viaje'),
  (7, 'Registro de Llegada Destino'),
  (8, 'Compra de Pasaje o Encomienda'),
  (9, 'Cancelacion de Pasaje o Encomienda'),
  (10, 'Consulta de Millas de Pasajero Frecuente'),
  (11, 'Canje de Millas de Pasajero Frecuente'),
  (12, 'Listado Estadistico');

SET IDENTITY_INSERT "TS".Funcionalidad OFF

INSERT INTO "TS".Rol(Rol_Nombre, Rol_Estado) VALUES
  ('Administrador', 'Habilitado'),
  ('Cliente', 'Habilitado');

INSERT INTO "TS".Rol_Funcionalidad(Func_Cod, Rol_Nombre) VALUES
  (1, 'Administrador'),
  (2, 'Administrador'),
  (3, 'Administrador'),
  (4, 'Administrador'),
  (5, 'Administrador'),
  (6, 'Administrador'),
  (7, 'Administrador'),
  (8, 'Administrador'),
  (8, 'Cliente'),
  (9, 'Administrador'),
  (10, 'Cliente'),
  (11, 'Cliente'),
  (12, 'Administrador');

INSERT INTO "TS".Producto(Prod_Nombre, Prod_Stock, Prod_Valor) VALUES
  ('Llavero', 1000, 30),
  ('Viaje a Jujuy', 5, 100000),
  ('Computadora', 12, 30000),
  ('Tostadora', 123, 10000);

INSERT INTO "TS".Tipo_Tarjeta(TipoTar_Nombre, TipoTar_Cuotas) VALUES
  ('VISA', 12),
  ('MASTERCARD', 6),
  ('CREDICOP', 3),
  ('ICBC', 1),
  ('FRBA PLUS', 120);

/*********** INSERTO 3 USUARIOS ADMIN, ADMIN2 Y ADMIN3 CON PASSWORD w23e **********************/
INSERT INTO "TS".Usuario(Usr_Username, Usr_Password, Usr_Intentos_Login, Usr_Borrado) VALUES
  ('admin1', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 0),
  ('admin2', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 0),
  ('admin3', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 0);

INSERT INTO "TS".Rol_Usuario(Rol_Nombre, Usr_Username) VALUES
  ('Administrador', 'admin1'),
  ('Administrador', 'admin2'),
  ('Administrador', 'admin3');

/*********** MIGRACION **********************/
INSERT INTO "TS".Cliente(Cli_Nombre, Cli_Direccion, Cli_Tel, Cli_Mail, Cli_Fecha_Nacimiento, Cli_DNI)
SELECT DISTINCT Cli_Apellido + ', ' + Cli_Nombre, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac, Cli_Dni
FROM GD2C2015.gd_esquema.Maestra
WHERE Cli_Dni IS NOT NULL;

INSERT INTO "TS".Aeronave(Aero_Matricula, Aero_Modelo, Aero_Cantidad_Kg_Disponibles, Aero_Fabricante, Aero_Servicio, Aero_Fecha_Fuera_De_Servicio, Aero_Fecha_Reinicio_De_Servicio, Aero_Fecha_Baja_Definitiva, Aero_Fecha_De_Alta)
SELECT DISTINCT Aeronave_Matricula, Aeronave_Modelo, Aeronave_KG_Disponibles, Aeronave_Fabricante, Tipo_Servicio, NULL, NULL, NULL, GETDATE()
FROM GD2C2015.gd_esquema.Maestra
WHERE Aeronave_Matricula IS NOT NULL;

INSERT INTO "TS".Ciudad(Ciudad_Nombre)
SELECT DISTINCT LTRIM(Ruta_Ciudad_Destino) Ciudad
FROM GD2C2015.gd_esquema.Maestra 
WHERE Ruta_Ciudad_Destino IS NOT NULL
UNION
SELECT DISTINCT Ruta_Ciudad_Origen Ciudad
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Ciudad_Origen IS NOT NULL;

INSERT INTO "TS".Butaca(Aero_Num, But_Numero, But_Piso, But_Tipo)
SELECT DISTINCT Aero_Num, Butaca_Nro, Butaca_Piso, Butaca_Tipo
FROM GD2C2015.gd_esquema.Maestra, "TS".Aeronave
WHERE Aero_Matricula=Aeronave_Matricula AND Butaca_Tipo != '0';

SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BaseKG, Ruta_Ciudad_Origen, 
				  Ruta_Ciudad_Destino, Tipo_Servicio
INTO #RutasXEncomienda
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Precio_BaseKG > 0

SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, 
				  Ruta_Ciudad_Destino, Tipo_Servicio
INTO #RutasXPasaje
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Precio_BasePasaje > 0
  
INSERT INTO "TS".Ruta(Ruta_Codigo, Ruta_Precio_Base_Kg, Ruta_Precio_Base_Pasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Servicio)
SELECT e.Ruta_Codigo, e.Ruta_Precio_BaseKG, p.Ruta_Precio_BasePasaje, C1.Ciudad_Cod, C2.Ciudad_Cod, e.Tipo_Servicio
FROM #RutasXEncomienda as e, #RutasXPasaje as p, TS.Ciudad as C1, TS.Ciudad as C2
WHERE e.Ruta_Codigo = p.Ruta_Codigo AND e.Ruta_Ciudad_Origen = p.Ruta_Ciudad_Origen 
      AND e.Ruta_Ciudad_Destino = p.Ruta_Ciudad_Destino 
      AND e.Tipo_Servicio = p.Tipo_Servicio
	  AND e.Ruta_Ciudad_Origen = C1.Ciudad_Nombre
	  AND e.Ruta_Ciudad_Destino = C2.Ciudad_Nombre

INSERT INTO "TS".Viaje(Fecha_Salida, Fecha_Llegada, Fecha_Llegada_Estimada, Aero_Num, Ruta_Cod)
SELECT DISTINCT M.FechaSalida, M.FechaLLegada, M.Fecha_LLegada_Estimada, Aero_Num, R.Ruta_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Aeronave, "TS".Ruta as R
WHERE Aero_Matricula=Aeronave_Matricula
AND R.Ruta_Codigo=M.Ruta_Codigo
AND M.Ruta_Codigo IS NOT NULL

SET IDENTITY_INSERT "TS".Pasaje ON;

INSERT INTO "TS".Pasaje(Pas_Cod, Pas_Fecha_Compra, Pas_Precio, Viaj_Cod, Cli_Cod, But_Cod)
SELECT DISTINCT M.Pasaje_Codigo, M.Pasaje_FechaCompra, M.Pasaje_Precio ,V.Viaj_Cod, Cli.Cli_Cod, B.But_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Ruta as R, "TS".Cliente as Cli, TS.Viaje as V, "TS".Aeronave as A, "TS".Butaca as B, TS.Ciudad as C1, TS.Ciudad as C2
WHERE Pasaje_Codigo > 0
AND A.Aero_Matricula = M.Aeronave_Matricula
AND C2.Ciudad_Nombre = M.Ruta_Ciudad_Destino AND C1.Ciudad_Nombre = M.Ruta_Ciudad_Origen
AND R.Ruta_Codigo = M.Ruta_Codigo AND R.Ruta_Servicio = M.Tipo_Servicio AND R.Ruta_Ciudad_Destino = C2.Ciudad_Cod AND R.Ruta_Ciudad_Origen = C1.Ciudad_Cod
AND Cli.Cli_Nombre = M.Cli_Apellido + ', ' + M.Cli_Nombre AND Cli.Cli_DNI = M.Cli_Dni 
AND V.Ruta_Cod = R.Ruta_Cod AND V.Fecha_Salida = M.FechaSalida AND V.Fecha_Llegada_Estimada = M.Fecha_LLegada_Estimada AND V.Aero_Num = A.Aero_Num AND V.Fecha_Llegada = M.FechaLLegada
AND M.Butaca_Nro = B.But_Numero AND M.Butaca_Piso = B.But_Piso AND M.Butaca_Tipo = B.But_Tipo AND V.Aero_Num = B.Aero_Num

SET IDENTITY_INSERT "TS".Pasaje OFF;

SET IDENTITY_INSERT "TS".Encomienda ON;

INSERT INTO "TS".Encomienda(Enc_Cod, Enc_Fecha_Compra, Enc_Kg, Enc_Precio, Viaj_Cod, Cli_Cod)
SELECT DISTINCT Paquete_Codigo, Paquete_FechaCompra, Paquete_KG, Paquete_Precio, R.Ruta_Cod, Cli.Cli_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Ruta as R, "TS".Butaca as B, "TS".Cliente as Cli, TS.Ciudad as C1, TS.Ciudad as C2
WHERE Paquete_Codigo > 0
AND C2.Ciudad_Nombre = M.Ruta_Ciudad_Destino AND C1.Ciudad_Nombre = M.Ruta_Ciudad_Origen
AND R.Ruta_Codigo = M.Ruta_Codigo AND R.Ruta_Servicio = M.Tipo_Servicio AND R.Ruta_Ciudad_Destino = C2.Ciudad_Cod AND R.Ruta_Ciudad_Origen = C1.Ciudad_Cod
AND Cli.Cli_Nombre = M.Cli_Apellido + ', ' + M.Cli_Nombre AND Cli.Cli_DNI = M.Cli_Dni

SET IDENTITY_INSERT "TS".Encomienda OFF;

INSERT INTO "TS".Pasaje_Compra(Pas_Cod, Com_PNR)
SELECT DISTINCT P.Pas_Cod, C.Com_PNR
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Compra AS C, "TS".Pasaje AS P
WHERE Pasaje_Codigo > 0
AND P.Pas_Cod = M.Pasaje_Codigo
/*** AND COMPRA ***/

INSERT INTO "TS".Pasaje_Cancelacion(Can_Cod, Pas_Cod)
SELECT DISTINCT Can_Cod, Pas_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Pasaje AS P, "TS".Cancelacion_Compra AS C
WHERE Pasaje_Codigo > 0
AND P.Pas_Cod = M.Pasaje_Codigo
/*** AND CANCELACION ***/

INSERT INTO "TS".Encomienda_Cancelacion(Can_Cod, Enc_Cod)
SELECT DISTINCT Can_Cod, Enc_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Encomienda AS E, "TS".Cancelacion_Compra AS C
WHERE Paquete_Codigo > 0
AND E.Enc_Cod = M.Paquete_Codigo
/*** AND CANCELACION ***/

INSERT INTO "TS".Encomienda_Compra(Com_PNR, Enc_Cod)
SELECT DISTINCT Com_PNR, Enc_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Compra AS C, "TS".Encomienda AS E
WHERE Paquete_Codigo > 0
AND E.Enc_Cod = M.Paquete_Codigo
/*** AND COMPRA ***/