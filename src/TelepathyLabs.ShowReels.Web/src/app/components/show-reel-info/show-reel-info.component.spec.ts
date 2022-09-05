import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowReelInfoComponent } from './show-reel-info.component';

describe('ShowReelInfoComponent', () => {
  let component: ShowReelInfoComponent;
  let fixture: ComponentFixture<ShowReelInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowReelInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowReelInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
