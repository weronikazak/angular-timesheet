/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RaportsService } from './raports.service';

describe('Service: Raports', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RaportsService]
    });
  });

  it('should ...', inject([RaportsService], (service: RaportsService) => {
    expect(service).toBeTruthy();
  }));
});
