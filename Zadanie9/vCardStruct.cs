using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public class vCardStruct
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String TelNumber { get; set; }
        public String Email { get; set; }
        public String PhotoData { get; set; }

        public vCardStruct(vCardStruct reference)
        {
            Name = reference.Name;
            Address = reference.Address;
            TelNumber = reference.TelNumber;
            Email = reference.Email;
            PhotoData = reference.PhotoData;
        }

        public vCardStruct()
        {
            Name = "";
            Address = "";
            TelNumber = "";
            Email = "";
            PhotoData = "";
        }
    }

}
