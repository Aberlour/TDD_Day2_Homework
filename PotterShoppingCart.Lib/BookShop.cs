using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Lib
{
    /// <summary>
    /// 書店
    /// </summary>
    public class BookShop
    {
        /// <summary>
        /// 取得書店
        /// </summary>
        /// <returns></returns>
        public static BookShop GetBookShop()
        {
            return new BookShop();
        }

        /// <summary>
        /// 計算購物車內容價格
        /// </summary>
        /// <param name="shoppingList">購物車</param>
        /// <returns></returns>
        public int CheckCart(List<BookInfo> shoppingList)
        {
            var typeGroup = shoppingList.GroupBy(s => s.DiscountType);
            int sumPrice = 0;
            foreach (var shippingGroup in typeGroup)
            {
                var strategy = GetStrategy(shippingGroup.Key);
                strategy.AddShoppingList(shippingGroup.ToList());
                sumPrice += strategy.GetResultPrice();
            }
            return sumPrice;
        }

        /// <summary>
        /// 取得折扣策略
        /// </summary>
        /// <param name="discountType">折扣類型</param>
        /// <returns></returns>
        private IDiscountStrategy GetStrategy(DiscountType discountType)
        {
            switch (discountType)
            {
                case DiscountType.Default:
                    return null;
                    break;
                case DiscountType.HarryPotter:
                    return PotterDiscountStrategy.NewStrategy();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
