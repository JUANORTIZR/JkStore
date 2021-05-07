import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './componentes/login/login.component';
import { NavBarComponent } from './componentes/nav-bar/nav-bar.component';
import { ProductosComponent } from './componentes/productos/productos.component';
import { ResgistroProductoComponent } from './componentes/resgistro-producto/resgistro-producto.component';
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
    path: "**",
    redirectTo: "Login"
  },
];

@NgModule({

  imports: [RouterModule.forRoot(routes),CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
