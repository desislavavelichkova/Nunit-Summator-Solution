using NUnit.Framework;
using System;

namespace Collections.Tests
{
    public class Tests
    {

        [Test]
        public void Test_InitialCapacity()
        {
            Collection<int> collection = new Collection<int>();
            int capacity = 16;
            Assert.That(capacity == collection.Capacity);
        }

        [Test]
        public void Test_Count_WhenIsEmptyCollection()
        {
            Collection<int> collection = new Collection<int>();

            Assert.AreEqual(0, collection.Count);
        }
        [Test]
        public void Test_Count_WhenCollectionIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });

            Assert.AreEqual(5, collection.Count);
        }


        [Test]
        public void Test_WhenAddNumberInTheCollection_NumberExist()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });
            collection.Add(60);
            int expectedNumber = 60;
            Assert.That(expectedNumber == collection[5]);

        }

        [Test]
        public void Test_WhenAddNumberInTheCollection_CountIsDifferent()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });
            int expectedCount = 6;
            collection.Add(60);
            Assert.AreEqual(expectedCount, collection.Count);

        }
        [Test]
        public void Test_WhenAddNumberInTheCollectionAndCountIs16()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            int expectedCount = 17;
            collection.Add(60);
            Assert.AreEqual(expectedCount, collection.Count);

        }
        [Test]
        public void Test_EnsureCapacity()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            int expectedCapacity = 32;
            collection.Add(60);
            Assert.AreEqual(expectedCapacity, collection.Capacity);

        }

        [Test]
        public void Test_AddRange_WhenRangeIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });
            Collection<int> expectedCollection = new Collection<int>(new int[] { 10, 20, 30, 40, 50, 1, 2, 3, 4 });
            int[] newArr = new int[] { 1, 2, 3, 4 };

            collection.AddRange(newArr);

            Assert.AreEqual(expectedCollection.Count, collection.Count);

        }
        [Test]
        public void Test_AddRange_AddNewRangeToCollection()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20 });
            Collection<int> expectedCollection = new Collection<int>(new int[] { 10, 20, 1, 2 });
            int[] newArr = new int[] { 1, 2 };

            collection.AddRange(newArr);

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());

        }
        [Test]
        public void Test_AddRange_AddNewRangeToCollectionWithCountMoreThanInitialCapacity()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20 });

            int[] newArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int expectedCollctionCapacity = 32;

            collection.AddRange(newArr);

            Assert.AreEqual(expectedCollctionCapacity, collection.Capacity);

        }
        [Test]
        public void Test_AddRange_CountOfNewCollection_AddNewRangeToCollectionWithCountMoreThanInitialCapacity()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20 });

            int[] newArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int expectedCollctionCount = 18;

            collection.AddRange(newArr);

            Assert.AreEqual(expectedCollctionCount, collection.Count);
        }
        [Test]
        public void Test_InsertAt_WhenIndexExist()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 2;
            int item = 100;

            collection.InsertAt(index, item);

            var expectedCollection = new Collection<int>(new int[] { 1, 2, 100, 3, 4, 5 });

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_InsertAt_WhenCollectionHasMaxCapacity()
        {
            Collection<int> collection = new Collection<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});

            int index = 0 ;
            int item = 100;

            collection.InsertAt(index, item);

            var collectionCapacity = 32;

            Assert.AreEqual(collectionCapacity, collection.Capacity);
        }
        [Test]
        public void Test_InsertAt_WhenCollectionHasMaxCapacity_Count()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            int index = 0;
            int item = 100;

            collection.InsertAt(index, item);

            var collectionCount = 17;

            Assert.AreEqual(collectionCount, collection.Count);
        }

        [Test]
        public void Test_CheckRange_WhenInputsIsLessThenMinValue()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = -2;
            string paramName = nameof(index);
            int minValue = 0;
            int maxValue = collection.Count;

            Assert.That(() =>  collection.InsertAt(-2, 100),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
           
        }
        [Test]
        public void Test_CheckRange_WhenInputsIsMoreThenMaxValue()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 10;
            string paramName = nameof(index);
            int minValue = 0;
            int maxValue = collection.Count;

            Assert.That(() => collection.InsertAt(index, 100),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        
        public void Test_Exchange_WhenInputIndexAreExisting()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            collection.Exchange(0, 2);
            var expectedCollection = new Collection<int>(new int[] { 3, 2, 1, 4, 5});

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }

        [Test]
        public void Test_Exchange_WhenInputIndex1DoesNotExisting_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
                        
            Assert.That(() => collection.Exchange(-2, 2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Exchange_WhenInputIndex1DoesNotExisting_PositiveIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(10, 2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Exchange_WhenInputIndex2DoesNotExisting_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(2, -2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Exchange_WhenInputIndex2DoesNotExisting_PositiveIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(2, 20),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Index_IndexDoesExist()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 1;           
            int indexValue = 2;

            Assert.AreEqual(indexValue, collection[index]);

        }

        [Test]
        public void Test_Index_IndexIsInRangeOfArray()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 1;
            
            Assert.That(index >=0 && index <= collection.Count-1);

        }

        [Test]
        public void Test_Index_IndexDoesNotExist_NegativeNumber()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = -10;
           
            Assert.That(() => collection[index],
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Index_IndexDoesNotExist_PositiveNumberMoreThanCount()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 10;

            Assert.That(() => collection[index],
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_EnsureCapacity_WhenCountAndCapacityAreEqual()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});
            collection.Add(12);
            
            Assert.That(collection.Capacity == 32);
        }

        [Test]
        public void Test_RemoveAt_WhenIndexIsValid()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            collection.RemoveAt(0);

            Assert.That(collection.Count == 2);
        }

        [Test]
        public void Test_RemoveAt_WhenIndexIsNotValid_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection.RemoveAt(-2),
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_RemoveAt_WhenIndexIsOutOfRange()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection.RemoveAt(100),
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_RemoveAt_WhenIndexIsValidAndCapacityIsMoreThan16_Count()
        {
            Collection<int> collection = new Collection<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});

            collection.RemoveAt(0);

            Assert.That(collection.Count == 15);
           
        }

        //[Test]
        //public void Test_RemoveAt_WhenIndexIsValidAndCapacityIsMoreThan16_Capacity()
        //{
        //    Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

        //    collection.RemoveAt(0);
        //    collection.RemoveAt(0);
            
        //    Assert.AreEqual(32, collection.Capacity);
        //}

        [Test]
        public void Test_Clear_WhenCollectionIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            collection.Clear();

            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Clear_WhenCollectionIsNotEmpty_CheckToStingMethod()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedCollection = new Collection<int>();

            collection.Clear();

            Assert.That(expectedCollection.ToString(), Is.EqualTo(collection.ToString()));
        }

        [Test]
        public void Test_ToString_WhenCollectionIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedMessage = "[1, 2, 3]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }
        [Test]
        public void Test_ToString_WhenCollectionIsLong()
        {
            Collection<int> collection = new Collection<int>(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                                     var expectedMessage = "[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }
        [Test]
        public void Test_ToString_WhenCollectionIsEmpty()
        {
            Collection<int> collection = new Collection<int>();
            var expectedMessage = "[]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }
    }
}