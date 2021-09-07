using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Samples_MapWithDrawing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.MapClicked += new GoogleMapForASPNet.MapClickedHandler(OnMapClicked);
        GoogleMapForASPNet1.PushpinClicked += new GoogleMapForASPNet.PushpinClickedHandler(OnPushpinClicked);
        GoogleMapForASPNet1.PushpinDrag += new GoogleMapForASPNet.PushpinDragHandler(OnPushpinDrag);
        //Add event handler for PushpinMoved event
        if (!IsPostBack)
        {


            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet1.GoogleMapObject.Width = "600px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet1.GoogleMapObject.Height = "400px";

            //Specify initial Zoom level.
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.66619, -79.44268);

        }
    }

     //Add event handler for Map Click event
    void OnMapClicked(double dLat, double dLng)
    {
        //Print clicked map positions
        lblPushpin1.Text = "(" + dLat.ToString() + "," + dLng.ToString() + ")";

        //Generate new id for object
        string sID = (GoogleMapForASPNet1.GoogleMapObject.Points.Count+1).ToString();
        GooglePoint GP1 = new GooglePoint(sID, dLat, dLng);
        GP1.Draggable = true;
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);
    }

    //Add event handler for PushpinMoved event
    void OnPushpinClicked(string pID)
    {
        //pID is ID of pushpin which was moved.
       // lblLastPushpin.Text = pID;
        //Print all pushpin positions
        lblPushpin1.Text = "(" + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Latitude.ToString() + "," + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Longitude.ToString() + ")";
    }
    //Add event handler for PushpinDrag event
    void OnPushpinDrag(string pID)
    {
        //pID is ID of pushpin which was moved.
        //lblLastPushpin.Text = pID;
        //Print all pushpin positions
        lblPushpin1.Text = "(" + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Latitude.ToString() + "," + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Longitude.ToString() + ")";
    }
}
