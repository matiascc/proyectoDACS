import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../interfaces/Pedido';
import { Router, ActivatedRoute } from '@angular/router';
import { ObtenerPedidosService } from '../../servicios/pedidos-service/pedidos-service.service';


@Component({
  selector: 'app-list-reorder',
  templateUrl: './list-reorder.page.html',
  styleUrls: ['./list-reorder.page.scss'],
})
export class ListReorderPage implements OnInit {

  pedidos

  constructor(private pedidosServicio: ObtenerPedidosService , private router: Router, private state: ActivatedRoute) { }

  ngOnInit() {
    this.pedidos = JSON.parse(this.state.snapshot.params.pedido);
  }

  reorder(event){
  
    const itemMover = this.pedidos.splice(event.detail.from, 1)[0];  //devuelve los elementos que fueron eliminador en un array
    this.pedidos.splice(event.detail.to, 0, itemMover);    //quiero eliminar 0 elementos es decir añadir

    event.detail.complete();
  }

  verDetalles(pedido: Pedido){

    this.router.navigate(['detalle-pedido', {pedido: JSON.stringify(pedido)} ])
  }

  OnClick() {
    console.log(this.pedidos);
  }


}
