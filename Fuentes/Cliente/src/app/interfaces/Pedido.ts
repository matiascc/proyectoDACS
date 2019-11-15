import { Item_Pedido } from './Item_pedido';

export interface Pedido {
    id: number,
    fechaCreacion: Date,
    fechaFinalizacion: Date,
    fechaLimite: Date,
    Entregado: number,
    precioTotal: number,
    cliente: Cliente,
    itemPedido: Item_Pedido
  }
  


interface Cliente{
    nombre: string,
   dirreccion : string
}
  
 