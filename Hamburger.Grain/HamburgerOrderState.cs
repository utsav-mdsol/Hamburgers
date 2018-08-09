using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hamburger.Domain;
using Hamburger.Domain.Events;

namespace Hamburger.Grain
{
    public class HamburgerOrderState
    {
        static HamburgerOrderState()
        {
            Mapper.Initialize(c => { c.CreateMap<HamburgerOrderState, Domain.Hamburger>(); });
        }

        public Guid Id { get; set; }
        public BurgerBuns burgerBuns { get; set; }
        public Pattie pattie { get; set; }
        public PattieStyle pattieStyle { get; set; }

        public List<CondimentsChoices> condimentsChoices { get; set; } = new List<CondimentsChoices>();


        public void Apply(HamburgerCreatedEvent ev)
        {
            Id = ev.Id;
            burgerBuns = ev.Buns;
            pattie = ev.Pattie;
            pattieStyle = ev.PattieStyle;
        }

        public void Apply(CondimentsAddedEvent ev)
        {
            condimentsChoices.Add(ev.Condiments);
        }
        public void Apply(CondimentsRemovedEvent ev)
        {
            condimentsChoices.Remove(ev.Condiments);
        }
    }
}
