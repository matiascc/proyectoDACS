import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/interfaces/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(public http: HttpClient) { }


  obtenerCliente(idCliente: number): Observable<Cliente> {
    return this.http.get<Cliente>('https://localhost:5001/api/clientes/'+idCliente);
  }
  obtenerClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>('https://localhost:5001/api/clientes');
  }
 
}
