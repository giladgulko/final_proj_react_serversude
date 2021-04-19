using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class dish
    {
        int id;
        string name;
        string image;
        string cookingType;
        double time;

        public dish(int id, string name, string image, string cookingType, double time)
        {
            Id = id;
            Name = name;
            Image = image;
            CookingType = cookingType;
            Time = time;
        }
        public dish() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string CookingType { get => cookingType; set => cookingType = value; }
        public double Time { get => time; set => time = value; }

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.InsertDish(this);
        }

        public List<dish> Read()
        {
            DBServices dbs = new DBServices();
            List<dish> bus = dbs.ReadDish();
            return bus;
        }

    }
}