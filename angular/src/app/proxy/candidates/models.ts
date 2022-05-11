import type { AuditedEntityDto } from '@abp/ng.core';

export interface CandidateDto extends AuditedEntityDto<string> {
  name?: string;
  lastName?: string;
  email?: string;
  availability?: string;
  noticeDuration?: number;
  lastContact?: string;
  currentSalary?: number;
  requestedSalary?: number;
}

export interface CreateCandidateDto {
  name: string;
  lastName: string;
  email: string;
  availability?: string;
  noticeDuration?: number;
  lastContact?: string;
  currentSalary?: number;
  requestedSalary?: number;
}

export interface UpdateCandidateDto {
  name: string;
  lastName: string;
  email: string;
  availability?: string;
  noticeDuration?: number;
  lastContact?: string;
  currentSalary?: number;
  requestedSalary?: number;
}
