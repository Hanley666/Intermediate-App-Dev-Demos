using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_List()
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Albums.OrderBy(x => x.Title).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Albums_Get(int albumid)
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void Albums_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                //staged to be physical placed on the database
                context.Albums.Add(item);
                //physically cause the staged item to be
                //    placed on the database
                //this is the commit of the using transaction
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Albums_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;

                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(Album item)
        {
            Albums_Delete(item.AlbumId);
        }

        public void Albums_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {
                    throw new Exception("Album does not exists on file.");
                }
                context.Albums.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}

