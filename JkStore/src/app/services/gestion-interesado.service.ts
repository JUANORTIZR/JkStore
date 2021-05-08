import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Interesado } from '../models/interesado';

@Injectable({
  providedIn: 'root'
})
export class GestionInteresadoService {
  url = "https://localhost:5001/Interesado";
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }

  guardar(interesado:Interesado):Observable<Interesado>{
    return this.http.post<Interesado>(this.url, interesado, this.httpOptions )
    .pipe(
      tap(p => console.log(p))
    )
  }

  consultar(): Observable<Interesado[]> {
    return this.http.get<Interesado[]>(this.url, this.httpOptions)
  }
}
