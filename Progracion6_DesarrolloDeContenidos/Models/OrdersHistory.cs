namespace Progracion6_DesarrolloDeContenidos.Models
{
    public class OrdersHistory
    {
        public int TX_NUMBER { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string ACTION{ get; set; }
        public string STATUS{ get; set; }
        public string SYMBOL { get; set; }
        public int  QUANTITY { get; set; }
        public double PRICE { get; set; }
    }
}
