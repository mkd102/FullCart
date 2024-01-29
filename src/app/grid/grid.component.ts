import { Component, OnInit ,Input,EventEmitter, Output} from '@angular/core';
import { Product } from '../product/Product';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {

  columnDefs :Array<string>=new Array<string>();

rowData:Array<Object> =new Array<Object>();

@Output("grid-selected")
selected: EventEmitter<any>=new EventEmitter<any>();


@Input("name") name:string='';
  constructor() { }

  ngOnInit(): void {
  }
  
  @Input("row-data")
set rowDataAssign(_rowdata: Array<Object>){
  if(_rowdata.length>0)
  {
    //console.log(_rowdata);
    if(this.columnDefs.length==0)
    {
        var columnNames= Object.keys(_rowdata[0]);
        for(var i in columnNames)
        {
          if(columnNames[i]!="formUserGroup")
          this.columnDefs.push(columnNames[i]);
        }
      }
  //console.log(this.columnDefs);
  this.rowData=_rowdata;
}
}
Select( _selected:any)
{
  this.selected.emit(_selected);
  return false;
}
}
