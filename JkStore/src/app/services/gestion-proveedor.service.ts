import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Proveedor } from '../models/factura';

@Injectable({
  providedIn: 'root'
})
export class GestionProveedorService {
  url = "https://localhost:5001/Proveedor"
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }

  BuscarId(id:string): Observable<Proveedor> {
    return this.http.get<Proveedor>(this.url+"/"+id, this.httpOptions)
    .pipe(
      tap(p => console.log(p))
    )
  }

}
