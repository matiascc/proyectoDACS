import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from 'src/app/interfaces/Producto';

@Pipe({
  name: 'filtroProductos'
})
export class FiltroProductosPipe implements PipeTransform {

  transform(productos: Producto[], texto: string): Producto[] {

    if (texto == '') {
      return productos;
    }

    texto = texto.toLowerCase();

    return productos.filter (producto => {
      return producto.nombre.toLowerCase().includes( texto );
    });
  }

}
