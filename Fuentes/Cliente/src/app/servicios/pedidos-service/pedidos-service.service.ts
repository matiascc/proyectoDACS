import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from '../../interfaces/Pedido';
import { Componente } from '../../interfaces/Interfaces';

@Injectable({
  providedIn: 'root'
})
export class ObtenerPedidosService {
  constructor(public http: HttpClient) { }
 
  obtenerPedidos(): Observable<Pedido[]>{
    //return this.http.get<Pedido[]>('https://localhost:5001/pedidos/pendientes');
     return this.http.get<Pedido[]>('/assets/data/pedidos_para_probar.json');
  }
  
  getMenuOpts(){
    return this.http.get<Componente[]>('/assets/data/menu.json')
  }
}
