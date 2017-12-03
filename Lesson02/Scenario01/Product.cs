using System;
using System.Collections.Generic;
using System.Text;

namespace Scenario01
{
    public class Product
    {
        private string _name;
        public string Name { get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                _name = value;
            }
        }

        public decimal Price { get; set; }

        public override string ToString() => $"The price of product {_name} is {Price:C}";
    }
}
