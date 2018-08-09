using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hamburger.Domain;

namespace HamburgerDemo.ViewModels
{
    public class HamburgerViewModel
    {
        public BurgerBuns bunType { get; set; }
        public Pattie pattieType { get; set; }
        public PattieStyle pattieStyle { get; set; }
    }
}
