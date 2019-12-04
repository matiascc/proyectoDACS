import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../interfaces/Pedido';
import { Componente } from '../../interfaces/Interfaces';
import { Cliente } from 'src/app/interfaces/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ObtenerPedidosService {
  pedido: any = {
    "id": 1,
    "fechaCreacion": "2019-04-15T00:00:00",
    "fechaFinalizacion": "0001-01-01T00:00:00",
    "fechaLimite": "2019-05-28T00:00:00",
    "entregado": 0,
    "precioTotal": 10150,
    "cliente": {
      "nombre": "3T Federal Solutions LLC",
      "direccion": "405 Kingsford Point"
    },
    "itemPedido": [
      {
        "id": 1,
        "cantidad": 4,
        "cantidadRechazada": 0,
        "precio": 400,
        "producto": {
          "codigoQR": "65862-599",
          "nombre": "Rizatriptan Benzoate",
          "precio": 100
        }
      },
      {
        "id": 2,
        "cantidad": 7,
        "cantidadRechazada": 0,
        "precio": 1050,
        "producto": {
          "codigoQR": "54575-325",
          "nombre": "STANDARDIZED MITE D FARINAE",
          "precio": 150
        }
      },
      {
        "id": 3,
        "cantidad": 2,
        "cantidadRechazada": 0,
        "precio": 600,
        "producto": {
          "codigoQR": "57520-0239",
          "nombre": "2 Gallbladder",
          "precio": 300
        }
      }
    ]
  }

  constructor(public http: HttpClient) { }

  //Acomodar aca
  obtenerPedidos(): Observable<Pedido[]>{
    // return this.http.get<Pedido[]>('https://localhost:5001/pedidos');
    return this.http.get<Pedido[]>('/assets/data/pedidos_para_probar.json');

  }

  obtenerClientes(): Observable<Cliente[]>{
    return this.http.get< Cliente[]>('https://localhost:5001/api/clientes');
  }

  getMenuOpts(){
    return this.http.get<Componente[]>('/assets/data/menu.json')
  }

  
}
