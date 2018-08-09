using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Orleans;
using Orleans.EventSourcing;
using Hamburger.Grains.Interfaces;
using Hamburger.Domain.Events;
using Hamburger.Domain;



namespace Hamburger.Grain
{
    public class HamburgerOrderGrain : JournaledGrain<HamburgerOrderState, BaseHamburgerEvent>, IHamburgerOrderGrain
    {
        public Task Create(BurgerBuns burgerBuns, Pattie pattie, PattieStyle pattieStyle)
        {
            if (Version != 0) throw new Exception();


            RaiseEvent(new HamburgerCreatedEvent
            {
                Id = this.GetPrimaryKey(),
                Buns = burgerBuns,
                Pattie = pattie,
                PattieStyle = pattieStyle
            });
            return ConfirmEvents();
        }

        public Task AddCondiments(CondimentsChoices condiments)
        {
            if (State.condimentsChoices.Contains(condiments))
                throw new Exception();

            RaiseEvent(new CondimentsAddedEvent
            {
                Id = this.GetPrimaryKey(),
                Condiments = condiments
            });

            return ConfirmEvents();
        }

        public Task RemoveCondiments(CondimentsChoices condiments)
        {
            if (State.condimentsChoices.Contains(condiments))
                throw new Exception();

            RaiseEvent(new CondimentsRemovedEvent
            {
                Id = this.GetPrimaryKey(),
                Condiments = condiments
            });

            return ConfirmEvents();
        }

        public Task<Domain.Hamburger> GetState()
        {
            var domainState = Mapper.Map<Domain.Hamburger>(State);

            return Task.FromResult(domainState);
        }

    }
}
