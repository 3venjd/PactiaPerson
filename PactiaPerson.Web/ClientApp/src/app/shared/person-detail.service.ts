import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PersonDetail } from './person-detail.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PersonDetailService {


url:string = environment.apiBaseUrl
ListPersons : PersonDetail[] = []
formData : PersonDetail = new PersonDetail()
formSubmitted: boolean = false;
constructor(private http: HttpClient) { }
  refreshList(){
    this.http.get(this.url)
      .subscribe(
        {
          next: res => {
            //console.log(res);
            this.ListPersons = res as PersonDetail[]
          },
          error: err => {console.log(err)}
        }
      )
  }

  postPersonDetail(){
    return this.http.post(this.url,this.formData);
  }

  putPersonDetail(){
    return this.http.put(this.url, this.formData);
  }

  resetForm(form: NgForm){
    form.form.reset();
    this.formData = new PersonDetail();
    this.formSubmitted = false;
  }

  DeletePersonDetail(id :number){
    return this.http.delete(this.url + '/' + id);
  }
}
