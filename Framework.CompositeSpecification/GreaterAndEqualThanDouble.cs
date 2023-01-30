using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CompositeSpecification
{
    public class GreaterAndEqualThanDouble : Specification<double>
    {
        private readonly double _target;

        public GreaterAndEqualThanDouble(double target)
        {
            _target = target;
        }

        public override bool IsSatisfied(double value)
        {
            return value >= _target;
        }
    }
}
