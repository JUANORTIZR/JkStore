import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  usuario: Usuario =JSON.parse(localStorage.getItem("UsuarioActivo")) ;
  constructor(private router:Router){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    var rol = route.data.rol;
    
    if(this.usuario == null){
      this.router.navigate(["/Login"]);
      return false;
    }
    if(rol == "Todos"){
      return true;
    }
    if(rol==this.usuario.rol){
      return true;
    }    
    
  }
  
}
