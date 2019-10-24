import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pedido } from '../../interfaces/Pedido';
import { ObtenerPedidosService } from '../../servicios/pedidos-service/pedidos-service.service';
import { Cliente } from 'src/app/interfaces/Cliente';


@Component({
  selector: 'app-entregas-pendientes',
  templateUrl: './entregas-pendientes.page.html',
  styleUrls: ['./entregas-pendientes.page.scss'],
})
export class EntregasPendientesPage implements OnInit {

  // pedidos: Pedido[] = [
  //   {
  //   id: 1,
  //   cliente:
  //    {
  //             nombre: "Juan",
  //             apellido: "Raffo",
  //             address: "Rondeau 123",
  //             cell_phone: "11111"
  //     },
  //   fechaCreacion: new Date,
  //   fechaFinalizacion: new Date,
  //   fechaLimite: new Date,
  //   Entregado: {id: 1},
  //   precioTotal: 11
  //   },
  //   {
  //     id: 2,
  //     cliente:
  //    {
  //             nombre: "Nahuel",
  //             apellido: "Montesino",
  //             address: "Zaninetu 44",
  //             cell_phone: "11111"

  //     },
  //     fechaCreacion: new Date,
  //     fechaFinalizacion: new Date,
  //     fechaLimite: new Date,
  //     Entregado: {id: 2},
  //     precioTotal: 3
  //   },
  //   {
  //     id: 3,
  //     cliente:
  //    {
  //             nombre: "Matias",
  //             apellido: "Caporale",
  //             address: "Moreno 111",
  //             cell_phone: "11111"

  //     },
  //     fechaCreacion: new Date,
  //     fechaFinalizacion: new Date,
  //     fechaLimite: new Date,
  //     Entregado: {id: 2},
  //     precioTotal: 5
  //   }
  // ];
  pedidos : Pedido[];
  clientes : Cliente[];
  entregas: any = [];

  constructor(private serviciosPedido: ObtenerPedidosService, private router: Router) { }

  ngOnInit() {
       this.serviciosPedido.obtenerPedidos()
       .subscribe(
       (pedidos) => {this.pedidos= pedidos;},
       (error) => {console.log(error);}
    )
       this.serviciosPedido.obtenerClientes()
      .subscribe(
      (cliente) => {this.clientes= cliente;},
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
