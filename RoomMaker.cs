using System;
using System.Drawing;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace BeyondAEC
{
    public class RoomMaker : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public RoomMaker()
          : base("RoomMaker", "RM",
              "Make room objects using input data",
              "BeyondAEC", "MintyFresh")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Room name", GH_ParamAccess.item);
            pManager.AddTextParameter("Tags", "Ts", "Tags (comma separated)", GH_ParamAccess.item);
            pManager.AddPointParameter("CenterPoint", "Pt", "Center point of room", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "H", "1st dimension of room", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "W", "2nd dimension of room", GH_ParamAccess.item);
            pManager.AddColourParameter("Color", "C", "Room display color", GH_ParamAccess.item);

        }



        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new RoomParameter(), "Room", "Rm", "Rooms to read data from", GH_ParamAccess.item);
        }



        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            string tags = "";
            double height = 0;
            double width = 0;
            Point3d center = new Point3d();
            Color displayColor = Color.White;

            if (!DA.GetData(0, ref name)) return;
            if (!DA.GetData(1, ref tags)) return;
            if (!DA.GetData(2, ref center)) return;
            if (!DA.GetData(3, ref height)) return;
            if (!DA.GetData(4, ref width)) return;
            if (!DA.GetData(5, ref displayColor)) return;

            Room myRoom = new Room(name, tags, center, width, height, displayColor);

            DA.SetData(0, myRoom);
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
            get { return new Guid("c5e4f348-a5e2-4d39-b870-de14b7aeefe7"); }
        }
    }
}
