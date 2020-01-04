using Fumbbl;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl
{
    public enum LogLevel
    {
        All,
        Debug,
        Info,
        Warn,
        Error,
        Off,
    }
    
    class LogManager 
    {
        public static void Debug(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.Debug)
            {
                UnityEngine.Debug.Log(message);
            }
        }

        public static void Info(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.Info)
            {
                UnityEngine.Debug.Log(message);
                FFB.Instance.AddReport(Ffb.Dto.Reports.RawString.Create(message));
            }
        }

        public static void Warn(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.Warn)
            {
                UnityEngine.Debug.LogWarning(message);
            }
        }

        public static void Error(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.Error)
            {
                UnityEngine.Debug.LogError(message);
            }
        }

    }
}
