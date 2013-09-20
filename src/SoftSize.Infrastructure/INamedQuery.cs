using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Infrastructure
{
    public interface INamedQuery
    {
        string QueryName { get; }
    }
}
