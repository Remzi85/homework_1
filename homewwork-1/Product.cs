using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homewwork_1
{
    public class Product
    {
        private static int _idCounter = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        private decimal _salePrice;

        public decimal SalePrice
        {
            get => _salePrice;
            set
            {
                if (value < CostPrice)
                    throw new ArgumentException("SalePrice cannot be lower than CostPrice.");
                _salePrice = value;
            }
        }

        public Product()
        {
            Id = _idCounter++;
        }
    }

}
