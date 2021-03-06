import type { CandidateDto, CreateCandidateDto, SkillDto, UpdateCandidateDto } from './models';
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

  getIsUsedBySkillId = (skillId: string) =>
    this.restService.request<any, boolean>({
      method: 'GET',
      url: `/api/app/candidate/is-used/${skillId}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CandidateDto>>({
      method: 'GET',
      url: '/api/app/candidate',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName })

  update = (id: string, input: UpdateCandidateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/candidate/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
