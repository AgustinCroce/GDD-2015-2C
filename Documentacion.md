## Devolución

El form presenta en el campo PNR un Autocomplete de todas las compras en el sistema.
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



