export class Ruta {
    constructor(
        public id?:number,
        public turnoId?:number,
        public inicia?:Date,
        public termina?:Date,
        public destino?:string,
        public telefono?:string,
        public valor?:number,
        public estado?:boolean,
        public placa?:string,
        public nombrePropietario?:string,
        public observacion?:string
    ){}
}

export class TablaRuta {
    constructor(
        public id?:number,
        public turnoId?:number,
        public inicia?:Date,
        public termina?:Date,
        public destino?:string,
        public telefono?:string,
        public valor?:number,
        public estado?:boolean,
        public placa?:string,
        public nombrePropietario?:string,
        public observacion?:string,
        public bloqueado?:string,
        public edit?:string
    ){}
}