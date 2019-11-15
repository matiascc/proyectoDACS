import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../interfaces/Pedido';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-modificar-entrega',
  templateUrl: './modificar-entrega.page.html',
  styleUrls: ['./modificar-entrega.page.scss'],
})
export class ModificarEntregaPage implements OnInit {

  pedidos

  
 

  constructor(private router: Router, private state: ActivatedRoute) { }

  ngOnInit() {
    this.pedidos = JSON.parse(this.state.snapshot.params.pedido);
  }

  verDetalles(pedido: Pedido){

    this.router.navigate(['detalle-pedido', {pedido: JSON.stringify(pedido)} ])
  }

  

}
