## ** En la carpeta Recursos se encuentra la lista de Collections de la Base de Datos y la Collections de Postman


### Se ha implementado la base de datos "EcommerceDB"  que consiste en varias colecciones interrelacionadas para gestionar un sistema de Ecommerce. A continuación, se describen las colecciones y las relaciones entre ellas:

## Categorías (id, nombre): 
Esta colección almacena las distintas categorías de productos disponibles en el sistema. Cada categoría está identificada por un ID único y tiene un nombre descriptivo.

## Productos (id, nombre, cantidad, fechaIngreso, CategoriaId): 
Aquí se registran los productos disponibles para la venta. Cada producto tiene un ID único, nombre, cantidad en inventario, fecha de ingreso y una referencia a la categoría a la que pertenece mediante el ID de categoría.

## Tiendas (id, nombre, nit): 
La colección de tiendas almacena la información sobre los distintos establecimientos. Cada tienda tiene un ID único, nombre y número de identificación tributaria (NIT).

## Usuarios (id, nombre, dirección, cédula, correo, tiendaId): 
En esta colección se mantienen los registros de los usuarios del sistema. Cada usuario está identificado por un ID único y tiene información como nombre, dirección, número de cédula, correo electrónico y una referencia a la tienda a la que pertenece mediante el ID de tienda.

## Ventas (id, fechaVenta, usuarioId, productoId, tiendaId): 
La colección de ventas registra las transacciones realizadas. Cada venta tiene un ID único, fecha de venta, referencia al usuario que realizó la compra mediante el ID de usuario, referencias a los productos adquiridos mediante el ID de producto y una referencia a la tienda en la que se llevó a cabo la venta mediante el ID de tienda.

# Relaciones entre las colecciones:

Un producto pertenece a una categoría, y cada categoría puede tener varios productos.
Un usuario puede tener múltiples ventas, pero cada venta está asociada a un único usuario.
Cada venta involucra uno o varios productos, y cada producto puede estar presente en varias ventas.
Cada venta está relacionada con un usuario, y cada usuario puede tener múltiples ventas.
Cada venta se asocia a una tienda, y cada tienda puede tener múltiples ventas.
En resumen, la base de datos "EcommerceDB" está diseñada para gestionar productos, categorías, tiendas, usuarios y ventas en un sistema de comercio electrónico, manteniendo relaciones coherentes entre las diferentes entidades para permitir un seguimiento completo de las transacciones y actividades dentro del sistema.


### En este proyecto, hemos implementado el patrón de diseño de Inyección de Dependencias (DI) para gestionar las dependencias entre los componentes del sistema. La Inyección de Dependencias es una técnica de diseño que promueve la modularidad, la flexibilidad y la mantenibilidad del código al invertir el control sobre la creación y suministro de objetos requeridos.
