using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class inginDish
    {
        int dishId;
        int ingId;

        public inginDish(int dishId, int ingId)
        {
            DishId = dishId;
            IngId = ingId;
        }
        public inginDish() { }

        public int DishId { get => dishId; set => dishId = value; }
        public int IngId { get => ingId; set => ingId = value; }

     

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.InsertIng2Dish(this);
        }
    }
}