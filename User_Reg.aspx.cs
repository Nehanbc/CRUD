using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1neha
{
    public partial class User_Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadRecord();
            }
        }

        protected void Btn_insert_Click(object sender, EventArgs e)
        {
            SqlConnection mysqlcon = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=programming_db;Integrated Security=True");
            mysqlcon.Open();

            SqlCommand comm = new SqlCommand("Insert into StudentInfo values('"+int.Parse(TextBox1.Text)+"','"+TextBox2.Text+"','"+int.Parse(TextBox3.Text)+"','"+TextBox4.Text+"')", mysqlcon);
            comm.ExecuteNonQuery();
            mysqlcon.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
            LoadRecord();
        }


        protected void Btn_update_Click(object sender, EventArgs e)
        {
            using (SqlConnection mysqlcon = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=programming_db;Integrated Security=True"))
            {
                mysqlcon.Open();
                SqlCommand comm = new SqlCommand("UPDATE StudentInfo SET StudentName =  '"+TextBox2.Text+"',Age =  '"+TextBox3.Text+"',Contact =  '"+TextBox4.Text+"' where StudentID = "+int.Parse(TextBox1.Text)+"", mysqlcon);
                comm.ExecuteNonQuery();
                mysqlcon.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully updated');", true);
                LoadRecord();
            }
            
        }
        private void LoadRecord()
        {
            using (SqlConnection mysqlcon = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=programming_db;Integrated Security=True"))
            {
                mysqlcon.Open();
                string query = "SELECT * FROM StudentInfo";
                using (SqlCommand comm = new SqlCommand(query, mysqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                   
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                //mysqlcon.Close();
            }
        }

        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection mysqlcon = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=programming_db;Integrated Security=True"))
            {
                mysqlcon.Open();
                SqlCommand comm = new SqlCommand("Delete StudentInfo  where StudentID = "+int.Parse(TextBox1.Text)+"", mysqlcon);
                comm.ExecuteNonQuery();
                mysqlcon.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                LoadRecord();
            }
        }

        protected void Btn_search_Click(object sender, EventArgs e)
        {
            using (SqlConnection mysqlcon = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=programming_db;Integrated Security=True"))
            {
                SqlCommand comm = new SqlCommand("select * from StudentInfo  where StudentID = "+int.Parse(TextBox1.Text)+"", mysqlcon);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
                
            }
    }
}