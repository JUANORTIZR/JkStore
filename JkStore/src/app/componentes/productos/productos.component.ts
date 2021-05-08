import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Producto } from 'src/app/models/producto';
import { Usuario } from 'src/app/models/usuario';
import { GesionProductosService } from 'src/app/services/gesion-productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  usuario: Usuario = JSON.parse(localStorage.getItem("UsuarioActivo"));
  productos: Producto[] = [];
  liderEvaluo: boolean = false;
  liderVenta: boolean = false;
  totalCarrito: number = 0;
  carrito: Producto[] = [];
  constructor(private router: Router
    , private gestionProductoService: GesionProductosService
  ) { }

  ngOnInit(): void {
    this.consultar();
    this.validarUsuario();
    this.recuperarCarrito();
  }
  validarUsuario(){
    if (this.usuario.rol == "LiderEvaluo") {
      this.liderEvaluo = true;
    }
    if (this.usuario.rol == "LiderVenta") {
      this.liderVenta = true;
    }
  }

  agregarAlCarrito(producto?: Producto) {  
    if(!this.validarProducto(producto)){
      this.carrito.push(producto);
      localStorage.setItem("carrito", JSON.stringify(this.carrito));
      this.totalCarrito = this.carrito.length;
    }
  }
  recuperarCarrito(){
    this.carrito = JSON.parse(localStorage.getItem("carrito"));
    if(this.carrito==null){
      this.carrito = []
    }else{
      this.totalCarrito = this.carrito.length;
    }
  }

  validarProducto(producto:Producto):boolean{
    var encontrado = false;
    if (this.carrito.length === 0) {
      encontrado = false;
    }
    this.carrito.forEach(c => {
      if (c.codigo === producto.codigo) {
        encontrado = true;
      }
    });
    return encontrado
  }

  consultar() {
    this.gestionProductoService.consultar().subscribe(p => {
      this.productos = p
    });
  }
}
