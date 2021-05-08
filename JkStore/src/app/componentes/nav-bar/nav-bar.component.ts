import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  usuario:Usuario = JSON.parse(localStorage.getItem("UsuarioActivo"));
  liderEvaluo:boolean=false;
  constructor(private router:Router) { }

  ngOnInit(): void {
    if(this.usuario.rol == "LiderEvaluo"){
        this.liderEvaluo = true;
    }
  }
 
  cerrarSesion() {
    localStorage.removeItem("UsuarioActivo");
    this.router.navigate(['/Login'])
  }
}
