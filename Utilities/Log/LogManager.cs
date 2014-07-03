using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Log
{
    public class LogManager
    {
        private log4net.ILog logger;

        private static LogManager instance;

        public static LogManager GetInstance()
        {
            if (instance == null)
            {
                instance = new LogManager();
            }

            return instance;
        }

        public LogManager()
        {            
            XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger("siteLogger");
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
    }
}
