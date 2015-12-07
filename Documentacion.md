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




