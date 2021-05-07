import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Login, Usuario } from '../models/usuario';
import { catchError, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url = "https://localhost:5001/Usuario/Login"
  constructor(private http:HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }
  
  buscarCliente(login:Login):Observable<Usuario>{
    return this.http.post<Usuario>(this.url, JSON.stringify(login), this.httpOptions)
    .pipe(
      tap(l => {
        console.log(l)
        localStorage.setItem("UsuarioActivo",JSON.stringify(l))
      })
    );
  }
  
 
}
