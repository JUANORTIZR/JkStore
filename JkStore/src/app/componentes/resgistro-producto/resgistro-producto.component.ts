import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';

@Component({
  selector: 'app-resgistro-producto',
  templateUrl: './resgistro-producto.component.html',
  styleUrls: ['./resgistro-producto.component.css']
})
export class ResgistroProductoComponent implements OnInit {
  producto:Producto;
  constructor() { }

  ngOnInit(): void {
    this.producto = new Producto();
  }

  Registrar(){
    
  }
}
