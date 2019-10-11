import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Componente, Pedido } from '../../components/interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})
export class Proveedor2Service {

  constructor(public http: HttpClient) { }

  verPedidos() : Observable<Pedido> {
    return this.http.get<Pedido>("https://jsonplaceholder.typicode.com/users");
  }

  getMenuOpts(){
    return this.http.get<Componente[]>('/assets/data/menu.json');
  }

}


