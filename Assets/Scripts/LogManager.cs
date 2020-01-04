using Fumbbl;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl
{
    public enum LogLevel
    {
        ALL,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        OFF,
    }
    
    class LogManager 
    {
        public static void Debug(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.DEBUG)
            {
                UnityEngine.Debug.Log(message);
            }
        }

        public static void Info(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.INFO)
            {
                UnityEngine.Debug.Log(message);
                FFB.Instance.AddReport(Ffb.Dto.Reports.RawString.Create(message));
            }
        }

        public static void Warn(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.WARN)
            {
                UnityEngine.Debug.LogWarning(message);
            }
        }

        public static void Error(string message)
        {
            if(FFB.Instance.Settings.Debug.LogLevel <= LogLevel.ERROR)
            {
                UnityEngine.Debug.LogError(message);
            }
        }

    }
}
