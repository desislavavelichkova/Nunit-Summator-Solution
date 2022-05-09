using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class Tests
    {
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

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
        public void Test_Collection_EmptyConstructor()
        {
            Collection<int> collection = new Collection<int>();

            Assert.AreEqual(collection.ToString(), "[]");
        }
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            Collection<int> collection = new Collection<int>(100);

            Assert.AreEqual(collection.ToString(), "[100]");
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            Collection<int> collection = new Collection<int>(100, 102, 22, 33);

            Assert.AreEqual(collection.ToString(), "[100, 102, 22, 33]");
        }
        [Test]
        public void Test_Count_WhenCollectionIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });

            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
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
        public void Test_WhenAddNumberInTheCollection_CountIsGrow()
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
        public void Test_Collection_InsertAtMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 2;
            int item = 100;

            collection.InsertAt(index, item);

            var expectedCollection = new Collection<int>(new int[] { 1, 2, 100, 3, 4, 5 });

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_Collection_InsertAtWithGrow()
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
        public void Test_Collection_ExchangeFirstLast()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            collection.Exchange(0, 4);
            var expectedCollection = new Collection<int>(new int[] { 5, 2, 3, 4, 1});

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            collection.Exchange(2, 3);
            var expectedCollection = new Collection<int>(new int[] { 1, 2, 4, 3, 5, 6 });

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes_NegativeInputIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
                        
            Assert.That(() => collection.Exchange(-2, 2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collection_ExchangeInvalidIndexes_PositiveInputIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(10, 2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes_NegativeOutputIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(2, -2),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collection_ExchangeInvalidIndexes_PositiveOutputIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => collection.Exchange(2, 20),
                               Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collection_GetByIndex()
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
        public void Test_Collection_GetByInvalidIndex_NegativeNumber()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = -10;
           
            Assert.That(() => collection[index],
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_GetByInvalidIndex_PositiveNumberMoreThanCount()
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
        public void Test_Collection_RemoveAtStart()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedCollection = new Collection<int>(new int[] { 2, 3 });
            collection.RemoveAt(0);

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedCollection = new Collection<int>(new int[] { 1, 2 });
            collection.RemoveAt(2);

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5});
            var expectedCollection = new Collection<int>(new int[] { 1, 2, 4, 5 });
            collection.RemoveAt(2);

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }

        [Test]
        public void Test_Collection_RemoveAtAll()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            while (collection.Count > 0)
            {
                collection.RemoveAt(0);
            }            

            Assert.AreEqual("[]", collection.ToString());
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection.RemoveAt(-2),
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [Test]
        public void Test_Collection_RemoveAtInvalidIndex_OutOfRange()
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
        public void Test_Collection_Clear_WhenCollectionIsNotEmpty()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            collection.Clear();

            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Collection_Clear_WhenCollectionIsNotEmpty_CheckToStingMethod()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedCollection = new Collection<int>();

            collection.Clear();

            Assert.That(expectedCollection.ToString(), Is.EqualTo(collection.ToString()));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });
            var expectedMessage = "[1, 2, 3]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }
        [Test]
        public void Test_Collection_ToStringSingle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1 });
            var expectedMessage = "[1]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            Collection<int> collection = new Collection<int>();
            var expectedMessage = "[]";

            var message = collection.ToString();

            Assert.That(expectedMessage, Is.EqualTo(message));
        }
        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [Test]
        public void Test_Collection_SetByIndex() 
        {
            Collection<int> collection = new Collection<int>(1);
            
            Assert.AreEqual(1, collection[0]);
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection[-1],
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex_PositiveIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection[100],
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 0;
            int item = 100;

            collection.InsertAt(index, item);

            var expectedCollection = new Collection<int>(new int[] { 100, 1, 2, 3, 4, 5 });

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            int index = 5;
            int item = 100;

            collection.InsertAt(index, item);

            var expectedCollection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 100 });

            Assert.AreEqual(expectedCollection.ToString(), collection.ToString());
        }
        [Test]
        public void Test_Collection_InsertAtInvalidIndex_NegativeIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection.InsertAt(-1, 23),
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collection_InsertAtInvalidIndex_PositiveIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3 });

            Assert.That(() => collection.InsertAt(100, 6),
                                           Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}