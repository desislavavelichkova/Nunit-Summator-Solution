using NUnit.Framework;

namespace Summator.Test
{
    public class SumTests
    {
        [Test]
        public void Test_SumTwoPosititeNUmbers()
        {
            var nums = new int[] { 3, 5 };
            var sum = Summator.Sum(nums);
            Assert.AreEqual(8, sum);
        }
        [Test]
        public void Test_SumTwoNegativeNUmbers()
        {
            var nums = new int[] { -3, -5 };
            var sum = Summator.Sum(nums);
            Assert.AreEqual(-8, sum);
        }

        [Test]
        public void Test_SumEmptyArray()
        {
            var nums = new int[] { };
            var sum = Summator.Sum(nums);
            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Test_SumTooLongNumbers()
        {
            var nums = new int[] { 100000000, 100000000};
            var sum = Summator.Sum(nums);
            Assert.AreEqual(200000000, sum);
        }

        [Test]
        public void Test_SumTwoNegativeAndPositiveNumbers()
        {
            var nums = new int[] { -1, 7 };
            var sum = Summator.Sum(nums);
            Assert.AreEqual(6, sum);
        }

        [Test]
        public void Test_SumNegativeAndPositiveNumbers()
        {
            var nums = new int[] { -1, 7, -6};
            var sum = Summator.Sum(nums);
            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Test_FirstElementInArray()
        {
            var nums = new int[] { -1, 7, -6 };
            var number = nums[0];
            Assert.AreEqual(-1, number);
        }

        [Test]
        public void Test_CountArray()
        {
            var nums = new int[] { -1, 7, -6 };
            var count = 3;
            Assert.AreEqual(count, nums.Length);
        }
    }

    public class AverageTests
    {
        [Test]
        public void Test_AverageTwoPosititeNUmbers()
        {
            var nums = new long[] { 3, 5 };
            var expected = 4;

            var average = Summator.Average(nums);

            Assert.AreEqual(expected, average);
        }

        [Test]
        public void Test_AveragePositiveAndNegativeNumbers()
        {
            var nums = new long[] { 10, -5 };
            var expected = 2.5;

            var average = Summator.Average(nums);

            Assert.AreEqual(expected, average);
        }

        [Test]
        public void Test_Average_EmptyArray()
        {
            var nums = new long[] {};
            
            var average = Summator.Average(nums);

            Assert.AreEqual(double.NaN, average);
        }

        [Test]
        public void Test_Average_ZeroNumbers()
        {
            var nums = new long[] { 0, 0};

            var average = Summator.Average(nums);

            Assert.AreEqual(0, average);
        }
        [Test]
        public void Test_Average_DecimalNumbers()
        {
            var nums = new long[] { 111111111111111, 111111111111111 };

            double average = Summator.Average(nums);

            Assert.AreEqual(111111111111111, average);
        }
    }
}