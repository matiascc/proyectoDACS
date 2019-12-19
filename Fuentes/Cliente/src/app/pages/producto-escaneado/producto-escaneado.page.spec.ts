import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoEscaneadoPage } from './producto-escaneado.page';

describe('ProductoEscaneadoPage', () => {
  let component: ProductoEscaneadoPage;
  let fixture: ComponentFixture<ProductoEscaneadoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoEscaneadoPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoEscaneadoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
