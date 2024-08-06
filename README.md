# ACME School Management

## Description

Esta librería ayuda a la gestión de estudiantes, cursos e inscripción en ACME. 
Añade registro de estudiantes, inscripción en cursos y procesamiento de pagos.
Se añadio el patrón UnitOfWork que actua sobre la gestión de transacciones.
La idea es coordinar la escritura de los cambios en la base de datos en una 
sola transacción así como mantener un registro de los cambios realizados en algún en las entidades.
Se trabajo sobretodo en la abstracción del sistema con un repositorio que maneja entidades genéricas.

Se debe usar la interfaz *IRepository<T>* que define los metodos que el repositorio implementa.
Permite que los servicios interactuen y se comuniquen con la BD de manera desacoplada y flexible.

El *PaymentGatewayService* es una implementación del servicio de pasarela de pagos. Simula un pago y maneja la tokenización de tarjetas.

Qué cosas te hubiera gustado hacer pero no hiciste?
- Implementación de encriptación de datos en la pasarela de pagos
- Validación de datos de entrada
- Manejo de errores y logs
Qué cosas hiciste pero crees que se podrían mejorar o que sería necesario volver a ellas si el proyecto sigue adelante?
- Implementación de REPOSITORIOS. Se usa un repositorio generico y un UNIT OF WORK para manejar la persistencia.
- Migraciones para la base de datos a utilizar.
- Autenticación (JWT) y controles de autorización para usuarios autorizados
- Encriptación en el momento de tokenizar se debe reemplazar con una implementación real y encriptar datos sensibles
- Implementación de IDEMPOTENCIA asegyra que operaciones repetidas no tengan efectos adversos en el sistema.
Qué librerías de terceros has utilizado y por qué?
1. **Microsoft.EntityFrameworkCore**
ORM que facilita el acceso a BD Relacionales. Facilita la interacción con la base de datos, lectura, creación y eliminación de datos.
2. **xUnit**
Framework para pruebas unitarias. Permite escribir y ejecutar pruebas automatizadas para asegurar la calidad y estabilidad del código.
3. **Unit of Work Pattern**
Asegura que todas las operaciones dentro de una transacción sean ejecutadas de manera conjunta, proporcionando consistencia y facilitando la gestión de errores y rollbacks.

## Instalación

Para instalar la librería, clone el repositorio y restaure los paquetes NuGet:

```sh
git clone https://github.com/Luciano888/ACME.git
cd ACME.SchoolManagement
dotnet restore
