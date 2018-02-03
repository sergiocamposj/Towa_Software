using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionFinalXF
{
    public class UserModel
    {
        public String username { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String mail { get; set; }
        public _kmd _kmd { get; set; }

    }
    public class _kmd
    {
        public string authtoken { get; set; }
    }
}
