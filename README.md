# LabProject
This project is intended for laboratory purposes only

# Requisitos:
# Se debe implementar una vista que muestre estos resultados:
Cliente con mayor gasto será aquel cuyo importe agregado de todos los elementos de todas sus órdenes.
Listado general de clientes, no se requiere implementar paginación.
Top 5 de los elementos más frecuentemente comprados, el criterio para compararlos será el número total de ítems de entre todas las órdenes por cada sku.
# Los elementos del Top 5 deben mostrarse en un pie chart. 

Añadimos un controlador a los contextos y heredamos de DbContextOptionsBuilder optionsBuilder para generar la configuración.
En el archivo Program introducimos la apertura de la llamda a la base de datos con Scope para poder crear la migracion en SQL Management Studio con las tablas,
por último, realizamos el using con los bucles necesarios para realizar la insercción de los datos de prueba.

La lista de Customers puede abrirse pulsando en "Customers" en el menú superior.

El botón verde de la página "Customers" (Home, CustomerController) desencadena el cliente con mayor gasto.
El cliente con mayor gasto se ha creado buscando las Order y OrderDetail, con esto vamos separando en un bucle las Order por cliente.
A continuación sumamos los precios unitarios multiplicados por la cantidad de productos comprados para comparar este resultado y encontrar
el mayor gasto entre los clientes y buscar ese cliente para devolverlo a la vista. También devolveremos con un ViewBag el gasto en cuestión para mostrarlo en la vista.

El top 5 de productos vendidos puede abrirse pulsando en "Order Details" en el menú superior.
El top 5 de productos vendidos se busca en la tabla OrderDetail ordenando por SKU insertando más tarde la suma de los productos vendidos junto al SKU asociado en un diccionario.
Con este diccionario a continuación podemos ordenar descendentemente la lista por productos vendidos y recoger los 5 primeros para después mostrarlos en una lista.