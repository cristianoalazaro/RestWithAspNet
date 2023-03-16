using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Utils;
using System;

namespace RestWithASPNET.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private MySQLContext _context;
    private DbSet<T> dataset;

    public GenericRepository(MySQLContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }

    public List<T> FindAll(ParamsPagination paramsPagination)
    {
        return dataset
            .Skip((paramsPagination.PageNumber - 1) * paramsPagination.PageSize)
            .Take(paramsPagination.PageSize)
            .ToList();
    }

    public T FindById(long id)
    {
        return dataset.FirstOrDefault(p => p.Id.Equals(id));
    }

    public T Create(T item)
    {
        try
        {
            dataset.Add(item);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
        return item;
    }

    public T Update(T item)
    {
        if (item == null) return null;
        try
        {
            var result = FindById(item.Id);
            if (result != null)
            {
                dataset.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            else
            {
                return null;
            }
        }
        catch
        {
            throw;
        }
        return item;
    }

    public void Delete(long id)
    {
        var result = FindById(id);
        if (result != null)
        {
            try
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
