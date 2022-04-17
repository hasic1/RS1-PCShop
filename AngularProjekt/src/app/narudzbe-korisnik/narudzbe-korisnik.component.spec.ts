import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NarudzbeKorisnikComponent } from './narudzbe-korisnik.component';

describe('NarudzbeKorisnikComponent', () => {
  let component: NarudzbeKorisnikComponent;
  let fixture: ComponentFixture<NarudzbeKorisnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NarudzbeKorisnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NarudzbeKorisnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
