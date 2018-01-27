using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using System.Data.Entity;
#endregion

namespace ChinookSystem.DAL
{
    internal class ChinookContext:DbContext
    {
        //name holds the name value of your web connection string
        public ChinookContext():base("name=ChinookDB")
        {

        }

        //a reference to each table in the database as a virtual data set
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    }
}
