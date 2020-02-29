using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace BeyondAEC
{
    public class BeyondAECInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "RoomPlacer";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("f60ee0b7-67f3-4b9b-ae7b-72b0a791214e");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
