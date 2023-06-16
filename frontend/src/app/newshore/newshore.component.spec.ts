import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewshoreComponent } from './newshore.component';

describe('NewshoreComponent', () => {
  let component: NewshoreComponent;
  let fixture: ComponentFixture<NewshoreComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewshoreComponent]
    });
    fixture = TestBed.createComponent(NewshoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
