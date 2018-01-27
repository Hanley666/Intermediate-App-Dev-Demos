using Chinook.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ODSQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //first, we wish to access the specific row
            //that was selected by pressing the View link
            //which is the select command button of the
            //gridview.
            //remember, the View Link is a Command Button
            GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex];

            //access the data from the GridView Template control
            //use the .FindControl("IdControlName") to
            //access the desired control
            string albumid = (agvrow.FindControl("AlbumId") as Label).Text;
            //send the extracted value to another specified page
            //pagename?parameterset&parameterset&....
            // ? parameter set following
            // Parameter set  idlabel=value
            // & separates multiple parameter sets
            Response.Redirect("AlbumDetails.aspx?aid=" + albumid);
        }

        protected void CountAlbums_Click(object sender, EventArgs e)
        {
            //traversing a GridView display (counting artists in List<T> within GridView)
            //the only records available to us at this time out of the data set assigned to the GridView are the rows being displayed (only counts page being shown)

            //create a List<T> to hold the counts of the display
            List<ArtistAlbumCounts> Artists = new List<ArtistAlbumCounts>();

            //reusable pointer to an instance of the specified class
            ArtistAlbumCounts item = null;
            int artistId = 0;
            //setup the loop to traverse the GridVIew
            foreach(GridViewRow line in AlbumList.Rows)
            {
                //access the artist id
                artistId = int.Parse((line.FindControl("ArtistList") as DropDownList).SelectedValue);

                //determine if you have already created a count instance in the List<T> for this artist
                //if NOT, create a new instance for the artist and set it's count to 1
                //if Yes Increment the counter +1

                //search for artist in List<T> what will be return will either be null (Not found) or the insance in the List<T>
                item = Artists.Find(x => x.ArtistId == artistId);

                if(item == null)
                {
                    //Create Instance, Innitialize, add to list
                    item = new ArtistAlbumCounts();
                    item.ArtistId = artistId;
                    item.AlbumCount = 1;
                    Artists.Add(item);

                }
                else
                {
                    item.AlbumCount++;
                }

                //Attach List<T> to the display control
                ArtistAlbumCountList.DataSource = Artists;
                ArtistAlbumCountList.DataBind(); 
            }
        }
    }
}