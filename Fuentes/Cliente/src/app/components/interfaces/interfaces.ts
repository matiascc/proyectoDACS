export interface Componente {
    icon: string;
    name: string;
    redirecTo: string;
  }

export interface Usuario {
  id: number;
  name: string;
  email: string,
  address: Address,
  phone: string,
  website: string,
  company: Company
}

interface Address {
    street :string,
    suite: string,
    city: string,
    zipcode: string,
    geo: Geo
}

interface Geo{
  lat: string,
  lng: string,
}

interface Company {
  name: string,
  catchPhrase: string,
  bs: string
}

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