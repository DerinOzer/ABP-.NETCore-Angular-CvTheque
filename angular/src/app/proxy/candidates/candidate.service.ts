import type { CandidateDto, CandidateGetListInput, CreateCandidateDto, SkillLookupDto, UpdateCandidateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
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

  getList = (input: CandidateGetListInput) =>
    this.restService.request<any, PagedResultDto<CandidateDto>>({
      method: 'GET',
      url: '/api/app/candidate',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getSkillLookup = () =>
    this.restService.request<any, ListResultDto<SkillLookupDto>>({
      method: 'GET',
      url: '/api/app/candidate/skill-lookup',
    },
    { apiName: this.apiName });

  update = (id: string, input: UpdateCandidateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/candidate/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
