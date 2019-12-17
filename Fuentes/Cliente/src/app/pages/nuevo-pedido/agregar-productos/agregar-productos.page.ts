import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from '../../../interfaces/Cliente';
import { ProductosService } from '../../../servicios/productos-service/productos.service';
import { Producto, ProductoSeleccionado } from 'src/app/interfaces/Producto';


@Component({
  selector: 'app-agregar-productos',
  templateUrl: './agregar-productos.page.html',
  styleUrls: ['./agregar-productos.page.scss'],
})
export class AgregarProductosPage implements OnInit {
  
  cliente : Cliente;
  productos: Producto[] = [];
  textoBuscar = '';
  productosSeleccionados: ProductoSeleccionado[];

  constructor(private state: ActivatedRoute, private servicioProductos: ProductosService) { }

  ngOnInit() {
    this.cliente = JSON.parse(this.state.snapshot.params.cliente);
     this.servicioProductos.obtnerProductos()
     .subscribe(
       (productos) => {this.productos = productos;},
       (error) => {console.log(error);}
     )
  }

  suma(producto: Producto): number{
    var cantidad = 0;
    producto.stock.forEach(zona => {
     cantidad += zona.cantidad
    });
    return cantidad;
  }

  buscar(event) {
    this.textoBuscar = event.detail.value;
   }

   crearPedido(){

   }

   agregarProducto(event, producto: Producto, cantidad: number){
    if (event.target.checked) {
      this.productosSeleccionados.push({producto, cantidad});
      console.log(this.productosSeleccionados);
    }
    else {
      let index = this.quitarProductoDeLista(producto);
      this.productosSeleccionados.splice(index,1);
      console.log(this.productosSeleccionados);
    }
  }
 
  quitarProductoDeLista(pedido: any){
     return this.productosSeleccionados.findIndex((categoria)=>{
       return categoria === pedido;
     })
  }

}
