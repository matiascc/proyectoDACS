import { Component, OnInit } from '@angular/core';
import { Proveedor2Service } from '../../servicios/proveedor2/proveedor2.service';
import { Pedido } from '../../components/interfaces/interfaces';
import { Router } from '@angular/router';
import { Proveedor1Service } from 'src/app/servicios/proveedor1/proveedor1.service';

@Component({
  selector: 'app-list-reorder',
  templateUrl: './list-reorder.page.html',
  styleUrls: ['./list-reorder.page.scss'],
})
export class ListReorderPage implements OnInit {

  pedidos

  constructor(private noticiasServicio: Proveedor1Service , private router: Router) { }

  ngOnInit() {
    this.noticiasServicio.obtenerDatos()
    .subscribe(
      (noticias) => {this.pedidos = noticias;},
      (error) => {console.log(error)}
      )
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
