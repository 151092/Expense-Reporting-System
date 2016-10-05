using Expensite.Business;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JQChart;
namespace Expensite.Web
{
    public partial class Analytics : System.Web.UI.Page
    {
        AnalyticsBusiness analyticsBusiness = new AnalyticsBusiness();
        List<TempEntity> templist = new List<TempEntity>();
        AnalyticsEntity enty = new AnalyticsEntity();
        List<AnalyticsEntity> entys = new List<AnalyticsEntity>();
        protected void Page_Load(object sender, EventArgs e)
        {


            data();


        }
        public void data()
        {

            templist = analyticsBusiness.data();

            foreach (var newitem in templist)
            {
                float amt = Convert.ToInt32(newitem.Amount);
                int expid = Convert.ToInt16(newitem.ExpenseTypeId);
                string expname = newitem.ExpenseTypeName;
                float newamt = addition(amt, expid, expname);
            }

            float totalamount = sum();
            Session["Total"] = totalamount;
            List<TempEntity> temp = new List<TempEntity>();
            temp = analyticsBusiness.ExpensetypeId();
            foreach (var it in temp)
            {
                if (it.ExpenseTypeId == 1)
                {
                    Session["aname"] = it.ExpenseTypeName;
                }
                else if (it.ExpenseTypeId == 2)
                {
                    Session["cname"] = it.ExpenseTypeName;
                }
                else if (it.ExpenseTypeId == 3)
                {
                    Session["dname"] = it.ExpenseTypeName;
                }
                else if (it.ExpenseTypeId == 4)
                {
                    Session["ename"] = it.ExpenseTypeName;
                }
                else if (it.ExpenseTypeId == 5)
                {
                    Session["fname"] = it.ExpenseTypeName;
                }
                else if (it.ExpenseTypeId == 6)
                {
                    Session["gname"] = it.ExpenseTypeName;
                }
                else
                {
                    Session["hname"] = it.ExpenseTypeName;
                }
            }
            foreach (var it in temp)
            {

                if (Convert.ToInt16(it.ExpenseTypeId) == 1)
                {
                    float pera = Convert.ToInt32(Session["a"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["aname"].ToString();
                    enty.percentage = pera;


                }
                else if (Convert.ToInt16(it.ExpenseTypeId) == 2)
                {
                    float pera = Convert.ToInt32(Session["c"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["cname"].ToString();
                    enty.percentage = pera;

                }
                else if (Convert.ToInt16(it.ExpenseTypeId) == 3)
                {
                    float pera = Convert.ToInt32(Session["d"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["dname"].ToString();
                    enty.percentage = pera;

                }
                else if (Convert.ToInt16(it.ExpenseTypeId) == 4)
                {
                    float pera = Convert.ToInt32(Session["e"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["ename"].ToString();
                    enty.percentage = pera;

                }
                else if (Convert.ToInt16(it.ExpenseTypeId) == 5)
                {
                    float pera = Convert.ToInt32(Session["f"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["fname"].ToString();
                    enty.percentage = pera;

                }

                else if (Convert.ToInt16(it.ExpenseTypeId) == 6)
                {
                    float pera = Convert.ToInt32(Session["g"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["gname"].ToString();
                    enty.percentage = pera;

                }
                else
                {
                    float pera = Convert.ToInt32(Session["h"]) * 100;
                    pera = pera / Convert.ToInt32(Session["Total"]);
                    enty.ExpName = Session["hname"].ToString();
                    enty.percentage = pera;

                }
                entys.Add(new AnalyticsEntity { ExpName = enty.ExpName, percentage = enty.percentage });
            }
            Session["entity"] = entys;



            Chart1.DataSource = analyticsBusiness.GetPieChartData(entys);
            //    List<ChartData> data =  SamplesBrowser.Models.ChartData.GetPieChartData(entys);
            Chart1.DataBind();




        }




        float a, c, d, e, f, g, h = 0;
        private float addition(float b, int expid, string name)
        {

            if (expid == 1)
            {
                a += b;
                Session["a"] = a;

                return a;
            }
            else if (expid == 2)
            {
                c += b;
                Session["c"] = c;

                return c;
            }
            else if (expid == 3)
            {
                d += b;
                Session["d"] = d;
                return d;
            }
            else if (expid == 4)
            {
                e += b;
                Session["e"] = e;
                return e;
            }
            else if (expid == 5)
            {
                f += b;
                Session["f"] = f;
                return f;
            }
            else if (expid == 6)
            {
                g += b;
                Session["g"] = g;
                return g;
            }
            else
            {
                h += b;
                Session["h"] = h;
                return h;
            }
        }

        private int sum()
        {
            int s = Convert.ToInt32(Session["a"]) + Convert.ToInt32(Session["f"]) + Convert.ToInt32(Session["c"])
                + Convert.ToInt32(Session["d"]) + Convert.ToInt32(Session["e"]) + Convert.ToInt32(Session["g"]) + Convert.ToInt32(Session["h"]);
            return s;
        }



    }

}