import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserroleService {

  private role: boolean=false;
  constructor() { }

  set setUserRole(val:boolean){
    this.role=val;
  }
  get getUserRole():boolean{
    return this.role;
  }
}
