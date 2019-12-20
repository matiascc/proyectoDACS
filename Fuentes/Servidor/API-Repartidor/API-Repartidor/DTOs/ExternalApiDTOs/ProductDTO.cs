using System.Collections.Generic;

namespace API_Repartidor.DTOs.ExternalApiDTOs
{
    public class ProductDTO
    {
        public virtual int id { get; set; }

        public virtual string code { get; set; }

        public virtual string name { get; set; }

        public virtual string description { get; set; }

        public virtual string brand { get; set; }

        public virtual string image { get; set; }

        public virtual List<StockDTO> stock{ get; set; }
    }
}
