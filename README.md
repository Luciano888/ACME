# ACME School Management

## Description

Esta librer�a ayuda a la gesti�n de estudiantes, cursos e inscripci�n en ACME. 
A�ade registro de estudiantes, inscripci�n en cursos y procesamiento de pagos.
Se a�adio el patr�n UnitOfWork que actua sobre la gesti�n de transacciones.
La idea es coordinar la escritura de los cambios en la base de datos en una 
sola transacci�n as� como mantener un registro de los cambios realizados en alg�n en las entidades.
Se trabajo sobretodo en la abstracci�n del sistema con un repositorio que maneja entidades gen�ricas.

Se debe usar la interfaz *IRepository<T>* que define los metodos que el repositorio implementa.
Permite que los servicios interactuen y se comuniquen con la BD de manera desacoplada y flexible.

El *PaymentGatewayService* es una implementaci�n del servicio de pasarela de pagos. Simula un pago y maneja la tokenizaci�n de tarjetas.

Qu� cosas te hubiera gustado hacer pero no hiciste?
- Implementaci�n de encriptaci�n de datos en la pasarela de pagos
- Validaci�n de datos de entrada
- Manejo de errores y logs
Qu� cosas hiciste pero crees que se podr�an mejorar o que ser�a necesario volver a ellas si el proyecto sigue adelante?
- Implementaci�n de REPOSITORIOS. Se usa un repositorio generico y un UNIT OF WORK para manejar la persistencia.
- Migraciones para la base de datos a utilizar.
- Autenticaci�n (JWT) y controles de autorizaci�n para usuarios autorizados
- Encriptaci�n en el momento de tokenizar se debe reemplazar con una implementaci�n real y encriptar datos sensibles
- Implementaci�n de IDEMPOTENCIA asegyra que operaciones repetidas no tengan efectos adversos en el sistema.
Qu� librer�as de terceros has utilizado y por qu�?
1. **Microsoft.EntityFrameworkCore**
ORM que facilita el acceso a BD Relacionales. Facilita la interacci�n con la base de datos, lectura, creaci�n y eliminaci�n de datos.
2. **xUnit**
Framework para pruebas unitarias. Permite escribir y ejecutar pruebas automatizadas para asegurar la calidad y estabilidad del c�digo.
3. **Unit of Work Pattern**
Asegura que todas las operaciones dentro de una transacci�n sean ejecutadas de manera conjunta, proporcionando consistencia y facilitando la gesti�n de errores y rollbacks.

## Instalaci�n

Para instalar la librer�a, clone el repositorio y restaure los paquetes NuGet:

```sh
git clone <url-del-repositorio>
cd <nombre-del-proyecto>
dotnet restore