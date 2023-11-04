using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1_4.Models {
    public class People {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get; set;
        }

        [MaxLength(100)]
        public string names
        {
            get; set;
        }

        [MaxLength(200)]
        public string description
        {
            get; set;
        }

        public byte[] photo
        {
            get; set;
        }
    }
}
