using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class AfterEffectValue
    {
        int frame; 
        float value;

        public AfterEffectValue(int frame, float value)
        {
            this.frame = frame;
            this.value = value;
        }

        public int Frame { get => frame; set => frame = value; }
        public float Value { get => value; set => this.value = value; }
    }
}
