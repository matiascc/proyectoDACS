import { Item_Pedido } from './Item_pedido';

export interface Pedido {
    id: number,
    fechaCreacion: Date,
    fechaFinalizacion: Date,
    fechaLimite: Date,
    Entregado: Estado,
    precioTotal: number,
    idCliente: number,
    itemPedido: Item_Pedido
  }
  
  interface Estado {
   id: number
  }
  
 