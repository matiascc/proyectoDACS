import { Pipe, PipeTransform } from '@angular/core';
import { Cliente } from '../interfaces/Cliente';

@Pipe({
  name: 'filtro'
})
export class FiltroPipe implements PipeTransform {

  transform(clientes: Cliente[], texto: string): Cliente[] {
    
    if (texto == '') {
      return clientes;
    }

    texto = texto.toLowerCase();

   return clientes.filter (cliente => {
      return cliente.nombre.toLowerCase().includes( texto )
      || cliente.email.toLowerCase().includes( texto )
      || cliente.direccion.toLowerCase().includes(texto);
    });
  }

}
