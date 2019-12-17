import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'buscar',
  templateUrl: './buscar.component.html',
  styleUrls: ['./buscar.component.scss'],
})
export class BuscarComponent implements OnInit {

  @Input() placeHolder: string;

  constructor() { }

  ngOnInit() {}

}
