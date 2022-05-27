export class Paginator {
    public draw:number;
    public start:number;
    public length:number;
    public columns:Array<Column>;
    public search:Search;
    public order:Array<Order>;
    public empresaId:number;
    public filterDate:Date
}

export class Column
{
    public  data:string;
    public  name:string;
    public  searchable:boolean;
    public  orderable:boolean;
    public  search:Search;
}

export class Search
{
    public  value:string;
    public  regex:string;
}

export class Order
{
    public column:number;
    public dir:string;
}

export class ResultDataTable
{
    public draw:number;
    public recordsTotal:number;
    public recordsFiltered:number;
    public data:any;

}


