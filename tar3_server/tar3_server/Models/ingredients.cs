using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class ingredients
    {
        int id;
        string name;
        string image;
        double calories;

        public ingredients(int id, string name, string image, double calories)
        {
            Id = id;
            Name = name;
            Image = image;
            Calories = calories;
        }
        public ingredients() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public double Calories { get => calories; set => calories = value; }

        public List<ingredients> Read()
        {
            DBServices dbs = new DBServices();
            List<ingredients> bus = dbs.ReadIng();
            return bus;
        }

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.Insert(this);
        }
    }
}
