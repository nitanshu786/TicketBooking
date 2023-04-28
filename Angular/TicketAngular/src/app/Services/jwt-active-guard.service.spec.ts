import { TestBed } from '@angular/core/testing';

import { JwtActiveGuardService } from './jwt-active-guard.service';

describe('JwtActiveGuardService', () => {
  let service: JwtActiveGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtActiveGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
