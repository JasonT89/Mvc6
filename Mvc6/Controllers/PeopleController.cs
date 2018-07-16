using Mvc6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Mvc6.Controllers
{
    public class PeopleController : Controller
    {       
        public ActionResult Index(string searchtext = null)
        {
            var peps = people
                        .OrderBy(p => p.Name)
                        .Where(p => searchtext == null || p.Name.StartsWith(searchtext, StringComparison.InvariantCultureIgnoreCase))
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {               
                if (ModelState.IsValid) {
                    people.Add(
                        new Person {
                            Name = person.Name,
                            Phonenumber = person.Phonenumber,
                            City = person.City
                        });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPeople(string id)
        {
            if (Request.IsAjaxRequest()) {
                
                Person match = people.Find(p => p.Name == id);
                return PartialView("_EditPerson", match);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        
        public ActionResult Edit(int id)
        {            

            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name, City, Phonenumber")]Person person) {
            try
            {

                if (ModelState.IsValid)
                {

                    Person match = people.Find(p => p.Name == person.Name);

                    if (people.Contains(match))
                    {
                        match.Phonenumber = person.Phonenumber;
                        match.City = person.City;

                        return PartialView("_ListPeople", match);
                    }
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, "Missing data");
            }
            catch (Exception ex)
            {

                return View();
            }
        }
       
        public ActionResult Delete(string id)
        {
            Person match = people.Find(p => p.Name == id);
            if(match != null && people.Contains(match))
            {
                people.Remove(match);
            }

            var peps = people
                        .OrderBy(p => p.Name)
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };
            return PartialView("Index", model);
        }
      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<Person> people = new List<Person>()
        {
            new Person {
                Name = "Mark",
                Phonenumber = 0501234561,
                City = "Puls"
            },
            new Person {
                Name = "Carl",
                Phonenumber = 0502345674,
                City = "Erk"
            },
            new Person {
                Name = "Jonny",
                Phonenumber = 0503456784,
                City = "Kina"
            },
            new Person {
                Name = "David",
                Phonenumber = 0504567897,
                City = "Lung"
            },
            new Person {
                Name = "Johan",
                Phonenumber = 0505678906,
                City = "Stockholm"
            },
            new Person {
                Name = "Sanna",
                Phonenumber = 0506789011,
                City = "Falun"
            },
            new Person {
                Name = "George",
                Phonenumber = 0507890128,
                City = "Köping"
            },
            new Person {
                Name = "Tina",
                Phonenumber = 0508901236,
                City = "Skara"
            },
            new Person {
                Name = "Oscar",
                Phonenumber = 0796548231,
                City = "Kiruna"
            },
            new Person {
                Name = "Hanna",
                Phonenumber = 0796541352,
                City = "Stockholm"
            },
            new Person {
                Name = "Ivan",
                Phonenumber = 0791258632,
                City = "Moskva"
            },
            new Person {
                Name = "Vladimir",
                Phonenumber = 0798965230,
                City = "Russia"
            },
            new Person {
                Name = "Yasamaha",
                Phonenumber = 0739568923,
                City = "Japan"
            },
            new Person {
                Name = "Tonny",
                Phonenumber = 0738956892,
                City = "China"
            }
        };
    }
}
