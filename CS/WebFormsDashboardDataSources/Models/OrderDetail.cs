namespace WebFormsDashboardDataSources {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Quantity { get; set; }

        [Column(Order = 2, TypeName = "smallmoney")]
        public decimal UnitPrice { get; set; }

        [Column(Order = 3)]
        public float Discount { get; set; }

        [Column(Order = 4)]
        [StringLength(40)]
        public string ProductName { get; set; }

        [StringLength(217)]
        public string Supplier { get; set; }
    }
}
