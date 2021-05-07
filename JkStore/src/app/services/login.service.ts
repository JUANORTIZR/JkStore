import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Usuario } from '../models/usuario';
import { catchError, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url = "https://localhost:5001/Usuario"
  constructor(private http:HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('A ocurrido un error', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}` +
        ` Body was: ${error.message}`
      );
    }
    return throwError('Something bad happened; please try again later');
  }
  //error aqui terminar
  buscarCliente(nombreUsuario:string, clave:string):Observable<Usuario>{
    return this.http.get<Usuario>(this.url + '/' + nombreUsuario+'/'+clave, this.httpOptions)
    .pipe(
      tap(_ => console.log("Datos enviados")),
      catchError(this.handleError)
    );
  }
  
 
}
