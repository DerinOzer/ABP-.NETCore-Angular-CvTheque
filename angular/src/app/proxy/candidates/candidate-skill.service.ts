import type { CandidateSkillDto, CreateUpdateCandidateSkillDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CandidateSkillService {
  apiName = 'Default';

  create = (input: CreateUpdateCandidateSkillDto) =>
    this.restService.request<any, CandidateSkillDto>({
      method: 'POST',
      url: '/api/app/candidate-skill',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/candidate-skill/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CandidateSkillDto>({
      method: 'GET',
      url: `/api/app/candidate-skill/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CandidateSkillDto>>({
      method: 'GET',
      url: '/api/app/candidate-skill',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateCandidateSkillDto) =>
    this.restService.request<any, CandidateSkillDto>({
      method: 'PUT',
      url: `/api/app/candidate-skill/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
