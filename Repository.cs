using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
  /// <summary>
  /// Concrete implementation of IRepository
  /// </summary>
  public class Repository : IRepository<IStoreable>
  {
    private readonly List<IStoreable> _inMemDatabase;

    public Repository()
    {
      _inMemDatabase = new List<IStoreable>();
    }

    /// <summary>
    /// Method to get all the items
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IStoreable> All()
    {
      return _inMemDatabase;
    }

    /// <summary>
    /// Method to delete an item
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Delete(IComparable id)
    {
      var item = _inMemDatabase.FirstOrDefault(p => p.Id.Equals(id));

        //throw an exception if we cannot find the item
      if (item == null)
      {
        throw new InvalidOperationException(nameof(item));
      }

      _inMemDatabase.Remove(item);
    }

    /// <summary>
    /// Method to add a new item
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Save(IStoreable item)
    {
      //throw an exception if the item is null
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      _inMemDatabase.Add(item);
    }

    /// <summary>
    /// Method to find an item by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IStoreable FindById(IComparable id)
    {
      return _inMemDatabase.FirstOrDefault(p => p.Id.Equals(id));
    }
  }
}
