import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClientesServiceService {

  constructor(public http: HttpClient) { }

  clientes: any;

  obtenerClientes():any {
    return this.http.get<any>('https://localhost:5001/api/pedidos');
  }
 
}
