using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Lib
{
    /// <summary>
    /// 哈利波特的折扣策略
    /// </summary>
    public class PotterDiscountStrategy : IDiscountStrategy
    {
        readonly List<List<BookInfo>> _discountGroups;
        private PotterDiscountStrategy()
        {
            _discountGroups = new List<List<BookInfo>>() { new List<BookInfo>() };
        }

        /// <summary>
        /// 取得策略
        /// </summary>
        /// <returns></returns>
        public static PotterDiscountStrategy NewStrategy()
        {
            return new PotterDiscountStrategy();
        }

        /// <summary>
        /// 加入書目清單
        /// </summary>
        /// <param name="shoppingList"></param>
        public void AddShoppingList(List<BookInfo> shoppingList)
        {
            foreach (var bookInfo in shoppingList)
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
                    _discountGroups.Add(new List<BookInfo>() { bookInfo });
            }
        }

        /// <summary>
        /// 取得最後價格
        /// </summary>
        /// <returns></returns>
        public int GetResultPrice()
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
