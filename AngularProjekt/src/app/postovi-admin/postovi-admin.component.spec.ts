import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostoviAdminComponent } from './postovi-admin.component';

describe('PostoviAdminComponent', () => {
  let component: PostoviAdminComponent;
  let fixture: ComponentFixture<PostoviAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostoviAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostoviAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
