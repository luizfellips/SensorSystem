using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SensorSystem
{
    class SensorType
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        public string SensorTypeName { get; set; }
        public List<SensorType> GetSensorTypes()
        {
            List<SensorType> sensorTypeList = new List<SensorType>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery = "select SensorType from SENSOR_TYPE";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    SensorType sensorType = new SensorType();
                    sensorType.SensorTypeName = dr["SensorType"].ToString();
                    sensorTypeList.Add(sensorType);
                }
            }
            con.Close();
            return sensorTypeList;

        }
    }
}
