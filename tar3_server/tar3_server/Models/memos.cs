using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class memos
    {
        int id;
        int typeId;
        string text;

        public memos(int id, int typeId, string text)
        {
            Id = id;
            TypeId = typeId;
            Text = text;
        }
        public memos() { }
        public int Id { get => id; set => id = value; }
        public int TypeId { get => typeId; set => typeId = value; }
        public string Text { get => text; set => text = value; }

        public void Insert()
        {
            DBServices dbs = new DBServices();
            dbs.Insertmemo(this);
        }

        public List<memos> Read()
        {
            DBServices dbs = new DBServices();
            List<memos> bus = dbs.Readmemos();
            return bus;
        }

    }
}