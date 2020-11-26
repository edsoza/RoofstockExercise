using System.ComponentModel.DataAnnotations.Schema;

namespace RoofstockExercise.Models
{
    public class PropertiesModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Address { get; set; }
        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthyRent { get; set; }

        private decimal grossYield;
        public decimal GrossYield {
            get {
                return grossYield;
            } 
            set {
                if (ListPrice == 0)
                    grossYield = 0;
                else
                    grossYield = (MonthyRent * 12 / ListPrice);
            }
        }
    }
}
