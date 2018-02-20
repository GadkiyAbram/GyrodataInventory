using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SQLite;

namespace Insert_Data
{
    class ConnectionClassAllEquipment
    {
        public DataTable dt = new DataTable();
        DataSet dTable = new DataSet();
        public void SQL_ShowAll(DataGridView datagridview, SqlConnection SQLcon, string sql_query) {
            try
            {
                SQLcon.Open();
                SqlCommand cmd = SQLcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql_query;
                cmd.ExecuteNonQuery();
                dt = new Equipment.EmpDataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                datagridview.DataSource = dt;
                SQLcon.Close();
            }catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        public void SQLite_ShowALL(DataGridView datagridview, SQLiteConnection SQLitecon, string sqlite_query) {
            SQLitecon.Open();
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlite_query, SQLitecon);
                adapter.Fill(dTable);
                datagridview.DataSource = dTable.Tables[0].DefaultView;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            SQLitecon.Close();
        }
    }
}