import { Component, OnInit } from '@angular/core';
import {User} from './User';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-createuser',
  templateUrl: './createuser.component.html',
  styleUrls: ['./createuser.component.css']
})
export class CreateuserComponent implements OnInit {
  UserObj: User =new User();
  users: Array<User>=new Array<User>();
  http: HttpClient=null;
  constructor(_h:HttpClient) { 

   this.http=_h;
  }

  ngOnInit(): void {
  }
  CreateUser (){
    this.users.push(this.UserObj);
   
}
Submit(){
  var custs = [];
  for (let entry of this.users) {
    var user: any = {};
    user.FirstName = entry.firstName;
    user.LastName = entry.lastName;
    user.Address = entry.address;
    user.EmailId=entry.email;
    user.Password=entry.password;
    custs.push(user);
  }

    let body=JSON.stringify(custs);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8' });
  
    this.http.post("https://localhost:44321/api/User",body,{headers:headers}).subscribe((data)=>{
    if(data!=null)
    {
      alert("user created successfully");
    }
    } 
    );
}

}

