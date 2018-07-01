using Mvc6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

         
        public ActionResult Details(int id) {
            return View();
        }

        
        public ActionResult Create() {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Person person) {
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

        public ActionResult EditPeople(string id) {
            if (Request.IsAjaxRequest()) {
               

                Person match = people.Find(p => p.Name == id);
                return PartialView("_EditPerson", match);
            }
            else {
                return RedirectToAction("Index");
            }
        }

       
        public ActionResult Edit(int id) {            

            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name, City, Phonenumber")]Person person) {
            try {

                if (ModelState.IsValid) {

                    Person match = people.Find(p => p.Name == person.Name);

                    if (people.Contains(match)) {
                        match.Phonenumber = person.Phonenumber;
                        match.City = person.City;

                        return PartialView("_ListPeople", match);
                    }
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, "Missing data");
            }
            catch (Exception ex) {

                return View();
            }
        }

        
        public ActionResult Delete(string id) {
            Person match = people.Find(p => p.Name == id);
            if(match != null && people.Contains(match)) {
                people.Remove(match);
            }

            var peps = people
                        .OrderBy(p => p.Name)
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };
            return PartialView("Index", model);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<Person> people = new List<Person>() {
            new Person {
                Name = "Tonny",
                Phonenumber = 0738899264,
                City = "Kiruna"
            },
            new Person {
                Name = "Marcus",
                Phonenumber = 01797896502,
                City = "Uddevala"
            },
            new Person {
                Name = "Jonny",
                Phonenumber = 0738839564,
                City = "Umeå"
            },
            new Person {
                Name = "Pontus",
                Phonenumber = 0735698592,
                City = "Göteborg"
            },
            new Person {
                Name = "Johan",
                Phonenumber = 0478965482,
                City = "Stockholm"
            },
            new Person {
                Name = "Sonny",
                Phonenumber = 0736895489,
                City = "Uppsala"
            },
            new Person {
                Name = "George",
                Phonenumber = 0736948569,
                City = "Varberg"
            },
            new Person {
                Name = "David",
                Phonenumber = 0768954852,
                City = "Malmö"
            },
            new Person {
                Name = "Gustav",
                Phonenumber = 0789564125,
                City = "Falun"
            },
            new Person {
                Name = "Hanna",
                Phonenumber = 0751656984,
                City = "Karskrona"
            },
            new Person {
                Name = "Stefan",
                Phonenumber = 0754125693,
                City = "Borås"
            },
            new Person {
                Name = "Liam",
                Phonenumber = 0745689213,
                City = "Eskilstuna"
            },
            new Person {
                Name = "Karl",
                Phonenumber = 051314151,
                City = "Stockholm"
            },
            new Person {
                Name = "Per",
                Phonenumber = 051415161,
                City = "Timmele"
            }
        };
    }
}