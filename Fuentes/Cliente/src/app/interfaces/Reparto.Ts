import { Pedido } from './Pedido';

export interface Reparto {
    id: number,
    fecha: Date,
    finalizado: boolean,
    pedidos: Pedido[]
  }