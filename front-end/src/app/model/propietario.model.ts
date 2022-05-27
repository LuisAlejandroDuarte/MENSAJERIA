export class Propietario {

        constructor(public  id?:number,
            public  nombre?:string,
            public  apellido?:string,
            public  identificacion?:string,
            public  direccion?:string,
            public  telefono?:string,
            public  estado?:boolean,
            public  empresaId?:number) {}

}

export class TablaPropietario {
    constructor(public  id?:number,
        public  nombre?:string,
        public  apellido?:string,
        public  identificacion?:string,
        public  direccion?:string,
        public  telefono?:string,
        public  estado?:boolean,
        public  empresaId?:number,
        public  bloqueado?:string,
        public  edit?:string) {}
}