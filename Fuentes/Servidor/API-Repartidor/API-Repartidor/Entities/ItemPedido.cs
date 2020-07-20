namespace API_Repartidor.Entities
{
    public class ItemPedido : BaseEntity
    {
        public virtual int cantidad { get; set; }
        public virtual int cantidadRechazada { get; set; }
        public virtual double precio { get; set; }
        public virtual long idProducto { get; set; }
        public virtual Pedido pedido { get; set; }
    }
}
