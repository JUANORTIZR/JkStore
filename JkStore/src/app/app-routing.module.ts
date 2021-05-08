import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarritoComponent } from './componentes/carrito/carrito.component';
import { LoginComponent } from './componentes/login/login.component';
import { NavBarComponent } from './componentes/nav-bar/nav-bar.component';
import { ProductosComponent } from './componentes/productos/productos.component';
import { RegistroUsuarioComponent } from './componentes/registro-usuario/registro-usuario.component';
import { ResgistroProductoComponent } from './componentes/resgistro-producto/resgistro-producto.component';
import { UsuariosInteresadosComponent } from './componentes/usuarios-interesados/usuarios-interesados.component';
import { AuthGuard } from './Guards/auth.guard';

const routes: Routes = [
  {
    path:'Login',
    component:LoginComponent
  },
  {
    path:'Productos',
    component: ProductosComponent,
    canActivate: [AuthGuard], data: {"rol": "Todos"},
    pathMatch: "full"
  },
  {
    path: "registroProducto",
    canActivate: [AuthGuard], data: {"rol": "LiderEvaluo"},
    component: ResgistroProductoComponent,
  },
  {
    path: "usuarioInteresados",
    canActivate: [AuthGuard], data: {"rol": "LiderEvaluo"},
    component: UsuariosInteresadosComponent
  },
  {
    path: "registroUsuario",
    canActivate: [AuthGuard], data: {"rol": "LiderEvaluo"},
    component: RegistroUsuarioComponent
  },
  {
    path: "carrito",
    canActivate: [AuthGuard], data: {"rol": "LiderVenta"},
    component:CarritoComponent
  },
  {
    path: "**",
    redirectTo: "Login"
  },
];

@NgModule({

  imports: [RouterModule.forRoot(routes),CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
