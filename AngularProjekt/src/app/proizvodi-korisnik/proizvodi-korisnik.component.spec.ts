import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProizvodiKorisnikComponent } from './proizvodi-korisnik.component';

describe('ProizvodiKorisnikComponent', () => {
  let component: ProizvodiKorisnikComponent;
  let fixture: ComponentFixture<ProizvodiKorisnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProizvodiKorisnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProizvodiKorisnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
