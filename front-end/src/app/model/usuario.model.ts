export class Usuario {

    constructor(
        public  nombre?:string,
        public  apellido?:string,
        public  direccion?:string,
        public  telefono?:string,
        public  user?:string,      
        public  password?:string,            
        public  id?:string,
        public  rol?:string,                
        public  empresaId?:number,
        public  token?:string,
        public  estado?:boolean
       ) {}

}

export class TableUsuario {
    constructor(
        public  nombre?:string,
        public  apellido?:string,
        public  direccion?:string,
        public  telefono?:string,
        public  user?:string,      
        public  password?:string,            
        public  id?:string,
        public  rol?:string,                
        public  empresaId?:number,
        public  token?:string,
        public  bloqueado?:string,
        public  edit?:string
       ) {}
}


export interface Roles {
    id:number
    name:string;      
  };

export const DataRoles:Roles[]=  [{id:1,name:'admin'},{id:2,name:'user'}];

export class UserChangePassword {

    constructor(
        public id:string,
        public idEmpresa:number,
        public oldPassword:string,
        public newPassword:string
    ) {}    
}