import { Component, OnInit } from '@angular/core';
import { MenuController } from '@ionic/angular';
import { Componente } from '../../interfaces/Interfaces';
import { Router } from '@angular/router';
import { AuthService } from './../../servicios/autenticacion-service/auth.service';


@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss'],
})
export class InicioPage implements OnInit {
  
  componentes: Componente[] = [];

  constructor(private menuCtrl: MenuController, private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
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
  
}

