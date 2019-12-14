import { TestBed } from '@angular/core/testing';

import { RepartosService } from './repartos-service.service';

describe('RepartosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RepartosService = TestBed.get(RepartosService);
    expect(service).toBeTruthy();
  });
});
