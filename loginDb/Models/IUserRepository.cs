using loginDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace loginDb.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(Object o);
        void Edit(Object o);
        void Remove(int id);
        Object GetById(int id, string tableName);
        User GetByUsername(string username);
        IEnumerable<Client> GetAllClients();
        IEnumerable<Payer> GetAllPayers();
  //      void Remove(Object obj); //int id)


    }
}