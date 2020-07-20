import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Componente } from '../../interfaces/Interfaces';
import { ObtenerPedidosService } from '../../servicios/pedidos-service/pedidos-service.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {

  componentes: Observable<Componente[]>;
  
  constructor(private dataService: ObtenerPedidosService) { }

  ngOnInit() {
    this.componentes = this.dataService.getMenuOpts();
  }
}
