using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburger.Domain
{
    public class Hamburger
    {
        public Guid Id { get; set; }
        public BurgerBuns bunType { get; set; }
        public Pattie pattieType { get; set; }
        public PattieStyle pattieStyle { get; set; }
        public Cheese cheeseType { get; set; }
        
    }


    public enum Cheese
    {
        American,
        Italian,
        Pepperjack,
        Swiss,
        Cheddar
    }

    public enum BurgerBuns
    {
        SesameSeed,
        PotatoRoll,
        Plain,
        KaiserRoll
    } 

    public enum Pattie
    {
        Beef,
        Ham,
        Trukey,
        Chicken,
        Veggie
    }
    public enum PattieStyle
    {
        Welldone,
        Medium,
        Rare
    }

    public enum CondimentAmount
    {
        Extra,
        Medium,
        Little
    }

    public class CondimentsChoices : IEquatable<CondimentsChoices>
    {
        public Condiments Condiments { get; }
        public CondimentAmount Amount { get; }

        public CondimentsChoices(Condiments condiments, CondimentAmount amount)
        {
            Condiments = condiments;
            Amount = amount;
        }

        public bool Equals(CondimentsChoices other)
        {
            if (other==null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Condiments.Equals(other.Condiments) && Amount==other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CondimentsChoices);
        }

        public override int GetHashCode()
        {
            return Condiments.GetHashCode();
        }
    }

}
