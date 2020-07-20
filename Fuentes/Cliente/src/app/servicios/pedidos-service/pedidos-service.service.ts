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
  constructor(public http: HttpClient) { }
 
  //Acomodar aca
  obtenerPedidos(): Observable<Pedido[]>{
    return this.http.get<Pedido[]>('https://localhost:5001/pedidos/pendientes');
     //return this.http.get<Pedido[]>('/assets/data/pedidos_para_probar.json');

  }

  obtenerClientes(): Observable<Cliente[]>{
    return this.http.get< Cliente[]>('https://localhost:5001/api/clientes');
  }

  getMenuOpts(){
    return this.http.get<Componente[]>('/assets/data/menu.json')
  }
}
