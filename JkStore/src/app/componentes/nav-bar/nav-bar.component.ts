import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  
  liderEvaluo:boolean=false;
  liderVenta:boolean=false;
  @Input() totalCarrito:number;
  constructor(private router:Router) { }

  ngOnInit(): void {
    var usuario = JSON.parse(localStorage.getItem("UsuarioActivo"));
    if(usuario.rol == "LiderEvaluo"){
        this.liderEvaluo = true;
    }
    if(usuario.rol == "LiderVenta"){
      this.liderVenta = true;
  }
  }
 
  cerrarSesion() {
    localStorage.removeItem("UsuarioActivo");
    localStorage.removeItem("carrito");
    this.router.navigate(['/Login'])
  }
}
