using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionFinalXF
{
    public class MovieModel
    {
        public String _id { get; set; }
        public String title { get; set; }
        public String image { get; set; }
        public String category { get; set; }
        public String description { get; set; }
        public MovieModel()
        {
          
        }
        public override string ToString()
       {
           return string.Format("[MovieModel: _id={0}, title={1}, image={2}, category={3}, description={4}]", _id, title, image, category, description);
           
       }
    }
}
