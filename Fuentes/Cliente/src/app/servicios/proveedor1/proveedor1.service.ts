import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {HttpClientModule} from '@angular/common/http';
import { Pedido } from '../../interfaces/Pedido';

@Injectable({
  providedIn: 'root'
})
export class Proveedor1Service {

 
  constructor(public http:HttpClient) { 

  }

  obtenerDatos(){
    return this.http.get('https://localhost:5001/api/Productos');
  }


}
