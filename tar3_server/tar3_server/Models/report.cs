using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tar3_server.Models.DAL;

namespace tar3_server.Models
{
    public class report
    {
        
        int report_num;
        DateTime date;
        DateTime time;
        string area;
        string link;
        string text;
        string author;
        string beach;
        public report() { }

        public report(int report_num, DateTime date, DateTime time, string area, string link, string text, string author,string beach)
        {
            Report_num = report_num;
            Date = date;
            Time = time;
            Area = area;
            Link = link;
            Text = text;
            Author = author;
            Beach = beach;
        }

        public int Report_num { get => report_num; set => report_num = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Area { get => area; set => area = value; }
        public string Link { get => link; set => link = value; }
        public string Text { get => text; set => text = value; }
        public string Author { get => author; set => author = value; }
        public string Beach { get => beach; set => beach = value; }

        public List<report> Read(string date)
        {
            DBServices dbs = new DBServices();
            List<report> report = dbs.Readreport(date);
            return report;
        }

        public void insert()
        {
            DBServices dbs = new DBServices();
            dbs.InsertReport(this);
        }
    }
}