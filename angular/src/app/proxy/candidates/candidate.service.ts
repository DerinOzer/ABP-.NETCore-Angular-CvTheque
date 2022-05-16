import type { CandidateDto, CreateCandidateDto, UpdateCandidateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CandidateService {
  apiName = 'Default';

  create = (input: CreateCandidateDto) =>
    this.restService.request<any, CandidateDto>({
      method: 'POST',
      url: '/api/app/candidate',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/candidate/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CandidateDto>({
      method: 'GET',
      url: `/api/app/candidate/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CandidateDto>>({
      method: 'GET',
      url: '/api/app/candidate',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: UpdateCandidateDto) =>
    this.restService.request<any, CandidateDto>({
      method: 'PUT',
      url: `/api/app/candidate/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  updateDate = (id: string) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/candidate/${id}/date`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
