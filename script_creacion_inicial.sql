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
  Aero_Cantidad_Kg_Disponibles NUMERIC(18,0) NOT NULL
);

CREATE TABLE "TS".Tipo_Tarjeta
(
  TipoTar_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  TipoTar_Nombre NVARCHAR(255) NOT NULL,
  TipoTar_Cuotas INT DEFAULT 0
);

CREATE TABLE "TS".Ciudad
(
  Ciudad_Nombre NVARCHAR(255) PRIMARY KEY
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
  But_Tipo NVARCHAR(255) NOT NULL
);

CREATE TABLE "TS".Tarjeta
(
  Tar_Numero NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Tar_Fecha_Vencimiento DATE NOT NULL,
  Tar_Codigo_Seguridad NUMERIC(18,0) NOT NULL,
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  TipoTar_Cod NUMERIC(18,0) REFERENCES "TS".Tipo_Tarjeta(TipoTar_Cod)
);

CREATE TABLE "TS".Ruta
(
  Ruta_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Ruta_Codigo NUMERIC(18,0) NOT NULL,
  Ruta_Ciudad_Origen NVARCHAR(255) REFERENCES "TS".Ciudad(Ciudad_Nombre),
  Ruta_Ciudad_Destino NVARCHAR(255) REFERENCES "TS".Ciudad(Ciudad_Nombre),
  Ruta_Precio_Base_Kg NUMERIC(18,2) NOT NULL DEFAULT 0,
  Ruta_Precio_Base_Pasaje NUMERIC(18,2) NOT NULL DEFAULT 0,
  Ruta_Servicio NVARCHAR(255) NOT NULL
);

CREATE TABLE "TS".Viaje
(
  Viaj_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Viaj_Kgs_Disponibles NUMERIC(18,0) DEFAULT 0,
  Fecha_Salida DATE NOT NULL,
  Fecha_Llegada DATE,
  Fecha_Llegada_Estimada DATE NOT NULL,
  Aero_Num NUMERIC(18,0) REFERENCES "TS".Aeronave(Aero_Num),
  Ruta_Cod NUMERIC(18,0) REFERENCES "TS".Ruta(Ruta_Cod)
);
CREATE TABLE "TS".Pasaje
(
  Pas_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Viaj_Cod NUMERIC(18,0) REFERENCES "TS".Viaje(Viaj_Cod),
  But_Cod NUMERIC(18,0) REFERENCES "TS".Butaca(But_Cod),
  Pas_Fecha_Compra DATE NOT NULL
);

CREATE TABLE "TS".Encomienda
(
  Enc_Cod NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
  Cli_Cod NUMERIC(18,0) REFERENCES "TS".Cliente(Cli_Cod),
  Viaj_Cod NUMERIC(18,0) REFERENCES "TS".Viaje(Viaj_Cod),
  Enc_Kg NUMERIC(18,0) NOT NULL,
  Enc_Fecha_Compra DATE NOT NULL
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
  Can_Fecha DATE NOT NULL,
  Com_PNR NUMERIC(18,0) REFERENCES "TS".Compra(Com_PNR),
  Can_Motivo NVARCHAR(255)
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
SELECT DISTINCT Ruta_Ciudad_Destino Ciudad
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Ciudad_Destino IS NOT NULL
UNION
SELECT DISTINCT Ruta_Ciudad_Origen Ciudad
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Ciudad_Origen IS NOT NULL;

INSERT INTO "TS".Butaca(Aero_Num, But_Numero, But_Piso, But_Tipo)
SELECT DISTINCT Aero_Num, Butaca_Nro, Butaca_Piso, Butaca_Tipo
FROM GD2C2015.gd_esquema.Maestra, "TS".Aeronave
WHERE Aero_Matricula=Aeronave_Matricula
AND Butaca_Nro IS NOT NULL;

INSERT INTO "TS".Ruta(Ruta_Codigo, Ruta_Precio_Base_Kg, Ruta_Precio_Base_Pasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Servicio)
SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BaseKG, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Tipo_Servicio
FROM GD2C2015.gd_esquema.Maestra
WHERE Ruta_Codigo IS NOT NULL

INSERT INTO "TS".Viaje(Fecha_Salida, Fecha_Llegada, Fecha_Llegada_Estimada, Aero_Num, Ruta_Cod)
SELECT DISTINCT M.FechaSalida, M.FechaLLegada, M.Fecha_LLegada_Estimada, Aero_Num, R.Ruta_Cod
FROM GD2C2015.gd_esquema.Maestra as M, "TS".Aeronave, "TS".Ruta as R
WHERE Aero_Matricula=Aeronave_Matricula
AND R.Ruta_Codigo=M.Ruta_Codigo
AND M.Ruta_Codigo IS NOT NULL
