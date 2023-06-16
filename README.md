# Newshore_Test
This is the solution for the Newshore Air entrance test.

## Spanish
Esta es la solución para la prueba suministrada por Newshore, esta prueba se realizó en dos frentes, se implementó el backend en .Net, la cual expondrá un API para ser consumida por el Frontend, que se implementará en Angular.

* Backend : 
Este API se encarga de consumir un REST API suministrado por Newshore, con el fin de cargar la información de los vuelos, despues de consultar esta información se procede a realizar consultas por medio de LinQ con el fin de segmentar y separar los datos de acuerdo a estructura indicada en el documento de la prueba.

* Frontend : 
La parte del Frontend, se implementó en Angular, una aplicación sencilla que se encarga de consumir el API que se implementó en el Backend, enviando como parametros Origen y Destino, esto con el fin de consulta los vuelos y rutas asociadas a la solicitud.
 
La solución del proyecto se encuentra en la rama Dev, tanto la parte del Backend como del Frontend.
## English
This is the solution for the test provided by Newshore, this test was performed on two fronts, the backend was implemented in .Net, which will expose an API to be consumed by the Frontend, which will be implemented in Angular.

* Backend : 
This API is responsible for consuming a REST API provided by Newshore, in order to load the flight information, after consulting this information we proceed to perform queries through LinQ in order to segment and separate the data according to the structure indicated in the test document.

* Frontend : 
The Frontend part was implemented in Angular, a simple application that is responsible for consuming the API that was implemented in the Backend, sending as parameters Origin and Destination, this in order to query the flights and routes associated with the request.

The project solution is in the Dev branch, both the Backend and Frontend parts.