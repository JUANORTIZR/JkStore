import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { Factura, FacturaInput} from 'src/app/models/factura';
import { Usuario } from 'src/app/models/usuario';
import { DetalleDeFactura, DetalleDeFacturaInput } from 'src/app/models/detalle-factura';
import { GesionProductosService } from 'src/app/services/gesion-productos.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent implements OnInit {
  carrito:Producto[]=[];
  totalCarrito:number=0;
  cantidad:0;
  detalles:DetalleDeFactura[]=[];
  factura:FacturaInput;
  usuario:Usuario;
  constructor(private gestionProductoService:GesionProductosService
    ,private route:Router
    ) { }

  ngOnInit(): void {
    this.usuario = new Usuario();
    
    this.construirFactura();
    this.recuperarCarrito();
    this.CrearDetalles();
    console.log(this.detalles);
  }
  construirFactura(){
    this.usuario = JSON.parse(localStorage.getItem("UsuarioActivo"));

    this.factura = new FacturaInput();
    this.factura.idVendedor = this.usuario.identificacion;
    this.factura.evento = "Venta";
    this.factura.idInteresado = "123123";
  }



  comprar(){
    var detallesInput = this.mapear();
    this.factura.detallesDeFactura = detallesInput;
    this.gestionProductoService.guardar(this.factura).subscribe(f => console.log(f));
    localStorage.removeItem("carrito");
    this.route.navigate(['/Productos'])
  }


  mapear(){
    var detallesInput:DetalleDeFacturaInput[]=[];
    this.detalles.forEach(element => {
      var detalle:DetalleDeFacturaInput = new DetalleDeFacturaInput();
      detalle.IdProducto = element.producto.codigo;
      detalle.cantidad = element.cantidad;
      detalle.descuento = element.descuento;
      detalle.valorUnitario = element.valorUnitario;
      detallesInput.push(detalle);
    });
    return detallesInput;
  }

  CrearDetalles(){  
    this.carrito.forEach(c => {
       var detalle:DetalleDeFactura = new DetalleDeFactura();
       detalle.producto = new Producto();
       detalle.producto.idProveedor = c.idProveedor;
       detalle.producto.codigo = c.codigo;
       detalle.producto.categoria = c.categoria;
       detalle.producto.fecha = c.fecha;
       detalle.producto.descripcion = c.descripcion;
       detalle.producto.nombre = c.nombre;
       detalle.producto.valorUnitario = c.valorUnitario;
       this.detalles.push(detalle);
    });
  }

  recuperarCarrito(){
    this.carrito = JSON.parse(localStorage.getItem("carrito"));
    if(this.carrito==null){
      this.carrito = []
    }else{
      this.totalCarrito = this.carrito.length;
    }
  }
}
