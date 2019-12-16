import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from '../../../interfaces/Cliente';
import { ProductosService } from '../../../servicios/productos-service/productos.service';
import { Producto } from 'src/app/interfaces/Producto';


@Component({
  selector: 'app-agregar-productos',
  templateUrl: './agregar-productos.page.html',
  styleUrls: ['./agregar-productos.page.scss'],
})
export class AgregarProductosPage implements OnInit {
  
  cliente : Cliente;
  productos: Producto[] = [];

  constructor(private state: ActivatedRoute, private servicioProductos: ProductosService) { }

  ngOnInit() {
    this.cliente = JSON.parse(this.state.snapshot.params.cliente);
     this.servicioProductos.obtnerProductos()
     .subscribe(
       (productos) => {this.productos = productos;},
       (error) => {console.log(error);}
     )
  }
  

}
