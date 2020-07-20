import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from '../../../interfaces/Cliente';


@Component({
  selector: 'app-agregar-productos',
  templateUrl: './agregar-productos.page.html',
  styleUrls: ['./agregar-productos.page.scss'],
})
export class AgregarProductosPage implements OnInit {
  
  cliente : Cliente;

  constructor(private state: ActivatedRoute) { }

  ngOnInit() {
    this.cliente = JSON.parse(this.state.snapshot.params.cliente);
  }

  

}
