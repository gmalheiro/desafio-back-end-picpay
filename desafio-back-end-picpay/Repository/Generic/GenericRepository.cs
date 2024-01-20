using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace desafio_back_end_picpay.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{

    private readonly DatabaseContext _context;
    private readonly DbSet<T>? dataset;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }

    public T Create(T item)
    {
        try
        {
            dataset?.Add(item);
            _context?.SaveChanges();
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return item;
        }
    }

    public T Delete(int id)
    {
        var itemToBeFound = dataset?.FirstOrDefault(x => x.Id == id);

        if (itemToBeFound != null)
        {
            try
            {
                dataset?.Remove(itemToBeFound);
                _context?.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return itemToBeFound;
            }
            return itemToBeFound;
        }
        else
        {
            return itemToBeFound!;
        }
    }

    public bool Exists(long id)
    {
        return dataset!.Any(x => x.Id == id);
    }

    public List<T> FindAll()
    {
        var item = new List<T>();

        try
        {

            item = dataset?.ToList();

            return item == null ? new List<T>() : item;
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return item == null ? new List<T>() : item;
        }

    }

    public T FindById(long id)
    {
        T item;

        try
        {
            item = dataset?.FirstOrDefault(i => i.Id == id)!;
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            item = null!;
            return item;
        }

    }

    public List<T> FindWithPagedSearch(string query)
    {
        return dataset?.FromSqlRaw<T>(query).ToList() == null ? new List<T>() : dataset.FromSqlRaw<T>(query).ToList();
    }

    public int GetCount(string query)
    {
        var result = "";
        using (var connection = _context?.Database.GetDbConnection())
        {
            connection?.Open();
            using (var command = connection?.CreateCommand())
            {
                command!.CommandText = query;
                result = command?.ExecuteScalar()?.ToString() ?? "";
            }
        }
        return int.Parse(result);
    }

    public T Update(T item)
    {
        T result;

        result = dataset?.SingleOrDefault(i => i.Equals(item.Id))!;

        if (result != null)
        {
            try
            {
                _context?.Entry(result).CurrentValues.SetValues(item);
                _context?.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return result;
            }
        }
        else
        {
            return result!;
        }
    }
}
