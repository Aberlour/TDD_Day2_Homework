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
            var discountGroups = DiscountGroup.NewDiscountGroup();
            discountGroups.AddBooks(shoppingList);
            return discountGroups.GetTotalPrice();
        }
    }

    public class DiscountGroup
    {
        readonly List<List<BookInfo>> _discountGroups;
        private DiscountGroup()
        {
            _discountGroups = new List<List<BookInfo>>() {new List<BookInfo>()};
        }

        public static DiscountGroup NewDiscountGroup()
        {
            return new DiscountGroup();
        }

        public void AddBooks(List<BookInfo> shoppingBooks)
        {
            foreach (var bookInfo in shoppingBooks)
            {
                var isDepulicated = false;
                foreach (var discountGroup in _discountGroups)
                {
                    isDepulicated = discountGroup.Any(s => s.Name.Equals(bookInfo.Name));
                    if (isDepulicated == false)
                    {
                        discountGroup.Add(bookInfo);
                        break;
                    }
                }

                if (isDepulicated)
                    _discountGroups.Add(new List<BookInfo>() {bookInfo});
            }

        }

        public int GetTotalPrice()
        {
            return CalculatePrice(_discountGroups);
        }

        /// <summary>
        /// 總金額計算
        /// </summary>
        /// <param name="discountGroups">折扣群組</param>
        /// <returns></returns>
        private int CalculatePrice(IEnumerable<List<BookInfo>> discountGroups)
        {
            var sumPrice = 0.0;
            foreach (var discountGroup in discountGroups)
            {
                var originPrice = discountGroup.Sum(s => s.Price);
                switch (discountGroup.Count)
                {
                    case 1:
                        sumPrice += originPrice;
                        break;
                    case 2:
                        sumPrice += originPrice * 0.95;
                        break;
                    case 3:
                        sumPrice += originPrice * 0.9;
                        break;
                    case 4:
                        sumPrice += originPrice * 0.8;
                        break;
                    case 5:
                        sumPrice += originPrice * 0.75;
                        break;
                }
            }
            return Convert.ToInt32(sumPrice);
        }
    }
}
