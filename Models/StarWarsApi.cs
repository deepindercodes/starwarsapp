using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace starwarsapp.Models
{
    public class StarWarsApi
    {
        public static string ApiEndPoint = "https://swapi.dev/api/";

        /// <summary>
        /// This method will return the list of star wars films, using the endpoint films/
        /// </summary>
        /// <returns></returns>
        public static films GetFilms()
        {
            films objfilms = new films();

            string uri = ApiEndPoint + "films/";

            string json_response = Utilities.GetWebResponse(uri);

            objfilms = JsonConvert.DeserializeObject<films>(json_response);

            return objfilms;
        }

        /// <summary>
        /// This method will fetch the details of a particular star wars film, using the episode_id,  using the end point films/<episode_id>/
        /// </summary>
        /// <param name="episode_id"></param>
        /// <returns></returns>
        public static filmdetails GetFilmDetails(int episode_id)
        {
            filmdetails objfilmdetails = new filmdetails();

            string uri = ApiEndPoint + "films/" + episode_id + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objfilmdetails = JsonConvert.DeserializeObject<filmdetails>(json_response);
            }

            //Setting the character info
            List<characters> objcharacterinfoList = new List<characters>();
            foreach (var character in objfilmdetails.characters)
            {
                if (character.Contains("http://swapi.dev/api/people/"))
                {
                    string peopleid = character.Replace("http://swapi.dev/api/people/", "/").Replace("/", "");

                    if (!string.IsNullOrEmpty(peopleid))
                    {
                        int _peopleid = Convert.ToInt32(peopleid);
                        characters objcharacter = new characters();
                        objcharacter = GetCharactersInfo(_peopleid);

                        if (objcharacter != null)
                        {
                            objcharacterinfoList.Add(objcharacter);
                        }
                    }
                }
            }

            if (objcharacterinfoList.Count > 0)
            {
                objfilmdetails.characterinfo = objcharacterinfoList;
            }

            //Setting the planets info
            List<planets> objplanetsinfoList = new List<planets>();
            foreach (var planet in objfilmdetails.planets)
            {
                if (planet.Contains("http://swapi.dev/api/planets/"))
                {
                    string planetid = planet.Replace("http://swapi.dev/api/planets/", "/").Replace("/", "");

                    if (!string.IsNullOrEmpty(planetid))
                    {
                        int _planetid = Convert.ToInt32(planetid);
                        planets objplanet = new planets();
                        objplanet = GetPlanetInfo(_planetid);

                        if (objplanet != null)
                        {
                            objplanetsinfoList.Add(objplanet);
                        }
                    }
                }
            }

            if (objplanetsinfoList.Count > 0)
            {
                objfilmdetails.planetsinfo = objplanetsinfoList;
            }

            //Setting the starships info
            List<starships> objstarshipsinfoList = new List<starships>();
            foreach (var starship in objfilmdetails.starships)
            {
                if (starship.Contains("http://swapi.dev/api/starships/"))
                {
                    string starshipid = starship.Replace("http://swapi.dev/api/starships/", "/").Replace("/", "");

                    if (!string.IsNullOrEmpty(starshipid))
                    {
                        int _starshipid = Convert.ToInt32(starshipid);
                        starships objstarship = new starships();
                        objstarship = GetShipInfo(_starshipid);

                        if (objstarship != null)
                        {
                            objstarshipsinfoList.Add(objstarship);
                        }
                    }
                }
            }

            if (objstarshipsinfoList.Count > 0)
            {
                objfilmdetails.starshipsinfo = objstarshipsinfoList;
            }


            //Setting the vehicles info
            List<vehicles> objvehiclesinfoList = new List<vehicles>();
            foreach (var vehicle in objfilmdetails.vehicles)
            {
                if (vehicle.Contains("http://swapi.dev/api/vehicles/"))
                {
                    string vehicleid = vehicle.Replace("http://swapi.dev/api/vehicles/", "/").Replace("/", "");

                    if (!string.IsNullOrEmpty(vehicleid))
                    {
                        int _vehicleid = Convert.ToInt32(vehicleid);
                        vehicles objvehicle = new vehicles();
                        objvehicle = GetVehicleInfo(_vehicleid);

                        if (objvehicle != null)
                        {
                            objvehiclesinfoList.Add(objvehicle);
                        }
                    }
                }
            }

            if (objvehiclesinfoList.Count > 0)
            {
                objfilmdetails.vehiclesinfo = objvehiclesinfoList;
            }

            //Setting the species info
            List<species> objspeciesinfolist = new List<species>();
            foreach (var species in objfilmdetails.species)
            {
                if (species.Contains("http://swapi.dev/api/species/"))
                {
                    string speciesid = species.Replace("http://swapi.dev/api/species/", "/").Replace("/", "");

                    if (!string.IsNullOrEmpty(speciesid))
                    {
                        int _speciesid = Convert.ToInt32(speciesid);
                        species objspecies = new species();
                        objspecies = GetSepciesInfo(_speciesid);

                        if (objspecies != null)
                        {
                            objspeciesinfolist.Add(objspecies);
                        }
                    }
                }
            }

            if (objspeciesinfolist.Count > 0)
            {
                objfilmdetails.speciesinfo = objspeciesinfolist;
            }

            return objfilmdetails;
        }

        /// <summary>
        /// This method will fetch the info of the character, using the peopleid, via the endpoint using the end point people/<peopleid>/
        /// </summary>
        /// <param name="peopleid"></param>
        /// <returns></returns>
        public static characters GetCharactersInfo(int peopleid)
        {
            characters objcharacters = new characters();

            string uri = ApiEndPoint + "people/" + peopleid + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objcharacters = JsonConvert.DeserializeObject<characters>(json_response);
            }

            return objcharacters;
        }

        /// <summary>
        /// This method will fetch the info of the planet, using the planetid, via the endpoint using the end point planets/<planetid>/
        /// </summary>
        /// <param name="planetid"></param>
        /// <returns></returns>
        public static planets GetPlanetInfo(int planetid)
        {
            planets objplanet = new planets();

            string uri = ApiEndPoint + "planets/" + planetid + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objplanet = JsonConvert.DeserializeObject<planets>(json_response);
            }

            return objplanet;
        }

        /// <summary>
        /// This method will fetch the info of the starship, using the shipid, via the endpoint using the end point starships/<shipid>/
        /// </summary>
        /// <param name="shipid"></param>
        /// <returns></returns>
        public static starships GetShipInfo(int shipid)
        {
            starships objship = new starships();

            string uri = ApiEndPoint + "starships/" + shipid + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objship = JsonConvert.DeserializeObject<starships>(json_response);
            }

            return objship;
        }

        /// <summary>
        /// This method will fetch the info of the vehicle, using the vehicleid, via the endpoint using the end point vehicles/<vehicleid>/
        /// </summary>
        /// <param name="vehicleid"></param>
        /// <returns></returns>
        public static vehicles GetVehicleInfo(int vehicleid)
        {
            vehicles objvehicle = new vehicles();

            string uri = ApiEndPoint + "vehicles/" + vehicleid + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objvehicle = JsonConvert.DeserializeObject<vehicles>(json_response);
            }

            return objvehicle;
        }

        /// <summary>
        /// This method will fetch the info of the species, using the speciesid, via the endpoint using the end point species/<speciesid>/
        /// </summary>
        /// <param name="speciesid"></param>
        /// <returns></returns>
        public static species GetSepciesInfo(int speciesid)
        {
            species objspecies = new species();

            string uri = ApiEndPoint + "species/" + speciesid + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objspecies = JsonConvert.DeserializeObject<species>(json_response);
            }

            return objspecies;
        }

        /// <summary>
        /// This method will only fetch the film name as per the episodeid
        /// </summary>
        /// <param name="episode_id"></param>
        /// <returns></returns>
        public static string GetFilmName(int episode_id)
        {
            filmdetails objfilmdetails = new filmdetails();

            string uri = ApiEndPoint + "films/" + episode_id + "/";

            string json_response = Utilities.GetWebResponse(uri);

            if (json_response.Equals("404 error"))
            {
                //do nothing
            }
            else
            {
                objfilmdetails = JsonConvert.DeserializeObject<filmdetails>(json_response);
            }

            return objfilmdetails.title;
        }
    }
}