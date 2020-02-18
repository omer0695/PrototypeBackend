using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrototypeDataAccess;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace PrototypeBackend.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FilmController : ApiController
    {
        PrototypeEntities entities = new PrototypeEntities();

        [HttpGet, ActionName("LongestOpeningCrawl")]
        public IEnumerable<object> LongestOpeningCrawl()
        {
            var records = entities.films.Select(x => new {
                x.title,
                x.opening_crawl
            });

            var grouped = records.OrderBy(o => o.title).ToLookup(x => x.opening_crawl.Length);
            var maxRepetitions = grouped.Max(x => x.Key);
            var maxRepeatedItems = grouped.Where(x => x.Key == maxRepetitions).ToList();

            return maxRepeatedItems;
        }

        [HttpGet, ActionName("MostAppearencesCharacter")]
        public IEnumerable<object> MostAppearencesCharacter()
        {
            var records = from film in entities.films
                          from people in film.people
                          select new
                          {
                              film_id = film.id,
                              people_id = people.id,
                              person_name = people.name
                          };

            var grouped = records.ToLookup(x => Tuple.Create(x.person_name, x.people_id));
            var maxRepetitions = grouped.Max(x => x.Count());
            var maxRepeatedItems = grouped.OrderBy(o => o.Key.Item1).Where(x => x.Count() == maxRepetitions)
                                    .Select(s => s.Key.Item1).ToList();

            return maxRepeatedItems;
        }

        [HttpGet, ActionName("MostAppearencessSpecies")]
        public IEnumerable<object> MostAppearencesspecies()
        {
            var films_species = from film in entities.films
                                from species in film.species
                                select new
                                {
                                    film_id = film.id,
                                    species_id = species.id,
                                };

            var species_people = from people in entities.people
                                 from species in people.species
                                 select new
                                 {
                                     species_id = species.id,
                                     people_id = people.id
                                 };

            var records = from _species in entities.species
                          join _films_species in films_species on _species.id equals _films_species.species_id
                          join _species_people in species_people on _species.id equals _species_people.species_id
                          orderby _species.name
                          select new
                          {
                              species_name = _species.name
                          };

            var grouped = records.OrderBy(o => o.species_name).ToLookup(x => x.species_name);
            var maxRepetitions = grouped.Max(x => x.Count());
            var maxRepeatedItems = grouped.Where(x => x.Count() == maxRepetitions)
                                          .Select(x => x.Key + " (" + maxRepetitions + ")").ToList();

            return maxRepeatedItems;
        }

        [HttpGet, ActionName("MostPlanetVehicles")]
        public IEnumerable<object> MostPlanetVehicles()
        {

            var films_planets = from film in entities.films
                                from planet in film.planets
                                select new
                                {
                                    film_id = film.id,
                                    planet_id = planet.id
                                };

            var films_vehicles = from film in entities.films
                                 from vehicle in film.vehicles
                                 select new
                                 {
                                     film_id = film.id,
                                     vehicle_id = vehicle.id,
                                 };

            var vehicles_pilots = from people in entities.people
                                  from vehicle in people.vehicles
                                  select new
                                  {
                                      vehicle_id = vehicle.id,
                                      people_id = people.id
                                  };

            var records = from films_planet in films_planets
                          join films_vehicle in films_vehicles on films_planet.film_id equals films_vehicle.film_id
                          join vehicles_pilot in vehicles_pilots on films_vehicle.vehicle_id equals vehicles_pilot.vehicle_id
                          join people in entities.people on vehicles_pilot.people_id equals people.id
                          join planet in entities.planets on films_planet.planet_id equals planet.id
                          join species in entities.species on people.id equals species.id
                          group films_planet by new
                          {
                              planet_name = planet.name,
                              pilot_name = people.name,
                              species_name = species.name
                          } into g
                          select new
                          {
                              g.Key.planet_name,
                              g.Key.pilot_name,
                              g.Key.species_name
                          };

            var grouped = records.OrderBy(o => o.planet_name).ToLookup(x => x.planet_name);
            var maxRepetitions = grouped.Max(x => x.Count());
            var maxRepeatedItems = grouped.Where(x => x.Count() == maxRepetitions)
                                          .ToList();
            return maxRepeatedItems;
        }
    }
}
