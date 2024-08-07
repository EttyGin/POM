using loginDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace loginDb.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(Object o)
        {
           // throw new NotImplementedException();
            #region adding some rows to DB
            using (var db = new POMdbEntities())
            {
                #region adding student example
                if (o is User u)
                {
                    db.Users.Add(u);
                }
                if (o is Client c)
                {
                    db.Clients.Add(c);
                }
                if (o is UserAccount ua)
                {
                    db.UserAccounts.Add(ua);
                }
                if (o is Meeting m)
                {
                    db.Meetings.Add(m);
                }
                if (o is Payer p)
                {
                    db.Payers.Add(p);
                }
                db.SaveChanges();
                #endregion

            }
            #endregion
            
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;



                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(Object o)
        {
            #region update example
            using (var db = new POMdbEntities())
            {
                var clnt = o as Client; // = db.Clients.Find(idupdt);
                if (clnt != null)
                {
                    db.Clients.Attach(clnt);
                    db.Entry(clnt).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            #endregion
        }
        public IEnumerable<Client> GetAllClients()
        {
            using (var db = new POMdbEntities())
            {
                return db.Clients.ToList();

            }
        }

        public IEnumerable<Payer> GetAllPayers()
        {
            using (var db = new POMdbEntities())
            {
                return db.Payers.ToList();

            }
        }

        /*        public IEnumerable<T> GetByAll<T>(string tableName) where T : class
                {
                    if (!typeof(T).Name.Equals(tableName, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentException($"Type '{typeof(T).Name}' does not match table name '{tableName}'");
                    }

                    using (var db = new POMdbEntities())
                    {
                        switch (tableName)
                        {
                            case "Clients":
                                return (IEnumerable<T>)db.Clients.ToList();
                            default:
                                return null;

                        }
                    }
                }

        */

        public Object GetById(int id)
        {
            throw new NotImplementedException();
        }
        public User GetByUsername(string username)
        {
            User user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }
            }
            return user;
        }
        public void Remove(Object obj) //int id)
        {
            using (var db = new POMdbEntities())
            {

                var clnt = obj as Client;//(Client)obj;//db.Clients.Find(id);
                if (clnt != null)
                {
                    db.Clients.Remove(clnt);
                    db.SaveChanges();

                }


            }
        }    
    }
}