using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvcEFCore.Models;

namespace WebAppMvcEFCore.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any teams.
                if (context.Teams.Any())
                    return;   // DB has already been seeded
            
                if (context.Provinces.Any())
                    return;

                var teams = DummyData.GetTeams().ToArray();
                context.Teams.AddRange(teams);
                context.SaveChanges();

                var players = DummyData.GetPlayers(context).ToArray();
                context.Players.AddRange(players);
                context.SaveChanges();

                var provinces = DummyData.GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = DummyData.GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();

            }
        }

        public static List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>() {
            new Team() {
                TeamName="Canucks",
                City="Vancouver",
                Province="BC",
                Country="Canada",
            },
            new Team() {
                TeamName="Sharks",
                City="San Jose",
                Province="CA",
                Country="USA",
            },
            new Team() {
                TeamName="Oilers",
                City="Edmonton",
                Province="AB",
                Country="Canada",
            },
            new Team() {
                TeamName="Flames",
                City="Calgary",
                Province="AB",
                Country="Canada",
            },
            new Team() {
                TeamName="Leafs",
                City="Toronto",
                Province="ON",
                Country="Canada",
            },
            new Team() {
                TeamName="Ducks",
                City="Anaheim",
                Province="CA",
                Country="USA",
            },
            new Team() {
                TeamName="Lightening",
                City="Tampa Bay",
                Province="FL",
                Country="USA",
            },
            new Team() {
                TeamName="Blackhawks",
                City="Chicago",
                Province="IL",
                Country="USA",
            },
        };

            return teams;
        }

        public static List<Player> GetPlayers(ApplicationDbContext context)
        {
            List<Player> players = new List<Player>() {
            new Player {
                FirstName = "Sven",
                LastName = "Baertschi",
                TeamName = context.Teams.Find("Canucks").TeamName,
                Position = "Forward"
            },
            new Player {
                FirstName = "Hendrik",
                LastName = "Sedin",
                TeamName = context.Teams.Find("Canucks").TeamName,
                Position = "Left Wing"
            },
            new Player {
                FirstName = "John",
                LastName = "Rooster",
                TeamName = context.Teams.Find("Flames").TeamName,
                Position = "Right Wing"
            },
            new Player {
                FirstName = "Bob",
                LastName = "Plumber",
                TeamName = context.Teams.Find("Oilers").TeamName,
                Position = "Defense"
            },
        };

            return players;
        }

        public static List<Province> GetProvinces()
        {
            return new List<Province>() {
                new Province(){
                    ProvinceCode = "BC",
                    ProvinceName = "British Columbia"
                    
                },
                new Province(){
                    ProvinceCode = "AB",
                    ProvinceName = "Alberta"

                },
                new Province(){
                    ProvinceCode = "MB",
                    ProvinceName = "Manitoba"

                },
                new Province(){
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario"

                },
                new Province(){
                    ProvinceCode = "NS",
                    ProvinceName = "Nova Scotia"

                },
            };
        }

        public static List<City> GetCities(ApplicationDbContext ctx)
        {
            return new List<City>()
            {
                new City(){
                    CityName = "Vancouver",
                    Population =647540,
                    ProvinceCode = ctx.Provinces.Find("BC").ProvinceCode
                },
                new City(){
                    CityName = "Richmond",
                    Population =203178,
                    ProvinceCode = ctx.Provinces.Find("BC").ProvinceCode
                },
                new City(){
                    CityName = "Burnaby",
                    Population =239059,
                    ProvinceCode = ctx.Provinces.Find("BC").ProvinceCode
                },
                new City(){
                    CityName = "Coquitlam",
                    Population =134962,
                    ProvinceCode = ctx.Provinces.Find("BC").ProvinceCode,
                    
                },

                new City(){
                    CityName = "Edmonton",
                    Population =928182,
                    ProvinceCode = ctx.Provinces.Find("AB").ProvinceCode
                },
                new City(){
                    CityName = "Calgary",
                    Population =1260000,
                    ProvinceCode = ctx.Provinces.Find("AB").ProvinceCode
                },
                new City(){
                    CityName = "Banff",
                    Population =7847,
                    ProvinceCode = ctx.Provinces.Find("AB").ProvinceCode
                },
                new City(){
                    CityName = "Fort McMurray",
                    Population =66573,
                    ProvinceCode = ctx.Provinces.Find("AB").ProvinceCode
                },

                new City(){
                    CityName = "Winnipeg",
                    Population =709253,
                    ProvinceCode = ctx.Provinces.Find("MB").ProvinceCode
                },
                new City(){
                    CityName = "Brandon",
                    Population =48859,
                    ProvinceCode = ctx.Provinces.Find("MB").ProvinceCode
                },
                new City(){
                    CityName = "Selkirk",
                    Population =10278,
                    ProvinceCode = ctx.Provinces.Find("MB").ProvinceCode
                },
                new City(){
                    CityName = "Thompson",
                    Population =13123,
                    ProvinceCode = ctx.Provinces.Find("MB").ProvinceCode
                },

                new City(){
                    CityName = "Toronto",
                    Population =2809000,
                    ProvinceCode = ctx.Provinces.Find("ON").ProvinceCode
                },
                new City(){
                    CityName = "Ottawa",
                    Population =947031,
                    ProvinceCode = ctx.Provinces.Find("ON").ProvinceCode
                },
                new City(){
                    CityName = "Brampton",
                    Population =570290,
                    ProvinceCode = ctx.Provinces.Find("ON").ProvinceCode
                },
                new City(){
                    CityName = "Hamilton",
                    Population =551751,
                    ProvinceCode = ctx.Provinces.Find("ON").ProvinceCode
                },

                new City(){
                    CityName = "Halifax",
                    Population =414129,
                    ProvinceCode = ctx.Provinces.Find("NS").ProvinceCode
                },
                new City(){
                    CityName = "Cape Breton",
                    Population =95887,
                    ProvinceCode = ctx.Provinces.Find("NS").ProvinceCode
                },
                new City(){
                    CityName = "Truro",
                    Population =12261,
                    ProvinceCode = ctx.Provinces.Find("NS").ProvinceCode
                },
                new City(){
                    CityName = "Amherst",
                    Population =9413,
                    ProvinceCode = ctx.Provinces.Find("NS").ProvinceCode
                },
            };
        }
    }
}
