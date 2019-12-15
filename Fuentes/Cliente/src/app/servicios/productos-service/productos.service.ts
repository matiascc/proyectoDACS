import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Producto } from '../../interfaces/Producto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  constructor(private http: HttpClient) { }

  obtnerProductos(): Observable<Producto[]>{
    return this.http.get<Producto[]>('/assets/data/productos_para_probar.json');
  }
}
