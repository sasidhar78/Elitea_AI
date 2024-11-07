using log4net;
using log4net.Config;
using System.Reflection;

namespace Utilities
{
    public class Loggerss
    {
        public ILog LoggerInstance;
        public Loggerss(string fileName)
        {
            SetConfig(fileName);
        }
        public void GetLogger<T>()
        {
            LoggerInstance = LogManager.GetLogger(typeof(T));
        }
        private void SetConfig(string fileName)
        {
            var path = Path.Combine(
            Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName, fileName);
            XmlConfigurator.Configure(new FileInfo(path));
        }
        public void LogInfo(string message)
        {
            LoggerInstance.Info(message);
        }
        public void LogError(string message, Exception exception)
        {
            LoggerInstance.Error(message, exception);
        }
    }
}