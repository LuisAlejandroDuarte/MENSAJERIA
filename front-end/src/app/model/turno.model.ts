export enum TypeTurnos
{
    Disponible=1,
    EnRuta=2,
    Terminado=3
}

export class Turno {
    constructor(
        public id?:number,
        public fechaHora?:Date,
        public empresaId?:number,
        public motoId?:number,
        public posicion?:number,        
        public placa?:string,
        public nombrePropietario?:string,
        public inicia?:string,
        public termina?:string,
        public estado?:TypeTurnos

    ) {}
}

export class TablaTurno {
    constructor(
        public id?:number,
        public fechaHora?:Date,
        public empresaId?:number,
        public motoId?:number,
        public posicion?:number,        
        public placa?:string,
        public nombrePropietario?:string,
        public inicia?:string,
        public termina?:string,
        public estado?:TypeTurnos,       
        public edit?:string,
        public eliminar?:string

    ) {}
}