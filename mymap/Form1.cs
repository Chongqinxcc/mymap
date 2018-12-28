using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMap2.CustomMarkers;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace MyMap2
{
    public partial class Form1 : Form
    {
        // layers
       // readonly GMapOverlay top = new GMapOverlay();
        //标记层markers
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
       // internal readonly GMapOverlay polygons = new GMapOverlay("polygons");

        // marker
        //GMapMarker currentMarker;

        // polygons
        //GMapPolygon polygon;

        public Form1()
        {
            InitializeComponent();

            // Initialize map: 
            gMap.MapProvider = BingMapProvider.Instance;
            //gMap.MapProvider = GMapProviders.OpenStreetMap;

            GMaps.Instance.Mode = AccessMode.ServerOnly;//CacheOnly;
            //gMap.Position = new PointLatLng(30.981178, 108.273625);
            //用地名来进行初始化
           // gMap.SetPositionByKeywords("YUNNAN, CHINA");
            
            gMap.Position = new PointLatLng(24.93576, 102.78609);

            //加载离线地图时使用该段代码，注意地图提供者要和下载的离线地图对应。离线地图放在程序的目录中。
            //string fileName = "Data.gmdb";
            //bool ok = GMaps.Instance.ImportFromGMDB(fileName);
            //MessageBox.Show("Complete!", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


            gMap.DragButton = MouseButtons.Left;
            gMap.MinZoom = 0;
            gMap.MaxZoom = 12;
            gMap.Zoom = 5;

            //地图事件
            gMap.MouseMove += new MouseEventHandler(gMap_MouseMove);

            //把markers层和地图关联起来
            gMap.Overlays.Add(objects);
            
            
            
        }
        //鼠标移动时显示经纬度
        void gMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng latLng = gMap.FromLocalToLatLng(e.X, e.Y);
            //this.label3.Text = this.label4.Text = "";
            
            this.label3.Text = "经度：" + latLng.Lng.ToString("F2");
            this.label4.Text = "纬度：" + latLng.Lat.ToString("F2");

        }
        //添加标记

        private void button1_Click(object sender, EventArgs e)
        {
            double lat = double.Parse(textLat.Text);
            double lng = double.Parse(textLng.Text);
            //currentMarker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.arrow);
            

            //GMarkerGoogle m = new GMarkerGoogle(currentMarker.Position, GMarkerGoogleType.green_pushpin);
            GMarkerGoogle m = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green_pushpin);
            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            m.ToolTipText = "经度:"+ textLng.Text + "； 纬度："+ textLat.Text;// gMap.Position.ToString();
            
            objects.Markers.Add(m);
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            objects.Markers.Clear();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}
