namespace Order.Management.Repository.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public Segment CustomerSegment { get; set; }
        public decimal OrderDiscount { get; set; }
        public List<OrdersDetail>? OrderList { get; set; }
    }
}
