import { Component, OnInit } from '@angular/core';
import { BarcodeScanner } from '@ionic-native/barcode-scanner/ngx';

@Component({
  selector: 'app-escanear-codigo',
  templateUrl: './escanear-codigo.page.html',
  styleUrls: ['./escanear-codigo.page.scss'],
})
export class EscanearCodigoPage  {
  private barcode: string;
  constructor(private barcodeScanner: BarcodeScanner) {

   }

   scan() {
    this.barcodeScanner.scan().then(barcodeData => {
      this.barcode = barcodeData['text'];
     }).catch(err => {
         this.barcode = JSON.stringify(err);
     });
}
  }
