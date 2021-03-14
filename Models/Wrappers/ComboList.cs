using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNDP_Project1.Models.Wrappers
{
    public class ComboList
    {

        public ComboList()
        {
            ID = 0;
            Name = string.Empty;
        }

        public ComboList(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}