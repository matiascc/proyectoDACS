import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { IonicModule } from '@ionic/angular';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';
import { LoadingComponent } from './loading/loading/loading.component';



@NgModule({
  declarations: [HeaderComponent, MenuComponent, LoadingComponent],
  exports: [HeaderComponent, MenuComponent, LoadingComponent],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule
  ]
})
export class ComponentsModule { }
