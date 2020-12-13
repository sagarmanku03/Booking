using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Assignment4
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\Assignment4.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populategridview();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void populategridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection (connectionstring))
    {
    sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Booking", sqlcon);
                
                sqlDa.Fill(dtbl);
               
    }
            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            else
            { 
                dtbl.Rows.Add(dtbl.NewRow());
            
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No data Found ..!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        sqlcon.Open();
                        string query = "INSERT INTO Booking (Id,CustomerName,MovieName,PhoneNo,Address) VAlUES (@id,@name,@mname,@pn,@ad)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                        sqlCmd.Parameters.AddWithValue("@id", (GridView1.FooterRow.FindControl("txtIdFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@name", (GridView1.FooterRow.FindControl("txtCustomerNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@mname", (GridView1.FooterRow.FindControl("txtMovieNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@pn", (GridView1.FooterRow.FindControl("txtPhoneNoFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@ad", (GridView1.FooterRow.FindControl("txtAddressFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        populategridview();
                        Lblsuccessmessage.Text = "New Recoard Added";
                        Lblerrormessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                Lblsuccessmessage.Text = "";
                Lblerrormessage.Text = ex.Message;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            populategridview();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            populategridview();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    string query = "UPDATE Booking SET Id=@id,CustomerName=@name,MovieName=@mname,PhoneNo=@pn,Address=@ad WHERE Id=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                    sqlCmd.Parameters.AddWithValue("@id", (GridView1.Rows[e.RowIndex].FindControl("txtId") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@name", (GridView1.Rows[e.RowIndex].FindControl("txtCustomerName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@mname", (GridView1.Rows[e.RowIndex].FindControl("txtMovieName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@pn", (GridView1.Rows[e.RowIndex].FindControl("txtPhoneNo") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ad", (GridView1.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    populategridview();
                    Lblsuccessmessage.Text = "Recoard Updated";
                    Lblerrormessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                Lblsuccessmessage.Text = "";
                Lblerrormessage.Text = ex.Message;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    string query = "DELETE FROM Booking Where Id=@id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);                    
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    populategridview();
                    Lblsuccessmessage.Text = "Recoard deleted";
                    Lblerrormessage.Text = "";

                }

            }
            catch (Exception ex)
            {

                Lblsuccessmessage.Text = "";
                Lblerrormessage.Text = ex.Message;
            }
        }
    }
}