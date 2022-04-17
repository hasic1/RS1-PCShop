import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OglasiAdminComponent } from './oglasi-admin.component';

describe('OglasiAdminComponent', () => {
  let component: OglasiAdminComponent;
  let fixture: ComponentFixture<OglasiAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OglasiAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OglasiAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
