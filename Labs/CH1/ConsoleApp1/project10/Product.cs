using System;
using System.Collections.Generic;
using System.Text;

namespace project10
{
    public record Product(string Name, string Sku, decimal Price, ShippingDimensions Dimensions)
    {

    }
}
