import { Component, OnInit } from '@angular/core';
import { MenuController } from '@ionic/angular';
import { Componente } from '../../interfaces/Interfaces';
import { Router } from '@angular/router';
import { AuthService } from './../../servicios/autenticacion-service/auth.service';
import { RepartosService } from '../../servicios/repartos-service/repartos-service.service';
import { Reparto } from 'src/app/interfaces/Reparto';


@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss'],
})
export class InicioPage implements OnInit {
  
  componentes: Componente[] = [];
  repartos: Reparto[];

  constructor(private menuCtrl: MenuController, 
    private authService: AuthService,
    private servicioReparto: RepartosService,
    private router: Router) { }

  ngOnInit() {
    this.servicioReparto.obtenerRepartos()
    .subscribe(
      (repartos) => {this.repartos = repartos;},
      (error) => {console.log(error)}
    )
  }

  toggleMenu(){
    this.menuCtrl.toggle();
  }
  logout(){
    this.authService.doLogout()
    .then(res => {
      this.router.navigate(["/login"]);
    }, err => {
      console.log(err);
    })
  }

 armarRecorrido(){
   this.router.navigate(['/entregas-pendientes'])
 }
  
}

