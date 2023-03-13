﻿using RestWithASPNET.Model;

namespace RestWithASPNET.Repository
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
