using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebAppFeedback
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FeedbackConStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Feedback (Name, Email, Feedback) VALUES (@Name, @Email, @Feedback)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtname.Text);
                    command.Parameters.AddWithValue("@Email", txtemail.Text);
                    command.Parameters.AddWithValue("@Feedback", txtfeed.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LblMsg.Text = "Feedback submitted successfully!";
            ClearForm();
        }

        private void ClearForm()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtfeed.Text = "";
        }
    }
}

