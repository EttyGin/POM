/*using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace loginDb
{
    internal class Prog
    {
        static void Main(string[] args)
        {
            #region adding some rows to DB
            using (var db = new POMdbContainer())
            {
                #region adding student example
                ////adding student example
                Client c = new Client { Id = 325746147, Cname = "Etty Ginzburg", BirthDate = new DateTime(2004, 1, 6), Phone = "0533134012", Email = "ettyg325@gmail.com" };
                db.Clients.Add(c);
                db.SaveChanges();
                #endregion

            }
            #endregion
        }
    }
}
*/