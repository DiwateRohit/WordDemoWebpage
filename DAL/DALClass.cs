using MSSU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Web;


namespace DAL
{
    public class DALClass
    {
        string cc = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        DataTable dt = new DataTable();


        public DataSet DownloadWord(StudentLogin l)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(cc))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DownloadWord";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@Mode", l.Mode);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }

    }
}
    