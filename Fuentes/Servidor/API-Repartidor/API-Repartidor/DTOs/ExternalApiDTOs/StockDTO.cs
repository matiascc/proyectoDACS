namespace API_Repartidor.DTOs.ExternalApiDTOs
{
    public class StockDTO
    {
        public virtual int stock_id { get; set; }

        public virtual int zone_id { get; set; }

        public virtual int quantity { get; set; }

    }
}
