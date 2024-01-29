import {NgForm,FormGroup,FormControl,Validators,FormBuilder } from '@angular/forms'


export class Login{
   
    email: string="";
   
    password:string="";
    formUserGroup: FormGroup=null;

    constructor(){
        var _builder= new FormBuilder();
        this.formUserGroup=_builder.group({});
        this.formUserGroup.addControl("UserEmailControl",new FormControl('',[Validators.required, Validators.email]));
        this.formUserGroup.addControl("UserPasswordControl",new FormControl('',Validators.required));


    }
    IsValid(controlname, typeofvalidation): boolean {
        if (controlname==undefined) {
            return this.formUserGroup.valid;
        }
        else {
            return (!this.formUserGroup.
                controls[controlname].hasError(typeofvalidation));
        }
         
    }
    IsDirty(controlname): boolean {
        if (controlname == undefined) {
            return this.formUserGroup.dirty;
        }
        else {
            return (this.formUserGroup.
                controls[controlname].dirty);
        }

    }
}