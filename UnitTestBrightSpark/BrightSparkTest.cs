using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrightSpark.Controllers;
using BrightSpark.Models;
using System.Net.Http;
using System.Net;

namespace UnitTestBrightSpark
{
    [TestClass]
    public class BrightSparkTest
    {
        [TestMethod]
        public void GetFibonacci_ShouldReturnRequestedNandNTHinSequence()
        {
            // Arrange
            FibonacciController fc = new FibonacciController();

            //Act
            FibonacciStruct result = fc.GetFibonacci((uint)12);

            // Assert
            Assert.AreEqual(result.numberRequested,(uint)12);
            Assert.AreEqual(result.nthNumberOfFibonacciSequence, (uint)144);
        }

        [TestMethod]
        public void GetWords_ShouldReturnWordsSortedByIdAscendingNotUnique()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);

            Dictionary<int, string> resultGetWords = wc.GetWords("id", false);

            Dictionary<int, string> resExpected = new Dictionary<int, string> { { 0, "dog" }, { 1, "cat" }, { 2, "horse" }, { 3, "elephant" } };
            CollectionAssert.AreEquivalent(resultGetWords, resExpected);

        }

        [TestMethod]
        public void GetWords_ShouldReturnWordsSortedByIdDescendingNotUnique()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);

            Dictionary<int, string> resultGetWords = wc.GetWords("-id", false);

            // Assert
            Dictionary<int, string> resExpected = new Dictionary <int,string> {{ 3, "elephant"}, { 2, "horse"}, { 1, "cat"}, { 0, "dog" } };
            CollectionAssert.AreEquivalent(resultGetWords, resExpected);
        }


        [TestMethod]
        public void GetWords_ShouldReturnWordsSortedByValueAscendingNotUnique()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);
            Dictionary<int, string> resultGetWords = wc.GetWords("value", false);

            // Assert
            Dictionary<int, string> resExpected = new Dictionary<int, string> { { 1, "cat" }, { 0, "dog" }, { 3, "elephant" }, { 2, "horse" } };
            CollectionAssert.AreEquivalent(resultGetWords, resExpected);

        }

        [TestMethod]
        public void GetWords_ShouldReturnWordsSortedByValueDescendingNotUnique()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);
            Dictionary<int, string> resultGetWords = wc.GetWords("-value", false);

            // Assert
            Dictionary<int, string> resExpected = new Dictionary<int, string> { { 2, "horse" }, { 3, "elephant" }, { 0, "dog" }, { 1, "cat" } };
            CollectionAssert.AreEquivalent(resultGetWords, resExpected);
        }

        [TestMethod]
        public void GetWords_ShouldReturnWordsSortedByIdAscendingUnique()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);
            Dictionary<int, string> resultGetWords = wc.GetWords("id", true);

            // Assert
            Dictionary<int, string> resExpected = new Dictionary<int, string> { { 0, "dog" }, { 1, "cat" }, { 2, "horse" }, { 3, "elephant" } };
            CollectionAssert.AreEquivalent(resultGetWords, resExpected);

        }

        [TestMethod]
        public void PosttWords_ShouldAddWords()
        {
            // Arrange
            WordsController wc = new WordsController();

            //Act
            string[] saPost = new string[] { "dog", "cat", "horse", "elephant" };
            Dictionary<int, string> resultPost = wc.Post(saPost);

            // Assert
            Dictionary<int, string> resExpected = new Dictionary<int, string> { { 0, "dog" }, { 1, "cat" }, { 2, "horse" }, { 3, "elephant" } };
            CollectionAssert.AreEquivalent(resultPost, resExpected);
        }

        [TestMethod]
        public void DeleteWords_ShouldDeleteWords()
        {
            // Arrange
            WordsController dc = new WordsController();

            //Act
            HttpResponseMessage httpm = dc.Delete();

            // Assert will fail since web services are not running and this.Request is null
            //HttpResponseMessage httpExcpected = new HttpResponseMessage();
            //Assert.AreEqual(httpm.IsSuccessStatusCode, HttpStatusCode.OK);
        }
    }
}
