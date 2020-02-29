using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;


namespace BeyondAEC
{

    public class Room
    {
        private string m_name = "";
        private string m_tags ="";
        private Point3d m_center = new Point3d();
        private double m_size_width = 0;
        private double m_size_height = 0;
        private Color m_display_color = Color.White;

       
        public string Name { get { return m_name; } }
        public string Tags { get { return m_tags; } }
        public Point3d Center { get { return m_center; } }
        public double Width { get { return m_size_width; } }
        public double Height { get { return m_size_height; } }
        public Color Color { get { return m_display_color; } }
        public Rectangle3d Rect { get
            {

                Point3d lowerLeftCorner = new Point3d((m_center.X - (m_size_width * 0.5)), (m_center.Y - (m_size_height * 0.5)), (m_center.Z));
                Plane basePlane = new Plane(lowerLeftCorner, Vector3d.ZAxis);
                Rectangle3d myRect = new Rectangle3d(basePlane, m_size_width, m_size_height);
                return myRect;
            } 
        }


        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        


        
        public Room()
        {
            //Set any values to defaults.. 
        }

        public Room(string name, string tags, Point3d center, double size_width, double size_height, Color display_color)
        {
            m_name = name;
            m_tags = tags;
            m_center = center;
            m_size_width = size_width;
            m_size_height = size_height;
            m_display_color = display_color;

        }

        public Room Duplicate()
        {
            Room dup = new Room(this.m_name, this.m_tags, this.m_center, this.m_size_width, this.m_size_height, this.m_display_color);
            return dup;
        }

        public override string ToString()
        {
            return string.Format("A MintyPlans room named '{0}'.", this.m_name);
        }


    }

    public class RoomGoo : GH_Goo<Room>
    {
        #region Constructors
        public RoomGoo()
        {
            this.Value = new Room();
        }

        public RoomGoo(Room room)
        {
            if (room == null)
            {
                this.Value = new Room();
            }
            this.Value = room;
        }

        public override IGH_Goo Duplicate()
        {
            return new RoomGoo(Value == null ? new Room() : Value.Duplicate());
        }

        public override bool IsValid
        {
            get
            {
                if (Value == null) { return false; }
                return Value.IsValid;
            }
        }

        public override string IsValidWhyNot
        {
            get
            {
                if (Value == null) { return "No internal Room instance"; }
                if (Value.IsValid) { return string.Empty; }
                return "Invalid room instance"; //Todo: beef this up to be more informative.
            }
        }

        public override string ToString()
        {
            if (Value == null)
                return "Null room";
            else
                return Value.ToString();
        }

        public override string TypeName
        {
            get { return ("FreshPlan Room"); }
        }

        public override string TypeDescription
        {
            get { return ("Defines a single FreshPlan Room"); }
        }
        #endregion

        public override bool CastTo<Q>(ref Q target)
        {

            if (typeof(Q).IsAssignableFrom(typeof(Room)))
            {
                if (Value == null)
                    target = default(Q);
                else
                    target = (Q)(object)Value;
                return true;
            }
            target = default(Q);
            return false;
        }

        public override bool CastFrom(object source)
        {
            if (source == null) { return false; }

            //Cast from BoatShell
            if (typeof(Room).IsAssignableFrom(source.GetType()))
            {
                Value = (Room)source;
                return true;
            }

            return false;
        }

    }

    public class RoomParameter : GH_Param<RoomGoo>
    {
        public RoomParameter()
          : base(new GH_InstanceDescription("Room", "Room", "Maintains a collection of rooms for MintyPlans.", "BeyondAEC", "MintyFresh"))
        {
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null; //Todo, provide an icon.
            }
        }

        public override GH_Exposure Exposure
        {
            get
            {
                // If you want to provide this parameter on the toolbars, use something other than hidden.
                return GH_Exposure.hidden;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("bbc4f343-7382-4c4a-b134-d5c2a00c7069"); }
        }
    }

}
