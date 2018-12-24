using api.Controllers;
using NUnit.Framework;

namespace Tests
{
    public class RangeTests
    {
        [Test]
        public void Range_must_match_count()
        {
            var range = new Range { Count = 3 };
            var generated = range.Of(() => "");
            Assert.That(range.Count, Is.EqualTo(3));
        }

        [Test]
        public void Docker_fake()
        {
            Assert.Fail("for testing purposes");
        }
    }
}