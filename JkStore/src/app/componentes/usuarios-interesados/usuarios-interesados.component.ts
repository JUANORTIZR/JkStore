import { Component, OnInit } from '@angular/core';
import { Interesado } from 'src/app/models/interesado';
import { GestionInteresadoService } from 'src/app/services/gestion-interesado.service';

@Component({
  selector: 'app-usuarios-interesados',
  templateUrl: './usuarios-interesados.component.html',
  styleUrls: ['./usuarios-interesados.component.css']
})
export class UsuariosInteresadosComponent implements OnInit {
  interesados:Interesado[];
  liderEvaluo:boolean = true;
  constructor(private gestionInteresado:GestionInteresadoService) { }

  ngOnInit(): void {
    this.cosulta();
  }

  cosulta(){
    this.gestionInteresado.consultar().subscribe(i => this.interesados = i);
  }

}
