import { Producto } from "./producto";

export class Factura {
  proveedor: Proveedor;
  idInteresado: string;
  idVendedor: string;
  detallesDeFactura: DetallesDeFactura[];
}

export class  DetallesDeFactura {
  cantidad: number;
  idProducto: number;
  valorUnitario: number;
  descuento: number;
}

export class  Proveedor {
  nit: string;
  nombre: string;
  paginaWeb: string;
  productos: Producto[];
}

