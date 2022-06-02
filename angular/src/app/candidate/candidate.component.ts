import { Component, OnInit } from '@angular/core';
import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto, CreateUpdateCandidateSkillDto, CreateCandidateDto, UpdateCandidateDto, SkillDto} from '@proxy/candidates';
import { SkillService } from '@proxy/candidates';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';
import { DownloadService } from '../download.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [DatePipe, ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})

export class CandidateComponent implements OnInit {
  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  skill = { items: [], totalCount: 0 } as PagedResultDto<SkillDto>;
  input = {} as PagedAndSortedResultRequestDto;
  candidateCreate = {} as CandidateDto;
  candidateEdit = {} as CandidateDto;
  selectedCandidate = {} as CandidateDto;
  newCandidate = {} as CreateCandidateDto;
  updateCandidate = {} as UpdateCandidateDto;
  listSkills = [] as SkillDto[];
  showSkills = [];

  isModalOpen = false;

  form: FormGroup;

  constructor(private datePipe: DatePipe, 
    private downloads:DownloadService, 
    public readonly list: ListService,
    private skillService:SkillService,
    private candidateService:CandidateService, 
    private formbuilder: FormBuilder,
    private confirmation: ConfirmationService, 
    private httpClient: HttpClient) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
    this.skillService.getList(this.input).subscribe((skills) => this.listSkills = skills.items);
  }

  isEmpty(array:any[]){
    if (array.length==0){
      return true;
    }
    else{
      return false;
    }
  }

  formatDateAdded(date:string){
    return date=this.datePipe.transform(date, 'dd/MM/yyyy');
  }

  download(id: string): void
  {
      this.downloads.downloadFile(id).subscribe((blob: Blob): void => {
      const file = new Blob([blob], {type: 'application/pdf'});
      const fileURL = URL.createObjectURL(file);
      window.open(fileURL, '_blank', 'width=1000, height=800');
    });
  }

  deleteCandidate(id:string){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {if (status === Confirmation.Status.confirm) {this.candidateService.delete(id).subscribe(()=>this.list.get())}});
  }

  createCandidate() {
    this.selectedCandidate = {} as CandidateDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCandidate(id: string){
    this.candidateService.get(id).subscribe((candidateEdit)=>{
      this.selectedCandidate=candidateEdit;
      this.buildForm();
      this.isModalOpen = true;
      candidateEdit.skills.forEach(skill=>{
        this.skillService.get(skill.skillId).subscribe(s => {
          this.showSkills.push({
            Id: skill.skillId,
            Name: s.skillName,
            Note: skill.note
          });
        });
      });
    });
  }

  onFileSelect(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.get('file').setValue(file);
    }
  }

  buildForm(){
    this.form = this.formbuilder.group({
      name:[this.selectedCandidate.name, Validators.required],
      lastName:[this.selectedCandidate.lastName, Validators.required],
      email:[this.selectedCandidate.email, Validators.required],
      availability: [this.selectedCandidate.availability ? new Date(this.selectedCandidate.availability) : null],
      noticeDuration:[this.selectedCandidate.noticeDuration],
      lastContact:[this.selectedCandidate.lastContact ? new Date(this.selectedCandidate.lastContact) : null],
      currentSalary:[this.selectedCandidate.currentSalary],
      requestedSalary:[this.selectedCandidate.requestedSalary],
      skill : [''],
      note: [''],
      file: ['']
    });
    this.showSkills.splice(0);
  }

  addSkill(){
    let id = this.form.get('skill').value;
    this.skillService.get(id).subscribe((skill)=>{
      this.showSkills.push({
        Id : this.form.get('skill').value,
        Name: skill.skillName,
        Note: this.form.get('note').value
      });
      this.form.get('skill').setValue('');
      this.form.get('note').setValue('');
    })
    
  }

  removeSkill(id:string){
    let index = this.showSkills.indexOf(id);
    this.showSkills.splice(index,1);
  }

  uploadFile(id:string){
    const formData = new FormData();
    var SERVER_URL =  `https://localhost:44310/api/app/cv/${id}/upload-cv`;
    formData.append('file', this.form.get('file').value);
    return this.httpClient.post<any>(SERVER_URL,formData);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    
    if(this.selectedCandidate.id){
      this.updateCandidate = this.form.value;
      var createUpdateCandidateSkill = [] as CreateUpdateCandidateSkillDto[];
      this.showSkills.forEach(element => {
        var temp = {} as CreateUpdateCandidateSkillDto;
        temp.skillId = element.Id;
        temp.note = element.Note;
        createUpdateCandidateSkill.push(temp);}); 
      this.updateCandidate.skills = createUpdateCandidateSkill;
      this.candidateService.update(this.selectedCandidate.id, this.updateCandidate).subscribe(()=>{
        if(this.form.get('file').value){
          this.uploadFile(this.selectedCandidate.id).subscribe(()=>{
            this.isModalOpen=false; 
            this.form.reset(); 
            this.list.get();});
        }
        else{
          this.isModalOpen=false; 
          this.form.reset(); 
          this.list.get();
        }
      });
    }
    else{
      this.newCandidate = this.form.value;
      var createUpdateCandidateSkill = [] as CreateUpdateCandidateSkillDto[];
      this.showSkills.forEach(element => {
        var temp = {} as CreateUpdateCandidateSkillDto;
        temp.skillId = element.Id;
        temp.note = element.Note;
        createUpdateCandidateSkill.push(temp);}); 
      this.newCandidate.skills = createUpdateCandidateSkill;
      this.candidateService.create(this.newCandidate).subscribe((candidateCreate)=>{
        if(this.form.get('file').value){
          this.uploadFile(candidateCreate.id).subscribe(()=>{
            this.isModalOpen=false; 
            this.form.reset(); 
            this.list.get();});
        }
        else{
          this.isModalOpen=false; 
          this.form.reset(); 
          this.list.get();
        }});
    }
  }

}
