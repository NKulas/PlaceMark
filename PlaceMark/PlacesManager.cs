using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlaceMark
{
    public class PlacesManager
    {
        public void SavePlace(Place p)
        {
            List<Place> existingPlaces = GetPlaces();
            existingPlaces.Add(p);
            string json = JsonConvert.SerializeObject(existingPlaces);
            App.Instance.Properties["PlacesDatabase"] = json;
        }

        public List<Place> GetPlaces()
        {
            if (App.Instance.Properties.ContainsKey("PlacesDatabase"))
            {
                string json = (string)App.Instance.Properties["PlacesDatabase"];

                if (!string.IsNullOrWhiteSpace(json))
                {
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(json);
                    return places;
                }
            }

            return new List<Place>();
        }

        public void Delete(int id)
        {
            List<Place> existingPlaces = GetPlaces();
            List<Place> newPlaces = new List<Place>();

            foreach (Place p in existingPlaces)
            {
                if (p.Id != id) newPlaces.Add(p);
            }

            string json = JsonConvert.SerializeObject(newPlaces);
            App.Instance.Properties["PlacesDatabase"] = json;
        }

        public int GetNextId()
        {
            if (App.Instance.Properties.ContainsKey("NextId"))
            {
                int id = (int)App.Instance.Properties["NextId"];
                App.Instance.Properties["NextId"] = (id + 1);

                return id;
            }
            else
            {
                App.Instance.Properties["NextId"] = 1;

                return 0;
            }
        }
    }
}