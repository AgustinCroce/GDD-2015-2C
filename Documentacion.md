# Migracion

## Diseño de entidades

- Se ha utilizado de nombre de schema TS que son las siglas del grupo.
- Se ha mantenido a aquellos clientes cuyo DNI se encuetra repetido pero no se permitirá el ingreso de nuevos clientes con mismo DNI.
- Para cada cliente se ha generado un usuario con rol cliente. El nombre de usuario esta formado por el codigo generado en nuestro esquema y su nombre sin espacios y contraseña password.
- Para cada Encomienda y Pasaje realizado se ha generado una compra que lo representa todas con un solo item (el pasaje o la encomienda) y todas en efectivo.
- Al estar todos los vuelos de la tabla maestra con fecha de llegada ya establecida todas las millas de dichos viajes ya se encuentran asignadas a sus respectivos clientes aunque sean de fechas fúturas.
- A todos los servicios se les ha agregado como porcentaje para el precio de la compra un 40%. 

# Solucion

## Archivo de configuración
En el archivo de configuración en el parametro Modo con "Kiosko" o "Admin" segun el modo que se quiera probar.

## Registro de llegada
Si no se llena el campo matricula no se podra llevar a cabo el registro.
Solo se permite registrar la llegada de aquellos viajes a los cuales no se les haya registrado la llegada con anterioridad.
Se valida que la fecha de llegada sea posterior a la de salida por lo menos un minuto.

## Compra de pasaje
Para la fecha de compra se utiliza el campo Fecha de Sistema de las settings del proyecto.

### Selección de Vuelo
Solo se muestran los viajes que no tengan una fecha de llegada seteada.
Para activar el botón de aceptar se debe elegir una fila.

### Selección de Cantidades
Para activar el botón de aceptar por lo menos una de las opciones deben ser checkeada.
Se valida que las cantidades ingresadas respeten la disponibilidad del viaje.

### Selección de Items
Los botones de borrar solo se activan si se ha seleccionado con anterioridad una fila.
El botón de aceptar se activará si por lo menos se ha ingresado una encomienda o un pasaje.

### Datos del Pasaje
El form de datos de pasaje presenta un Autocomplete de todos los clientes en el sistema.
Al seleccionar un cliente se autocompletan los valores del form.

### Datos de la Encomienda
El form de datos de pasaje presenta un Autocomplete de todos los clientes en el sistema.
Al seleccionar un cliente se autocompletan los valores del form.

### Creación de Cliente
Al crear un cliente se validará que no haya otro cliente con el mismo Dni. Si bien esta situacíon se presenta en la
tabla maestra nostros decidimos que a partir de nuestro desarrollo no se permita el ingreso de más clientes con Dni 
duplicado.
Se valida que para crear el cliente todos los campos del form deben ser completados.

### Edición de Cliente
Se valida que para crear el cliente todos los campos del form deben ser completados.

### Pago en Modo Admin y Pago en modo Kiosko
El form de datos de pasaje presenta un Autocomplete de todos los clientes en el sistema.
Al seleccionar un cliente se autocompletan los valores del form y se cargan las tarjetas de credito que el cliente tenga en el ComboBox de tarjetas.
Al seleccionar una tarjeta del ComboBox se cargarán los datos de la misma.
Debe haber una tarjeta seleccionada o el pago debe ser en efectivo para habilitar el botón de aceptar.
Se valida que la tarjeta seleccionada no se encuentre vencida respecto a la fecha de sistema.

### Creación de Tarjeta
Se valida que para crear el cliente todos los campos del form deben ser completados.
Se valida que la fecha de vencimiento sea de acuerdo al formato MM/AA

### Edición de Tarjeta
Se valida que para crear el cliente todos los campos del form deben ser completados.
Se valida que la fecha de vencimiento sea de acuerdo al formato MM/AA

## Devolución
El form presenta en el campo PNR un Autocomplete de todas las compras en el sistema de aquellos vuelos que no hayan llegado a destino.
Una vez ingresado un número que mache con un PNR se cargarán las encomiendas y los pasajes que no esten cancelados de la misma.
Para que se active el boton de aceptar por lo menos deben ser seleccionados una encomienda o un pasaje.
Para la fecha de la devolución se utiliza el campo Fecha de Sistema de las settings del proyecto.

## Consulta de Millas

El form de consulta de millas presenta un ComboBox con Autocomplete de todos los clientes en el sistema.
El mismo muestra el Dni del cliente mas su nombre para evitar confuciones con los clientes de Dni duplicado.
En el caso de que se haya llenado el ComboBox con datos no validos se avisará por pantalla el error.

## Canje
El form de canje presenta un ComboBox con Autocomplete de todos los clientes en el sistema.
El mismo muestra el Dni del cliente mas su nombre para evitar confuciones con los clientes de Dni duplicado.
En el caso de que se haya llenado el ComboBox con datos no validos se avisará por pantalla el error.
Para la fecha del canje se utiliza el campo Fecha de Sistema de las settings del proyecto.
Se valida que el campo cantidad de productos solo contenga números y que contenga datos para poder realizar el canje.
En el caso de que no haya suficiente stock del producto elegido, o que cliente no tenga suficiente saldo se avisa por pantalla.


## ABM Aeronave

### Listado Aeronave
Permite busquedas por servicio que brinda la aeronave.
El listado no permite edicion, modificacion, seleccion multiple o cambios salvo el ordenamiento y solo permite seleccionar por fila completa.
Los botones de acciones salvo el agregar no estan habilitados hasta que se seleccione una fila.
Despues de cada accion realizada se actualiza el listado completo para reflejar cambios posibles.

### Alta Aeronave
Al agregar pide todos los datos requeridos en el enunciado.
No permite la seleccion de num ya que este es autogenerado.
El tipo se servicio se puede seleccion de un listado de servicios (los actualmente cargados en la base de datos).
Los campos kd Disponibles, butacas pasillo y butacas ventanilla solo pueden recibir numero (no permite escribir texto o simbolos).
El boton de guardar se habilita solo si estan todos los datos cargados.
La matricula se verifica en un store procedure en donde si esta en otro aeronave no te permite guardar y te avise de dicho problema de forma clara (un formulario de mensaje te dice que la matricula esta en otra aeronave y que no se puede repetir).

### Modificacion Aeronave
Recibe los datos de la aeronave a modificar y autocompleta los campos.
No permite modicicar el numero (primary key e identificardor autogenerado), la cantidad de butacas pasillo ni la cantidad de butacas ventanilla.
La matricula es validada al igual que en el alta.
Los campos tienen la mismas validaciones que en el alta.

### Borrado Aeronave
Primero verifica que el vuelo no tenga viajes pendientes a realizar.
Si no tiene viajes pendientes, pregunta si estas seguro y en el caso de estarlo hace el borrado logico de dicha aeronave.
En el caso de tener viajes pendientes, verifica si existe alguna aeronave disponible que cumpla con los requisitos establecidos en el enunciado.
Si no existe una aeronave, obliga a la creacion de una nueva o cancelacion del proceso.
En la generacion de la nueva aeronave no se permite modificar los requisitos obligatorios (mismo fabricante, mismo modelo, ...), una vez generada se valida que los pasajes y las encomientadas sean posibles de realizar en dicha aeronave.
Si la aeronve nueva no cumple con los requisitos se repite el proceso de creacion de una nueva aeronave.
En el caso de que ya habia una aeronave disponible que pueda remplazar a la aeronave a borrar, se pregunta al usuario si quiere efectivamente el remplazo o cancelar el proceso.
Si se quiere remplazar, se ejecuta el remplazo de una aeronave por otra en cada viaje.

### Fuera de Servicio Aeronave
Esta accion abre un formulario donde se pide de que fecha a que fecha se requiere el fuera de servicio de una aeronave.
Al igual que en el borrado se valida la aeronave y se realizan los resplazos para los viajes solo que en este caso se hace solo para los viajes que tenga como fecha de salida una fecha donde la aeronave este fuera de serivicio.
Deja un campo en la aeronave que indica que esta en baja, se le agrega las fechas en la cuales va a estar fuera de serivicio y se genera el nuevo dato en la auditoria de fuera de servicio.

### Baja de Servicio (Fin vida Util) Aeronave
Similar al borrado, verifica que la aeronave no tenga viajes pendientes y si los tiene hace el proceso de generacion o replazo de la aeronave en los viajes pendientes
Deja un campo donde indica que la aeronave esta ya sin vida util y le agrega la fecha de baja definitiva.

## ABM Ciudades

### Listado de ciudades
El listado permite la visualizacion y busqueda de ciudades.
El listado no permite edicion, modificacion, seleccion multiple o cambios salvo el ordenamiento y solo permite seleccionar por fila completa.
Los botones de acciones salvo el de agregar no estan habilitados sin la seleccion de una ciudad en la lista.
Despues de ejecutar una accion el listado se actualiza para reflejar posibles cambios.

### Alta de ciudades
Pide el nombre de la ciudad a crear.

### Modificacion de ciudades
Permite la modificacion del nombre de la ciudad.

### Borrado de ciudades
Permite el borrado logico de la ciudad

## ABM Ruta

### Listado de rutas
El listado permite la visualizacion de rutas y busqueda de rutas por ciudades.
El listado no permite edicion, modificacion, seleccion multiple o cambios salvo el ordenamiento y solo permite seleccionar por fila completa.
Los botones de acciones salvo el de agregar no estan habilitados sin la seleccion de una ruta en la lista.
Despues de ejecutar una accion el listado se actualiza para reflejar posibles cambios.

### Alta de rutas
Te permite seleccion de una lista la ciudad origen y destino y el tipo se serivcio (las ciudades y servicio son los que estan actualmente cargados en la base mediante una query).
Se permite generar un codigo adicional.
Los campos de precio solo permiten el ingreso de datos numericos.
El boton de guardar solo se habilita en caso de que esten todos los campos completos.

### Modificacion de rutas
Los datos se cargan automaticamente segun la ruta seleccionada.
Permite modificar cualquiera de sus datos y tiena las misma validaciones que en el alta.

### Borrado de rutas
Permite el borrado logico de la ruta seleccionada.
Consulta al usuario si esta seguro de realizar esta accion y le indica que en caso de hacerlo todos los pasajes y encomiendas futuros que pasen por esa ruta seran cancelados de forma inmediata.
En caso de afirmar el borrado, se cancelan todos los pasajes y encomientas pendientes que pasen por esa ruta.

## ABM Rol

### Listado de roles
El listado permite la visualizacion y busqueda de roles.
El listado no permite edicion, modificacion, seleccion multiple o cambios salvo el ordenamiento y solo permite seleccionar por fila completa.
Los botones de acciones salvo el de agregar no estan habilitados sin la seleccion de un rol en la lista.
Despues de ejecutar una accion el listado se actualiza para reflejar posibles cambios.

### Alta de roles
Permite el ingreso del nombre y estado actual del rol nuevo.

### Modificacion de roles
Permite modificar el estado del rol seleccionado.

### Borrado de roles
Hace el borrado logico del rol seleccionado y ademas borra logicamente si realacion con usuarios.

### Habilitacion de rol
Cambia el estado del rol seleccionado a habilitado.

### Deshabilitacion de rol
Cambia el estado del rol seleccionado a deshabilitado.

### Agregar funcionalidad
Permite agregar una funcionalidad al rol selecciona, para esto abre una nueva ventana donde permite seleccion una funcionalidad cargada en la base y agregarla al rol seleccionado anteriormente.

### Borrar funcionalidad
Permite quitar una funcionalidad del rol seleccionado, para esto abre una nueva ventana con las funcionalidades que actualmente tiene ese rol y permite seleccionar una y quitarla.

## Generacion de viaje
Permite generar un viaje determinados.
Los campos de fechas no pueden ser anteriores a la fecha del sistema (la configurada en el properties del proyecto), la fecha de salida no puede ser posterior a la de estimada de llegada y la fecha de llegada no puede superar las 24 horas de diferencia con la de salida
La seleccion de ruta es solo en rutas ya generadas anteriormente.
La seleccion de aeronave no se habilita hasta que se seleccione la ruta ya que esta va a indicar el servicio a brindar por la aeronave y por ende el listado de aeronaves solo permite ver aeronaves validas para efectuar dicho servicio.
Si se selecciona una aeronave que ya tenga programado un viaje para esa fecha, la aeronave no podra ser utilizada y mediante un mensaje indica al usaurio que la cambie.
El servicio no se permite modificar sino que se selecciona mediante la ruta a utilizar.
El boton de guardar solo se habilita cuando todos los campos esten completos.

## Listado estadistico
El listado permite ver los reportes por semestre y año de determinados pedidos.
Para esto tiene dististos tabs en donde cada uno carga un reporte distinto y en la parte superior permite la seleccion del año y semestre a visualizar.
Tambien posee un boton actualizar para ver el reporte en una version mas actual o hacer el nuevo filtro del mismos (por otro año o semestre).

## Login
Permite el ingreso al sistema mediante el username y la contraseña en sha256.
Verifica el estado del usuario, si la contreseña es incorrecta avisa al usuario y agrega el intento del login al usaurio en la base datos y valida que el estado es en correcto (segun la cantidad de intentos fallidos).
Si la contraseña es correcta logea al usuario si su estado lo permite, en caso de no permitirlo indica al usuario que se contacte con un administrados para que este pude habilitarlo que su cuenta intento se ingresada insactifactoriomente mas de tres veces.
En el caso de login correcto y estado valido abre la ventana de seleccion de rol.

### Seleccion de Rol
Permite al usuario logeado seleccion el rol a utilizar de sus roles actuales.
Una vez seleccionado el rol, al precioar el boton aceptar se abre la pantalla de seleccion de funcionalidad.

### Seleccion de Funcionalidad
Permite al usuario logeado seleccionar la funcionalidad (entre las funcionalidades del rol que el usuario seleccion anteriormente).
Al seleccionar y precionar el boton aceptar abre la ventana que corresponda para la funcionalidad que el usuario selecciono.

