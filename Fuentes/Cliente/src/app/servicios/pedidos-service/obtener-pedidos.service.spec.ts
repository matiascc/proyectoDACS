import { TestBed } from '@angular/core/testing';
import { ObtenerPedidosService } from './obtener-pedidos.service';


describe('ObtenerPedidosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ObtenerPedidosService = TestBed.get(ObtenerPedidosService);
    expect(service).toBeTruthy();
  });
});
