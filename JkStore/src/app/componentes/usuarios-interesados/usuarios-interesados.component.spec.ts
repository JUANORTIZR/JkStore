import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariosInteresadosComponent } from './usuarios-interesados.component';

describe('UsuariosInteresadosComponent', () => {
  let component: UsuariosInteresadosComponent;
  let fixture: ComponentFixture<UsuariosInteresadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuariosInteresadosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuariosInteresadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
