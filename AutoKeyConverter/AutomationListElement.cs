using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class AutomationListElement
    {
        private int id;
        private int targetID;
        private string trackName;
        private List<AutomationValue> nodes;

        public AutomationListElement(int id, int targetID, String trackName, List<AutomationValue> nodes) 
        { 
            this.id = id;
            this.targetID = targetID;
            this.trackName = trackName;
            this.nodes = nodes;
        }

        public int Id { get => id; set => id = value; }
        public int TargetID { get => targetID; set => targetID = value; }
        public string TrackName { get => trackName; set => trackName = value; }
        public List<AutomationValue> Nodes { get => nodes; set => nodes = value; }
    }
}
