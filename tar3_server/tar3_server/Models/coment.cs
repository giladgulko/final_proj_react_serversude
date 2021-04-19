using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class coment
    {
        int coment_num;
        int report_num;
        DateTime date;
        DateTime time;
        string text;
        string author;

        public coment(int coment_num, int report_num, DateTime date, DateTime time, string text, string author)
        {
            Coment_num = coment_num;
            Report_num = report_num;
            Date = date;
            Time = time;
            Text = text;
            Author = author;
        }
        public coment() { }
        public int Coment_num { get => coment_num; set => coment_num = value; }
        public int Report_num { get => report_num; set => report_num = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Text { get => text; set => text = value; }
        public string Author { get => author; set => author = value; }

       // public List<coment> Read()
       // {
          //  DBServices dbs = new DBServices();
          //  List<coment> coment = dbs.Readcoment();
            
           // return coment;
        //}
    }
}