namespace API_Repartidor.DTOs
{
    public class ItemPedidoDTO
    {
        public virtual long id { get; set; }
        public virtual int cantidad { get; set; }
        public virtual int cantidadRechazada { get; set; }
        public virtual double precio { get; set; }
        public virtual long idProducto { get; set; }
    }
}
