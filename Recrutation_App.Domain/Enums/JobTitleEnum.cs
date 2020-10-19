using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Domain.Enums
{
    public enum JobTitleEnum
    {
        Administrator, Developer, Architect, Manager
    }

    public static class JobTitleHelper
    {
        public static JobTitleEnum GetEnumFromString(string str)
        {
            switch (str)
            {
                case "Administrator":
                    {
                        return JobTitleEnum.Administrator;
                    }
                case "Developer":
                    {
                        return JobTitleEnum.Developer;
                    }
                case "Architect":
                    {
                        return JobTitleEnum.Architect;
                    }
                case "Manager":
                    {
                        return JobTitleEnum.Manager;
                    }
                default:
                    {
                        throw new Exception("Invalid job title");
                    }
            }
        }
    }
}
