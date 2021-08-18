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
        public void UpdateQuality_as_expected()
        {
            var inn = new Inn();
            var legacyInn = new LegacyInn();

            for (var i = 0; i < 18; i++)
            {
                Check.That(inn.Items.Select(i => i.Name)).ContainsExactly(legacyInn.Items.Select(i => i.Name));
                Check.That(inn.Items.Select(i => i.SellIn)).ContainsExactly(legacyInn.Items.Select(i => i.SellIn));
                Check.That(inn.Items.Select(i => i.Quality)).ContainsExactly(legacyInn.Items.Select(i => i.Quality));

                inn.UpdateQuality();
                legacyInn.UpdateQuality();
            }
        }
    }
}
