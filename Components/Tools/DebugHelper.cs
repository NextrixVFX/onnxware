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
                MelonLogger.Error($"[DebugLine] Exception caught: {ex.Message}");
                MelonLogger.Error(ex.StackTrace);
            }
        }
    }

    /*
    public class ExampleDebug
    {
        public void Example()
        {
            DebugHelper dh = new DebugHelper();
            dh.DebugLine(() =>
            {
                MelonLogger.Msg(5 / 0);
            });
        }
    }
    */
}
