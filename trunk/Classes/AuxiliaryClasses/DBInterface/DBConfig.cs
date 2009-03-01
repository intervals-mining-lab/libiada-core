using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NHibernate.Cfg;

namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    ///<summary>
    ///</summary>
    public class DBConfig
    {
        private Configuration config;
        private static DBConfig _instance = null;

        protected DBConfig()
        {
            config = new Configuration();
            IDictionary<string, string> props = new Dictionary<string, string>();
            // TODO: Create code to get config params from config file.
            String connectionString = "Server=localhost; Database=db_libiada; User ID=root";
            props.Add("dialect", "NHibernate.Dialect.MySQLDialect");
            props.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            props.Add("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
            props.Add("connection.connection_string", connectionString);
            config.AddProperties(props);
            config.AddAssembly("ChainAnalises");
            MappingInit();
        }

        public static DBConfig GetInstance()
        {
            if (null == _instance)
            {
                _instance = new DBConfig();
            }
            return _instance;
        }

        public ISession CreateSession()
        {
            ISessionFactory factory = config.BuildSessionFactory();
            return factory.OpenSession();
        }

        private void MappingInit()
        {
            // TODO: Create code to get all xml files from this folder
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBFileType.hbm.xml");
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBFile.hbm.xml");
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBMessage.hbm.xml");
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBChainMessage.hbm.xml");
/*
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBAlphabet.hbm.xml");
            config.AddFile(Directory.GetCurrentDirectory() + "\\../../Mapping/DBChain.hbm.xml");
*/
        }
    }
}