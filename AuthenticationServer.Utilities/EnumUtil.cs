using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace AuthenticationServer.Utilities
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetDisplayName(this object val)
        {
            return
                val.GetType()
                    .GetMember(val.ToString())
                    .FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>(false)?.Name ??
                (val.ToString() == "0" ? "" : val.ToString());
        }

        public static string GetEnumDesc(object val)
        {
            return
                val.GetType()
                    .GetMember(val.ToString())
                    .FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>(false)?.Description ??
                (val.ToString() == "0" ? "" : val.ToString());
        }
    }
}