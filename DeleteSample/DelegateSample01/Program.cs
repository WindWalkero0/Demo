using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample01
{
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    public class Iphone6
    {
        decimal price;

        public event PriceChangedHandler PriceChanged;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                //如果调用列表不为空，则触发
                PriceChanged?.Invoke(oldPrice, price);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Iphone6 iphone6 = new Iphone6() { Price = 5288 };
            //订阅事件
            iphone6.PriceChanged += Iphone6_PriceChanged;

            //调整价格（事件发生）
            iphone6.Price = 3999;
            Console.ReadKey();
        }

        static void Iphone6_PriceChanged(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"年中大促销，iPhone6只卖 {newPrice} 元， 原价 {oldPrice} 元，快来抢购！");
        }
    }
}
