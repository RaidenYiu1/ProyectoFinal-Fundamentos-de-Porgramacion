using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Libreria_y_Bazar
{
    class Program
    {
        //Lista que almacenara todo los productos registrados.
        static List<Producto> productos = new List<Producto>();

        //Lista que almacenara todas las ventas realizadas
        static List<Venta> ventas = new List<Venta>();


        // Lo principal del programa.
        // Cargara toda la informacion guardada.    
        // Mostrar el menu con sus opciones de
        // diferentes funcionalidades del sistema.
        static void Main()
        {
            CargarProductos();
            CargarVentas();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=====================================");
                Console.WriteLine(" LIBRERIA Y BAZAR");
                Console.WriteLine(" SISTEMA DE INVENTARIO Y VENTAS");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Mostrar inventario");
                Console.WriteLine("4. Mostrar inventario por categorias");
                Console.WriteLine("5. Registrar venta");
                Console.WriteLine("6. Ver ventas del día");
                Console.WriteLine("7. Ver total recaudado");
                Console.WriteLine("8. Estado de categorías");
                Console.WriteLine("9. Reporte de ventas por categoria");
                Console.WriteLine("10. Modificar producto");
                Console.WriteLine("11. Eliminar producto");
                Console.WriteLine("12. Producto más vendido");
                Console.WriteLine("13. Cierre del día");
                Console.WriteLine("14. Historial de ventas");
                Console.WriteLine("15. Guardar datos");
                Console.WriteLine("16. Salir");

                Console.Write("\nOpción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        RegistrarProducto();
                        break;

                    case 2:
                        BuscarProducto();
                        break;

                    case 3:
                        MostrarInventario();
                        break;

                    case 4:
                        MostrarInventarioPorCategorias();
                        break;

                    case 5:
                        RegistrarVenta();
                        break;

                    case 6:
                        MostrarVentasDelDia();
                        break;

                    case 7:
                        TotalRecaudado();
                        break;

                    case 8:
                        EstadoCategorias();
                        break;

                    case 9:
                        ReporteVentasPorCategoria();
                        break;

                    case 10:
                        ModificarProducto();
                        break;

                    case 11:
                        EliminarProducto();
                        break;

                    case 12:
                        ProductoMasVendido();
                        break;

                    case 13:
                        CierreDelDia();
                        break;

                    case 14:
                        MostrarHistorialVentas();
                        break;

                    case 15:
                        GuardarProductos();
                        GuardarVentas();
                        Console.WriteLine("Datos guardados.");
                        Console.ReadKey();
                        break;

                }

            } while (opcion != 16);

            GuardarProductos();
            GuardarVentas();
        }

        //// Permite registrar Y añadir un nuevo producto 
        ///en el inventario y solicita los datos del 
        ///producto y los almacena en la lista.

        // Permite registrar y añadir un nuevo producto al inventario.
        // Valida que los datos ingresados sean correctos antes de almacenarlos.
        static void RegistrarProducto()
        {
            Producto p = new Producto();

            // Código
            while (true)
            {
                Console.Write("Código: ");
                p.Codigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(p.Codigo))
                {
                    Console.WriteLine("El código no puede estar vacío.");
                    continue;
                }

                if (!Regex.IsMatch(p.Codigo, @"^[A-Za-z0-9-]+$"))
                {
                    Console.WriteLine("El código solo puede contener letras, números y guiones.");
                    continue;
                }

                if (productos.Any(x => x.Codigo.Equals(p.Codigo, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("El código ya existe.");
                    continue;
                }

                break;
            }

            // Categoría
            while (true)
            {
                Console.Write("Categoría: ");
                p.Categoria = Console.ReadLine().Trim();

                if (Regex.IsMatch(p.Categoria, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$"))
                    break;

                Console.WriteLine("Ingrese una categoría válida (solo letras).");
            }

            // Subcategoría
            while (true)
            {
                Console.Write("Subcategoría: ");
                p.Subcategoria = Console.ReadLine().Trim();

                if (Regex.IsMatch(p.Subcategoria, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$"))
                    break;

                Console.WriteLine("Ingrese una subcategoría válida (solo letras).");
            }

            // Nombre
            while (true)
            {
                Console.Write("Nombre: ");
                p.Nombre = Console.ReadLine().Trim();

                if (Regex.IsMatch(p.Nombre, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s().,-]+$"))
                    break;

                Console.WriteLine("Ingrese un nombre válido.");
            }

            // Unidad de medida
            while (true)
            {
                Console.Write("Unidad de medida: ");
                p.UnidadMedida = Console.ReadLine().Trim();

                if (Regex.IsMatch(p.UnidadMedida, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$"))
                    break;

                Console.WriteLine("Ingrese una unidad de medida válida.");
            }

            // Precio de compra
            while (true)
            {
                Console.Write("Precio compra: ");

                if (double.TryParse(Console.ReadLine(), out double compra) && compra >= 0)
                {
                    p.PrecioCompra = compra;
                    break;
                }

                Console.WriteLine("Ingrese un precio de compra válido.");
            }

            // Precio de venta
            while (true)
            {
                Console.Write("Precio venta: ");

                if (double.TryParse(Console.ReadLine(), out double venta) && venta >= 0)
                {
                    p.PrecioVenta = venta;
                    break;
                }

                Console.WriteLine("Ingrese un precio de venta válido.");
            }

            // Stock
            while (true)
            {
                Console.Write("Stock: ");

                if (int.TryParse(Console.ReadLine(), out int stock) && stock >= 0)
                {
                    p.Stock = stock;
                    break;
                }

                Console.WriteLine("Ingrese un stock válido.");
            }

            productos.Add(p);
            GuardarProductos();

            Console.WriteLine("\nProducto registrado correctamente.");
            Console.ReadKey();
        }

        // Busca un producto por su código y muestra la información si existe.
        static void BuscarProducto()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("      BUSCAR PRODUCTO");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Buscar por código");
            Console.WriteLine("2. Buscar por nombre");
            Console.Write("\nOpción: ");

            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 2)
            {
                Console.Write("Opción no válida. Intente nuevamente: ");
            }

            switch (opcion)
            {
                case 1:
                    BuscarPorCodigo();
                    break;

                case 2:
                    BuscarPorNombre();
                    break;
            }
        }
        static void BuscarPorCodigo()
        {
            Console.Write("\nIngrese el código: ");

            string codigo = Console.ReadLine().Trim().ToUpper();

            Producto p = productos.Find(x => x.Codigo.ToUpper() == codigo);

            if (p == null)
            {
                Console.WriteLine("\nProducto no encontrado.");
            }
            else
            {
                MostrarDatosProducto(p);
            }

            Console.ReadKey();
        }
        static void BuscarPorNombre()
        {
            Console.Write("\nIngrese el nombre del producto: ");

            string nombre = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Debe ingresar un nombre.");
                Console.ReadKey();
                return;
            }

            var encontrados = productos
                .Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine("\nNo se encontraron productos.");
            }
            else
            {
                Console.WriteLine($"\nSe encontraron {encontrados.Count} producto(s):\n");

                foreach (Producto p in encontrados)
                {
                    Console.WriteLine("-------------------------------------");
                    MostrarDatosProducto(p);
                }
            }

            Console.ReadKey();
        }
        static void MostrarDatosProducto(Producto p)
        {
            Console.WriteLine($"Código: {p.Codigo}");
            Console.WriteLine($"Nombre: {p.Nombre}");
            Console.WriteLine($"Categoría: {p.Categoria}");
            Console.WriteLine($"Subcategoría: {p.Subcategoria}");
            Console.WriteLine($"Unidad: {p.UnidadMedida}");
            Console.WriteLine($"Precio Compra: S/{p.PrecioCompra:F2}");
            Console.WriteLine($"Precio Venta : S/{p.PrecioVenta:F2}");
            Console.WriteLine($"Stock: {p.Stock}");
        }

        // Muestra todos los productos registrados junto con su precio y cantidad disponible
        static void MostrarInventario()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nINVENTARIO\n");
            foreach (var p in productos)
            {
                Console.WriteLine(
                    $"{p.Codigo} | {p.Nombre} | S/{p.PrecioVenta} | Stock: {p.Stock}"
                );
            }
            Console.ReadKey();
        }
        // Muestra el inventario organizado por
        // categorías y subcategorías.
        static void MostrarInventarioPorCategorias()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                Console.ReadKey();
                return;
            }

            var categorias = productos
                .Select(p => p.Categoria)
                .Distinct()
                .ToList();

            Console.WriteLine("CATEGORÍAS DISPONIBLES:");

            for (int i = 0; i < categorias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categorias[i]}");
            }

            Console.Write("\nSeleccione una categoría: ");
            int opcion;

            if (!int.TryParse(Console.ReadLine(), out opcion) ||
                opcion < 1 ||
                opcion > categorias.Count)
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
                return;
            }

            string categoriaSeleccionada =
                categorias[opcion - 1];

            var subcategorias = productos
                .Where(p => p.Categoria == categoriaSeleccionada)
                .Select(p => p.Subcategoria)
                .Distinct();

            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine($"CATEGORÍA: {categoriaSeleccionada}");
            Console.WriteLine("================================");

            foreach (var sub in subcategorias)
            {
                Console.WriteLine($"\nSubcategoría: {sub}");

                var lista = productos.Where(p =>
                    p.Categoria == categoriaSeleccionada &&
                    p.Subcategoria == sub);

                foreach (var p in lista)
                {
                    Console.WriteLine(
                        $"- {p.Nombre} | Stock: {p.Stock} | S/{p.PrecioVenta}"
                    );
                }
            }

            Console.ReadKey();
        }






        // Registra la venta de un producto.
        // Verifica la existencia del producto y la disponibilidad de stock antes de vender.
        //Se busca el producto deseado por medio del codigo registrado.
        static void RegistrarVenta()
        {
            Console.Write("Código producto: ");
            string codigo = Console.ReadLine();

            Producto p = productos.Find(x => x.Codigo == codigo);

            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
                Console.ReadKey();
                return;
            }
            int cantidad;
            Console.Write("Cantidad: ");
            while (!int.TryParse(Console.ReadLine(), out cantidad)
            || cantidad <= 0)

                if (cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida.");
                    Console.ReadKey();
                    return;
                }

            if (cantidad > p.Stock)
            {
                Console.WriteLine("Stock insuficiente.");
                Console.ReadKey();
                return;
            }

            Venta v = new Venta();

            v.Fecha = DateTime.Now;
            v.CodigoProducto = p.Codigo;
            v.NombreProducto = p.Nombre;
            v.Cantidad = cantidad;
            v.PrecioUnitario = p.PrecioVenta;
            v.TotalVenta = cantidad * p.PrecioVenta;
            ventas.Add(v);
            p.Stock -= cantidad;

            GuardarProductos();
            GuardarVentas();

            Console.WriteLine($"Venta registrada.");
            Console.WriteLine($"Total: S/{v.TotalVenta}");
            Console.ReadKey();
        }

        // Muestra todas las ventas
        // realizadas en la fecha actual.
        static void MostrarVentasDelDia()
        {
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                Console.ReadKey();
                return;
            }
            var hoy = DateTime.Today;

            foreach (var v in ventas.Where(x => x.Fecha.Date == hoy))
            {
                Console.WriteLine(
                    $"{v.NombreProducto} x{v.Cantidad} = S/{v.TotalVenta}"
                );
            }

            Console.ReadKey();
        }

        // Calcula el monto total de
        // dinero obtenido por las ventas
        // realizadas durante todo el día.
        static void TotalRecaudado()
        {
            var hoy = DateTime.Today;

            double total = ventas
                .Where(v => v.Fecha.Date == hoy)
                .Sum(v => v.TotalVenta);

            Console.WriteLine($"Total del día: S/{total}");

            Console.ReadKey();
        }


        // Permite ver los productos
        // registrados por categoría,
        // así como los agotados
        // y los que están próximos a agotarse.
        static void EstadoCategorias()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                Console.ReadKey();
                return;
            }
            var categorias = productos
       .Select(x => x.Categoria)
       .Distinct();

            foreach (var c in categorias)
            {
                var lista = productos
                    .Where(x => x.Categoria == c)
                    .ToList();

                Console.WriteLine($"\n====================");
                Console.WriteLine(c.ToUpper());
                Console.WriteLine("====================");

                Console.WriteLine($"Productos registrados: {lista.Count}");

                Console.WriteLine("\nPor agotarse:");

                var porAgotarse =
                    lista.Where(x => x.Stock > 0 && x.Stock <= 5);

                if (!porAgotarse.Any())
                {
                    Console.WriteLine("Ninguno");
                }
                else
                {
                    foreach (var p in porAgotarse)
                    {
                        Console.WriteLine($"- {p.Nombre} ({p.Stock} unidades)");
                    }
                }

                Console.WriteLine("\nAgotados:");

                var agotados =
                    lista.Where(x => x.Stock == 0);

                if (!agotados.Any())
                {
                    Console.WriteLine("Ninguno");
                }
                else
                {
                    foreach (var p in agotados)
                    {
                        Console.WriteLine($"- {p.Nombre}");
                    }
                }
            }

            Console.ReadKey();
        }


        // Genera un reporte estadístico
        // de las ventas, agrupando los productos
        // según su categoría.
        static void ReporteVentasPorCategoria()
        {
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                Console.ReadKey();
                return;
            }
            Console.Clear();

            Console.WriteLine("===================================");
            Console.WriteLine(" REPORTE DE VENTAS POR CATEGORÍA");
            Console.WriteLine("===================================");

            var categorias = productos
                .Select(p => p.Categoria)
                .Distinct();

            foreach (var categoria in categorias)
            {
                double totalCategoria = 0;
                int cantidadVendida = 0;

                foreach (var venta in ventas)
                {
                    Producto producto =
                        productos.Find(p => p.Codigo == venta.CodigoProducto);

                    if (producto != null &&
                        producto.Categoria == categoria)
                    {
                        totalCategoria += venta.TotalVenta;
                        cantidadVendida += venta.Cantidad;
                    }
                }

                Console.WriteLine($"\nCategoría: {categoria}");
                Console.WriteLine($"Productos vendidos: {cantidadVendida}");
                Console.WriteLine($"Dinero recaudado: S/{totalCategoria:F2}");
            }

            double totalGeneral =
                ventas.Sum(v => v.TotalVenta);

            Console.WriteLine("\n===================================");
            Console.WriteLine($"TOTAL GENERAL: S/{totalGeneral:F2}");
            Console.WriteLine("===================================");

            Console.ReadKey();
        }

        // Permite modificar la información de un producto registrado.
        static void ModificarProducto()
        {
            Console.Clear();
            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine().Trim().ToUpper();

            Producto p = productos.Find(x => x.Codigo.ToUpper() == codigo);

            if (p == null)
            {
                Console.WriteLine("\nProducto no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("      DATOS DEL PRODUCTO");
            Console.WriteLine("==================================");
            Console.WriteLine($"Código: {p.Codigo}");
            Console.WriteLine($"Nombre: {p.Nombre}");
            Console.WriteLine($"Categoría: {p.Categoria}");
            Console.WriteLine($"Subcategoría: {p.Subcategoria}");
            Console.WriteLine($"Unidad: {p.UnidadMedida}");
            Console.WriteLine($"Precio Compra: S/{p.PrecioCompra}");
            Console.WriteLine($"Precio Venta : S/{p.PrecioVenta}");
            Console.WriteLine($"Stock: {p.Stock}");

            Console.WriteLine("\n¿Qué desea modificar?");
            Console.WriteLine("1. Código");
            Console.WriteLine("2. Nombre");
            Console.WriteLine("3. Categoría");
            Console.WriteLine("4. Subcategoría");
            Console.WriteLine("5. Unidad de medida");
            Console.WriteLine("6. Precio de compra");
            Console.WriteLine("7. Precio de venta");
            Console.WriteLine("8. Stock");
            Console.Write("\nOpción: ");

            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 8)
            {
                Console.Write("Opción inválida. Intente nuevamente: ");
            }

            switch (opcion)
            {
                case 1:
                    CambiarCodigo(p);
                    break;

                case 2:
                    CambiarNombre(p);
                    break;

                case 3:
                    CambiarCategoria(p);
                    break;

                case 4:
                    CambiarSubcategoria(p);
                    break;

                case 5:
                    CambiarUnidad(p);
                    break;

                case 6:
                    CambiarPrecioCompra(p);
                    break;

                case 7:
                    CambiarPrecioVenta(p);
                    break;

                case 8:
                    CambiarStock(p);
                    break;
            }

            GuardarProductos();

            Console.WriteLine("\nProducto modificado correctamente.");
            Console.ReadKey();
        }
        static void CambiarCodigo(Producto p)
        {
            string nuevoCodigo;

            while (true)
            {
                Console.Write("Nuevo código: ");
                nuevoCodigo = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(nuevoCodigo))
                {
                    Console.WriteLine("El código no puede estar vacío.");
                    continue;
                }

                if (!nuevoCodigo.All(char.IsLetterOrDigit))
                {
                    Console.WriteLine("Solo se permiten letras y números.");
                    continue;
                }

                if (productos.Any(x => x.Codigo.ToUpper() == nuevoCodigo && x != p))
                {
                    Console.WriteLine("Ese código ya existe.");
                    continue;
                }

                break;
            }

            p.Codigo = nuevoCodigo;
        }
        static void CambiarNombre(Producto p)
        {
            string nombre;

            while (true)
            {
                Console.Write("Nuevo nombre: ");
                nombre = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    continue;
                }

                if (!nombre.All(c => char.IsLetterOrDigit(c) || c == ' '))
                {
                    Console.WriteLine("Solo letras y números.");
                    continue;
                }

                break;
            }

            p.Nombre = nombre;
        }
        static void CambiarCategoria(Producto p)
        {
            string categoria;

            while (true)
            {
                Console.Write("Nueva categoría: ");
                categoria = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(categoria))
                {
                    Console.WriteLine("La categoría no puede estar vacía.");
                    continue;
                }

                if (!categoria.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Solo letras.");
                    continue;
                }

                break;
            }

            p.Categoria = categoria;
        }
        static void CambiarSubcategoria(Producto p)
        {
            string subcategoria;

            while (true)
            {
                Console.Write("Nueva subcategoría: ");
                subcategoria = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(subcategoria))
                {
                    Console.WriteLine("La subcategoría no puede estar vacía.");
                    continue;
                }

                if (!subcategoria.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Solo letras.");
                    continue;
                }

                break;
            }

            p.Subcategoria = subcategoria;
        }
        static void CambiarUnidad(Producto p)
        {
            string unidad;

            while (true)
            {
                Console.Write("Nueva unidad de medida: ");
                unidad = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(unidad))
                {
                    Console.WriteLine("La unidad no puede estar vacía.");
                    continue;
                }

                if (!unidad.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Solo letras.");
                    continue;
                }

                break;
            }

            p.UnidadMedida = unidad;
        }
        static void CambiarPrecioCompra(Producto p)
        {
            double precio;

            Console.Write("Nuevo precio de compra: ");

            while (!double.TryParse(Console.ReadLine(), out precio) || precio < 0)
            {
                Console.Write("Precio inválido. Intente nuevamente: ");
            }

            p.PrecioCompra = precio;
        }
        static void CambiarPrecioVenta(Producto p)
        {
            double precio;

            Console.Write("Nuevo precio de venta: ");

            while (!double.TryParse(Console.ReadLine(), out precio) || precio < 0)
            {
                Console.Write("Precio inválido. Intente nuevamente: ");
            }

            p.PrecioVenta = precio;
        }
        static void CambiarStock(Producto p)
        {
            int stock;

            Console.Write("Nuevo stock: ");

            while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
            {
                Console.Write("Stock inválido. Intente nuevamente: ");
            }

            p.Stock = stock;
        }


        // Elimina un producto del
        // inventario previa confirmación.
        static void EliminarProducto()
        {
            Console.Write("Ingrese el código: ");
            string codigo = Console.ReadLine();

            Producto p = productos.Find(x => x.Codigo == codigo);

            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write($"¿Eliminar {p.Nombre}? (S/N): ");
            string r = Console.ReadLine().ToUpper();

            if (r == "S")
            {
                productos.Remove(p);
                GuardarProductos();
                Console.WriteLine("Producto eliminado.");
            }

            Console.ReadKey();
        }

        // Determina cuál es el producto
        // que ha registrado la mayor cantidad de ventas.
        static void ProductoMasVendido()
        {
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                Console.ReadKey();
                return;
            }

            var producto = ventas
                .GroupBy(v => v.NombreProducto)
                .OrderByDescending(g => g.Sum(x => x.Cantidad))
                .First();

            Console.WriteLine("PRODUCTO MÁS VENDIDO");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Producto: {producto.Key}");
            Console.WriteLine($"Cantidad: {producto.Sum(x => x.Cantidad)}");

            Console.ReadKey();
        }

        // Genera un resumen diario de las
        // ventas, productos agotados y dinero recaudado.
        static void CierreDelDia()
        {
            Console.Clear();

            var hoy = DateTime.Today;

            var ventasHoy =
                ventas.Where(v => v.Fecha.Date == hoy).ToList();

            double total =
                ventasHoy.Sum(v => v.TotalVenta);

            Console.WriteLine("=================================");
            Console.WriteLine("         CIERRE DEL DÍA");
            Console.WriteLine("=================================");
            Console.WriteLine($"Fecha: {hoy:dd/MM/yyyy}");
            Console.WriteLine($"Ventas realizadas: {ventasHoy.Count}");
            Console.WriteLine($"Dinero recaudado: S/{total:F2}");

            Console.WriteLine("\nProductos agotados:");

            foreach (var p in productos.Where(x => x.Stock == 0))
            {
                Console.WriteLine($"- {p.Nombre}");
            }

            Console.WriteLine("\nProductos por agotarse:");

            foreach (var p in productos.Where(x => x.Stock > 0 && x.Stock <= 5))
            {
                Console.WriteLine($"- {p.Nombre} ({p.Stock})");
            }

            Console.ReadKey();
        }

        static void MostrarHistorialVentas()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("      HISTORIAL DE VENTAS");
            Console.WriteLine("======================================");

            if (ventas.Count == 0)
            {
                Console.WriteLine("No existen ventas registradas.");
                Console.ReadKey();
                return;
            }

            foreach (Venta v in ventas)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Fecha      : {v.Fecha:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Código     : {v.CodigoProducto}");
                Console.WriteLine($"Producto   : {v.NombreProducto}");
                Console.WriteLine($"Cantidad   : {v.Cantidad}");
                Console.WriteLine($"P. Unitario: S/ {v.PrecioUnitario:F2}");
                Console.WriteLine($"Total Venta: S/ {v.TotalVenta:F2}");
            }

            Console.WriteLine("--------------------------------------");

            double total = ventas.Sum(v => v.TotalVenta);

            Console.WriteLine($"\nTOTAL HISTÓRICO: S/ {total:F2}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }



        // Guarda la información de los productos en
        // un archivo de texto para mantener la persistencia.
        static void GuardarProductos()
        {
            using (StreamWriter sw = new StreamWriter("productos.txt"))
            {
                foreach (var p in productos)
                {
                    sw.WriteLine($"{p.Codigo};{p.Categoria};{p.Subcategoria};{p.Nombre};{p.PrecioCompra};{p.PrecioVenta};{p.Stock}");
                }
            }
        }

        // Guarda el historial de ventas en un archivo de texto.
        static void GuardarVentas()
        {
            using (StreamWriter sw = new StreamWriter("ventas.txt"))
            {
                foreach (var v in ventas)
                {
                    sw.WriteLine(
                        $"{v.Fecha};{v.CodigoProducto};{v.NombreProducto};{v.Cantidad};{v.PrecioUnitario};{v.TotalVenta}"
                    );
                }
            }

        }

        // Lee el archivo de productos y carga la información
        // en la lista de inventario al iniciar el sistema.
        static void CargarProductos()
        {
            if (!File.Exists("productos.txt"))
                return;

            productos.Clear();

            foreach (var linea in File.ReadAllLines("productos.txt"))
            {
                string[] datos = linea.Split(';');

                Producto p = new Producto();

                p.Codigo = datos[0];
                p.Categoria = datos[1];
                p.Subcategoria = datos[2];
                p.Nombre = datos[3];
                p.PrecioCompra = double.Parse(datos[4]);
                p.PrecioVenta = double.Parse(datos[5]);
                p.Stock = int.Parse(datos[6]);

                productos.Add(p);
            }
        }

        // Recupera el historial de ventas almacenado
        // en el archivo de texto.
        static void CargarVentas()
        {
            if (!File.Exists("ventas.txt"))
                return;

            ventas.Clear();

            foreach (var linea in File.ReadAllLines("ventas.txt"))
            {
                string[] datos = linea.Split(';');

                Venta v = new Venta();

                v.Fecha = DateTime.Parse(datos[0]);
                v.CodigoProducto = datos[1];
                v.NombreProducto = datos[2];
                v.Cantidad = int.Parse(datos[3]);
                v.PrecioUnitario = double.Parse(datos[4]);
                v.TotalVenta = double.Parse(datos[5]);

                ventas.Add(v);
            }
        }
    }
}









