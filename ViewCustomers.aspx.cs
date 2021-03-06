using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;



namespace BasicBankingSystemWeb_TSF_
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=basicbankingsystem;password=;SSL Mode=None");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                ViewCustomersGridView.DataSource = dt;
                                ViewCustomersGridView.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void ViewCustomersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}