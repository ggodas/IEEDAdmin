using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Infrastructure.Rules
{
    public abstract class RuleBase : IRule
    {
        public bool IsValid { get; protected set; }

        public int RuleId { get; set; }

        public string[] ParticipatingLogicalFields { get; set; }
    }

    public class DateIsInRangeRule : Attribute
    {
        public DateIsInRangeRule()
        {
            
        }


    }
}
