import { Component, OnInit } from '@angular/core';
import { User } from '../createuser/User';
import { Login } from './Login';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import jwt from "jsonwebtoken";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  UserObj: Login =new Login();
  token: any="";
  http: HttpClient=null;
  constructor(_h:HttpClient) { 

   this.http=_h;
  }
  parseBearer = (bearer: string) => {
    const [_, token] = bearer.trim().split(" ");
    return token;
  }
  ngOnInit(): void {
  }
Login(){
  var custs = [];
  //for (let entry of this.users) {
    var user: any = {};
  
    user.EmailId=this.UserObj.email;
    user.Password=this.UserObj.password;
    custs.push(user);
  //}

    let body=JSON.stringify(custs);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8','Accept': 'text/plain' });
  
    this.http.post("https://localhost:7092/api/Token",body,{headers:headers,responseType: "text"}).subscribe((data)=>{
    if(data!=null)
    {
      this.token=data;

      alert("token created successfully");
    }
    } 
    );
  }
  IsAdmin(){
    
  }
}
