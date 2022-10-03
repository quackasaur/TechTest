using System.Linq;
using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests
    {

      [TestCase]
      public void AllTest()
      {
        List<DataStorage> dataList = new List<DataStorage>()
        {
          new DataStorage() { Id = (IComparable)1 },
          new DataStorage() { Id = (IComparable)2 },
          new DataStorage() { Id = (IComparable)3 }
        };

        var repositoryMock = new Mock<IRepository<IStoreable>>();
        repositoryMock.Setup(x => x.All()).Returns(dataList);

        var demoController = new DemoController(repositoryMock.Object);
        var outputList = demoController.All();

        Assert.AreEqual(3, outputList.Count());
      }

      [TestCase]
      public void FindByIdTest()
      {
        List<DataStorage> dataList = new List<DataStorage>()
        {
          new DataStorage() { Id = (IComparable)1 },
          new DataStorage() { Id = (IComparable)2 },
          new DataStorage() { Id = (IComparable)3 }
        };

        var repositoryMock = new Mock<IRepository<IStoreable>>();
        repositoryMock.Setup(x => x.FindById(It.IsAny<IComparable>())).Returns((IComparable id)=> dataList.FirstOrDefault(dl => dl.Id.Equals(id)));

        var demoController = new DemoController(repositoryMock.Object);
        var output = demoController.FindById((IComparable)1);

        Assert.AreEqual(1, output.Id);
      }


      [TestCase]
      public void DeleteItemTest()
      {
        List<DataStorage> dataList = new List<DataStorage>()
        {
          new DataStorage() { Id = (IComparable)1 },
          new DataStorage() { Id = (IComparable)2 },
          new DataStorage() { Id = (IComparable)3 }
        };

        var repositoryMock = new Mock<IRepository<IStoreable>>();
        repositoryMock.Setup(x => x.Delete(It.IsAny<IComparable>()));
        var demoController = new DemoController(repositoryMock.Object);
        demoController.Delete((IComparable)1);

        repositoryMock.Verify( rep => rep.Delete((IComparable)1));
      }


      [TestCase]
      public void SaveItemTest()
      {
        List<DataStorage> dataList = new List<DataStorage>()
        {
          new DataStorage() { Id = (IComparable)1 },
          new DataStorage() { Id = (IComparable)2 },
          new DataStorage() { Id = (IComparable)3 }
        };

        var newItem = new DataStorage() { Id = 4 };

        var repositoryMock = new Mock<IRepository<IStoreable>>();
        repositoryMock.Setup(x => x.Save(It.IsAny<IStoreable>()));
        var demoController = new DemoController(repositoryMock.Object);
        demoController.Save(newItem);

        repositoryMock.Verify( rep => rep.Save((newItem)));
      }
    }
}
