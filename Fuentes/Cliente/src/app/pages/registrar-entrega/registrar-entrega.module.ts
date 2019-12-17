import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { ComponentsModule } from 'src/app/components/components.module';


import { IonicModule } from '@ionic/angular';

import { RegistrarEntregaPage } from './registrar-entrega.page';

const routes: Routes = [
  {
    path: '',
    component: RegistrarEntregaPage
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
  declarations: [RegistrarEntregaPage]
})
export class RegistrarEntregaPageModule {}
