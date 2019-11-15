import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pedido } from '../../interfaces/Pedido';

@Component({
  selector: 'app-detalle-pedido',
  templateUrl: './detalle-pedido.page.html',
  styleUrls: ['./detalle-pedido.page.scss'],
})


export class DetallePedidoPage implements OnInit {
  pedido: Pedido;

  constructor(private state: ActivatedRoute) { }

  ngOnInit() {
    this.pedido = JSON.parse(this.state.snapshot.params.pedido);
    //debugger;
  }

  

}
