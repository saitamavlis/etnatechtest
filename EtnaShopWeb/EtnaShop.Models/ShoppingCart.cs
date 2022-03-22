using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Range(1,100,ErrorMessage="Ingrese un valor entre 1 y 100")]
        public int Count { get; set; }
        public string OrderId { get; set; }
    }
}
