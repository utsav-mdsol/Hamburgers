using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger.Domain.Events
{
    public abstract class BaseHamburgerEvent
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Version;
    }
    public class HamburgerCreatedEvent : BaseHamburgerEvent
    {
        public BurgerBuns Buns { get; set; }
        public Pattie Pattie { get; set; }
        public PattieStyle PattieStyle { get; set; }
        public Cheese CheeseType { get; set; }
        
        //Constructor
        public HamburgerCreatedEvent(Guid id, BurgerBuns buns, Pattie pattie, PattieStyle pattieStyle, Cheese cheeseType )
        {
            Id = id;
            Buns = buns;
            Pattie = pattie;
            PattieStyle = pattieStyle;
            CheeseType = cheeseType;
        }

    }


    public class CondimentsAddedEvent : BaseHamburgerEvent
    {
        public CondimentsChoices Condiments { get; set; }
        public CondimentAmount CondimentAmount { get; set; }

        //Constructor
        public CondimentsAddedEvent(Guid id , CondimentsChoices condiments, CondimentAmount condimentAmount)
        {
            Id = id;
            Condiments = condiments;
            CondimentAmount = condimentAmount;
        }
    }

    public class CondimentsRemovedEvent : BaseHamburgerEvent
    {
        public CondimentsChoices Condiments { get; set; }

        //Constructor
        public CondimentsRemovedEvent(Guid id, CondimentsChoices condiments)
        {
            Id = id;
            Condiments = condiments;                       
        }
    }

}
