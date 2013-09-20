using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Infrastructure.Rules
{
    public interface IRule
    {
        bool IsValid { get; }
        int RuleId { get; set; }
        string[] ParticipatingLogicalFields { get; }
    }
}
