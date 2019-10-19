import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../interfaces/Pedido';
import { Componente } from '../../interfaces/Interfaces';

@Injectable({
  providedIn: 'root'
})
export class ObtenerPedidosService {

  pedidos: Pedido[] = [];

  constructor(public http: HttpClient) { }

  //Acomodar aca
  obtenerPedidos(): Observable<Pedido[]>{
    return this.http.get<Pedido[]>('https://localhost:5001/api/pedidos');
  }

  getMenuOpts(){
    return this.http.get<Componente[]>('/assets/data/menu.json')
  }

}
