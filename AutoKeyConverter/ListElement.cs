using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class ListElement
    {
        private String trackName;
        private String deviceName;
        private String parameterName;
        private float min;
        private float max;
        private List<AutomationValue> values;
        private int id;

        public ListElement(String trackName, String deviceName, String parameterName, float min, float max, List<AutomationValue> values, int id)
        {
            this.TrackName = trackName;
            this.DeviceName = deviceName;
            this.ParameterName = parameterName;
            this.min = min;
            this.Max = max;
            this.Values = values;
            this.Id = id;
        }

        public string TrackName { get => trackName; set => trackName = value; }
        public string DeviceName { get => deviceName; set => deviceName = value; }
        public string ParameterName { get => parameterName; set => parameterName = value; }
        public float Max { get => max; set => max = value; }
        public float Min { get => min; set => min = value; }
        internal List<AutomationValue> Values { get => values; set => values = value; }
        public int Id { get => id; set => id = value; }

        public String ToString()
        { 
            return Id + ": " +TrackName + " - " + DeviceName + " - " + ParameterName;
        }

        public List<AfterEffectValue> convert(float fps, float bpm, float min, float max, bool normalize)
        {
            float bps = bpm / 60;
            float beatlength = 1 / bps;
            float minAutomation = Values[0].Value;
            float maxAutomation = Values[0].Value;
            List <AfterEffectValue> result = new List<AfterEffectValue>();
            foreach (AutomationValue value in Values)
            {
                if (value.Value > maxAutomation)
                    maxAutomation = value.Value;
                if (value.Value < minAutomation)
                    minAutomation = value.Value;
            }
            for (int i = 0; i < Values.Count(); i++)
            {
                int j = i + 1;
                int similar = 0;
                bool nextSame = false;
                AutomationValue value = Values[i];
                float timeInSeconds = value.Time * beatlength;
                int frames = (int)Math.Round(timeInSeconds * fps);
                float valueScaled = value.Value;
                if (normalize)
                {
                    valueScaled = (maxAutomation) * (value.Value - minAutomation) / (maxAutomation - minAutomation);
                    minAutomation = 0;
                }
                valueScaled = (max + min) - ( (max - min) * (valueScaled - minAutomation) / (maxAutomation - minAutomation) + min );
                do
                {
                    if (Values.Count() > j && Values[j++].Time == value.Time)
                    {
                        similar++;
                        nextSame = true;
                    }
                    else
                        nextSame = false;
                } while (nextSame);
                //issues with more than 2 nodes in a frame.
                if (similar == 0)
                    result.Add(new AfterEffectValue(frames, valueScaled));
                if (similar == 1 || (similar > 1 && Values[i - 1].Time != value.Time))
                    result.Add(new AfterEffectValue(frames - 1, valueScaled));
            }
            return result;
        }
    }
}
