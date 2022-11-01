using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SensorSystem
{
    class Sensor
    {
        public void SaveSensorData(string sensorName, string sensorType)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SaveSensor", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SensorName", sensorName));
                    cmd.Parameters.Add(new SqlParameter("@SensorType", sensorType));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("SUCCESSFULL!");
            }
            catch
            {
                MessageBox.Show("Error writing to the database");
            }
        }
    }
}
