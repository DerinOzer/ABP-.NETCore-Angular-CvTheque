
export interface CvDto {
  content: number[];
  name?: string;
}

export interface GetCvDto {
  name: string;
}

export interface SaveCvDto {
  content: number[];
  name: string;
}
