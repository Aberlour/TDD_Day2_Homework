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
            var discountGroups = GetDiscountGroups(shoppingList);
            return CalculatePrice(discountGroups);
        }

        /// <summary>
        /// 取得折扣群組
        /// </summary>
        /// <param name="shoppingList">購物車內容</param>
        /// <returns></returns>
        private IEnumerable<List<BookInfo>> GetDiscountGroups(IEnumerable<BookInfo> shoppingList)
        {
            var discountGroups = new List<List<BookInfo>>();
            foreach (var bookInfo in shoppingList)
            {
                if (discountGroups.Any() == false)
                {
                    discountGroups.Add(new List<BookInfo>() { bookInfo });
                    continue;
                }

                var isDepulicated = false;
                foreach (var discountGroup in discountGroups)
                {
                    if (discountGroup.Contains(bookInfo) == false)
                    {
                        discountGroup.Add(bookInfo);
                    }
                    else
                    {
                        isDepulicated = true;
                    }
                }

                if (isDepulicated)
                    discountGroups.Add(new List<BookInfo>() { bookInfo });
            }
            return discountGroups;
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
                }
            }
            return Convert.ToInt32(sumPrice);
        }
    }
}
