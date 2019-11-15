import { Component, OnInit, ViewChild } from '@angular/core';
import { ClientesService } from 'src/app/servicios/clientes-service/clientes-service.service';
import { Cliente } from 'src/app/interfaces/Cliente';
import { IonInfiniteScroll } from '@ionic/angular';

@Component({
  selector: 'app-agregar-pedido',
  templateUrl: './agregar-pedido.page.html',
  styleUrls: ['./agregar-pedido.page.scss'],
})
export class AgregarPedidoPage implements OnInit {

  
  clientes: Cliente[];

  constructor(private obtenerClientes: ClientesService) { }

  ngOnInit() {
    this.obtenerClientes.obtenerClientes()
    .subscribe(
      (cliente) => {this.clientes = cliente;},
      (error) => {console.log(error);}
    )
  }
 
  
}
