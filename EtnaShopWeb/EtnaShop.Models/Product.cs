using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EtnaShop.Models
{
    public class Product
    {
        /*since all the variables and annotations will be in English, but the view in Spanish will use display 
         * name to show it in this language*/
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        
        [DisplayName("Descripción")]
        public string Description { get; set; } = "No Description found.";
        
        [Required]
        [DisplayName("Precio")]
        public double Price { get; set; }
    }
}