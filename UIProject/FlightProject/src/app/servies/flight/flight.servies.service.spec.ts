import { TestBed } from '@angular/core/testing';

import { FlightServiesService } from './flight.servies.service';

describe('FlightServiesService', () => {
  let service: FlightServiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlightServiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
