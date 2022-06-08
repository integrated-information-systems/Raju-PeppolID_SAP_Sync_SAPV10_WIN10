using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PeppolID_Sync.Business
{
    public static class Common
    {
        private static LogLevel LogLvl{get; set; }
        private static string LogPath { get; set; }
      
        public static string CompanyDBName { get; set; }

        private enum LogLevel
        {
            Error = 0,
            Info = 1,
            Warning = 2,
            Debug =3,
            Diagnostic = 4

        };

        public static void SetLogFile(LogicFileParams ObjLogFile)
        {

            string logLevel = "DEBUG";
            switch (logLevel.ToUpperInvariant())
            {
                case "INFO":LogLvl = LogLevel.Info;break;
                case "WARNING": LogLvl = LogLevel.Warning; break;
                case "DEBUG": LogLvl = LogLevel.Debug; break;
                case "DIAGNOSTIC": LogLvl = LogLevel.Diagnostic; break;
                case "DIAG": LogLvl = LogLevel.Diagnostic; break;
                default: LogLvl = LogLevel.Diagnostic; break;

            }

            LogPath = ObjLogFile.vPath;

        }
          
        private static void Log(string str, LogLevel level = LogLevel.Debug)
        {
            if (level <= LogLvl)
                WriteLogString(level.ToString().ToUpperInvariant(), str);

        }

        private static void WriteLogString(string level,string str)
        {
            try
            {
                using (var file = new StreamWriter(LogPath, true))
                {
                    file.WriteLine("{0:MM/dd/yyyy HH:mm:ss} : {1} - {2}", DateTime.Now, level, str);
                }

            }
            catch(Exception)
            {

            }

        }

        public static void SetDefaultLogFile()
        {
            LogLvl = LogLevel.Debug;

            var logDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PeppolID Sync");

            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);

            string logFile = System.IO.Path.Combine(logDirectory, DateTime.Today.ToString("MM.dd.yy") + ".txt");

            LogPath = logFile;

        }


        public static void ReadConfigParams()
        {
            try
            {
                ConfigParams.vCompany_Server = ConfigurationManager.AppSettings["Company_Server"].ToString();
                ConfigParams.vCompany_Username = ConfigurationManager.AppSettings["Company_Username"].ToString();
                ConfigParams.vCompany_Password = ConfigurationManager.AppSettings["Company_Password"].ToString();
                ConfigParams.vSAPDB_Server = ConfigurationManager.AppSettings["SAPDB_Server"].ToString();
                ConfigParams.vSAPDB_DataBaseName = ConfigurationManager.AppSettings["SAPDB_DataBaseName"].ToString();
                ConfigParams.vSAPDB_Username = ConfigurationManager.AppSettings["SAPDB_Username"].ToString();
                ConfigParams.vSAPDB_Password = ConfigurationManager.AppSettings["SAPDB_Password"].ToString();
                ConfigParams.vPeppolDirectorySGAPI = ConfigurationManager.AppSettings["PeppolDirectorySG_API"].ToString();
                ConfigParams.vGrid_PageSize = ConfigurationManager.AppSettings["Grid_PageSize"].ToString();
                ConfigParams.vMSSQLVersion = ConfigurationManager.AppSettings["MSSQLVersion"].ToString();

                ConfigParams.vSAP_DB_ConnectionString = ConfigurationManager.ConnectionStrings["SAP_DB_ConnectionString"].ToString();
                

            }
            catch (Exception ex)
            {
                throw new Exception("ReadConfigParams :: "+ex.Message.ToString());
            }
                       
           
        }
                
    }

    public class LogicFileParams
    {
        public string vPath { get; set; }

    }

    public static class ConfigParams
    {
        public static string vCompany_Server { get; set; }
        public static string vCompany_Username { get; set; }
        public static string vCompany_Password { get; set; }

        public static string vSAPDB_Server { get; set; }
        public static string vSAPDB_DataBaseName { get; set; }
        public static string vSAPDB_Username { get; set; }
        public static string vSAPDB_Password { get; set; }
        public static string vPeppolDirectorySGAPI { get; set; }
        public static string vSAP_DB_ConnectionString { get; set; }

        public static string vGrid_PageSize { get; set; }

        public static string vMSSQLVersion { get; set; }

        

    }




}
