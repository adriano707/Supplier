import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JuridicalPersonComponent } from './juridical-person.component';

describe('JuridicalPersonComponent', () => {
  let component: JuridicalPersonComponent;
  let fixture: ComponentFixture<JuridicalPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JuridicalPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JuridicalPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
