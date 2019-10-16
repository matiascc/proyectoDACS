import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../components/interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})
export class ObtenerPedidosService {

  pedidos: Pedido[];
  constructor(public http: HttpClient) { }

  //Acomodar aca
  obtenerPedidos(): Observable<Pedido[]>{
    return this.http.get<Pedido[]>('https://localhost:5001/api/pedidos');
  }
}
