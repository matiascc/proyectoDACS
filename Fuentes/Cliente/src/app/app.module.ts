import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentsModule } from './components/components.module';
import { Proveedor1Service } from './servicios/proveedor1/proveedor1.service';
import { HttpClientModule } from '@angular/common/http';
import { ObtenerPedidosService } from './servicios/pedidos-service/pedidos-service.service';
import { QRScanner } from '@ionic-native/qr-scanner/ngx';
import { PipesModule } from './pipes/pipes.module';

import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { environment } from '../environments/environment';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [AppComponent],
  entryComponents: [],
  imports: [BrowserModule, 
    IonicModule.forRoot(), 
    AppRoutingModule,
    ComponentsModule,
    HttpClientModule,
    PipesModule,
    FormsModule,
    ReactiveFormsModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule
  ],
    providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
    Proveedor1Service,
    ObtenerPedidosService,
    QRScanner
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
