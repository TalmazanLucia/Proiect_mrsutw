using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using MRSUTW.Models;

namespace MRSUTW.Controllers
{
    public class SalaController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<ActivitiesModel> activities = new List<ActivitiesModel>();

        public SalaController()
        {
            con.ConnectionString = MRSUTW.Properties.Resources.ConnectionString;
        }

        // GET: Home
        public ActionResult Index()
        {
            FetchData();
            return View(activities);
        }
        private void FetchData()
        {
            if(activities.Count > 0)
            {
                activities.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [id],[Prof],[Luni],[Marti],[Miercuri],[Joi],[Vineri],[Sambata],[Duminica],[LoculDesfasurarii] FROM [MRSUTW].[dbo].[Table_Activities]";
                dr = com.ExecuteReader();
                while(dr.Read())
                {
                    activities.Add(new ActivitiesModel() {
                        //id = dr["id"].ToString(),
                        Prof = dr["Prof"].ToString(),
                        Luni = dr["Luni"].ToString(),
                        Marti = dr["Marti"].ToString(),
                        Miercuri = dr["Miercuri"].ToString(),
                        Joi = dr["Joi"].ToString(),
                        Vineri = dr["Vineri"].ToString(),
                        Sambata = dr["Sambata"].ToString(),
                        Duminica = dr["Duminica"].ToString(),
                        LoculDesfasurarii = dr["LoculDesfasurarii"].ToString(),
                    });
                }
                con.Close();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}