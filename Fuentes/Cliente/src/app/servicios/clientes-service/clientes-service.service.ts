import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/interfaces/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClientesServiceService {

  constructor(public http: HttpClient) { }

  clientes: Cliente[];

  obtenerCliente(idCliente: number): Observable<Cliente> {
    return this.http.get<Cliente>('https://localhost:5001/api/cliente/'+idCliente);
  }
 
}
