using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logger.Config
{
    using System;
    using System.Reflection;

    public static class MyLogger
    {
       
        static MyLogger()
        {
            Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        private static log4net.ILog Log { get; set; }

        public static void Error(object msg)
        {
            try
            {
                Log.Error(msg);
            }
            catch(Exception e ){ }


        }

        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }

    }
}
