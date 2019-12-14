import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pedido } from '../../interfaces/Pedido';


@Injectable({
  providedIn: 'root'
})
export class RepartosService {

  constructor(public http: HttpClient) { }

  agregarReparto(reparto: Pedido[]){
     this.http.post<Pedido[]>('https://localhost:5001/repartos', reparto);
  }
}
