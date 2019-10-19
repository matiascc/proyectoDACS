export interface Cliente {
    Id:number,
    Name:string,
    Address:string,
    Email:string,
    position:Position,
    Fixed_phone:string,
    Cell_phone:string,
    legal_id:string
}

interface Position {
    latitude: string,
    longitude: string
}