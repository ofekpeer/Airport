import { TestBed } from '@angular/core/testing';

import { TerminalServiesService } from './terminal.servies.service';

describe('TerminalServiesService', () => {
  let service: TerminalServiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TerminalServiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
