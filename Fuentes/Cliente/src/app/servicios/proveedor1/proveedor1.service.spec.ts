import { TestBed } from '@angular/core/testing';

import { Proveedor1Service } from './proveedor1.service';

describe('Proveedor1Service', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Proveedor1Service = TestBed.get(Proveedor1Service);
    expect(service).toBeTruthy();
  });
});
