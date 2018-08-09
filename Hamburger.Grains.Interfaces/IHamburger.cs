using System;
using System.Collections.Generic;
using System.Text;
using Hamburger.Domain;
using System.Threading.Tasks;

namespace Hamburger.Grains.Interfaces
{
    public interface IHamburger
    {
        Domain.Hamburger GetByType(string id);

     // void Create(BurgerBuns burgerBuns, Pattie pattie, PattieStyle pattieStyle);
    }

    public class HamburgerRepository : IHamburger
    {
        
        public List<Domain.Hamburger> CreateHamburgers()
        {
            return new List<Domain.Hamburger>()
            {
                new Domain.Hamburger()
                {
                    Id = Guid.NewGuid(),
                    bunType = BurgerBuns.Plain,
                    pattieType = Pattie.Beef,
                    pattieStyle = PattieStyle.Rare
                },
                new Domain.Hamburger()
                {
                    bunType = BurgerBuns.Plain,
                    pattieType = Pattie.Chicken,
                    pattieStyle = PattieStyle.Welldone
                },
                new Domain.Hamburger()
                {
                    bunType = BurgerBuns.SesameSeed,
                    pattieType = Pattie.Trukey,
                    pattieStyle = PattieStyle.Welldone
                }
            };
        }
        
        public Domain.Hamburger GetByType(string id)
        {
            var getAllBurgers = CreateHamburgers();

            foreach (var burger in getAllBurgers)
            {
                if(burger.pattieType.ToString().Equals(id))
                return burger;
            }
            throw new EntryPointNotFoundException();
        } 
    }
}
