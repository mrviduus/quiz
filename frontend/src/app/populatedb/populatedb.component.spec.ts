import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopulatedbComponent } from './populatedb.component';

describe('PopulatedbComponent', () => {
  let component: PopulatedbComponent;
  let fixture: ComponentFixture<PopulatedbComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopulatedbComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopulatedbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
