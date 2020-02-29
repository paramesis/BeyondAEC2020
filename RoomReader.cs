using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;



namespace BeyondAEC
{
    public class RoomReader : GH_Component
    {

        public RoomReader()
          : base("RoomReader", "RR",
              "Get data out of a room object",
              "BeyondAEC", "MintyFresh")
        {
        }



        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new RoomParameter(), "Room", "Rm", "Rooms to read data from", GH_ParamAccess.item);
        }



        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Room name", GH_ParamAccess.item);
            pManager.AddTextParameter("Tags", "Ts", "Tags, comma separated", GH_ParamAccess.item);
            pManager.AddPointParameter("CenterPoint", "Pt", "Center point of room", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "H", "1st dimension of room", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "W", "2nd dimension of room", GH_ParamAccess.item);
            pManager.AddRectangleParameter("Rect", "Rt"," Room rectangles", GH_ParamAccess.item);
            pManager.AddColourParameter("Color", "C", "Room display color", GH_ParamAccess.item);
        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Room myRoom = new Room();

            if (!DA.GetData(0, ref myRoom)) return;

            DA.SetData(0, myRoom.Name);
            DA.SetData(1, myRoom.Tags);
            DA.SetData(2, myRoom.Center);
            DA.SetData(3, myRoom.Height);
            DA.SetData(4, myRoom.Width);
            DA.SetData(5, myRoom.Rect);
            DA.SetData(6, myRoom.Color);
        }




        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }



        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }


        public override Guid ComponentGuid
        {
            get { return new Guid("323b2e2f-4bc7-493e-bfa3-27a5bf92885e"); }
        }
    }
}
