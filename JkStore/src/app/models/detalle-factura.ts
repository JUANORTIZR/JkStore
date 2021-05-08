import { Producto } from "./producto";

export class  DetalleDeFactura {
    cantidad: number;
    producto: Producto;
    valorUnitario: number;
    descuento: number;
}
export class  DetalleDeFacturaInput {
    cantidad: number;
    IdProducto: number;
    valorUnitario: number;
    descuento: number;
}