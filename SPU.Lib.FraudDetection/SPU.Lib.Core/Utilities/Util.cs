namespace SPU.Lib.Core.Utilities
{
    using System;

    public class Utility
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}