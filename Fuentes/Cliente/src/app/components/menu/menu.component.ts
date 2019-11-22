import { Component, OnInit } from '@angular/core';
import { Proveedor2Service } from '../../servicios/proveedor2/proveedor2.service';
import { Observable } from 'rxjs';
import { Componente } from '../interfaces/interfaces';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {

  componentes: Observable<Componente[]>;
  
  constructor(private dataService: Proveedor2Service) { }

  ngOnInit() {
    this.componentes = this.dataService.getMenuOpts();
  }

}
