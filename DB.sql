create table Rol(
idRol int primary key identity(1,1),
descripcion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

create table Menu(
idMenu int primary key identity(1,1),
descripcion varchar(30),
idMenuPadre int references Menu(idMenu),
icono varchar(30),
controlador varchar(30),
paginaAccion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

 create table RolMenu(
 idRolMenu int primary key identity(1,1),
 idRol int references Rol(idRol),
 idMenu int references Menu(idMenu),
 esActivo bit,
 fechaRegistro datetime default getdate()
 )

 create table Usuario(
idUsuario int primary key identity(1,1),
nombre varchar(50),
correo varchar(50),
telefono varchar(50),
idRol int references Rol(idRol),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

create table Producto(
idProducto int primary key identity(1,1),
codigo varchar(15),
sku varchar(15),
nombre varchar(100),
descripcion varchar(500),
unidad varchar(3),
categoria varchar(10),
costo decimal(10,2),
precio decimal(10,2),
utilidad float,
costoUSD decimal(10,2),
cotizacionProveedor varchar(20),
idProveedor int,
stock varchar(5),
urlImagen varchar(500),
nombreImagen varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

create table NumeroCorrelativo(
idNumeroCorrelativo int primary key identity(1,1),
ultimoNumero int,
cantidadDigitos int,
gestion varchar(50),
fechaActualizacion datetime
)

create table Cliente(
idCliente int primary key identity(1,1),
nombre varchar(150),
rfc varchar(13),
calle varchar(50),
colonia varchar(50),
municipio varchar(50),
alias varchar(10),
fechaRegistro datetime default getdate()
)

create table ColaboradorCliente(
idColaborador int primary key identity(1,1),
idCliente int references Cliente(idCliente),
nombre varchar(60),
correo varchar(60),
telefono varchar(10)
)

create table Cotizacion(
idCotizacion int primary key identity(1,1),
numeroCotizacion varchar(10),
idUsuario int references Usuario(idUsuario),
idCliente int references Cliente(idCliente),
idColaborador int references ColaboradorCliente(idColaborador),
fecha datetime default getdate(),
total decimal(10,2),
formaPago varchar(8),
condicionPago varchar(50),
validez int,
lab varchar(20),
moneda varchar(20),
descripcion varchar(20),
notas varchar(500),
estatus varchar(20),
referencia varchar(20)
)

create table Proveedor(
idProveedor int primary key identity(1,1),
nombre varchar(150),
rfc varchar(13),
calle varchar(50),
colonia varchar(50),
municipio varchar(50),
alias varchar(10),
credito bit,
plazo int,
importe decimal(7,2),
saldoRestante decimal(7,2)
)

create table Vendedor(
idVendedor int primary key identity(1,1),
idProveedor int references Proveedor(idProveedor),
nombre varchar(60),
correo varchar(60),
telefono varchar(10)
)

create table DetalleCotizacion(
idDetalleCotizacion int primary key identity(1,1),
idCotizacion int references Cotizacion(idCotizacion),
idProducto int,
codigo varchar(15),
sku varchar(15),
nombre varchar(100),
descripcion varchar(500),
categoria varchar(10),
cantidad decimal(10,1),
precio decimal(10,2),
total decimal(10,2),
entrega varchar(9),
idCotizacionProveedor varchar(20),
idProveedor int references Proveedor(idProveedor)
)

create table Negocio(
idNegocio int primary key,
urlLogo varchar(500),
nombreLogo varchar(100),
nombre varchar(100),
rfc varchar(13),
correo varchar(50),
calle varchar(50),
colonia varchar(50),
municipio varchar(50),
telefono varchar(10),
IVA decimal(2,2)
)

create table OrdenCompra(
idOrdenCompra int primary key identity(1,1),
numeroOrden varchar(10),
idUsuario int references Usuario(idUsuario),
idCotizacion int references Cotizacion(idCotizacion),
idProveedor int references Proveedor(idProveedor),
idVendedor int references Vendedor(idVendedor),
fecha datetime default getdate(),
referencia varchar(20),
moneda varchar(3),
uso varchar(3),
total decimal(10,2)
)

create table DetalleOrdenCompra(
idDetalleOrdenCompra int primary key identity(1,1),
idOrdenCompra int references OrdenCompra(idOrdenCompra),
idProducto int,
codigo varchar(15),
sku varchar(15),
nombre varchar(100),
descripcion varchar(500),
categoria varchar(10),
cantidad decimal(10,1),
costo decimal(10,2),
total decimal(10,2)
)

create table SeguimientoFacturas(
idSeguimiento int primary key identity(1,1),
numeroFactura varchar(11),
idOrdenCompra int references OrdenCompra(idOrdenCompra),
idCliente int references Cliente(idCliente),
estado varchar(10),
importe decimal(10,2),
moneda varchar(3),
fechaAlmacen date,
credito int,
fechaReal date,
krea varchar(15)
)

create table FacturasProveedores(
idFacturaProveedor int primary key identity(1,1),
numeroFactura varchar(11),
idOrdenCompra int references OrdenCompra(idOrdenCompra),
idProveedor int references Proveedor(idProveedor),
fecha date,
vence date,
estado varchar(7),
importe decimal(10,2),
moneda varchar(3),
fechaPago date,
referencia varchar(15)
)