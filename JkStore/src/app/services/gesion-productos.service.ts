import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Factura } from '../models/factura';
import { Producto } from '../models/producto';

@Injectable({
  providedIn: 'root'
})
export class GesionProductosService {
  url = "https://localhost:5001"
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }

  consultar(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.url+"/Producto", this.httpOptions)
  }

  guardar(factura):Observable<any> {
    return this.http.post<Factura>(this.url+"/Factura", JSON.stringify(factura) , this.httpOptions)
      .pipe(
        tap(f => console.log(f))
      )
  }
}
