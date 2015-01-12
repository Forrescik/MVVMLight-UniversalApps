using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Database
{
    public class Person
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(200)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string LastName { get; set; }

    }
}
