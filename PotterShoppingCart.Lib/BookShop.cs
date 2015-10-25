using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Lib
{
    public class BookShop
    {
        public static BookShop GetBookShop()
        {
            return new BookShop();
        }

        public int CheckCart(List<BookInfo> shoppingList)
        {
            return shoppingList.Sum(s => s.Price);
        }
    }
}
