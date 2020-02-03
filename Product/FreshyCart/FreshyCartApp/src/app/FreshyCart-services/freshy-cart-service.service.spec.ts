import { TestBed } from '@angular/core/testing';

import { FreshyCartServiceService } from './freshy-cart-service.service';

describe('FreshyCartServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FreshyCartServiceService = TestBed.get(FreshyCartServiceService);
    expect(service).toBeTruthy();
  });
});
