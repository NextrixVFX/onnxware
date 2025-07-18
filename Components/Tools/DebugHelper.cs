using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace onnxware.Components.Tools
{
    public class DebugHelper
    {
        public void DebugLine(Action code)
        {
            try { code(); }
            catch (Exception ex)
            {
                ConsoleAPI.Logger.Error($"[DebugLine] Exception caught: {ex.Message}");
                ConsoleAPI.Logger.Error(ex.StackTrace);
            }
        }
    }
}
