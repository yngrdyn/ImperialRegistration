using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using NLog;

namespace Data
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RebelRegisterData : IRebelRegisterData
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public RebelRegisterData()
        {

        }

        public bool registerRebel(string username, string planet)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["rebelLogPath"].ToString();
                string lines = "rebel " + username + " on " + planet + " at " + DateTime.Now;

                // Write the string to a file.
                StreamWriter file = new StreamWriter(path,true);
                file.WriteLine(lines);
                file.Close();

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error Registering rebel into file");
                Console.WriteLine("An error occurred: '{0}'", e);
                throw new Exception("Error Registering rebel into file: " + e);
            }
        }
    }
}
