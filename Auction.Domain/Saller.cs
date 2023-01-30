using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain
{
    public class Saller
    {
        public Saller()
        { }

        public Saller(string name, string lastName, Sex sex)
        {
            Name = name;
            LastName = lastName;
            Sex = sex;
            State = new RegisteredState();
        }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public Sex Sex { get; private set; }

        public SallerState State { get; private set; }

        public void Update(string name, string lastName, Sex sex)
        {
            if (State.CanUpdateProperty())
            {
                Name = name;
                LastName = lastName;
                Sex = sex;
            }
            else
                throw new Exception("Impossible to change the Properies!");
        }

        public void AcceptSaller()
        {
            if (State.GetType() == typeof(InProgressState))
            {
                State = new AcceptedState();
            }
            else
                throw new Exception("Invalide State for Accept it");
        }

        public void InProgressSaller()
        {
            if (State.GetType() == typeof(RegisteredState))
            {
                State = new InProgressState();
            }
            else
                throw new Exception("Invalide State for In Progress it");
        }
    }
}
