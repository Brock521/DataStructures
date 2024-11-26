using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Dictionary = DataStructures.ArrayBased.Dictionary<string>;


namespace DataStructuresTestSuite.ArrayBased
{

    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void TestAddNewKeyValuePair()
        {
            var dictionary = new Dictionary();
            int initialCount = dictionary.GetCount();

            dictionary.Add(1, "Value1");

            Assert.AreEqual(initialCount + 1, dictionary.GetCount());
        }

        [Test]
        public void TestAddNewKey()
        {
            var dictionary = new Dictionary();

            dictionary.Add(10, "Value10");
            dictionary.Add(20, "Value20");

            int newKey = dictionary.GenerateKey();

            Assert.AreEqual(21, newKey);
        }

        [Test]
        public void TestClear()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");
            dictionary.Add(2, "Value2");

            dictionary.Clear();

            Assert.AreEqual(0, dictionary.GetCount());
        }

        [Test]
        public void TestContains()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");

            bool exists = dictionary.Contains(1);

            Assert.IsTrue(exists);

            exists = dictionary.Contains(42);

            Assert.IsFalse(exists);
        }



        [Test]
        public void TestRemove()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");

            dictionary.Remove(1);

            Assert.AreEqual(0, dictionary.GetCount());
            dictionary.Remove(42);

            Assert.AreEqual(0, dictionary.GetCount());

        }


        [Test]
        public void TestGetKeys()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");
            dictionary.Add(2, "Value2");

            var keys = dictionary.GetKeys();

            Assert.Contains(1, keys);
            Assert.Contains(2, keys);
            Assert.AreEqual(2, keys.Count);
        }

        [Test]
        public void TestGetValues()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");
            dictionary.Add(2, "Value2");

            var values = dictionary.GetValues();

            Assert.Contains("Value1", values);
            Assert.Contains("Value2", values);
            Assert.AreEqual(2, values.Count);
        }

        [Test]
        public void TestGenerateKey()
        {
            var dictionary = new Dictionary();
            dictionary.Add(1, "Value1");

            int newKey = dictionary.GenerateKey();

            Assert.AreEqual(2, newKey);
        }
    }
}

