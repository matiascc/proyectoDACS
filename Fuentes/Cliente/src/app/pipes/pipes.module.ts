import { NgModule } from '@angular/core';
import { FiltroPipe } from './filtro.pipe';
import { FiltroProductosPipe } from './filtro-productos.pipe';



@NgModule({
  declarations: [FiltroPipe, FiltroProductosPipe],
  exports : [FiltroPipe, FiltroProductosPipe]
})
export class PipesModule { }
