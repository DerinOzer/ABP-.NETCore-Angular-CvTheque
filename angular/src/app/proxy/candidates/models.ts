import type { AuditedEntityDto, EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CandidateDto extends AuditedEntityDto<string> {
  name?: string;
  lastName?: string;
  email?: string;
  availability?: string;
  noticeDuration?: number;
  lastContact?: string;
  currentSalary?: number;
  requestedSalary?: number;
  dateCvUpload?: string;
  skills: string[];
  notes: number[];
}

export interface CandidateGetListInput extends PagedAndSortedResultRequestDto {
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
  skills: string[];
  notes: number[];
}

export interface CreateUpdateSkillDto {
  skillName: string;
}

export interface SkillDto extends AuditedEntityDto<string> {
  skillName?: string;
}

export interface SkillLookupDto extends EntityDto<string> {
  skillName?: string;
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
  skills: string[];
  notes: number[];
}
