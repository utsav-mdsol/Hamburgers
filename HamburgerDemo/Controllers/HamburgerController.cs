using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hamburger.Domain;
using Hamburger.Grains.Interfaces;
using Orleans;
using System.Text.Encodings.Web;
using AutoMapper;



namespace HamburgerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamburgerController : ControllerBase
    {
        public readonly IClusterClient _clusterClient;

        public HamburgerController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        //GET
        public async Task<string> Get()
        {
            var hamburgerId = Guid.NewGuid();
            var grain = _clusterClient.GetGrain<IHamburgerOrderGrain>(hamburgerId);
            await grain.Create(BurgerBuns.Plain, Pattie.Chicken, PattieStyle.Welldone);
            return hamburgerId.ToString();
        }
        //GET
        /*[HttpGet]
        [Route("{id}")]
        public IActionResult GetById(string id)
        {
            HamburgerRepository hamburgerRepo = new HamburgerRepository();

            var hamburger = hamburgerRepo.GetByType(id);

            //return Ok(Mapper.Map<Hamburger.Domain.Hamburger, HamburgerDemo.ViewModels.HamburgerViewModel>(hamburger));

            return Ok(hamburger);

            //return Ok($"{id} Burger\n" +
            //    $"{hamburger.bunType.ToString()}\n" +
            //    $"{hamburger.pattieStyle.ToString()}\n" +
            //    $"{hamburger.pattieType.ToString()}");
        }*/
        
    }
}