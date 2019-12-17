import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-registrar-entrega',
  templateUrl: './registrar-entrega.page.html',
  styleUrls: ['./registrar-entrega.page.scss'],
})
export class RegistrarEntregaPage implements OnInit {

  constructor(private router: Router,private state: ActivatedRoute) { }

  pedido

  ngOnInit() {
    this.pedido = JSON.parse(this.state.snapshot.params.pedido);
  }



}

