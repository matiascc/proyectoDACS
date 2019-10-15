import { Component, OnInit } from '@angular/core';
import { Proveedor2Service } from '../../servicios/proveedor2/proveedor2.service';
import { Pedido } from '../../components/interfaces/interfaces';


@Component({
  selector: 'app-entregas-pendientes',
  templateUrl: './entregas-pendientes.page.html',
  styleUrls: ['./entregas-pendientes.page.scss'],
})
export class EntregasPendientesPage implements OnInit {

  pedidos;
  entregas: any = [];

  constructor(private serviciosPedido: Proveedor2Service) { }

  ngOnInit() {
    this.serviciosPedido.verPedidos()
    .subscribe(
      (pedidos) => {this.pedidos = pedidos;},
      (error) => {console.log(error);}
    )
  }


 agregarPedido(event, pedido: any){
   if (event.target.checked) {
     this.entregas.push(pedido);
     console.log(this.entregas);
   }
   else {
     let index = this.quitarPedidoDeLista(pedido);
     this.entregas.splice(index,1);
     console.log(this.entregas);
   }
   
 }

 quitarPedidoDeLista(pedido: any){
    return this.entregas.findIndex((categoria)=>{
      return categoria === pedido;
    })
 }

 obtenerPedidosSeleccionados(){
    console.log(this.entregas);
 }
 
 mostrarPedido(){

 }

}
