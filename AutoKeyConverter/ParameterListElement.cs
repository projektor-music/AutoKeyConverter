using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class ParameterListElement
    {
        private String name;
        private int automationID;
        private float min;
        private float max;

        public ParameterListElement(string name, int automationID, float min, float max)
        {
            Name = name;
            AutomationID = automationID;
            Min = min;
            Max = max;
        }

        public string Name { get => name; set => name = value; }
        public int AutomationID { get => automationID; set => automationID = value; }
        public float Min { get => min; set => min = value; }
        public float Max { get => max; set => max = value; }
    }
}
