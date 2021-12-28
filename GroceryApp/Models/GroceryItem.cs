using System;

namespace GroceryApp.Models
{
    public class GroceryItem
    {
        public string Name { get; set; }

        public decimal? Quantity { get; set; }

        public string Category { get; set; }

        public Guid ItemID { get; }
        public string CategoryNameField { get; set; }

        public GroceryItem(string _name, decimal? _quantity, string _category)
        {
            Name = _name;
            Quantity = _quantity;
            Category = _category;
            ItemID = Guid.NewGuid();
            CategoryNameField = Category + " - " + Name;
        }

        public override string ToString()
        {
            return "Grocery item {" + Name + " | " + Quantity + " | " + Category + "}"+CategoryNameField;
        }
    }
}
