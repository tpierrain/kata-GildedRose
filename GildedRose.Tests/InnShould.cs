using System.Linq;
using GildedRose.Cli;
using NFluent;

namespace GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class InnShould
    {
        [Test]
        public void Update_Items_Quality_as_always_but_not_for_Conjured_Items_Quality()
        {
            var inn = new Inn();
            var legacyInn = new LegacyInn();

            for (var i = 0; i < 18; i++)
            {
                Check.That(inn.Items.Select(i => i.Name)).ContainsExactly(legacyInn.Items.Select(i => i.Name));
                Check.That(inn.Items.Select(i => i.SellIn)).ContainsExactly(legacyInn.Items.Select(i => i.SellIn));

                for (var j = 0; j < inn.Items.Count; j++)
                {
                    if (inn.Items[j].Name != "Conjured Mana Cake")
                    {
                        Check.That(inn.Items[j].Quality).IsEqualTo(legacyInn.Items[j].Quality);
                    }
                }

                inn.UpdateQuality();
                legacyInn.UpdateQuality();
            }
        }

        [Test]
        public void Degrade_Quality_twice_as_fast_as_normal_items_for_Conjured_Items()
        {
            var inn = new Inn();

            var normalItem = inn.Items.Single(i => i.Name == "+5 Dexterity Vest");
            var conjuredItem = inn.Items.Single(i => i.Name.Contains("Conjured"));

            var previousNormalItemQuality = normalItem.Quality;
            var previousConjuredItemQuality = conjuredItem.Quality;

            inn.UpdateQuality();

            var deltaConjured = previousConjuredItemQuality - conjuredItem.Quality;
            var deltaNormal = previousNormalItemQuality - normalItem.Quality;

            Check.That(deltaConjured).IsEqualTo(2* deltaNormal);
        }
    }
}
