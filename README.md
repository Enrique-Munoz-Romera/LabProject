# LabProject
This project is intended for laboratory purposes only

# Requisitos:
# Se debe implementar una vista que muestre estos resultados:
Cliente con mayor gasto ser� aquel cuyo importe agregado de todos los elementos de todas sus �rdenes.
Listado general de clientes, no se requiere implementar paginaci�n.
Top 5 de los elementos m�s frecuentemente comprados, el criterio para compararlos ser� el n�mero total de �tems de entre todas las �rdenes por cada sku.
# Los elementos del Top 5 deben mostrarse en un pie chart. 

A�adimos un controlador a los contextos y heredamos de DbContextOptionsBuilder optionsBuilder para generar la configuraci�n.
En el archivo Program introducimos la apertura de la llamda a la base de datos con Scope para poder crear la migracion en SQL Management Studio con las tablas,
por �ltimo, realizamos el using con los bucles necesarios para realizar la insercci�n de los datos de prueba.

La lista de Customers puede abrirse pulsando en "Customers" en el men� superior.

El bot�n verde de la p�gina "Customers" (Home, CustomerController) desencadena el cliente con mayor gasto.
El cliente con mayor gasto se ha creado buscando las Order y OrderDetail, con esto vamos separando en un bucle las Order por cliente.
A continuaci�n sumamos los precios unitarios multiplicados por la cantidad de productos comprados para comparar este resultado y encontrar
el mayor gasto entre los clientes y buscar ese cliente para devolverlo a la vista. Tambi�n devolveremos con un ViewBag el gasto en cuesti�n para mostrarlo en la vista.

El top 5 de productos vendidos puede abrirse pulsando en "Order Details" en el men� superior.
El top 5 de productos vendidos se busca en la tabla OrderDetail ordenando por SKU insertando m�s tarde la suma de los productos vendidos junto al SKU asociado en un diccionario.
Con este diccionario a continuaci�n podemos ordenar descendentemente la lista por productos vendidos y recoger los 5 primeros para despu�s mostrarlos en una lista.