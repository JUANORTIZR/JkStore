import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  value3:string;
  constructor(private loginService:LoginService) { }

  ngOnInit(): void {
    this.loginService.buscarCliente("Juan","1234").subscribe(u => console.log(u));
  }

}
