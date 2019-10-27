import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pedido } from '../../interfaces/Pedido';
import { ObtenerPedidosService } from '../../servicios/pedidos-service/pedidos-service.service';
import { Cliente } from 'src/app/interfaces/Cliente';
import { ClientesServiceService } from '../../servicios/clientes-service/clientes-service.service';


@Component({
  selector: 'app-entregas-pendientes',
  templateUrl: './entregas-pendientes.page.html',
  styleUrls: ['./entregas-pendientes.page.scss'],
})
export class EntregasPendientesPage implements OnInit {

  // pedidos: Pedido[] = [
  //   {
  //     id: 1,
  //     fechaCreacion: new Date,
  //     fechaFinalizacion: new Date,
  //     fechaLimite: new Date,
  //     Entregado: {id: 1},
  //     precioTotal: 11,
  //     idcliente: 2,
  //     itemPedido: {
  //       id: 1,
  //       cantidad: 3,
  //       cantidadRechazada: 3,
  //       precio: 4,
  //       idProducto: 3
  //     }
  //   }
  // ];
   pedidos : Pedido[];
  
   entregas: any = [];

  constructor(private serviciosPedido: ObtenerPedidosService, private router: Router, private servicioCliente: ClientesServiceService) { }

     ngOnInit() { 
        this.serviciosPedido.obtenerPedidos()
        .subscribe(
        (pedidos) => {this.pedidos= pedidos;},
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
    this.router.navigate(['list-reorder', {pedido: JSON.stringify(this.entregas)} ])
 }
 
 mostrarPedido(){

 }
 verDetalles(pedido: Pedido){

  this.router.navigate(['detalle-pedido', {pedido: JSON.stringify(pedido)} ])
}


}
