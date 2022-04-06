import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostoviComponent } from './postovi.component';

describe('PostoviComponent', () => {
  let component: PostoviComponent;
  let fixture: ComponentFixture<PostoviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostoviComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostoviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
