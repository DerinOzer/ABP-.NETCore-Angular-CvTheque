import type { CreateUpdateSkillDto, SkillDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SkillService {
  apiName = 'Default';

  create = (input: CreateUpdateSkillDto) =>
    this.restService.request<any, SkillDto>({
      method: 'POST',
      url: '/api/app/skill',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/skill/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, SkillDto>({
      method: 'GET',
      url: `/api/app/skill/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<SkillDto>>({
      method: 'GET',
      url: '/api/app/skill',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateSkillDto) =>
    this.restService.request<any, SkillDto>({
      method: 'PUT',
      url: `/api/app/skill/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
