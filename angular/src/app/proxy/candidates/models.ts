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
  dateCvUpload?: string;
  skills: CreateUpdateCandidateSkillDto[];
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
  skills: CreateUpdateCandidateSkillDto[];
}

export interface CreateUpdateCandidateSkillDto {
  id?: string;
  note?: number;
}

export interface CreateUpdateSkillDto {
  skillName: string;
}

export interface SkillDto extends AuditedEntityDto<string> {
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
  skills: CreateUpdateCandidateSkillDto[];
}
