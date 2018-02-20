using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//datagridView1.Refresh();

namespace Insert_Data
{
    public partial class RemvUpdt : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public RemvUpdt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=EHSW7WSA4550\\SQLEXPRESS;Initial Catalog=Equ;Integrated Security=True;");


        private void SBCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemvUpdt_Load(object sender, EventArgs e)
        {
            

        }

        private void show_records_Click(object sender, EventArgs e)
        {
            con.Open();
            sda = new SqlDataAdapter(@"SELECT ID, boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment
                                    FROM LBatteries order by boxN", con);
            dt = new DataTable();
            sda.Fill(dt);
            removeUpdtBatts.DataSource = dt;
            con.Close();

            //Highlighting NEW / USED Batteries
            for (int i = 0; i < removeUpdtBatts.Rows.Count - 1; i++)
            {
                if (removeUpdtBatts.Rows[i].Cells[2].Value.ToString().Trim() == "used")
                {
                    removeUpdtBatts.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Orange;
                }
                else if (removeUpdtBatts.Rows[i].Cells[2].Value.ToString().Trim() == "new")
                {
                    removeUpdtBatts.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            //End of Highlighting
            for (int i = 0; i < removeUpdtBatts.Rows.Count - 1; i++) {
                int jobnCheck = Int32.Parse(removeUpdtBatts.Rows[i].Cells[1].Value.ToString().Trim());
                if (jobnCheck % 2 == 0) {
                    for (int j = 0; j < removeUpdtBatts.Columns.Count - 1; j++) {
                        removeUpdtBatts.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightGray;
                        if (removeUpdtBatts.Rows[i].Cells[2].Value.ToString().Trim() == "new")
                        {
                            removeUpdtBatts.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (removeUpdtBatts.Rows[i].Cells[2].Value.ToString().Trim() == "used") {
                            removeUpdtBatts.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Orange;
                        }
                    }
                }
            }

        }

        private void updt_batts_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                MessageBox.Show("Data successfully updated");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }
            
        }
        private void buttonCountID_Click(object sender, EventArgs e)
        {
            for (int i = 0, iD = 1; i < removeUpdtBatts.Rows.Count - 1; i++, iD++)
            {
                removeUpdtBatts.Rows[i].Cells[0].Value = iD;
            }
        }
    }

}
