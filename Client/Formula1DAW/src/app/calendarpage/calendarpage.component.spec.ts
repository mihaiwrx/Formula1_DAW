import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarpageComponent } from './calendarpage.component';

describe('CalendarpageComponent', () => {
  let component: CalendarpageComponent;
  let fixture: ComponentFixture<CalendarpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalendarpageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalendarpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
