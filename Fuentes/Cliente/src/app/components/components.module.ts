import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { IonicModule } from '@ionic/angular';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';
import { LoadingComponent } from './loading/loading/loading.component';
import { BuscarComponent } from './buscar/buscar.component';



@NgModule({
  declarations: [HeaderComponent, MenuComponent, LoadingComponent, BuscarComponent],
  exports: [HeaderComponent, MenuComponent, LoadingComponent, BuscarComponent],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule
  ]
})
export class ComponentsModule { }
