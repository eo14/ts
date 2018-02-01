using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Enums
{
    public enum FaultStatuses
    {
        Created,
        Forwarded,
        Pending,
        Canceled,
        Completed,
    }
}
