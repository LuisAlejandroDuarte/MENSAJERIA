import { Propietario } from "./propietario.model";

export class Moto {

    constructor(public  id?:number,
        public  nombrePropietario?:string,
        public  propietarioId?:number,
        public  placa?:string,        
        public  estado?:boolean) {}
}

export class TablaMoto {
    constructor(public  id?:number,
        public  nombrePropietario?:string,
        public  propietarioId?:number,
        public  placa?:string,                
        public  bloqueado?:string,
        public  edit?:string) {}
}