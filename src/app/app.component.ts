import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserroleService } from './userrole.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Binder-UI';
  Admin:boolean;
  constructor(private router: Router,private userRoleService:UserroleService){
    this.Admin=this.userRoleService.getUserRole;
  }
  MoveToLogin(){
    this.router.navigate(['/', 'Login']);
  }
}
