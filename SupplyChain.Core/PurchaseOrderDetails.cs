namespace SupplyChain.Core
{
    public  class PurchaseOrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int PurchaseOrderHeaderId { get; set; }

        public virtual Product Product { get; set; }

        public virtual PurchaseOrderHeader PurchaseOrderHeader { get; set; }
    }
}