import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  { path: 'inicio', loadChildren: './pages/inicio/inicio.module#InicioPageModule' },
  { path: 'list-reorder', loadChildren: './pages/list-reorder/list-reorder.module#ListReorderPageModule' },
  { path: 'detalle-pedido', loadChildren: './pages/detalle-pedido/detalle-pedido.module#DetallePedidoPageModule' },
  { path: 'entregas-pendientes', loadChildren: './pages/entregas-pendientes/entregas-pendientes.module#EntregasPendientesPageModule' },
  { path: 'escanear-codigo', loadChildren: './pages/escanear-codigo/escanear-codigo.module#EscanearCodigoPageModule' },
  { path: 'seleccionar-cliente', loadChildren: './pages/nuevo-pedido/seleccionar-cliente/seleccionar-cliente.module#SeleccionarClientePageModule' },
  { path: 'agregar-productos', loadChildren: './pages/nuevo-pedido/agregar-productos/agregar-productos.module#AgregarProductosPageModule' },
  { path: 'login', loadChildren: './pages/login/login.module#LoginPageModule' }

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
