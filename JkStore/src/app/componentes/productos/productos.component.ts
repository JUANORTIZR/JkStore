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
  constructor(private router: Router
    , private gestionProductoService: GesionProductosService
  ) { }

  ngOnInit(): void {
    this.consultar();
    if (this.usuario.rol == "LiderEvaluo") {
      this.liderEvaluo = true;
    }
  }

  consultar() {
    this.gestionProductoService.consultar().subscribe(p => {
      this.productos = p
    });
  }
}
