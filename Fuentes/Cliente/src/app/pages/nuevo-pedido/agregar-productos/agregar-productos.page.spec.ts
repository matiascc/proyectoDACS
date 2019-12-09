import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarProductosPage } from './agregar-productos.page';

describe('AgregarProductosPage', () => {
  let component: AgregarProductosPage;
  let fixture: ComponentFixture<AgregarProductosPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregarProductosPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarProductosPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
