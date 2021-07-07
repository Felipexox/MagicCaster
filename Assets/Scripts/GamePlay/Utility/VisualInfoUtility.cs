using System;

namespace GamePlay.Utility
{
    public static class VisualInfoUtility
    {
        public static string FormatAddressableGuid(Guid guid)
        {
            string guidStr = guid.ToString();

            while (guidStr.IndexOf('-') != -1)
                guidStr = guidStr.Replace("-", "");
            return guidStr;
        }
    }
}
