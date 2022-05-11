import type { CvDto, GetCvDto, SaveCvDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CvService {
  apiName = 'Default';

  getCv = (input: GetCvDto) =>
    this.restService.request<any, CvDto>({
      method: 'GET',
      url: '/api/app/cv/cv',
      params: { name: input.name },
    },
    { apiName: this.apiName });

  saveCv = (input: SaveCvDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/cv/save-cv',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
