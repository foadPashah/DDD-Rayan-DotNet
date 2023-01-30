using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain
{
    public abstract class SallerState
    {
        public virtual bool CanUpdateProperty() => false;

        public virtual bool CanNegotiate() => false;
    }

    public class RegisteredState : SallerState
    {
        public override bool CanUpdateProperty() => true;
        
    }

    public class InProgressState : SallerState
    { 
    
    }

    public class AcceptedState : SallerState
    {
        public override bool CanUpdateProperty() => true;

        public override bool CanNegotiate() => true;
    }

    public class RejectedState : SallerState
    {

    }
}
