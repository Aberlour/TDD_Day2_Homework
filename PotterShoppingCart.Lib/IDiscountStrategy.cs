using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Lib
{
    interface IDiscountStrategy
    {
        void AddShoppingList(List<BookInfo> shoppingList);
        int GetResultPrice();
    }
}
