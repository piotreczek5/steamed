using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Infrastructure.Exceptions
{
    public class SettingsNotConfiguredException : Exception
    {
        public SettingsNotConfiguredException(string message) : base(message)
        {
        }
    }
}
