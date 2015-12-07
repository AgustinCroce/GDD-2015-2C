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

IF OBJECT_ID('TS.Tipo_Servicio', 'U') IS NOT NULL
  DROP TABLE "TS".Tipo_Servicio
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

CREATE TABLE "TS".Tipo_Servicio
(
	TipoSer_Nombre NVARCHAR(255) PRIMARY KEY,
	TipoSer_Porcentaje NUMERIC(2,2)
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
  Tar_Fecha_Vencimiento NVARCHAR(4) NOT NULL,
  Tar_Codigo_Seguridad NVARCHAR(3) NOT NULL,
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
  Mil_Valida BIT DEFAULT 0,
  Mil_Cantidad NUMERIC(18,0) NOT NULL
);

CREATE TABLE "TS".Compra
(
  Com_PNR NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Com_Forma_Pago NVARCHAR(255) CHECK (Com_Forma_Pago IN('Tarjeta', 'Efectivo')),
  Tar_Numero NUMERIC(18,0) REFERENCES "TS".Tarjeta(Tar_Numero),
  Com_Fecha DATE NOT NULL,
  Com_Cuotas NUMERIC(18,0) DEFAULT 1
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
	@CiudadOrigen NUMERIC(18,0),
	@CiudadDestino NUMERIC(18,0),
	@Aero_Matricula NUMERIC(18,0),
	@Fecha_Salida DATETIME
AS
BEGIN
	DECLARE @Cantidad INT
	SET @Cantidad = (SELECT COUNT(*)
						FROM TS.Viaje as V, TS.Ruta as R, TS.Aeronave as A
						WHERE R.Ruta_Ciudad_Destino = @CiudadDestino AND R.Ruta_Ciudad_Origen = @CiudadOrigen
							AND V.Aero_Num = A.Aero_Num AND A.Aero_Matricula = @Aero_Matricula AND Fecha_Salida = @Fecha_Salida AND Fecha_Llegada IS NULL)
	IF @Cantidad = 0
	BEGIN
		IF ((SELECT COUNT(*)
				FROM TS.Viaje as V, TS.Ruta as R, TS.Aeronave as A
				WHERE R.Ruta_Ciudad_Origen = @CiudadOrigen
				AND V.Aero_Num = A.Aero_Num AND A.Aero_Matricula = @Aero_Matricula AND Fecha_Salida = @Fecha_Salida AND Fecha_Llegada IS NULL) = 1)
		BEGIN
			SET @Cantidad = -1
		END
	END
	
	RETURN @Cantidad
END
GO

IF OBJECT_ID (N'TS.spRegistrarLlegada') IS NOT NULL
   DROP PROCEDURE "TS".spRegistrarLlegada
GO

CREATE PROCEDURE "TS".spRegistrarLlegada
	@CiudadOrigen NUMERIC(18,0),
	@CiudadDestino NUMERIC(18,0),
	@Aero_Matricula NUMERIC(18,0),
	@Fecha_Salida DATETIME,
	@Llegada DATETIME
AS
BEGIN
	DECLARE @Viaj_Cod NUMERIC(18,0) = (SELECT V.Viaj_Cod
						FROM TS.Viaje as V, TS.Ruta as R, TS.Aeronave as A
						WHERE R.Ruta_Ciudad_Destino = @CiudadDestino AND R.Ruta_Ciudad_Origen = @CiudadOrigen
							AND V.Aero_Num = A.Aero_Num AND A.Aero_Matricula = @Aero_Matricula AND Fecha_Salida = @Fecha_Salida AND Fecha_Llegada IS NULL)
	UPDATE TS.Viaje
	SET Fecha_Llegada = @Llegada
	WHERE Viaj_Cod = @Viaj_Cod

	UPDATE TS.Milla
	SET Mil_Valida = 1
	WHERE Mil_Cod IN (SELECT M.Mil_Cod
						FROM TS.Milla AS M, TS.Encomienda as E
						WHERE M.Enc_Cod IS NOT NULL AND E.Enc_Cod = M.Enc_Cod AND E.Viaj_Cod = @Viaj_Cod)

	UPDATE TS.Milla
	SET Mil_Valida = 1
	WHERE Mil_Cod IN (SELECT M.Mil_Cod
						FROM TS.Milla AS M, TS.Pasaje as P
						WHERE M.Pas_Cod IS NOT NULL AND P.Pas_Cod = M.Pas_Cod AND P.Viaj_Cod = @Viaj_Cod)
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



IF OBJECT_ID (N'TS.fnViajesPendientes') IS NOT NULL
   DROP FUNCTION "TS".fnViajesPendientes
GO

CREATE FUNCTION "TS".fnViajesPendientes(@Aero NUMERIC(18,0), @HOY DATETIME)
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	FROM TS.Viaje AS V, TS.Pasaje AS P, TS.Encomienda AS E, TS.Pasaje_Compra AS PC, TS.Encomienda_Compra AS EC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0 AND ((P.Viaj_Cod=V.Viaj_Cod AND PC.Pas_Cod=P.Pas_Cod) OR (E.Viaj_Cod=V.Viaj_Cod AND EC.Enc_Cod=E.Enc_Cod)))
END
GO

IF OBJECT_ID (N'TS.spRemplazarAeroEnDesdeHasta') IS NOT NULL
   DROP PROCEDURE "TS".spRemplazarAeroEnDesdeHasta
GO

CREATE PROCEDURE "TS".spRemplazarAeroEnDesdeHasta
  @Aero NUMERIC(18,0),
  @AeroFutura NUMERIC(18,0),
  @Desde DATETIME,
  @Hasta DATETIME
AS
BEGIN
DECLARE @Viaj_cods TABLE(Viaj_cod NUMERIC(18,0))
  INSERT INTO @Viaj_cods(Viaj_cod)
	SELECT DISTINCT V.Viaj_cod
	FROM TS.Viaje AS V, TS.Pasaje AS P, TS.Pasaje_Compra AS PC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @Desde, V.Fecha_Salida)>0 AND DATEDIFF(minute, @Hasta, V.Fecha_Salida)<0 AND P.Viaj_Cod=V.Viaj_Cod AND PC.Pas_Cod=P.Pas_Cod
	UNION
	SELECT DISTINCT V.Viaj_cod
	FROM TS.Viaje AS V, TS.Encomienda AS E, TS.Encomienda_Compra AS EC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @Desde, V.Fecha_Salida)>0 AND DATEDIFF(minute, @Hasta, V.Fecha_Salida)<0 AND E.Viaj_Cod=V.Viaj_Cod AND EC.Enc_Cod=E.Enc_Cod

  DECLARE @Viaj_Cod NUMERIC(18,0)
  DECLARE tscursor CURSOR FOR SELECT * FROM @Viaj_cods
  OPEN tscursor
  FETCH NEXT FROM tscursor
  INTO @Viaj_Cod
  WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE TS.Viaje SET Aero_Num=@AeroFutura WHERE Viaj_Cod=@Viaj_Cod
		FETCH NEXT FROM tscursor
		INTO @Viaj_Cod
	END
  CLOSE tscursor
  DEALLOCATE tscursoR
  RETURN 0
END
GO

IF OBJECT_ID (N'TS.fnViajesPendientesDesdeHasta') IS NOT NULL
   DROP FUNCTION "TS".fnViajesPendientesDesdeHasta
GO

CREATE FUNCTION "TS".fnViajesPendientesDesdeHasta(@Aero NUMERIC(18,0), @Desde DATETIME, @Hasta DATETIME)
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	FROM TS.Viaje AS V, TS.Pasaje AS P, TS.Encomienda AS E, TS.Pasaje_Compra AS PC, TS.Encomienda_Compra AS EC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @Desde, V.Fecha_Salida)>0 AND DATEDIFF(minute, @Hasta, V.Fecha_Salida)<0 AND ((P.Viaj_Cod=V.Viaj_Cod AND PC.Pas_Cod=P.Pas_Cod) OR (E.Viaj_Cod=V.Viaj_Cod AND EC.Enc_Cod=E.Enc_Cod)))
END
GO

IF OBJECT_ID (N'TS.fnAeronavesParaRemplazarA') IS NOT NULL
   DROP FUNCTION "TS".fnAeronavesParaRemplazarA
GO

CREATE FUNCTION "TS".fnAeronavesParaRemplazarA(@Aero NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	FROM TS.Aeronave AS A, TS.Aeronave AS A2
	WHERE A.Aero_Num=@Aero AND A.Aero_Num!=A2.Aero_Num AND A2.Aero_Fabricante=A.Aero_Fabricante AND A.Aero_Servicio=A2.Aero_Servicio AND A.Aero_Modelo=A2.Aero_Modelo)
END
GO

IF OBJECT_ID (N'TS.fnAeronavesParaRemplazarAEn') IS NOT NULL
   DROP FUNCTION "TS".fnAeronavesParaRemplazarAEn
GO

CREATE FUNCTION "TS".fnAeronavesParaRemplazarAEn(@Aero NUMERIC(18,0), @Viaj_Cod NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	FROM TS.Aeronave AS A, TS.Aeronave AS A2, TS.Viaje AS V
	WHERE A.Aero_Num=@Aero AND A.Aero_Num!=A2.Aero_Num AND A2.Aero_Fabricante=A.Aero_Fabricante AND A.Aero_Servicio=A2.Aero_Servicio AND A.Aero_Modelo=A2.Aero_Modelo
	AND V.Viaj_Cod=@Viaj_Cod
	AND A2.Aero_Cantidad_Kg_Disponibles>=A.Aero_Cantidad_Kg_Disponibles-V.Viaj_Kgs_Disponibles
	AND TS.fnButacasTotales(A2.Aero_Num)>=TS.fnButacasTotales(A.Aero_Num)-V.Viaj_Butacas_Disponibles)
END
GO

IF OBJECT_ID (N'TS.spMigrarCompraEncomienda') IS NOT NULL
   DROP PROCEDURE "TS".spMigrarCompraEncomienda
GO

CREATE PROCEDURE "TS".spMigrarCompraEncomienda
AS
BEGIN
	DECLARE TrEncCursor CURSOR FOR
	SELECT Enc_Cod, Enc_Fecha_Compra, Cli_Cod
	FROM TS.Encomienda

	DECLARE @Enc_Cod NUMERIC(18,0)
	DECLARE @Cli_Cod NUMERIC(18,0)
	DECLARE @Enc_Fecha_Compra DATETIME

	OPEN TrEncCursor
	FETCH NEXT FROM TrEncCursor
	INTO @Enc_Cod, @Enc_Fecha_Compra, @Cli_Cod
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @Com_PNR TABLE
		(
		Com_PNR NUMERIC(18,0)
		);

		INSERT INTO TS.Compra(Com_Fecha, Cli_Cod, Com_Forma_Pago)
		OUTPUT inserted.Com_PNR INTO @Com_PNR
		VALUES(@Enc_Fecha_Compra, @Cli_Cod, 'Efectivo')
		
		INSERT INTO TS.Encomienda_Compra(Enc_Cod, Com_PNR)
		VALUES(@Enc_Cod, (SELECT TOP 1 Com_PNR FROM @Com_PNR))


		DELETE FROM @Com_PNR
		FETCH NEXT FROM TrEncCursor
		INTO @Enc_Cod, @Enc_Fecha_Compra, @Cli_Cod
	END
	CLOSE TrEncCursor
	DEALLOCATE TrEncCursor

	INSERT INTO "TS".Milla(Cli_Cod, Enc_Cod, Mil_Fecha, Mil_Cantidad, Mil_Valida)
	SELECT E.Cli_Cod, E.Enc_Cod, E.Enc_Fecha_Compra, E.Enc_Precio / 10, 1
	FROM "TS".Encomienda as E , "TS".Encomienda_Compra as EC
	WHERE E.Enc_Cod = EC.Enc_Cod
END
GO

IF OBJECT_ID (N'TS.spMigrarCompraPasaje') IS NOT NULL
   DROP PROCEDURE "TS".spMigrarCompraPasaje
GO

CREATE PROCEDURE "TS".spMigrarCompraPasaje
AS
BEGIN
	DECLARE TrPasCursor CURSOR FOR
	SELECT Pas_Cod, Pas_Fecha_Compra, Cli_Cod
	FROM TS.Pasaje

	DECLARE @Pas_Cod NUMERIC(18,0)
	DECLARE @Cli_Cod NUMERIC(18,0)
	DECLARE @Pas_Fecha_Compra DATETIME

	OPEN TrPasCursor
	FETCH NEXT FROM TrPasCursor
	INTO @Pas_Cod, @Pas_Fecha_Compra, @Cli_Cod
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @Com_PNR TABLE
		(
		Com_PNR NUMERIC(18,0)
		);

		INSERT INTO TS.Compra(Com_Fecha, Cli_Cod, Com_Forma_Pago)
		OUTPUT inserted.Com_PNR INTO @Com_PNR
		VALUES(@Pas_Fecha_Compra, @Cli_Cod, 'Efectivo')
		
		INSERT INTO TS.Pasaje_Compra(Pas_Cod, Com_PNR)
		VALUES(@Pas_Cod, (SELECT TOP 1 Com_PNR FROM @Com_PNR))

		DELETE FROM @Com_PNR
		FETCH NEXT FROM TrPasCursor
		INTO @Pas_Cod, @Pas_Fecha_Compra, @Cli_Cod
	END
	CLOSE TrPasCursor
	DEALLOCATE TrPasCursor

	INSERT INTO "TS".Milla(Cli_Cod, Pas_Cod, Mil_Fecha, Mil_Cantidad, Mil_Valida)
	SELECT P.Cli_Cod, P.Pas_Cod, P.Pas_Fecha_Compra, P.Pas_Precio / 10, 1
	FROM "TS".Pasaje as P , "TS".Pasaje_Compra as PC
	WHERE P.Pas_Cod = PC.Pas_Cod
END
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'fnButacasDisponibles' 
)
   DROP FUNCTION "TS".fnButacasDisponibles
GO

CREATE FUNCTION "TS".fnButacasDisponibles(
  @Viaje_Cod NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	DECLARE @Butacas INT;
	DECLARE @ButacasCompradas INT;
	DECLARE @Aeronave NUMERIC(18,0);
	SET @Aeronave = (SELECT Aero_Num FROM TS.Viaje WHERE Viaj_Cod = @Viaje_Cod)
	SET @Butacas = (SELECT COUNT(*) FROM TS.Butaca WHERE Aero_Num = @Aeronave)
	SET @ButacasCompradas = (SELECT COUNT(*) FROM TS.Pasaje_Compra AS PC, TS.Pasaje AS P WHERE P.Viaj_Cod = @Viaje_Cod AND PC.Pas_Cod = P.Pas_Cod)
	RETURN (@Butacas - @ButacasCompradas)
END
GO

IF OBJECT_ID (N'TS.fnButacasTotales') IS NOT NULL
   DROP FUNCTION "TS".fnButacasTotales
GO

CREATE FUNCTION "TS".fnButacasTotales(
  @Aero NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	DECLARE @Butacas INT;
	SET @Butacas = (SELECT COUNT(*) FROM TS.Butaca WHERE Aero_Num = @Aero)
	RETURN (@Butacas)
END
GO

IF OBJECT_ID (N'TS.fnKGsDisponibles') IS NOT NULL
   DROP FUNCTION "TS".fnKGsDisponibles
GO

CREATE FUNCTION "TS".fnKGsDisponibles(
  @Viaje_Cod NUMERIC(18,0))
RETURNS INT
AS
BEGIN
	DECLARE @KGDisponibles INT;
	DECLARE @KgComprados INT;
	DECLARE @Aeronave NUMERIC(18,0);
	SET @Aeronave = (SELECT Aero_Num FROM TS.Viaje WHERE Viaj_Cod = @Viaje_Cod)
	SET @KGDisponibles = (SELECT Aero_Cantidad_Kg_Disponibles FROM TS.Aeronave WHERE Aero_Num = @Aeronave)
	SET @KgComprados = (SELECT ISNULL(SUM(E.Enc_Kg),0) FROM TS.Encomienda_Compra AS EC, TS.Encomienda AS E WHERE E.Viaj_Cod = @Viaje_Cod AND EC.Enc_Cod = E.Enc_Cod)
	RETURN (@KGDisponibles - @KgComprados)
END
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'fnConsultarSaldoMillas' 
)
   DROP FUNCTION "TS".fnConsultarSaldoMillas
GO

CREATE FUNCTION "TS".fnConsultarSaldoMillas(
  @Hoy DATETIME,
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

		SET @Millas= ISNULL((SELECT SUM(Mil_Cantidad)
						FROM "TS".Milla
						WHERE Cli_Cod = @Cli_Cod AND DATEDIFF(DAY, Mil_Fecha, @Hoy) <= 365
						GROUP BY Cli_Cod),0);
		SET @Canjes = ISNULL((SELECT ISNULL(SUM(Canje_Total),0)
						FROM "TS".Canje
						WHERE Cli_Cod = @Cli_Cod AND DATEDIFF(DAY, Canje_Fecha, @Hoy) <= 365
						GROUP BY Cli_Cod),0)
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

IF OBJECT_ID (N'TS.spRemplazarAeroEn') IS NOT NULL
   DROP PROCEDURE "TS".spRemplazarAeroEn
GO

CREATE PROCEDURE "TS".spRemplazarAeroEn
  @Aero NUMERIC(18,0),
  @AeroFutura NUMERIC(18,0),
  @HOY DATETIME
AS
BEGIN
DECLARE @Viaj_cods TABLE(Viaj_cod NUMERIC(18,0))
  INSERT INTO @Viaj_cods(Viaj_cod)
	SELECT DISTINCT V.Viaj_cod
	FROM TS.Viaje AS V, TS.Pasaje AS P, TS.Pasaje_Compra AS PC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0 AND P.Viaj_Cod=V.Viaj_Cod AND PC.Pas_Cod=P.Pas_Cod
	UNION
	SELECT DISTINCT V.Viaj_cod
	FROM TS.Viaje AS V, TS.Encomienda AS E, TS.Encomienda_Compra AS EC
	WHERE V.Aero_Num = @Aero AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0 AND E.Viaj_Cod=V.Viaj_Cod AND EC.Enc_Cod=E.Enc_Cod

  DECLARE @Viaj_Cod NUMERIC(18,0)
  DECLARE tscursor CURSOR FOR SELECT * FROM @Viaj_cods
  OPEN tscursor
  FETCH NEXT FROM tscursor
  INTO @Viaj_Cod
  WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE TS.Viaje SET Aero_Num=@AeroFutura WHERE Viaj_Cod=@Viaj_Cod
		FETCH NEXT FROM tscursor
		INTO @Viaj_Cod
	END
  CLOSE tscursor
  DEALLOCATE tscursoR
  RETURN 0
END
GO

IF OBJECT_ID (N'TS.spAltaViaje') IS NOT NULL
  DROP PROCEDURE "TS".spAltaViaje
GO

CREATE PROCEDURE "TS".spAltaViaje
  @Aero NUMERIC(18, 0),
  @Ruta NUMERIC(18, 0),
  @Fecha_salida DATETIME,
  @Fecha_estimada DATETIME
AS
BEGIN
  DECLARE @Status INT
  DECLARE @Butacas INT;
  DECLARE @KGDisponibles INT;

  DECLARE @OtroViaje INT;
  SET @OtroViaje = (SELECT COUNT(*) FROM TS.Viaje WHERE Aero_Num=@Aero AND DATEDIFF(day, @Fecha_salida, Fecha_Salida)=0)

  IF (@OtroViaje>0)
	BEGIN
		RETURN -1
	END
  SET @Butacas = (SELECT COUNT(*) FROM TS.Butaca WHERE Aero_Num = @Aero)
  SET @KGDisponibles = (SELECT Aero_Cantidad_Kg_Disponibles FROM TS.Aeronave WHERE Aero_Num = @Aero)
  INSERT INTO "TS".Viaje(Fecha_Salida, Fecha_Llegada, Fecha_Llegada_Estimada, Aero_Num, Ruta_Cod, Viaj_Butacas_Disponibles, Viaj_Kgs_Disponibles) 
	VALUES (@Fecha_salida, NULL, @Fecha_estimada, @Aero, @Ruta, @Butacas, @KGDisponibles)
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
  @servicio VARCHAR(255),
  @HOY DATETIME
AS
BEGIN
  DECLARE @Status INT
  DECLARE @StatusButacasV INT
  DECLARE @StatusButacasP INT
  SET @Status = 0
  DECLARE @Matriculas INT
  SET @Matriculas = (SELECT COUNT(*) FROM [GD2C2015].[TS].[Aeronave] WHERE Aero_Matricula = @matricula)

  IF (@Matriculas>0)
	BEGIN
		SET @Status = -1
		RETURN @Status
	END

  INSERT INTO "TS".Aeronave(Aero_Matricula, Aero_Modelo, Aero_Cantidad_Kg_Disponibles, Aero_Fabricante, Aero_Servicio, Aero_Fecha_Fuera_De_Servicio, Aero_Fecha_Reinicio_De_Servicio, Aero_Fecha_Baja_Definitiva, Aero_Fecha_De_Alta)
  VALUES (@matricula, @modelo, @kg_disponibles, @fabricante, @servicio, NULL, NULL, NULL, @HOY)
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

IF OBJECT_ID (N'TS.spFinVidaUtilAeronave') IS NOT NULL
  DROP PROCEDURE "TS".spFinVidaUtilAeronave
GO

CREATE PROCEDURE "TS".spFinVidaUtilAeronave
  @numero NUMERIC(18,0),
  @hoy DATETIME
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Aeronave] SET Aero_Fecha_Baja_Definitiva=@hoy, Aero_Baja_Vida_Util = 1  WHERE Aero_Num = @numero
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spFueraDeServicioAeronave') IS NOT NULL
  DROP PROCEDURE "TS".spFueraDeServicioAeronave
GO

CREATE PROCEDURE "TS".spFueraDeServicioAeronave
  @numero NUMERIC(18,0),
  @Desde DATETIME,
  @Hasta DATETIME
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Aeronave] SET Aero_Baja_Fuera_De_Servicio = 1, Aero_Fecha_Fuera_De_Servicio=@Desde, Aero_Fecha_Reinicio_De_Servicio=@Hasta WHERE Aero_Num = @numero
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
  DECLARE @Matriculas INT
  SET @Matriculas = (SELECT COUNT(*) FROM [GD2C2015].[TS].[Aeronave] WHERE Aero_Matricula = @matricula)

  IF (@Matriculas>0)
	BEGIN
		SET @Status = -1
		RETURN @Status
	END

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

IF OBJECT_ID (N'TS.spBorrarRolFuncionalidad') IS NOT NULL
  DROP PROCEDURE "TS".spBorrarRolFuncionalidad
GO

CREATE PROCEDURE "TS".spBorrarRolFuncionalidad
  @rol VARCHAR(255),
  @funcionalidad NUMERIC(18,0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  DECLARE @CantRolFucionalidad INT
  SET @CantRolFucionalidad = (SELECT COUNT(*) FROM [GD2C2015].[TS].[Rol_Funcionalidad] WHERE Rol_Nombre=@rol AND Func_Cod=@funcionalidad)

  IF @CantRolFucionalidad < 1
  BEGIN
    RETURN -1
  END

  DELETE FROM [GD2C2015].[TS].[Rol_Funcionalidad] WHERE Rol_Nombre=@rol AND Func_Cod=@funcionalidad
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spAltaRolFuncionalidad') IS NOT NULL
  DROP PROCEDURE "TS".spAltaRolFuncionalidad
GO

CREATE PROCEDURE "TS".spAltaRolFuncionalidad
  @rol VARCHAR(255),
  @funcionalidad NUMERIC(18,0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  DECLARE @CantRolFucionalidad INT
  SET @CantRolFucionalidad = (SELECT COUNT(*) FROM [GD2C2015].[TS].[Rol_Funcionalidad] WHERE Rol_Nombre=@rol AND Func_Cod=@funcionalidad)
  IF @CantRolFucionalidad > 0
  BEGIN
    RETURN -1
  END
  INSERT INTO [GD2C2015].[TS].[Rol_Funcionalidad](Rol_Nombre, Func_Cod)
  VALUES (@rol, @funcionalidad)
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
  @HOY DATETIME,
  @Codigo NUMERIC(18,0)
AS
BEGIN
  DECLARE @Status INT
  SET @Status = 0
  UPDATE [GD2C2015].[TS].[Ruta] SET Ruta_Borrada = 1  WHERE Ruta_Cod = @Codigo
 
  DECLARE @Com_PNRs TABLE(Com_PNR NUMERIC(18,0))
  INSERT INTO @Com_PNRs(Com_PNR)
	SELECT DISTINCT PC.Com_PNR
	FROM TS.Pasaje AS P, TS.Viaje AS V, TS.Pasaje_Compra AS PC
	WHERE P.Viaj_cod = V.Viaj_cod AND PC.Pas_Cod = P.Pas_Cod AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0
	UNION
	SELECT DISTINCT EC.Com_PNR
	FROM TS.Encomienda AS E, TS.Viaje AS V, TS.Encomienda_Compra AS EC
	WHERE E.Viaj_cod = V.Viaj_cod AND EC.Enc_Cod = E.Enc_Cod AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0

  DECLARE @Com_PNR NUMERIC(18,0)
  DECLARE tscursor CURSOR FOR SELECT * FROM @Com_PNRs
  OPEN tscursor
  FETCH NEXT FROM tscursor
  INTO @Com_PNR
  WHILE @@FETCH_STATUS = 0
	BEGIN
		EXEC "TS".spCancelarCompraPorRuta @HOY, @Com_PNR, 'Cancelado por borrado de ruta'
		FETCH NEXT FROM tscursor
		INTO @Com_PNR
	END
  CLOSE tscursor
  DEALLOCATE tscursor
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spModificarRuta') IS NOT NULL
  DROP PROCEDURE "TS".spModificarRuta
GO

CREATE PROCEDURE "TS".spModificarRuta
  @HOY DATETIME,
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
  DECLARE @Com_PNRs TABLE(Com_PNR NUMERIC(18,0))
  INSERT INTO @Com_PNRs(Com_PNR)
	SELECT DISTINCT PC.Com_PNR
	FROM TS.Pasaje AS P, TS.Viaje AS V, TS.Pasaje_Compra AS PC
	WHERE P.Viaj_cod = V.Viaj_cod AND PC.Pas_Cod = P.Pas_Cod AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0
	UNION
	SELECT DISTINCT EC.Com_PNR
	FROM TS.Encomienda AS E, TS.Viaje AS V, TS.Encomienda_Compra AS EC
	WHERE E.Viaj_cod = V.Viaj_cod AND EC.Enc_Cod = E.Enc_Cod AND DATEDIFF(minute, @HOY, V.Fecha_Salida)>0

  DECLARE @Com_PNR NUMERIC(18,0)
  DECLARE tscursor CURSOR FOR SELECT * FROM @Com_PNRs
  OPEN tscursor
  FETCH NEXT FROM tscursor
  INTO @Com_PNR
  WHILE @@FETCH_STATUS = 0
	BEGIN
		EXEC "TS".spCancelarCompraPorRuta @HOY, @Com_PNR, 'Cancelado por modificacion de ruta'
		FETCH NEXT FROM tscursor
		INTO @Com_PNR
	END
  CLOSE tscursor
  DEALLOCATE tscursor
  RETURN @Status
END
GO

IF OBJECT_ID (N'TS.spCrearTarjeta') IS NOT NULL
   DROP PROCEDURE "TS".spCrearTarjeta
GO

CREATE PROCEDURE "TS".spCrearTarjeta
  @Cli_Cod NUMERIC(18,0),
  @Tar_Numero NUMERIC(18,0),
  @Tar_Fecha_Vencimiento NVARCHAR(4),
  @Tar_Codigo_Seguridad NVARCHAR(4),
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
  @Tar_Fecha_Vencimiento NVARCHAR(4),
  @Tar_Codigo_Seguridad NVARCHAR(3),
  @TipoTar_Cod NUMERIC(18,0)
AS
BEGIN
	UPDATE TS.Tarjeta
	SET Tar_Codigo_Seguridad = @Tar_Codigo_Seguridad, Tar_Fecha_Vencimiento = @Tar_Fecha_Vencimiento, TipoTar_Cod = @TipoTar_Cod
	WHERE Tar_Numero = @Tar_Numero

	RETURN 0
END
GO
IF OBJECT_ID (N'TS.spCrearCompra') IS NOT NULL
   DROP PROCEDURE "TS".spCrearCompra
GO

IF EXISTS (
	SELECT * 
	FROM sys.types 
	WHERE is_table_type = 1 AND name = 'ListaPasaje'
)
	DROP TYPE TS.ListaPasaje
GO

CREATE TYPE TS.ListaPasaje AS Table (
	Cli_Cod NUMERIC(18,0),
	But_Cod NUMERIC(18,0)
);
GO

CREATE PROCEDURE "TS".spCrearCompra
  @Viaj_Cod NUMERIC(18,0),
  @Com_Fecha DATE,
  @Com_Cli NUMERIC(18,0),
  @Tar_Numero NUMERIC(18,0),
  @Com_Forma_Pago NVARCHAR(255),
  @Com_Cuotas NUMERIC(18,0),
  @Enc_Cli NUMERIC(18,0),
  @Enc_Kgs NUMERIC(18,0),
  @Pas_Lista ListaPasaje READONLY
AS
BEGIN
	DECLARE @Com_PNR TABLE
	(
		Com_PNR NUMERIC(18,0)
	);

	DECLARE @Enc_Cod TABLE
	(
		Enc_Cod NUMERIC(18,0)
	);

	DECLARE @Pas_Cod TABLE
	(
		Pas_Cod NUMERIC(18,0)
	);

	IF (@Com_Forma_Pago = 'Tarjeta')
	BEGIN
		INSERT INTO TS.Compra(Cli_Cod, Com_Fecha, Tar_Numero, Com_Forma_Pago, Com_Cuotas)
		OUTPUT INSERTED.Com_PNR INTO @Com_PNR
		VALUES(@Com_Cli, @Com_Fecha, @Tar_Numero, @Com_Forma_Pago, @Com_Cuotas)
	END
	ELSE
	BEGIN
		INSERT INTO TS.Compra(Cli_Cod, Com_Fecha, Com_Forma_Pago)
		OUTPUT INSERTED.Com_PNR INTO @Com_PNR
		VALUES(@Com_Cli, @Com_Fecha, @Com_Forma_Pago)
	END
	

	DECLARE @Enc_Precio INT = @Enc_Kgs * (SELECT R.Ruta_Precio_Base_Kg 
											FROM TS.Ruta as R, TS.Viaje as V 
											WHERE R.Ruta_Cod = V.Ruta_Cod AND V.Viaj_Cod = @Viaj_Cod)

	IF @Enc_Cli > 0 AND @Enc_Kgs > 0
	BEGIN
		INSERT INTO TS.Encomienda(Cli_Cod, Enc_Fecha_Compra, Enc_Kg, Viaj_Cod, Enc_Precio)
		OUTPUT INSERTED.Enc_Cod INTO @Enc_Cod
		VALUES(@Enc_Cli, @Com_Fecha, @Enc_Kgs, @Viaj_Cod, @Enc_Precio)
	
		INSERT INTO TS.Encomienda_Compra(Com_PNR, Enc_Cod)
		SELECT Com_PNR, Enc_Cod
		FROM @Com_PNR, @Enc_Cod
	END
	

	INSERT INTO TS.Pasaje(Cli_Cod, Pas_Fecha_Compra, But_Cod, Viaj_Cod, Pas_Precio)
	OUTPUT INSERTED.Pas_Cod INTO @Pas_Cod
	SELECT Cli_Cod, @Com_Fecha, But_Cod, @Viaj_Cod, (SELECT R.Ruta_Precio_Base_Pasaje 
														FROM TS.Ruta as R, TS.Viaje as V
														WHERE R.Ruta_Cod = V.Ruta_Cod AND V.Viaj_Cod= @Viaj_Cod)
	FROM @Pas_Lista

	INSERT TS.Pasaje_Compra(Com_PNR, Pas_Cod)
	SELECT Com_PNR, Pas_Cod
	FROM @Com_PNR, @Pas_Cod

	DECLARE @PNR NUMERIC(18,0)
	SET @PNR = (SELECT TOP 1 Com_PNR FROM @Com_PNR)
	
	RETURN @PNR
END
GO

IF OBJECT_ID (N'TS.spCancelarCompra') IS NOT NULL
   DROP PROCEDURE "TS".spCancelarCompra
GO

IF EXISTS (
	SELECT * 
	FROM sys.types 
	WHERE is_table_type = 1 AND name = 'ListaPasajeCod'
)
	DROP TYPE TS.ListaPasajeCod
GO

CREATE TYPE TS.ListaPasajeCod AS Table (
	Pas_Cod NUMERIC(18,0)
);
GO

CREATE PROCEDURE "TS".spCancelarCompra
	@Can_Fecha DATETIME,
	@Com_PNR NUMERIC(18,0),
	@Can_Motivo NVARCHAR(255),
	@Enc_Cod NUMERIC(18,0),
	@ListaPasajes ListaPasajeCod READONLY
AS
BEGIN
	DECLARE @Can_Cod TABLE
	(
		Can_Cod NUMERIC(18,0)
	);
	
	INSERT INTO Cancelacion_Compra(Can_Fecha, Can_Motivo, Com_PNR)
	OUTPUT inserted.Can_Cod INTO @Can_Cod
	VALUES(@Can_Fecha, @Can_Motivo, @Com_PNR)

	IF @Enc_Cod > 0
	BEGIN
		DELETE
		FROM TS.Encomienda_Compra
		WHERE Enc_Cod = @Enc_Cod

		INSERT INTO TS.Encomienda_Cancelacion(Enc_Cod, Can_Cod)
		SELECT @Enc_Cod, Can_Cod
		FROM @Can_Cod
	END

	DELETE
	FROM TS.Pasaje_Compra
	WHERE Pas_Cod IN (SELECT L.Pas_Cod FROM @ListaPasajes as L)

	INSERT INTO TS.Pasaje_Cancelacion(Can_Cod, Pas_Cod)
	SELECT Can_Cod, Pas_Cod
	FROM @Can_Cod, @ListaPasajes

	RETURN 0
END
GO

IF OBJECT_ID (N'TS.spCancelarCompraPorRuta') IS NOT NULL
   DROP PROCEDURE "TS".spCancelarCompraPorRuta
GO

CREATE PROCEDURE "TS".spCancelarCompraPorRuta
	@Can_Fecha DATETIME,
	@Com_PNR NUMERIC(18,0),
	@Can_Motivo NVARCHAR(255)
AS
BEGIN
	DECLARE @Can_Cod TABLE
	(
		Can_Cod NUMERIC(18,0)
	);
	
	INSERT INTO Cancelacion_Compra(Can_Fecha, Can_Motivo, Com_PNR)
	OUTPUT inserted.Can_Cod INTO @Can_Cod
	VALUES(@Can_Fecha, @Can_Motivo, @Com_PNR)

	DECLARE @Enc_Cod NUMERIC(18, 0)
	SET @Enc_Cod = (SELECT Enc_Cod FROM TS.Encomienda_Compra WHERE Com_PNR=@Com_PNR)
	IF (@Enc_Cod != NULL)
		INSERT INTO TS.Encomienda_Cancelacion(Enc_Cod, Can_Cod) SELECT @Enc_Cod, Can_Cod FROM @Can_Cod
	DELETE FROM TS.Encomienda_Compra WHERE Enc_Cod=@Enc_cod
	INSERT INTO TS.Pasaje_Cancelacion(Can_Cod, Pas_Cod) SELECT Can_Cod, P.Pas_Cod FROM @Can_Cod, (SELECT Pas_Cod FROM TS.Pasaje_Compra WHERE Com_PNR=@Com_PNR) AS P
	DELETE FROM TS.Pasaje_Compra WHERE Com_PNR=@Com_PNR

	RETURN 0
END
GO

/* o Top 5 de los destinos con más pasajes comprados. */
IF OBJECT_ID (N'TS.vsDestinoConMasPasajesComprados') IS NOT NULL
   DROP VIEW "TS".vsDestinoConMasPasajesComprados
GO

CREATE VIEW "TS".vsDestinoConMasPasajesComprados
   AS
	SELECT TOP 5 C.Ciudad_Nombre Nombre, COUNT(*) Cantidad
	FROM TS.Pasaje_Compra AS PC, TS.Pasaje AS P, TS.Viaje AS V, TS.Ruta AS R, TS.Ciudad AS C
	WHERE PC.Pas_Cod=P.Pas_Cod AND P.Viaj_Cod=V.Viaj_Cod AND V.Ruta_Cod=R.Ruta_Cod AND R.Ruta_Ciudad_Destino=C.Ciudad_Cod
	GROUP BY C.Ciudad_Nombre
	ORDER BY Cantidad DESC
GO

/* o Top 5 de los destinos con aeronaves más vacías.*/
IF OBJECT_ID (N'TS.vsDestinoAernovesMasVacias') IS NOT NULL
   DROP VIEW "TS".vsDestinoAernovesMasVacias
GO

CREATE VIEW "TS".vsDestinoAernovesMasVacias
   AS
	SELECT TOP 5 C.Ciudad_Nombre Nombre, SUM(TS.fnButacasDisponibles(AE.Aero_Num)) Cantidad
	FROM TS.Pasaje_Compra AS PC, TS.Pasaje AS P, TS.Viaje AS V, TS.Ruta AS R, TS.Ciudad AS C, TS.Aeronave AS AE
	WHERE PC.Pas_Cod=P.Pas_Cod AND P.Viaj_Cod=V.Viaj_Cod AND V.Ruta_Cod=R.Ruta_Cod AND R.Ruta_Ciudad_Destino=C.Ciudad_Cod AND AE.Aero_Num=V.Aero_Num
	GROUP BY C.Ciudad_Nombre
	ORDER BY Cantidad DESC
GO

/* o Top 5 de los Clientes con más puntos acumulados a la fecha*/
IF OBJECT_ID (N'TS.vsClientesConMasMillas') IS NOT NULL
   DROP VIEW "TS".vsClientesConMasMillas
GO

CREATE VIEW "TS".vsClientesConMasMillas
   AS
	SELECT TOP 5 C.Cli_Nombre Nombre, SUM(ISNULL(TS.fnConsultarSaldoMillas(GETDATE(), C.Cli_Cod),0)) Cantidad
	FROM TS.Cliente AS C
	GROUP BY C.Cli_Nombre
	ORDER BY Cantidad DESC
GO

/* o Top 5 de los destinos con pasajes cancelados.*/
IF OBJECT_ID (N'TS.vsDestinosConMasPasajesCancelados') IS NOT NULL
   DROP VIEW "TS".vsDestinosConMasPasajesCancelados
GO

CREATE VIEW "TS".vsDestinosConMasPasajesCancelados
   AS
	SELECT TOP 5 C.Ciudad_Nombre Nombre, COUNT(*) Cantidad
	FROM TS.Pasaje_Cancelacion AS PC, TS.Pasaje AS P, TS.Viaje AS V, TS.Ruta AS R, TS.Ciudad AS C
	WHERE PC.Pas_Cod=P.Pas_Cod AND P.Viaj_Cod=V.Viaj_Cod AND V.Ruta_Cod=R.Ruta_Cod AND R.Ruta_Ciudad_Destino=C.Ciudad_Cod
	GROUP BY C.Ciudad_Nombre
	ORDER BY Cantidad DESC
GO

/* o Top 5 de las aeronaves con mayor cantidad de días fuera de servicio.*/
IF OBJECT_ID (N'TS.fnDiasFueraServicio') IS NOT NULL
   DROP FUNCTION "TS".fnDiasFueraServicio
GO

CREATE FUNCTION "TS".fnDiasFueraServicio(@Aero NUMERIC(18,0)) RETURNS INT
AS
BEGIN
	DECLARE @DiasFueraServicio INT
	SET @DiasFueraServicio = (
		SELECT SUM(ISNULL(DATEDIFF(day, AFS.AudFS_Fecha_Inicio, AFS.AudFS_Fecha_Fin),0))
		FROM TS.Auditoria_Fuera_De_Servicio AS AFS 
		WHERE AFS.Aero_Num=@Aero
		GROUP BY AFS.Aero_Num
	) 
	RETURN @DiasFueraServicio
END
GO

IF OBJECT_ID (N'TS.vsAeronaveMasFueraDeServicio') IS NOT NULL
   DROP VIEW "TS".vsAeronaveMasFueraDeServicio
GO

CREATE VIEW "TS".vsAeronaveMasFueraDeServicio
   AS
	SELECT TOP 5 AE.Aero_Matricula Matricula, SUM(ISNULL("TS".fnDiasFueraServicio(AE.Aero_Num), 0)) Cantidad
	FROM TS.Aeronave AS AE
	GROUP BY AE.Aero_Matricula
	ORDER BY Cantidad DESC
GO

IF OBJECT_ID (N'TS.fnGetViaje') IS NOT NULL
   DROP FUNCTION "TS".fnGetViaje
GO

CREATE FUNCTION "TS".fnGetViaje(
  @Ruta_Destino NVARCHAR(255),
  @Ruta_Origen NVARCHAR(255),
  @Ruta_Codigo NUMERIC(18,0),
  @Ruta_Servicio NVARCHAR(255),
  @Aero_Matricula NVARCHAR(255),
  @Fecha_Salida DATETIME,
  @Fecha_Llegada DATETIME,
  @Fecha_Llegada_Estimada DATETIME
  )
RETURNS NUMERIC(18,0)
AS
BEGIN
	DECLARE @Viaj_Cod NUMERIC(18,0)
	DECLARE @Aero_Num NUMERIC(18,0)
	DECLARE @Ruta_Cod NUMERIC(18,0)

	SET @Aero_Num = (SELECT TOP 1 Aero_Num FROM TS.Aeronave WHERE Aero_Matricula = @Aero_Matricula)
	SET @Ruta_Cod = (SELECT TOP 1 R.Ruta_Cod FROM TS.Ruta as R, TS.Ciudad as C1, Ts.Ciudad as C2 
						WHERE C2.Ciudad_Nombre =  @Ruta_Destino AND C1.Ciudad_Nombre = @Ruta_Origen
						AND R.Ruta_Codigo = @Ruta_Codigo AND R.Ruta_Servicio = @Ruta_Servicio 
						AND R.Ruta_Ciudad_Destino = C2.Ciudad_Cod AND R.Ruta_Ciudad_Origen = C1.Ciudad_Cod)
	SET @Viaj_Cod = (SELECT TOP 1 V.Viaj_Cod
	FROM TS.Viaje as V, "TS".Ruta as R , TS.Ciudad as C1, TS.Ciudad as C2
		WHERE V.Aero_Num = @Aero_Num
			AND V.Ruta_Cod = @Ruta_Cod
			AND V.Fecha_Llegada = @Fecha_Llegada AND V.Fecha_Salida = @Fecha_Salida AND V.Fecha_Llegada_Estimada = @Fecha_Llegada_Estimada)

	RETURN @Viaj_Cod
END
GO

IF OBJECT_ID (N'TS.fnGetButaca') IS NOT NULL
   DROP FUNCTION "TS".fnGetButaca
GO

CREATE FUNCTION "TS".fnGetButaca(
  @But_Numero NUMERIC(18,0),
  @But_Piso NUMERIC(18,0),
  @But_Tipo NVARCHAR(255),
  @Aero_Matricula NVARCHAR(255)
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	DECLARE @But_Cod NUMERIC(18,0)
	DECLARE @Aero_Num NUMERIC(18,0)

	SET @Aero_Num = (SELECT TOP 1 Aero_Num FROM TS.Aeronave WHERE Aero_Matricula = @Aero_Matricula)
	SET @But_Cod = (SELECT TOP 1 But_Cod FROM TS.Butaca WHERE Aero_Num = @Aero_Num AND But_Numero = @But_Numero AND But_Tipo = @But_Tipo AND But_Piso = @But_Piso)

	RETURN @But_Cod
END
GO

IF OBJECT_ID (N'TS.fnGetCliente') IS NOT NULL
   DROP FUNCTION "TS".fnGetCliente
GO

CREATE FUNCTION "TS".fnGetCliente(
  @Cli_Nombre NVARCHAR(255),
  @Cli_Apellido NVARCHAR(255),
  @Cli_DNI NUMERIC(18,0)
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	DECLARE @Cli_Cod NUMERIC(18,0)

	SET @Cli_Cod = (SELECT TOP 1 Cli_Cod FROM TS.Cliente AS Cli WHERE Cli.Cli_DNI = @Cli_DNI AND Cli.Cli_Nombre = @Cli_Apellido + ', ' + @Cli_Nombre) 

	RETURN @Cli_Cod
END
GO

/******************************* INDICES *********************************************/

IF OBJECT_ID (N'ixAeronave') IS NOT NULL
   DROP INDEX ixAeronave ON "TS".Aeronave
GO

CREATE UNIQUE INDEX ixAeronave ON "TS".Aeronave (Aero_Matricula)
GO

IF OBJECT_ID (N'ixCiudad') IS NOT NULL
   DROP INDEX ixCiudad ON "TS".Ciudad
GO

CREATE UNIQUE INDEX ixCiudad ON "TS".Ciudad (Ciudad_Nombre)
GO

IF OBJECT_ID (N'ixRuta') IS NOT NULL
   DROP INDEX ixRuta ON "TS".Ruta
GO

CREATE INDEX ixRuta ON "TS".Ruta (Ruta_Codigo)
GO

IF OBJECT_ID (N'ixCliente') IS NOT NULL
   DROP INDEX ixCliente ON "TS".Ruta
GO

CREATE INDEX ixCliente ON "TS".Cliente (Cli_DNI)
GO

IF OBJECT_ID (N'TS.trCompraPasaje') IS NOT NULL
   DROP TRIGGER "TS".trCompraPasaje
GO

IF OBJECT_ID (N'TS.trCancelacionEncomienda') IS NOT NULL
   DROP TRIGGER "TS".CancelacionEncomienda
GO

IF OBJECT_ID (N'TS.trCancelacionPasaje') IS NOT NULL
   DROP TRIGGER "TS".CancelacionPasaje
GO

IF OBJECT_ID (N'TS.trCompraEncomienda') IS NOT NULL
   DROP TRIGGER "TS".trCompraEncomienda
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

INSERT INTO "TS".Tipo_Servicio(TipoSer_Nombre, TipoSer_Porcentaje) VALUES
  ('Primera Clase', 0.8),
  ('Ejecutivo', 0.4),
  ('Turista', 0.2);

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

 
INSERT INTO "TS".Ruta(Ruta_Codigo, Ruta_Precio_Base_Kg, Ruta_Precio_Base_Pasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Servicio)
SELECT e.Ruta_Codigo, e.Ruta_Precio_BaseKG, p.Ruta_Precio_BasePasaje, C1.Ciudad_Cod, C2.Ciudad_Cod, e.Tipo_Servicio
FROM (SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BaseKG, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Tipo_Servicio
		FROM GD2C2015.gd_esquema.Maestra
		WHERE Ruta_Precio_BaseKG > 0) as e,
	(SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Tipo_Servicio
		FROM GD2C2015.gd_esquema.Maestra
		WHERE Ruta_Precio_BasePasaje > 0) as p, TS.Ciudad as C1, TS.Ciudad as C2
WHERE e.Ruta_Codigo = p.Ruta_Codigo AND e.Ruta_Ciudad_Origen = p.Ruta_Ciudad_Origen 
      AND e.Ruta_Ciudad_Destino = p.Ruta_Ciudad_Destino 
      AND e.Tipo_Servicio = p.Tipo_Servicio
	  AND e.Ruta_Ciudad_Origen = C1.Ciudad_Nombre
	  AND e.Ruta_Ciudad_Destino = C2.Ciudad_Nombre

INSERT INTO "TS".Viaje(Fecha_Salida, Fecha_Llegada, Fecha_Llegada_Estimada, Aero_Num, Ruta_Cod)
SELECT DISTINCT M.FechaSalida, M.FechaLLegada, M.Fecha_LLegada_Estimada, Aero_Num, R.Ruta_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Aeronave, "TS".Ruta as R, "TS".Ciudad as C1, "TS".Ciudad as C2
WHERE Aero_Matricula=Aeronave_Matricula
AND R.Ruta_Codigo = M.Ruta_Codigo AND R.Ruta_Servicio = M.Tipo_Servicio AND R.Ruta_Ciudad_Destino = C2.Ciudad_Cod AND R.Ruta_Ciudad_Origen = C1.Ciudad_Cod
AND M.Ruta_Codigo IS NOT NULL

SET IDENTITY_INSERT "TS".Pasaje ON;

INSERT INTO "TS".Pasaje(Pas_Cod, Pas_Fecha_Compra, Pas_Precio, Viaj_Cod, Cli_Cod, But_Cod)
SELECT DISTINCT M.Pasaje_Codigo, M.Pasaje_FechaCompra, M.Pasaje_Precio ,
	TS.fnGetViaje(M.Ruta_Ciudad_Destino, M.Ruta_Ciudad_Origen, M.Ruta_Codigo, M.Tipo_Servicio, M.Aeronave_Matricula, M.FechaSalida, M.FechaLLegada, M.Fecha_LLegada_Estimada) Viaj_Cod,
	Cli.Cli_Cod Cli_Cod,
	TS.fnGetButaca(M.Butaca_Nro, M.Butaca_Piso, M.Butaca_Tipo, M.Aeronave_Matricula) But_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Cliente as Cli
WHERE Pasaje_Codigo > 0
AND Cli.Cli_Nombre = M.Cli_Apellido + ', ' + M.Cli_Nombre AND Cli.Cli_DNI = M.Cli_Dni 

SET IDENTITY_INSERT "TS".Pasaje OFF;

SET IDENTITY_INSERT "TS".Encomienda ON;

INSERT INTO "TS".Encomienda(Enc_Cod, Enc_Fecha_Compra, Enc_Kg, Enc_Precio, Viaj_Cod, Cli_Cod)
SELECT DISTINCT Paquete_Codigo, Paquete_FechaCompra, Paquete_KG, Paquete_Precio, 
	"TS".fnGetViaje(M.Ruta_Ciudad_Destino, M.Ruta_Ciudad_Origen, M.Ruta_Codigo, M.Tipo_Servicio, M.Aeronave_Matricula, M.FechaSalida, M.FechaLLegada, M.Fecha_LLegada_Estimada) Viaj_Cod, Cli.Cli_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Cliente as Cli
WHERE Paquete_Codigo > 0
AND Cli.Cli_Nombre = M.Cli_Apellido + ', ' + M.Cli_Nombre AND Cli.Cli_DNI = M.Cli_Dni

SET IDENTITY_INSERT "TS".Encomienda OFF;

/*** ACTUALIZACIÓN DE VIAJES CON BUTACAS Y KGS ***/
UPDATE TS.Viaje
SET Viaj_Butacas_Disponibles = TS.fnButacasDisponibles(Viaj_Cod),
	Viaj_Kgs_Disponibles = TS.fnKGsDisponibles(Viaj_Cod)

EXEC "TS".spMigrarCompraEncomienda;

EXEC "TS".spMigrarCompraPasaje ;

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

		UPDATE TS.Viaje
		SET Viaj_Butacas_Disponibles = Viaj_Butacas_Disponibles - (SELECT COUNT(*) FROM TS.Viaje as V, TS.Pasaje as P, inserted as I WHERE V.Viaj_Cod = P.Pas_Cod AND I.Pas_Cod = P.Pas_Cod)
		WHERE Viaj_Cod IN (SELECT V.Viaj_Cod FROM TS.Viaje as V, TS.Pasaje as P, inserted as I WHERE V.Viaj_Cod = P.Pas_Cod AND I.Pas_Cod = P.Pas_Cod)

	END
END
GO


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

		UPDATE TS.Viaje
		SET Viaj_Kgs_Disponibles = Viaj_Kgs_Disponibles - (SELECT SUM(Enc_Kg) FROM TS.Viaje as V, TS.Encomienda as E, inserted as I WHERE V.Viaj_Cod = E.Viaj_Cod AND I.Enc_Cod = E.Enc_Cod)
		WHERE Viaj_Cod IN (SELECT V.Viaj_Cod FROM TS.Viaje as V, TS.Encomienda as E, inserted as I WHERE V.Viaj_Cod = E.Viaj_Cod AND I.Enc_Cod = E.Enc_Cod)
	END
END
GO

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

		UPDATE TS.Viaje
		SET Viaj_Butacas_Disponibles = Viaj_Butacas_Disponibles + (SELECT COUNT(*) FROM TS.Viaje as V, TS.Pasaje as P, inserted as I WHERE V.Viaj_Cod = P.Pas_Cod AND I.Pas_Cod = P.Pas_Cod)
		WHERE Viaj_Cod IN (SELECT V.Viaj_Cod FROM TS.Viaje as V, TS.Pasaje as P, inserted as I WHERE V.Viaj_Cod = P.Pas_Cod AND I.Pas_Cod = P.Pas_Cod)
	END
END
GO

CREATE TRIGGER "TS".CancelacionEncomienda ON "TS".Encomienda_Cancelacion AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) >= 1
	BEGIN
		DELETE
		FROM "TS".Milla
		WHERE Enc_Cod IN (SELECT I.Enc_Cod FROM inserted as I)

		UPDATE TS.Viaje
		SET Viaj_Kgs_Disponibles = Viaj_Kgs_Disponibles + (SELECT SUM(Enc_Kg) FROM TS.Viaje as V, TS.Encomienda as E, inserted as I WHERE V.Viaj_Cod = E.Viaj_Cod AND I.Enc_Cod = E.Enc_Cod)
		WHERE Viaj_Cod IN (SELECT V.Viaj_Cod FROM TS.Viaje as V, TS.Encomienda as E, inserted as I WHERE V.Viaj_Cod = E.Viaj_Cod AND I.Enc_Cod = E.Enc_Cod)
	END
END
GO