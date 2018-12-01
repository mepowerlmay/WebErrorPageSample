using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ExceptionUtility 的摘要描述
/// </summary>
public class ExceptionUtility
{
    private ExceptionUtility()
    { }

    // Log an Exception
    public static void LogException(Exception exc, string source)
    {
        // Include logic for logging exceptions
        // Get the absolute path to the log file
        string logFile = "App_Data/ErrorLog.txt";
        logFile = HttpContext.Current.Server.MapPath(logFile);

        // Open the log file for append and write the log
        StreamWriter sw = new StreamWriter(logFile, true);
        sw.WriteLine("********** {0} **********", DateTime.Now);
        if (exc.InnerException != null)
        {
            sw.Write("Inner Exception Type: ");
            sw.WriteLine(exc.InnerException.GetType().ToString());
            sw.Write("Inner Exception: ");
            sw.WriteLine(exc.InnerException.Message);
            sw.Write("Inner Source: ");
            sw.WriteLine(exc.InnerException.Source);
            if (exc.InnerException.StackTrace != null)
            {
                sw.WriteLine("Inner Stack Trace: ");
                sw.WriteLine(exc.InnerException.StackTrace);
            }
        }
        sw.Write("Exception Type: ");
        sw.WriteLine(exc.GetType().ToString());
        sw.WriteLine("Exception: " + exc.Message);
        sw.WriteLine("Source: " + source);
        sw.WriteLine("Stack Trace: ");
        if (exc.StackTrace != null)
        {
            sw.WriteLine(exc.StackTrace);
            sw.WriteLine();
        }
        sw.Close();
    }


    /// <summary>
    /// Builds the exception message.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns></returns>
    public static string BuildExceptionMessage(Exception x)
    {
        Exception logException = x;
        if (x.InnerException != null)
        {
            logException = x.InnerException;
        }
        StringBuilder message = new StringBuilder();
        message.AppendLine();
        message.AppendLine("Error in Path : " + System.Web.HttpContext.Current.Request.Path);
        // Get the QueryString along with the Virtual Path
        message.AppendLine("Raw Url : " + System.Web.HttpContext.Current.Request.RawUrl);
        // Type of Exception
        message.AppendLine("Type of Exception : " + logException.GetType().Name);
        // Get the error message
        message.AppendLine("Message : " + logException.Message);
        // Source of the message
        message.AppendLine("Source : " + logException.Source);

        // Stack Trace of the error
        message.AppendLine("Stack Trace : " + logException.StackTrace);
        // Method where the error occurred
        message.AppendLine("TargetSite : " + logException.TargetSite);
        return message.ToString();
    }
}