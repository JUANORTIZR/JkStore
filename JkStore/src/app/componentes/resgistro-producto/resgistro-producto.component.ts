import { Component, OnInit } from '@angular/core';
import { Factura, Proveedor } from 'src/app/models/factura';
import { Producto } from 'src/app/models/producto';
import { GesionProductosService } from 'src/app/services/gesion-productos.service';
import { GestionProveedorService } from 'src/app/services/gestion-proveedor.service';

@Component({
  selector: 'app-resgistro-producto',
  templateUrl: './resgistro-producto.component.html',
  styleUrls: ['./resgistro-producto.component.css']
})
export class ResgistroProductoComponent implements OnInit {
  producto:Producto;
  proveedor:Proveedor;
  factura:Factura;
  constructor(private gestionProductoService:GesionProductosService
    ,private gestionProveedorService:GestionProveedorService
      ) { }

  ngOnInit(): void {
    this.producto = new Producto();
    this.proveedor = new Proveedor();
    this.factura = new Factura();
    this.factura.evento = "Compra";
    this.factura.detallesDeFactura=[];
    this.factura.idInteresado = "na"
    this.factura.idVendedor = "na"
  }

  buscar(){
    this.gestionProveedorService.BuscarId(this.proveedor.nit).subscribe(p => this.proveedor = p);
  }
  Registrar(){
    this.producto.idProveedor = this.proveedor.nit;
    this.proveedor.productos = [];
    this.proveedor.productos.push(this.producto);
    this.factura.proveedor = new Proveedor();
    this.factura.proveedor = this.proveedor;
    this.gestionProductoService.guardar(this.factura).subscribe(f => console.log(f));
  }
}
