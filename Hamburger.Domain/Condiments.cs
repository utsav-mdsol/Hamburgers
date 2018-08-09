using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburger.Domain
{
    public class Condiments : IEquatable<Condiments>
    {
        //Condiments
        public static readonly Condiments Lettuce = new Condiments("Let", "Lettuce");
        public static readonly Condiments Tomatoes = new Condiments("Tom", "Tomatoes");
        public static readonly Condiments Onions = new Condiments("Oni", "Onions");
        public static readonly Condiments Mushrooms = new Condiments("Mus", "Mushrooms");
        public static readonly Condiments Relish = new Condiments("Rel", "Relish");

        //Sauces
        public static readonly Condiments Ketchup = new Condiments("Ket", "Ketchup");
        public static readonly Condiments Mustard = new Condiments("Mus", "Mustard");
        public static readonly Condiments Mayo = new Condiments("May", "Mayo");


        public string Id;
        public string Name;

        private Condiments(string id, string name)
        {
            if (string.IsNullOrEmpty(id)) throw new NullReferenceException();
            if (string.IsNullOrEmpty(name)) throw new NullReferenceException();
            Id = id;
            Name = name;
        }
        public bool Equals(Condiments other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as Condiments);

        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
