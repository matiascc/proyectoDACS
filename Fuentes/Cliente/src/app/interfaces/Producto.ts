export interface Producto {
    id: number,
    codigoQR: string,
    nombre: string,
    descripcion:  string,
    fabricante: string,
    stock: Stock[],
    precio: number
}

interface Stock {
    id: number,
    idZona: number,
    cantidad: number
}