import { Component, OnInit } from '@angular/core';
import { Interesado } from 'src/app/models/interesado';
import { GestionInteresadoService } from 'src/app/services/gestion-interesado.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-registro-usuario',
  templateUrl: './registro-usuario.component.html',
  styleUrls: ['./registro-usuario.component.css']
})
export class RegistroUsuarioComponent implements OnInit {
  interesado:Interesado;
 
  constructor(private gestionInteresado:GestionInteresadoService) { }

  ngOnInit(): void {
    this.interesado = new Interesado;
  }
  

  Registrar(){
    this.gestionInteresado.guardar(this.interesado).subscribe(i => {
      this.interesado = i
      console.log(i);
    });
  }
}
