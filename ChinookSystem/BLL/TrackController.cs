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
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_List()
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.OrderBy(x => x.Name).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Tracks_Get(int trackid)
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Find(trackid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_GetByAlbumID(int albumid)
        {
            //create an transaction instance of your Context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Where(x => x.AlbumId == albumid).Select(x => x).ToList();
            }
        }
    }
}
