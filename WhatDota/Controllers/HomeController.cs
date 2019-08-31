using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WhatDota.Data;

namespace WhatDota.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GenerateCombinations()
        {
            var rand = new Random();
            var heroes = new List<Entity>();
            var roles = new List<Entity>();

            using (StreamReader r = new StreamReader("Heroes.json"))
            {
                string json = r.ReadToEnd();
                heroes = JsonConvert.DeserializeObject<List<Entity>>(json);
            }

            using (StreamReader r = new StreamReader("Roles.json"))
            {
                string json = r.ReadToEnd();
                roles = JsonConvert.DeserializeObject<List<Entity>>(json);
            }

            var heroId = rand.Next(0, heroes.Count);
            var roleId = rand.Next(0, roles.Count);

            var hero = heroes[heroId];
            var role = roles[roleId];

            return role.Name + " " + hero.Name;
        }
    }
}
