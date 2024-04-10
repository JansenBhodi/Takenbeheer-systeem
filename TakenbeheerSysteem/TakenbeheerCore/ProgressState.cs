using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore
{
    public enum ProgressState
    {
        [Description("Not Yet Started")]
        Beginning,
        [Description("In Progress")]
        Progressing,
        [Description("Under Review")]
        Reviewing,
        [Description("Finished")]
        Done
    }
}
