using System.IO.Compression;
using System.Diagnostics;
using System.Xml.Linq;
using System.Globalization;
using System.Xml.XPath;

namespace AutoKeyConverter
{
    public partial class Form1 : Form
    {
        private string fileContent;

        private Stream fileStream;

        private bool processed = false;

        private List<ListElement> listElements;
        public Form1()
        {
            InitializeComponent();
            fileContent = string.Empty;
            fileStream = Stream.Null;
        }

        private void btn_file_open_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "als files (*.als)|*.als|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_file_select.Text = openFileDialog.FileName;
                }
            }
        }

        private void btn_file_process_Click(object sender, EventArgs e)
        {
            String filepath = String.Empty;
            
            if (txt_file_select.Text.Length > 0)
                filepath = txt_file_select.Text;
            else
                lbl_file.ForeColor = Color.Red;
            if (filepath != String.Empty)
            {
                lst_deselected.Items.Clear();
                lst_selected.Items.Clear();
                rtb_output.Visible = false;
                lst_deselected.Visible = true;
                lst_selected.Visible = true;
                listElements = processALS(filepath);
                foreach (ListElement element in listElements)
                {
                    lst_deselected.Items.Add(element.ToString());
                }
                btn_file_process.ForeColor = SystemColors.ControlText;
                lbl_file.ForeColor = SystemColors.ControlText;
                btn_convert.Enabled = true;
                processed = true;
            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            if (processed)
            {
                float fps = 0;
                float bpm = 0;
                float min = 0;
                float max = 0;
                bool normalize;
                bool empty = false;
                if ((txt_fps.Text.Length > 0 && txt_fps.Text.Length < 5) && !empty)
                    fps = float.Parse(txt_fps.Text, CultureInfo.InvariantCulture.NumberFormat);
                else
                {
                    lbl_fps.ForeColor = Color.Red;
                    empty = true;
                }
                if ((txt_fps.Text.Length > 0 && txt_fps.Text.Length < 5) && !empty)
                    bpm = float.Parse(txt_bpm.Text, CultureInfo.InvariantCulture.NumberFormat);
                else
                {
                    lbl_bpm.ForeColor = Color.Red;
                    empty = true;
                }
                if ((txt_min.Text.Length > 0 && txt_min.Text.Length < 5) && !empty)
                    min = float.Parse(txt_min.Text, CultureInfo.InvariantCulture.NumberFormat);
                else
                {
                    lbl_min.ForeColor = Color.Red;
                    empty = true;
                }
                if ((txt_max.Text.Length > 0 && txt_max.Text.Length < 5) && !empty)
                    min = float.Parse(txt_max.Text, CultureInfo.InvariantCulture.NumberFormat);
                else
                {
                    lbl_max.ForeColor = Color.Red;
                    empty = true;
                }
                normalize = chb_normalize.Checked;
                if (!empty)
                {
                    rtb_output.Text = convertTimings(fps, bpm, min, max, normalize, reduceUnselectedElements(listElements, lst_selected.Items));
                    rtb_output.Visible = true;
                    lst_deselected.Visible = false;
                    lst_selected.Visible = false;
                    lbl_fps.ForeColor = SystemColors.ControlText;
                    lbl_bpm.ForeColor = SystemColors.ControlText;
                    lbl_min.ForeColor = SystemColors.ControlText;
                    lbl_max.ForeColor = SystemColors.ControlText;
                }
            }
            else {
                btn_file_process.ForeColor = Color.Red;
            }
        }

        private void btn_lane_select_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_deselected.SelectedItems)
            {
                lst_selected.Items.Add(item.Text);
                lst_deselected.Items.Remove(item);
            }
        }

        private void btn_lane_deselect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_selected.SelectedItems)
            {
                lst_deselected.Items.Add(item.Text);
                lst_selected.Items.Remove(item);
            }
        }

        private void btn_select_all_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_deselected.Items)
            {
                lst_selected.Items.Add(item.Clone() as ListViewItem);
            }
            lst_deselected.Items.Clear();
        }

        private void btn_deselect_all_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_selected.Items)
            {
                lst_deselected.Items.Add(item.Clone() as ListViewItem);
            }
            lst_selected.Items.Clear();
        }

        private void txt_fps_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleNumberInput(sender, e);
        }

        private void txt_bpm_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleNumberInput(sender, e);
        }

        private void txt_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleNumberInput(sender, e);
        }

        private void txt_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleNumberInput(sender,e);
        }

        private void handleNumberInput(object sender, KeyPressEventArgs e) 
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private List<ListElement> processALS(String filepath) 
        {
            using (FileStream reader = File.OpenRead(filepath))
            using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
            using (StreamReader unzip = new StreamReader(zip))
            {
                String fileContent = unzip.ReadToEnd();
                XDocument document = processXMLFile(fileContent);
                return obtainList(document); 
            }
        }

        private XDocument processXMLFile(String xmlString)
        { 
            XDocument document = XDocument.Parse(xmlString);
            return document;
        }

        private List<ListElement> obtainList(XDocument document) 
        {
            List<ListElement> listElements = new List<ListElement>();
            var tracks = document.Elements("Ableton").Elements("LiveSet").Elements("Tracks").Elements("AudioTrack").Union(document.Elements("Ableton").Elements("LiveSet").Elements("Tracks").Elements("GroupTrack"));
            List<AutomationListElement> automations = new List<AutomationListElement>();
            List<DeviceListElement> devices = new List<DeviceListElement>();
            int id = 0;
            foreach (var track in tracks) 
            {
                String trackname = track.Elements("Name").Elements("EffectiveName").FirstOrDefault().Attribute("Value").Value.ToString();
                automations.AddRange(obtainAutomations(track, trackname));
                devices.AddRange(obtainDevices(track, trackname));
            }
            foreach (DeviceListElement device in devices)
            {
                foreach (ParameterListElement parameter in device.Parameters)
                {
                    foreach (AutomationListElement automation in automations)
                    {
                        if (parameter.AutomationID == automation.TargetID)
                        {
                            ListElement listElement = new ListElement(device.TrackName, device.Name, parameter.Name, parameter.Min, parameter.Max, automation.Nodes, id++);
                            listElements.Add(listElement);
                        }
                    }
                }   
            }
            return listElements;
        }

        private List<DeviceListElement> obtainDevices(XElement track, String trackname) 
        {
            List<DeviceListElement> devices = new List<DeviceListElement>();
            IEnumerable<XElement> deviceInstances = track.Elements("DeviceChain").Elements("DeviceChain").Elements("Devices").Elements().Union(track.Elements("DeviceChain").Elements("DeviceChain").Elements("PluginDevices").Elements()); 
            foreach (XElement deviceInstance in deviceInstances)
            {
                String deviceName = deviceInstance.Name.ToString();
                int deviceID = int.Parse(deviceInstance.Attribute("Id").Value.ToString());
                List<ParameterListElement> parameters = new List<ParameterListElement>();
                foreach (XElement property in deviceInstance.Elements())
                {
                    List<ParameterListElement> parameter = obtainParameters(property, trackname, deviceInstance);
                    if (parameter.Count != 0)
                        parameters.AddRange(parameter);
                }
                devices.Add(new DeviceListElement(deviceName, deviceID, trackname, parameters));
            }
            return devices;
        }

        private List<ParameterListElement> obtainParameters(XElement property, String trackname, XElement deviceInstance) 
        {
            List<ParameterListElement> parameter = new List<ParameterListElement>();
            if (property.Elements("AutomationTarget").FirstOrDefault() != null)
            {
                String parameterName = property.Name.ToString();
                int parameterID = int.Parse(property.Elements("AutomationTarget").Attributes("Id").FirstOrDefault().Value.ToString());
                float minValue = 0;
                float maxValue = 1;
                if (property.Elements("MidiControllerRange").FirstOrDefault() != null)
                {
                    minValue = float.Parse(property.Elements("MidiControllerRange").Elements("Min").FirstOrDefault().Attribute("Value").Value.ToString());
                    maxValue = float.Parse(property.Elements("MidiControllerRange").Elements("Max").FirstOrDefault().Attribute("Value").Value.ToString());
                }
                parameter.Add(new ParameterListElement(parameterName, parameterID, minValue, maxValue));
            }
            else
            { 
                foreach(XElement propertyChild in property.Elements())
                    parameter.AddRange(obtainParameters(propertyChild, trackname, deviceInstance));
            }
            return parameter;
        }

        private List<AutomationListElement> obtainAutomations(XElement track, String trackname)
        {
            List<AutomationListElement> automations = new List<AutomationListElement>();
            var automationEnvelopes = track.Elements("AutomationEnvelopes").Elements("Envelopes").Elements("AutomationEnvelope");
            foreach (XElement automationElement in automationEnvelopes)
            {
                int automationID = int.Parse(automationElement.Attribute("Id").Value.ToString());
                int targetID = int.Parse(automationElement.Elements("EnvelopeTarget").Elements("PointeeId").FirstOrDefault().Attribute("Value").Value.ToString());
                var events = automationElement.Elements("Automation").Elements("Events").Elements("FloatEvent").Union(automationElement.Elements("Automation").Elements("Events").Elements("EnumEvent").Union(automationElement.Elements("Automation").Elements("Events").Elements("BoolEvent")));
                List<AutomationValue> nodes = new List<AutomationValue>();
                foreach (XElement eventElement in events)
                {
                    float automationTime = float.Parse(eventElement.Attribute("Time").Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    String valueString = eventElement.Attribute("Value").Value.ToString();
                    float automationValue;
                    if (valueString.Equals("true"))
                        automationValue = 1;
                    else if (valueString.Equals("false"))
                        automationValue = 0;
                    else
                        automationValue = float.Parse(valueString, CultureInfo.InvariantCulture.NumberFormat);
                    nodes.Add(new AutomationValue(automationTime, automationValue));
                }
                nodes.RemoveAt(0);
                automations.Add(new AutomationListElement(automationID, targetID, trackname, nodes));
            }
            return automations;
        }

        private List<ListElement> reduceUnselectedElements(List<ListElement> elements, ListView.ListViewItemCollection selectedItems)
        {
            List<ListElement> result = new List<ListElement>();
            foreach (ListViewItem selectedItem in selectedItems)
            {
                int id = int.Parse(new String(selectedItem.Text.TakeWhile(Char.IsDigit).ToArray()));
                foreach (ListElement element in elements)
                {
                    if (int.Parse(new String(element.ToString().TakeWhile(Char.IsDigit).ToArray())) == id)
                    {
                        result.Add(element);
                    }
                }
            }
            return result;
        }

        private String convertTimings(float fps, float bpm, float min, float max, bool normalize, List<ListElement> elements) 
        {
            int i = 1;
            String result = getHeader(fps);
            String slider;
            foreach (ListElement element in elements)
            {
                slider = "Effects\tSlider Control #" + i++ + "\tSlider #2\n\tFrame";
                foreach (AfterEffectValue value in element.convert(fps, bpm, min, max, normalize))
                {
                    slider+="\n\t" + value.Frame + "\t" + value.Value;
                }
                result += slider +"\n\n";
            }
            result = result + "\nEnd of Keyframe Data";
            return result;
        }

        private String getHeader(float fps)
        {
            return "Adobe After Effects 8.0 Keyframe Data\n\n\tUnits Per Second\t" + fps + "\n\tSource Width\t100\n\tSource Height\t100\n\tSource Pixel Aspect Ratio\t1\n\tComp Pixel Aspect Ratio\t1\n\n";
        }

        private void lst_deselecxted_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_lane_select.Enabled = true;
        }

        private void lst_selected_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_lane_deselect.Enabled = true;
        }

        private void lst_deselected_MouseHover(object sender, EventArgs e)
        {
            //Point localPoint = lst_deselected.PointToClient(Cursor.Position);
            //Debug.WriteLine("showing: " + lst_deselected.GetItemAt(localPoint.X, localPoint.Y).Text);
            //ttp_deselected.Show(lst_deselected.GetItemAt(localPoint.X, localPoint.Y).Text, this);
        }

        private void txt_file_select_TextChanged(object sender, EventArgs e)
        {
            processed = false;
            btn_convert.Enabled = false;
        }
    }
}
