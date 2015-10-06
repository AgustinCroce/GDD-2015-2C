# Tablas

- Funcionalidad
- Rol
- Usuario
- Cliente
- Pasaje
- Encomienda
- Milla
- Producto
- Canje
- Butacas
- Aeronaves
- Compra
- Cacelacion_Compra
- Tarjeta
- Tipo_Tarjeta
- Ruta
- Ciudad
- Auditoria_Fuera_De_Servicio
- Tipo_Servicio
- Viajes

# Tablas Internedias

- Rol_Funcionalidad
- Rol_Usuario
- Pasaje_Cancelacion
- Encomienda_Cancelacion
- Pasaje_Compra
- Encomienda_Compra

# Campos

- Funcionalidad
    - Func_Cod
    - Func_Nombre
    - Func_Borrado

- Rol
    - Rol_Nombre
    - Rol_Estado
    - Rol_Borrado

- Usuario
    - Usr_Username
    - Usr_Estado
    - Usr_Borrado
    - Usr_Intentos_Login
    - Usr_Password

- Cliente
    - Cli_Cod
    - Cli_Nombre
    - Cli_Direccion
    - Cli_Tel
    - Cli_Mail
    - Cli_Fecha_Nacimiento
    - Cli_DNI

- Pasaje
    - Cli_Cod 
    - Viaj_Cod
    - But_Cod
    - Pas_Fecha_Compra

- Encomienda
    - Cli_Cod 
    - Viaj_Cod
    - Enc_Kg
    - Enc_Fecha_Compra 

- Milla
    - Cli_Cod
    - Enc_Cod
    - Pas_Cod
    - Mil_Fecha
    - Mil_Cantidad

- Producto
    - Prod_Cod
    - Prod_Nombre
    - Prod_Valor
    - Prod_Stock

- Canje
    - Canje_Cod
    - Cli_Cod
    - Prod_Cod
    - Canje_Cantidad_Prod
    - Canje_Fecha
    - Canje_Total

- Butacas
    - But_Cod
    - Aero_Num
    - But_Numero
    - But_Piso
    - But_Tipo

- Aeronaves
    - Aero_Fecha_De_Alta
    - Aero_Num
    - Aero_Modelo
    - Aero_Matricula
    - Aero_Fabricante
    - Ser_Codigo
    - Aero_Baja_Fuera_De_Servicio
    - Aero_Baja_Vida_Util
    - Aero_Fecha_Fuera_De_Servicio
    - Aero_Fecha_Reinicio_De_Servicio
    - Aero_Fecha_Baja_Definitiva
    - Aero_Cantidad_Kg_Disponibles

- Compra
    - Com_PNR
    - Cli_Cod
    - Com_Forma_Pago
    - Tar_Cod
    - Com_Fecha

- Cancelacion_Compra
    - Can_Fecha
    - Com_PNR
    - Can_Motivo

- Tarjeta
    - Tar_Cod
    - Tar_Fecha_Vencimiento 
    - Tar_Codigo_Seguridad
    - Tar_Numero
    - Cli_Cod
    - TipoTar_Cod

- Tipo_Tarjeta
    - TipoTar_Cod
    - TipoTar_Nombre
    - TipoTar_Cuotas

- Ruta
    - Ruta_Cod
    - Ruta_Ciudad_Origen
    - Ruta_Ciudad_Destino
    - Ruta_Precio_Base_Kg
    - Ruta_Precio_Base_Pasaje
    - Tipo de servicio

- Ciudad
    - Ciudad_Nombre

- Auditoria_Fuera_De_Servicio
    - Aero_Num
    - AudFS_Fecha_Inicio
    - AudFS_Fecha_Fin

- Tipo_Servicio
    - 
    - 
    - 

- Viajes
    - Viaj_Cod
    - Viaj_Kgs_Disponibles
    - 
