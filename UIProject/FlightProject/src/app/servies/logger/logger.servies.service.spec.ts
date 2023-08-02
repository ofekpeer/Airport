import { TestBed } from '@angular/core/testing';

import { LoggerServiesService } from './logger.servies.service';

describe('LoggerServiesService', () => {
  let service: LoggerServiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoggerServiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
