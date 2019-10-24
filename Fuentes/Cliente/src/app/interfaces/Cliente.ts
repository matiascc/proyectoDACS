export interface Cliente {
    id: number,
    nombre: string,
    direccion: string,
    email: string,
    telefonoFijo: string,
    telefonoCelular: string,
    cuit: string
}

interface Position {
    latitude: string,
    longitude: string
}