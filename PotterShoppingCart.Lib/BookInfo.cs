
namespace PotterShoppingCart.Lib
{
    public class BookInfo
    {
        /// <summary>
        /// 書名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 單價
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 折扣策略
        /// </summary>
        public DiscountType DiscountType { get; set; }
    }

    public enum DiscountType
    {
        Default,
        HarryPotter
    }
}
