using System.Diagnostics;

namespace Tuna.Revit.Test
{
    public class Tests
    {
        [Test]
        public void RangeInt()
        {
            var result = Extension.Enumerator.Range(0,-1,-0.1);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Assert.Pass();
        }
    }
}