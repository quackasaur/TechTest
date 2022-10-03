using System;
using System.Collections.Generic;

namespace Interview
{
  /// <summary>
  /// Class to use the repository
  /// </summary>
  public class DemoController
  {
    private readonly IRepository<IStoreable> _repository;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="repository"></param>
    public DemoController(IRepository<IStoreable> repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Method to get all the items
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IStoreable> All()
    {
      return _repository.All();
    }

    /// <summary>
    /// Method to delete an item
    /// </summary>
    /// <param name="id"></param>
    public void Delete(IComparable id)
    {
      try
      {
        _repository.Delete(id);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Unable to delete: {ex.Message}");
      }
    }

    /// <summary>
    /// Method to add a new item
    /// </summary>
    /// <param name="item"></param>
    public void Save(IStoreable item)
    {
      try
      {
        _repository.Save(item);
      }

      catch (Exception ex)
      {
        Console.WriteLine($"Unable to save: {ex.Message}");
      }
    }

    /// <summary>
    /// Method to find an item by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IStoreable FindById(IComparable id)
    {
      return _repository.FindById(id);
    }
  }
}
