import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pedido } from '../../interfaces/Pedido';
import { Cliente } from 'src/app/interfaces/Cliente';
import { ClientesServiceService } from '../../servicios/clientes-service/clientes-service.service';

@Component({
  selector: 'app-detalle-pedido',
  templateUrl: './detalle-pedido.page.html',
  styleUrls: ['./detalle-pedido.page.scss'],
})
export class DetallePedidoPage implements OnInit {
  pedido: Pedido;
  cliente: Cliente;

  constructor(private state: ActivatedRoute,private servicioCliente: ClientesServiceService) { }

  ngOnInit() {
    this.pedido = JSON.parse(this.state.snapshot.params.pedido);
  }

  obtenerCliente(idCliente: number): Cliente {
    this.servicioCliente.obtenerCliente(idCliente)
        .subscribe(
        (cliente) => {this.cliente = cliente;},
        (error) => {console.log(error);}
      )
    return this.cliente;
 }

}
