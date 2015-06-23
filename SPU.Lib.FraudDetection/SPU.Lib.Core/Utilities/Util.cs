using System;

namespace SPU.Lib.Core.Utilities
{
    public class Utility
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}