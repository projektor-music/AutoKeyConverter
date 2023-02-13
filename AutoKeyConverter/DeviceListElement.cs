using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    internal class DeviceListElement
    {
        private String name;
        private int id;
        private String trackName;
        private List<ParameterListElement> parameters;

        public DeviceListElement(String name, int id, String trackname, List<ParameterListElement> parameters) 
        { 
            this.name = name;
            this.id = id;
            this.trackName = trackname;
            this.parameters = parameters;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string TrackName { get => trackName; set => trackName = value; }
        public List<ParameterListElement> Parameters { get => parameters; set => parameters = value; }

        public void addParameter(ParameterListElement element)
        { 
            parameters.Add(element);
        }

        public void flushUnautomated(List<AutomationListElement> automations) 
        {
            List<int> automationIDs = new List<int>();
            List<int> parameterIDs = new List<int>();
            foreach (AutomationListElement automation in automations) 
            {
                automationIDs.Add(automation.Id);
            }
            foreach (ParameterListElement parameter in parameters)
            {
                parameterIDs.Add(parameter.AutomationID);
            }
            List<int> nonintersect = (List<int>)automationIDs.Except(parameterIDs).Union(parameterIDs.Except(automationIDs));
            foreach (ParameterListElement parameter in Parameters)
            {
                if(nonintersect.Contains(parameter.AutomationID))
                    Parameters.Remove(parameter);
            }
        }
    }
}
