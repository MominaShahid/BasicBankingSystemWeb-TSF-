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
    public partial class TransferMoney : System.Web.UI.Page
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
                                TransferMoneyGridView.DataSource = dt;
                                TransferMoneyGridView.DataBind();
                            }
                        }
                    }
                }
            }


        }
        protected void btn_Transact_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into transfer (Sender_id,Receiver_id,Amount) values('" + Convert.ToInt32(drop_Sname.Text) + "','" + Convert.ToInt32(drop_name.Text) + "','" + Convert.ToInt32(txt_Amount.Text) + "')";
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd1.CommandText = "select Current_Balance from customer where Cus_id='" + Convert.ToInt32(drop_Sname.Text) + "'";
                cmd2.CommandText = "select Current_Balance from customer where Cus_id='" + Convert.ToInt32(drop_name.Text) + "'";
                int SenderCurr = cmd1.ExecuteNonQuery();
                int ReceiverCurr = cmd2.ExecuteNonQuery();
                int Amount = Convert.ToInt32(txt_Amount.Text);
                int SenderCurrentBalance = SenderCurr - Amount;
                int ReceiverCurrentBalance = ReceiverCurr + Amount;
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update customer set Current_Balance='" + SenderCurrentBalance + "' where Cus_id='" + Convert.ToInt32(drop_Sname.Text) + "'";
                MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd3);
                cmd3.ExecuteNonQuery();
                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update customer set Current_Balance='" + ReceiverCurrentBalance + "' where Cus_id='" + Convert.ToInt32(drop_Sname.Text) + "'";
                MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd4); 
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }

            protected void TransferMoneyGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drop_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void drop_Sname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}