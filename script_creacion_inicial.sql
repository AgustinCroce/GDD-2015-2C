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
  Usr_Fecha_Creacion DATETIME NOT NULL,
  Usr_Fecha_Ultima_Modificacion DATETIME NOT NULL,
  Usr_Pregunta_Secreta NVARCHAR(255) NOT NULL,
  Usr_Respuesta_Secreta NVARCHAR(255) NOT NULL,
  Usr_Intentos_Login INT DEFAULT 0,
  Usr_Borrado BIT NOT NULL DEFAULT 0,
  Usr_Estado NVARCHAR(255) DEFAULT 'Habilitado' NOT NULL CHECK (Usr_Estado IN('Habilitado', 'Deshabilitado'))
);

CREATE TABLE "TS".Rol_Usuario
(
  Rol_Nombre NVARCHAR(255) REFERENCES "TS".Rol(Rol_Nombre),
  Usr_Username NVARCHAR(255) REFERENCES "TS".Usuario(Usr_Username),
  PRIMARY KEY(Rol_Nombre, Usr_Username)
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
	
	INSERT INTO [GD2C2015].[TC].[Rol_Funcionalidad](Rol_Nombre, Func_Cod)
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
	
	DELETE [GD2C2015].[TC].[Rol_Funcionalidad]
	WHERE Rol_Nombre = @Rol_Pk
	
	UPDATE [GD2C2015].[TC].[Rol]
	SET Rol_Nombre = @Rol_Nombre, Rol_Estado = @Rol_Estado
	WHERE Rol_Nombre = @Rol_Pk
	
	INSERT INTO [GD2C2015].[TC].[Rol_Funcionalidad](Rol_Nombre, Func_Cod)
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

/*********** INSERTO 3 USUARIOS ADMIN, ADMIN2 Y ADMIN3 CON PASSWORD w23e **********************/
INSERT INTO "TS".Usuario(Usr_Username, Usr_Password, Usr_Fecha_Creacion, 
              Usr_Fecha_Ultima_Modificacion, Usr_Pregunta_Secreta,
              Usr_Respuesta_Secreta, Usr_Intentos_Login, Usr_Borrado) VALUES
  ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',
  GETDATE(), GETDATE(), 'Pregunta?',
  '9853528a46d3fc973096dc43528e4a2a660496fb5a24739d9788d5891a49121d', 0, 0),
  ('admin2', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',
  GETDATE(), GETDATE(), 'Pregunta?',
  '9853528a46d3fc973096dc43528e4a2a660496fb5a24739d9788d5891a49121d', 0, 0),
  ('admin3', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',
  GETDATE(), GETDATE(), 'Pregunta?',
  '9853528a46d3fc973096dc43528e4a2a660496fb5a24739d9788d5891a49121d', 0, 0);

INSERT INTO "TS".Rol_Usuario(Rol_Nombre, Usr_Username) VALUES
  ('Administrador', 'admin'),
  ('Administrador', 'admin2'),
  ('Administrador', 'admin3');