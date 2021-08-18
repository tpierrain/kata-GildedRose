using System.Collections.Generic;

namespace GildedRose.Cli
{
    public class Inn
    {
        private const int MaxQuality = 50;
        private const int TenDays = 10;
        private const int FiveDays = 5;

        private readonly IList<Item> _items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        public IList<Item> Items => _items;

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQuality(item);
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            switch (item.Name)
            {
                case "Aged Brie":
                {
                    HandleAgedBrie(item);
                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    HandleBackstagePass(item);
                    break;
                }
                case "Conjured Mana Cake":
                {
                    DecreaseQualityWhenPositive(item);
                    DecreaseQualityWhenPositive(item);

                    DecrementSellIn(item);

                    if (item.SellIn < 0)
                    {
                        DecreaseQualityWhenPositive(item);
                    }

                    break;
                }
                default:
                {
                    DecreaseQualityWhenPositive(item);

                    DecrementSellIn(item);

                    if (item.SellIn < 0)
                    {
                        DecreaseQualityWhenPositive(item);
                    }

                    break;
                }
            }
        }

        private static void HandleBackstagePass(Item item)
        {
            IncrementQualityIfNotMaxAlready(item);

            if (item.SellIn <= TenDays)
            {
                IncrementQualityIfNotMaxAlready(item);
            }

            if (item.SellIn <= FiveDays)
            {
                IncrementQualityIfNotMaxAlready(item);
            }

            DecrementSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void HandleAgedBrie(Item item)
        {
            IncrementQualityIfNotMaxAlready(item);

            DecrementSellIn(item);

            if (item.SellIn < 0)
            {
                IncrementQualityIfNotMaxAlready(item);
            }
        }

        private static void DecreaseQualityWhenPositive(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void DecrementSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static void IncrementQualityIfNotMaxAlready(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}