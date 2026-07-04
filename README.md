# Librería y Bazar - Sistema de Inventario y Ventas

##  Descripción
Este proyecto consiste en el desarrollo de un sistema de inventario y ventas para una librería y bazar, implementado en C# como aplicación de consola. El objetivo es facilitar el registro, búsqueda y control de productos, así como la gestión de ventas y la generación de reportes, reemplazando el manejo manual de la información.
El sistema permite administrar el inventario mediante un menú interactivo, validando los datos ingresados por el usuario y almacenando la información en archivos de texto para conservar los registros entre ejecuciones.
---

## Objetivos
- Automatizar el control del inventario.
- Registrar las ventas realizadas diariamente.
- Facilitar la búsqueda y modificación de productos.
- Generar reportes de ventas e inventario.
- Aplicar programación modular y persistencia de datos.
---

## Funcionalidades
- Registrar productos.
- Buscar productos por código o nombre.
- Mostrar inventario completo.
- Mostrar inventario por categorías.
- Registrar ventas.
- Mostrar ventas del día.
- Mostrar historial de ventas.
- Calcular el total recaudado.
- Mostrar estado de categorías.
- Generar reporte de ventas por categoría.
- Modificar productos.
- Eliminar productos.
- Mostrar producto más vendido.
- Generar cierre del día.
- Guardar y cargar datos mediante archivos de texto.
---

## Tecnologías utilizadas
- Lenguaje: **C#**
- Framework: **.NET**
- IDE: **Visual Studio 2026**
- Control de versiones: **Git**
- Repositorio remoto: **GitHub**
---

##  Estructura del proyecto
```text
Libreria_y_Bazar/
│
├── Program.cs
├── Producto.cs
├── Venta.cs
├── productos.txt
├── ventas.txt
├── README.md
└── Libreria_y_Bazar.csproj
```
---

## Ejecución
1. Abrir el proyecto en Visual Studio.
2. Compilar la solución.
3. Ejecutar la aplicación.
4. Seleccionar una opción del menú principal.
---

## Menú del sistema
1. Registrar producto
2. Buscar producto
3. Mostrar inventario
4. Mostrar inventario por categorías
5. Registrar venta
6. Ver ventas del día
7. Ver total recaudado
8. Estado de categorías
9. Reporte de ventas por categoría
10. Modificar producto
11. Eliminar producto
12. Producto más vendido
13. Cierre del día
14. Historial de ventas
15. Guardar datos
16. Salir
---

##  Persistencia de datos
La información se almacena en archivos de texto:
- **productos.txt**
- **ventas.txt**
Esto permite conservar los registros incluso después de cerrar el programa.
---

## Integrantes

- Jhonatan Daniel Chuqiruna Rodriguez
- Lucas Samuel Colorado Llanos
---

## Curso
Fundamentos de Programación

---

## Estado del proyecto
Proyecto culminado satisfactoriamente como parte del curso de Fundamentos de Programación.

---

## Posibles mejoras
- Implementar una base de datos (SQL Server o MySQL).
- Desarrollar una interfaz gráfica (Windows Forms o WPF).
- Incorporar control de usuarios y autenticación.
- Generar reportes en PDF y Excel.
- Implementar gráficos estadísticos de ventas.

---

## Version final
Se realizaron mejoras en la documentación y organización del proyecto para la entrega final.
