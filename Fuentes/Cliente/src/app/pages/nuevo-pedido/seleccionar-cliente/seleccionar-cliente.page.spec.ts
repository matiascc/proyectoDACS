import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeleccionarClientePage } from './seleccionar-cliente.page';

describe('SeleccionarClientePage', () => {
  let component: SeleccionarClientePage;
  let fixture: ComponentFixture<SeleccionarClientePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeleccionarClientePage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeleccionarClientePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
