/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SingleProjectAddComponent } from './single-project-add.component';

describe('SingleProjectAddComponent', () => {
  let component: SingleProjectAddComponent;
  let fixture: ComponentFixture<SingleProjectAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingleProjectAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleProjectAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
