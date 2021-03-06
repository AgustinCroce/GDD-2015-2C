  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 10000 [Cli_Nombre]
      ,[Cli_Apellido]
      ,[Cli_Dni]
      ,[Cli_Dir]
      ,[Cli_Telefono]
      ,[Cli_Mail]
      ,[Cli_Fecha_Nac]
      ,[Pasaje_Codigo]
      ,[Pasaje_Precio]
      ,[Pasaje_FechaCompra]
      ,[Butaca_Nro]
      ,[Butaca_Tipo]
      ,[Butaca_Piso]
      ,[Paquete_Codigo]
      ,[Paquete_Precio]
      ,[Paquete_KG]
      ,[Paquete_FechaCompra]
      ,[FechaSalida]
      ,[Fecha_LLegada_Estimada]
      ,[FechaLLegada]
      ,[Ruta_Codigo]
      ,[Ruta_Precio_BaseKG]
      ,[Ruta_Precio_BasePasaje]
      ,[Ruta_Ciudad_Origen]
      ,[Ruta_Ciudad_Destino]
      ,[Aeronave_Matricula]
      ,[Aeronave_Modelo]
      ,[Aeronave_KG_Disponibles]
      ,[Aeronave_Fabricante]
      ,[Tipo_Servicio]
  FROM [GD2C2015].[gd_esquema].[Maestra]

  /* Ciudades*/
  SELECT DISTINCT Ruta_Ciudad_Destino Ciudad
  FROM GD2C2015.gd_esquema.Maestra
  UNION
  SELECT DISTINCT Ruta_Ciudad_Origen Ciudad
  FROM GD2C2015.gd_esquema.Maestra

  /*Rutas*/
  SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BaseKG, Ruta_Ciudad_Origen, 
				  Ruta_Ciudad_Destino, Tipo_Servicio
  INTO #RutasXEmpaques
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Ruta_Precio_BaseKG > 0

  SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, 
				  Ruta_Ciudad_Destino, Tipo_Servicio
  INTO #RutasXPasaje
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Ruta_Precio_BasePasaje > 0
  
  
  SELECT e.Ruta_Codigo, e.Ruta_Precio_BaseKG, p.Ruta_Precio_BasePasaje, e.Ruta_Ciudad_Destino, 
         e.Ruta_Ciudad_Origen, e.Tipo_Servicio
  FROM #RutasXEmpaques as e, #RutasXPasaje as p
  WHERE e.Ruta_Codigo = p.Ruta_Codigo AND e.Ruta_Ciudad_Origen = p.Ruta_Ciudad_Origen 
        AND e.Ruta_Ciudad_Destino = p.Ruta_Ciudad_Destino 
        AND e.Tipo_Servicio = p.Tipo_Servicio 
  
  /*Clientes*/
  SELECT DISTINCT Cli_Dni, Cli_Dir, Cli_Nombre, Cli_Apellido, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
  FROM GD2C2015.gd_esquema.Maestra

  /*Butacas*/
  SELECT DISTINCT Aeronave_Matricula, Butaca_Nro, Butaca_Piso, Butaca_Tipo
  FROM GD2C2015.gd_esquema.Maestra
  ORDER BY Aeronave_Matricula

  /*Aernonaves*/
  SELECT DISTINCT Aeronave_Matricula, Aeronave_Modelo, Aeronave_KG_Disponibles, Aeronave_Fabricante, Tipo_Servicio
  FROM GD2C2015.gd_esquema.Maestra
  ORDER BY Aeronave_Matricula

  /*Viajes*/
  SELECT DISTINCT FechaSalida, FechaLLegada, Fecha_LLegada_Estimada, Aeronave_Matricula, Ruta_Codigo
  FROM GD2C2015.gd_esquema.Maestra

  /*Pasajes*/
  SELECT DISTINCT Pasaje_Codigo, Pasaje_FechaCompra, Pasaje_Precio, Ruta_Codigo, Aeronave_Matricula, FechaSalida, Butaca_Nro, Butaca_Piso
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Pasaje_Codigo > 0

  SELECT DISTINCT Pasaje_Codigo, Pasaje_FechaCompra, Pasaje_Precio, Ruta_Codigo, Aeronave_Matricula, FechaSalida
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Pasaje_Codigo = 0

  /*Paquetes*/
  SELECT DISTINCT Paquete_Codigo, Paquete_FechaCompra, Paquete_KG, Paquete_Precio, Ruta_Codigo, Aeronave_Matricula, FechaSalida
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Paquete_Codigo > 0

  SELECT DISTINCT Paquete_Codigo, Paquete_FechaCompra, Paquete_KG, Paquete_Precio, Aeronave_Matricula, FechaSalida
  FROM GD2C2015.gd_esquema.Maestra
  WHERE Paquete_Codigo = 0