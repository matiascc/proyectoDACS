import { TestBed } from '@angular/core/testing';

import { Proveedor2Service } from './proveedor2.service';

describe('Proveedor2Service', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Proveedor2Service = TestBed.get(Proveedor2Service);
    expect(service).toBeTruthy();
  });
});
