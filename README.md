# VentaOnline

##Esta app esta desarrollada con la función de mantener ventas en el momento no basadas en un inventario sino al ingreso directo, enfocandose en el valor y precios de los articulos

##Esta completamente realizada con ajax para evitar el recargado de la pagina tras la ejecucion de una función por parte del backend

##Esta app esta mas enfocada en funcionalidad por encima del diseño por lo que se ha dado mas importancia al funcionamiento 

##Main Page
###Este apartado es el iniciar al ingresar a la pagina, muestra una interfaz limpia la cual en el header estan los sublinks las cuales pueden ingresar directamente a operar
![Main Page](https://github.com/VirtualKley/VentaOnline/blob/master/ImgRunApp/MainPage.png?raw=true)

##View Clients
###Esta pagina se encarga en la gestion total del cliente haciendo que ingresen solamente nombres, celular y tiene un apartado el cual muestra la ventas del dia enlistados separados por ","
![View Clients](https://github.com/VirtualKley/VentaOnline/blob/master/ImgRunApp/ViewClients.png?raw=true)

##View Sales
###Aqui se registran cada una de las ventas, estas funcionan con ajax para evitar el sobrecarga de la app haciendo que pueda el usuario operar directamente, esta segmentado en 3 partes
###La primera es el formulario de registrar la venta el cual indican en cada label que es lo que se debe de llenar, tambien consta con un boton para la creacón del cliente sin necesidad de cambiarse de pagina para ello, al completar el registro la lista de clientes se actualiza sin necesidad de recargar la pagina para poder ver el cliente, tambien se colocar seleccioando directo en la persona que se acaba de registrar

###La segunda parte se enfoca a un resumen global por clientes, articulos y total recaudado, haciendo que el usuario vea que comprador lleva más recaudado por las compras y tambien viendo cuantos articulos en total ha comprado en el día y mostrando su número de telefono el cual tiene un link que permite abrir una sesion de whatsapp que se encuentre en la pagina para redireccionar a un mensaje ya programado para que solo el usuario le de click a enviar

###La tercera parte que se encuentra en la zona inferior de la pagina muestra cada una de las transacciones dadas la cual permite en caso de algun mal registro ser eliminadas haciendo que toda la pagina realice operaciones asincronas
![View Sales](https://github.com/VirtualKley/VentaOnline/blob/master/ImgRunApp/ViewSales.png?raw=true)
![View Sales Add Client](https://github.com/VirtualKley/VentaOnline/blob/master/ImgRunApp/ViewSalesAddClientInPage.png?raw=true)
![View Sales Show List CLient](https://github.com/VirtualKley/VentaOnline/blob/master/ImgRunApp/ViewSalesWithListUsers.png?raw=true)

###Si deseas ver como funciona la aplicación he dejado un archivo de la copia de estructura de base de datos el cual esta en SQL Server solo seria cargar el archivo de extension .dacpac y una vez cargada reasignar la cadena de configuración con las entradas y variables que consta en tu entorno
###Por parte del sistema solo es abrir la solucion y publicarlo en un wwwroot si deseas en tu maquina o aplicar el motodo que desees si deseas probarlo en un servidor externo

###Saludos :3
###VirtualKley
