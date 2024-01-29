import {NgForm,FormGroup,FormControl,Validators,FormBuilder } from '@angular/forms'


export class Product{
    name: string="";
    description: string="";
    price: number=0;
    brand: string="";
    category:string="";
    quantity:string="";
    image:string=""
    formUserGroup: FormGroup;

    constructor(){
        var _builder= new FormBuilder();
        this.formUserGroup=_builder.group({});
        this.formUserGroup.addControl("ProductNameControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("ProductDescriptionControl",new FormControl('',Validators.required));

        this.formUserGroup.addControl("ProductPriceControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("ProductBrandControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("ProductCategoryControl",new FormControl('',[Validators.required]));
        this.formUserGroup.addControl("ProductQuantityControl",new FormControl('',Validators.required));


    }
}