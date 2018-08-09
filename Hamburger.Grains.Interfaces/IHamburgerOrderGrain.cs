using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Hamburger.Domain;

namespace Hamburger.Grains.Interfaces
{
    public interface IHamburgerOrderGrain : IGrainWithGuidKey
    {
        Task Create(BurgerBuns buns, Pattie pattie, PattieStyle pattieStyle);
        Task AddCondiments(CondimentsChoices condiments);
        Task RemoveCondiments(CondimentsChoices condiments);

        Task<Hamburger.Domain.Hamburger> GetState();
    }
}
