Algoritmo SistemaInventarioVentas
	// Variable que almacena la opción del menú principal
	Definir opcion Como Entero
	// El programa se repite hasta que el usuario elija salir
	Repetir
		// MENÚ PRINCIPAL
		Escribir '================================='
		Escribir 'LIBRERIA Y BAZAR '
		Escribir 'SISTEMA DE INVENTARIO Y VENTAS'
		Escribir '================================='
		Escribir '1. Registrar producto'
		Escribir '2. Buscar producto'
		Escribir '3. Mostrar inventario'
		Escribir '4. Mostrar inventario por categorias'
		Escribir '5. Registrar venta'
		Escribir '6. Ver ventas del día'
		Escribir '7. Ver total recaudado'
		Escribir '8. Estado de categorías'
		Escribir '9. Reporte de ventas por categoría'
		Escribir '10. Modificar producto'
		Escribir '11. Eliminar producto'
		Escribir '12. Producto más vendido'
		Escribir '13. Cierre del día'
		Escribir '14. Historial de ventas'
		Escribir '15. Guardar datos'
		Escribir '16. Salir'
		// Pedimos la opción al usuario
		Escribir ''
		Escribir 'Ingrese una opción:'
		Leer opcion
		Según opcion Hacer
			1:
				RegistrarProducto()
			2:
				BuscarProducto()
			3:
				MostrarInventario()
			4:
				MostrarInventarioPorCategoria()
			5:
				RegistrarVenta()
			6:
				MostrarVentasDelDia()
			7:
				TotalRecaudado()
			8:
				EstadoCategorias()
			9:
				ReporteVentasPorCategoria()
			10:
				ModificarProducto()
			11:
				EliminarProducto()
			12:
				ProductoMasVendido()
			13:
				CierreDelDia()
			14:
				HistorialDeVentas()
			15:
				GuardarDatos()
			16:
				Escribir 'Gracias por utilizar el sistema.'
				// Si el usuario ingresa una opción inválida
			De Otro Modo:
				Escribir 'Opción inválida. Intente nuevamente.'
		FinSegún
	Hasta Que opcion=16
FinAlgoritmo

// Permite ingresar un nuevo producto al sistema
Función RegistrarProducto
	Definir nombre Como Cadena
	Definir precio, stock Como Entero
	Escribir 'REGISTRAR PRODUCTO'
	// Pedimos los datos básicos del producto
	Escribir 'Nombre:'
	Leer nombre
	Escribir 'Precio:'
	Leer precio
	Escribir 'Stock:'
	Leer stock
	Escribir 'Producto registrado correctamente.'
FinFunción

// ===================== BUSCAR PRODUCTO =====================
// Simula la búsqueda de un producto por código
Función BuscarProducto
	Definir codigo Como Cadena
	Definir nombre Como Cadena
	Escribir 'Ingrese código del producto:'
	Escribir 'Ingrese nombre del producto:'
	Leer codigo
	Leer nombre
	Escribir 'Buscando producto...'
FinFunción

// ===================== INVENTARIO =====================
// Muestra todos los productos (simulación)
Función MostrarInventario
	Escribir 'Mostrando inventario completo...'
FinFunción

// ===================== INVENTARIO SEGUN CATEGORIAS =====================
// Muestra todos los productos por categoria (simulación)
Función MostrarInventarioPorCategoria
	Escribir 'Mostrando inventario completo...'
FinFunción

// ===================== REGISTRAR VENTA =====================
// Registra una venta simple validando la cantidad
Función RegistrarVenta
	Definir cantidad Como Entero
	Escribir 'Cantidad vendida:'
	Leer cantidad
	// Validamos que la venta sea correcta
	Si cantidad>0 Entonces
		Escribir 'Venta registrada correctamente.'
	SiNo
		Escribir 'Error: cantidad inválida.'
	FinSi
FinFunción

// ===================== VENTAS DEL DÍA =====================
Función MostrarVentasDelDia
	Escribir 'Mostrando ventas realizadas en el día...'
FinFunción

// ===================== TOTAL RECAUDADO =====================
Función TotalRecaudado
	Escribir 'Calculando total de dinero recaudado...'
FinFunción

// ===================== CATEGORÍAS =====================
Función EstadoCategorias
	Escribir 'Mostrando estado de categorías...'
FinFunción

// ===================== REPORTE POR CATEGORÍA =====================
Función ReporteVentasPorCategoria
	Escribir 'Generando reporte de ventas por categoría...'
FinFunción

// ===================== MODIFICAR PRODUCTO =====================
Función ModificarProducto
	Escribir 'Modificar datos de un producto existente...'
FinFunción

// ===================== ELIMINAR PRODUCTO =====================
Función EliminarProducto
	Escribir 'Eliminar producto del inventario...'
FinFunción

// ===================== PRODUCTO MÁS VENDIDO =====================
Función ProductoMasVendido
	Escribir 'Calculando producto más vendido...'
FinFunción

// ===================== CIERRE DEL DÍA =====================
Función CierreDelDia
	Escribir 'Generando resumen de cierre del día...'
FinFunción

// ===================== HISTORIAL DE VENTAS =====================
Función HistorialDeVentas
	Escribir 'Generando historial de ventas...'
FinFunción

// ===================== GUARDAR DATOS =====================
Función GuardarDatos
	Escribir 'Guardando información del sistema...'
FinFunción
