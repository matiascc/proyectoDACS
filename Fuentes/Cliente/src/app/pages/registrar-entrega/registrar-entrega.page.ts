import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pedido } from '../../interfaces/Pedido';

@Component({
  selector: 'app-registrar-entrega',
  templateUrl: './registrar-entrega.page.html',
  styleUrls: ['./registrar-entrega.page.scss'],
})
export class RegistrarEntregaPage implements OnInit {
  pedido:Pedido;

  constructor(private state: ActivatedRoute) { }

  ngOnInit() {
    this.pedido = JSON.parse(this.state.snapshot.params.pedido);
  }

}
