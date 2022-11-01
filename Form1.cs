using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SensorSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillSensorTypeComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
        }
        private void FillSensorTypeComboBox()
        {
            SensorType sensorType = new SensorType();
            List<SensorType> sensorTypeList = new List<SensorType>();
            sensorTypeList = sensorType.GetSensorTypes();
            foreach (SensorType sensorTypeItem in sensorTypeList)
            {
                comboSensorType.Items.Add(sensorTypeItem.SensorTypeName);
            }

        }
        private void saveData()
        {
            string sensorName = txtSensorName.Text;
            string sensorType = comboSensorType.SelectedItem.ToString();
            Sensor sensor = new Sensor();
            sensor.SaveSensorData(sensorName, sensorType);
        }
    }
}