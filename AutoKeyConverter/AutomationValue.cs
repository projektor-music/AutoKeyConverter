using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class AutomationValue
    {
        float time;
        float value;

        public AutomationValue(float time, float value) 
        { 
            this.time = time;
            this.value = value;
        }

        public float Time { get => time; set => time = value; }
        public float Value { get => value; set => this.value = value; }
    }
}
