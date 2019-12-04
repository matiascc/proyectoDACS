import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EscanearCodigoPage } from './escanear-codigo.page';

describe('EscanearCodigoPage', () => {
  let component: EscanearCodigoPage;
  let fixture: ComponentFixture<EscanearCodigoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EscanearCodigoPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EscanearCodigoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
