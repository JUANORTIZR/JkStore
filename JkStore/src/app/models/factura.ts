import { DetalleDeFactura, DetalleDeFacturaInput } from "./detalle-factura";
import { Producto } from "./producto";

export class Factura {
  evento:string;
  proveedor: Proveedor;
  idInteresado: string;
  idVendedor: string;
  detallesDeFactura: DetalleDeFactura[];
}

export class FacturaInput {
  evento:string;
  proveedor: Proveedor;
  idInteresado: string;
  idVendedor: string;
  detallesDeFactura: DetalleDeFacturaInput[];
}


export class  Proveedor {
  nit: string;
  nombre: string;
  paginaWeb: string;
  productos: Producto[];
}

