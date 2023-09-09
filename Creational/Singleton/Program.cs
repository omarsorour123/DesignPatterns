internal class Program
{   public sealed class Logger
    {
        private static Logger instance;
        private string logFileName="logs.log";
        private StreamWriter logWriter;
     private Logger()
        {
            logWriter = new StreamWriter(logFileName, true);
        }

        public static Logger Instance()
        {  
             if (instance == null)
            {
                instance = new Logger();
            }
             return instance;

        }
        public void Log(string message)
        {
            string formattedMessage = $"{DateTime.Now}: {message}";
            logWriter.WriteLine(formattedMessage);
            logWriter.Flush();

        }
        public void Close()
        {
            logWriter.Close();
        }

    }

    private static void Main(string[] args)
    {
        Logger logger1= Logger.Instance();
        Logger logger2= Logger.Instance();
        if(logger1 == logger2) {
            Console.WriteLine("equal");
        }
        logger1.Log("hi");
        logger1.Close();
    }
}