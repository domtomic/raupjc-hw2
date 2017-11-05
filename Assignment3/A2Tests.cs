using Assignment2;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
    [TestClass]
    public class A2Tests
    {
        // TodoItem class - TESTS
        [TestMethod]
        public void MarkAsCompletedTest()
        {
            TodoItem varItem = new TodoItem("First task");
            Assert.IsFalse(varItem.IsCompleted);
            Assert.IsTrue(varItem.MarkAsCompleted());
            Assert.IsTrue(varItem.IsCompleted);
            Assert.IsFalse(varItem.MarkAsCompleted());
        }
        [TestMethod]
        public void EqualsTest()
        {
            TodoItem varItem1 = new TodoItem("Generic task title");
            TodoItem varItem2 = new TodoItem("Generic task title");
            Assert.IsFalse(varItem1.Equals(varItem2));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            TodoItem varItem1 = new TodoItem("Generic task title");
            TodoItem varItem2 = new TodoItem("Generic task title");
            Assert.IsFalse(varItem1.GetHashCode().Equals(varItem2.GetHashCode()));
        }

        // TodoRepository class - TESTS
        [TestMethod]
        public void AddRemoveGetTest()
        {
            TodoRepository varRepository = new TodoRepository(null);
            TodoItem varItem = new TodoItem("Test item");
            Assert.AreEqual(varItem, varRepository.Add(varItem));
            Assert.AreEqual(varItem, varRepository.Get(varItem.Id));
            Assert.AreEqual("Test item", varRepository.Get(varItem.Id).Text);
            Assert.IsTrue(varRepository.Remove(varItem.Id));
            Assert.IsFalse(varRepository.Remove(varItem.Id));
            Assert.AreEqual(null, varRepository.Get(varItem.Id));
           
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddTestThrowsDuplicateTodoItemException()
        {
            TodoRepository varRepository = new TodoRepository(null);
            TodoItem varItem = new TodoItem("Duplicate");
            varRepository.Add(varItem);
            varRepository.Add(varItem);
        }

        [TestMethod]
        public void UpdateTest()
        {
            TodoRepository varRepository = new TodoRepository();
            TodoItem varItem1 = new TodoItem("First item");
            TodoItem varItem2 = new TodoItem("Second item");
            varRepository.Add(varItem1);
            varItem1.Text = "First item - updated text";
            Assert.AreEqual(varItem1, varRepository.Update(varItem1));
            Assert.AreEqual("First item - updated text", varRepository.Get(varItem1.Id).Text);
            varRepository.Update(varItem2);
            Assert.AreEqual("Second item", varRepository.Get(varItem2.Id).Text);
        }

        [TestMethod]
        public void MarkAsCompleted2Test()
        {
            TodoRepository varRepository = new TodoRepository();
            TodoItem varItem = new TodoItem("Test item");
            Assert.IsFalse(varRepository.MarkAsCompleted(varItem.Id));
            Assert.IsFalse(varItem.IsCompleted);
            varRepository.Add(varItem);
            Assert.IsTrue(varRepository.MarkAsCompleted(varItem.Id));
            Assert.IsTrue(varRepository.Get(varItem.Id).IsCompleted);
            Assert.IsFalse(varRepository.MarkAsCompleted(varItem.Id));

        }

        [TestMethod]
        public void GetAllTest()
        {
            TodoRepository varRepository = new TodoRepository(null);
            for (int i = 1; i <= 10; i++)
                varRepository.Add(new TodoItem(i + ". item"));
            List<TodoItem> list = varRepository.GetAll();
            Assert.AreEqual(list.Count, 10);
            Assert.AreEqual(list[7].Text, "8. item");
        }

        [TestMethod]
        public void GetActiveTest()
        {
            TodoRepository varRepository = new TodoRepository(null);
            for (int i = 1; i <= 9; i++)
                varRepository.Add(new TodoItem(i + ". item"));
            TodoItem varItem = new TodoItem("deactivate this");
            varRepository.Add(varItem);
            Assert.AreEqual(varRepository.GetActive().Count, 10);
            varRepository.Get(varItem.Id).MarkAsCompleted();
            Assert.AreEqual(varRepository.GetActive().Count, 9);
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            TodoRepository varRepository = new TodoRepository(null);
            for (int i = 1; i <= 9; i++)
                varRepository.Add(new TodoItem(i + ". item"));
            TodoItem varItem = new TodoItem("deactivate this");
            varRepository.Add(varItem);
            Assert.AreEqual(varRepository.GetCompleted().Count, 0);
            varRepository.Get(varItem.Id).MarkAsCompleted();
            Assert.AreEqual(varRepository.GetCompleted().Count, 1);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            TodoRepository varRepository = new TodoRepository(null);
            for (int i = 1; i <= 10; i++)
                varRepository.Add(new TodoItem(i.ToString()));
            Assert.AreEqual(varRepository.GetFiltered(varItem => int.Parse(varItem.Text) > 6).Count, 4);
        }
    }
}
