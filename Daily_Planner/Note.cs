using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Planner
{ 
    class Note
    {
        public string Name { get ; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public static List<Note> Notes = new List<Note>();
        public static List<Note> todaynote = new List<Note>();
    }
}
