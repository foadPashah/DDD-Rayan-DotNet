using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CompositeSpecification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left,ISpecification<T> right) : base(left, right)
        {

        }
        public override bool IsSatisfied(T value)
        {
            return Right.IsSatisfied(value) && Left.IsSatisfied(value);
        }
    }
}
