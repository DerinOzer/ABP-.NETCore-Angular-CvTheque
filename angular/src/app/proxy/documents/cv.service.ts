import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IFormFile } from '../microsoft/asp-net-core/http/models';
import type { FileResult } from '../microsoft/asp-net-core/mvc/models';

@Injectable({
  providedIn: 'root',
})
export class CvService {
  apiName = 'Default';

  getCv = (id: string) =>
    this.restService.request<any, FileResult>({
      method: 'GET',
      url: `/api/app/cv/${id}/cv`,
    },
    { apiName: this.apiName });

  uploadCv = (id: string, file: IFormFile) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/cv/${id}/upload-cv`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
