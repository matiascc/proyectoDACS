import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../../interfaces/Cliente';
import { ClientesService } from '../../../servicios/clientes-service/clientes-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seleccionar-cliente',
  templateUrl: './seleccionar-cliente.page.html',
  styleUrls: ['./seleccionar-cliente.page.scss'],
})
export class SeleccionarClientePage implements OnInit {

  textoBuscar = '';
  clientes: Cliente[] = [];

  constructor(private servicioClientes: ClientesService, private router: Router) { }

  ngOnInit() {
    this.servicioClientes.obtenerClientes()
    .subscribe(
      (clientes) => {this.clientes = clientes;},
      (error) => {console.log(error);}
    )
  }

  seleccionado(cliente: Cliente){

    this.router.navigate(['agregar-productos', {cliente: JSON.stringify(cliente)} ])
  }

  buscar(event) {
   // console.log(event);
   this.textoBuscar = event.detail.value;
  }

}
