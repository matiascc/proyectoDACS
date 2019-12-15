import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pedido } from '../../interfaces/Pedido';
import {Reparto} from '../../interfaces/Reparto'
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RepartosService {

  constructor(public http: HttpClient) { }

  agregarReparto(reparto: Pedido[]){
     this.http.post<Pedido[]>('https://localhost:5001/repartos', reparto);
  }

  obtenerRepartos(): Observable<Reparto[]>{
    return this.http.get<Reparto[]>('/assets/data/recorridos_para_probar.json')
  }
}
