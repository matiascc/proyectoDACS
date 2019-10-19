export interface Pedido {
    id: number,
    cliente: Cliente,
    fechaCreacion: Date,
    fechaFinalizacion: Date,
    fechaLimite: Date,
    Entregado: Estado,
    precioTotal: number
  }
  
  interface Estado {
   id: number
  }
  
  interface Cliente {
  
    nombre: string,
    apellido: string,
    address: string
    cell_phone: string
  }