/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PersonDetailService } from './person-detail.service';

describe('Service: PersonDetail', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonDetailService]
    });
  });

  it('should ...', inject([PersonDetailService], (service: PersonDetailService) => {
    expect(service).toBeTruthy();
  }));
});
