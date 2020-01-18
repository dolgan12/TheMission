/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UserskillListComponent } from './userskill-list.component';

describe('UserskillListComponent', () => {
  let component: UserskillListComponent;
  let fixture: ComponentFixture<UserskillListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserskillListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserskillListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
