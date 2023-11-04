using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_1_4.Models;

namespace Tarea_1_4.Controllers {
    public class DB {
        readonly SQLiteAsyncConnection connection;
        public DB() {

        }

        public DB(string path) {
            try {
                connection=new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<People>().Wait();
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /*CRUD*/
        public Task<int> add_person(People person) {
            if(person.id==0) {
                return connection.InsertAsync(person);
            } else {
                return connection.UpdateAsync(person);
            }
        }

        public Task<List<People>> list_people() {
            return connection.Table<People>().ToListAsync();
        }

        public Task<People> get_person_id(int id) {
            return connection.Table<People>().Where(p => p.id==id).FirstOrDefaultAsync();
        }
    }
}
