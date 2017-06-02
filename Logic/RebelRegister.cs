using Logic.ResponseTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using Data;
using NLog;

namespace Logic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RebelRegister : IRebelRegister
    {
        private IRebelRegisterData _rebelRegisterData;
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public RebelRegister(IRebelRegisterData rebelRegisterData)
        {
            _rebelRegisterData = rebelRegisterData;
        }
        public RegisterRebelResponse RegisterRebel(string username, string planet)
        {
            var response = new RegisterRebelResponse();

            try
            {
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(planet))
                {
                    throw new Exception("Username or Planet are empty or don't exists");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("RegisterRebel: '{0}'", ex.ToString());
                response.Status = false.ToString();
                response.Message = ex.Message;
            }

            if (response.Status != false.ToString())
            {
                bool registered = false;
                try
                {
                    registered = _rebelRegisterData.registerRebel(username, planet);
                    response.Status = registered.ToString();
                    return response;

                }
                catch (Exception e)
                {
                    _logger.Error("RegisterRebel: '{0}'", e.ToString());
                    Console.WriteLine("An error occurred: '{0}'", e);
                    throw new Exception("Error Registering rebel into file: " + e);
                }
            }
            return response;
        }
    }
}
