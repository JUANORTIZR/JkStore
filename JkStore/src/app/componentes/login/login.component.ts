import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Login, Usuario } from 'src/app/models/usuario';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login:Login;
  usuario:Usuario = JSON.parse(localStorage.getItem("UsuarioActivo"));
  constructor(private loginService:LoginService
    ,private router:Router
    ) { }
  
  ngOnInit(): void {
    this.login = new Login();
    if(this.usuario!=null){
      this.router.navigate(['/Productos'])
    }
  }

  iniciarSesion(){
    this.loginService.buscarCliente(this.login).subscribe(u => {
      
      if(u!=null){
        this.router.navigate(['/Productos'])
        console.log(u);
      }
      
    });
  }
}
