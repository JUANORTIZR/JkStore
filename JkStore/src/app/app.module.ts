import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './componentes/login/login.component';
import {InputTextModule} from 'primeng/inputtext';
import {DividerModule} from 'primeng/divider';
import {ButtonModule} from 'primeng/button';
import {PasswordModule} from 'primeng/password';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProductosComponent } from './componentes/productos/productos.component';
import { ResgistroProductoComponent } from './componentes/resgistro-producto/resgistro-producto.component';
import { NavBarComponent } from './componentes/nav-bar/nav-bar.component';
import { UsuariosInteresadosComponent } from './componentes/usuarios-interesados/usuarios-interesados.component';
import { RegistroUsuarioComponent } from './componentes/registro-usuario/registro-usuario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { CarritoComponent } from './componentes/carrito/carrito.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProductosComponent,
    ResgistroProductoComponent,
    NavBarComponent,
    UsuariosInteresadosComponent,
    RegistroUsuarioComponent,
    CarritoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    InputTextModule,
    DividerModule,
    ButtonModule,
    PasswordModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    NgbModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
