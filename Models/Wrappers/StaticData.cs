using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNDP_Project1.Models.Wrappers
{
    public static class StaticData
    {
        private static List<ComboList> _genders = null;
        public static List<ComboList> Genders
        {
            get
            {
                if (_genders == null)
                {
                    _genders = new List<ComboList>
                    {
                        new ComboList
                        {
                            ID = 0,
                            Name = "Female"
                        },
                        new ComboList
                        {
                            ID = 2,
                            Name = "Male"
                        }
                        ,
                        new ComboList
                        {
                            ID = 3,
                            Name = "Other"
                        }
                    };
                }
                return _genders;
            }
        }
    }
}