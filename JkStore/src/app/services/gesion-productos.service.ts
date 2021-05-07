import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Producto } from '../models/producto';

@Injectable({
  providedIn: 'root'
})
export class GesionProductosService {
  url = "https://localhost:5001/Producto"
  constructor(private http:HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json'
    })
  }

  consultar():Observable<Producto[]>{
    return this.http.get<Producto[]>(this.url,this.httpOptions)
  }

  
}
