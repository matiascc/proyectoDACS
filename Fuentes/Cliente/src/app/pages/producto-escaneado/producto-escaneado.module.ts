import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { ComponentsModule } from 'src/app/components/components.module';

import { IonicModule } from '@ionic/angular';

import { ProductoEscaneadoPage } from './producto-escaneado.page';

const routes: Routes = [
  {
    path: '',
    component: ProductoEscaneadoPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
    ComponentsModule 
  ],
  declarations: [ProductoEscaneadoPage]
})
export class ProductoEscaneadoPageModule {}
