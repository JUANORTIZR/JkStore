import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResgistroProductoComponent } from './resgistro-producto.component';

describe('ResgistroProductoComponent', () => {
  let component: ResgistroProductoComponent;
  let fixture: ComponentFixture<ResgistroProductoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResgistroProductoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResgistroProductoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
