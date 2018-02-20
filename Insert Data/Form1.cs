using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using System.IO;



namespace Insert_Data
{

    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
    
        ConnectionClassAllEquipment sqlConnect = new ConnectionClassAllEquipment();
        ComboboxLoading circHoursTotal = new ComboboxLoading();
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        SqlConnection con = new SqlConnection("Data Source=EHSW7WSA4550\\SQLEXPRESS;Initial Catalog=Equ;Integrated Security=True;");
        SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\itemsAll.db");
        System.Data.DataSet dast = new DataSet();
        string SQLite_selectALL_query = "SELECT * FROM ";
        string SQL_selectALL_query = "SELECT * FROM ";

        public void clear()
        {
            textBoxItem.Text = String.Empty;
            textBoxAsset.Text = String.Empty;
            textBoxArrived.Text = String.Empty;
            textBoxInvoice.Text = String.Empty;
            comboBoxBox.Text = "Choose Packing box type";
            textBoxCCD.Text = String.Empty;
            textBoxRus.Text = String.Empty;
            textBoxPos.Text = String.Empty;
            textBoxStatus.Text = String.Empty;
            textBoxContainer.Text = String.Empty;
            textBoxComment.Text = String.Empty;
        }

        public void clearGWDTracker()
        {
            textBoxJobN.Text = String.Empty;
            textBoxClient.Text = String.Empty;
            textBoxToolN.Text = String.Empty;
            gwdBullPlug.Text = String.Empty;
            textBoxModem.Text = String.Empty;
            textBoxModVer.Text = String.Empty;
            textBoxCirHrs.Text = String.Empty;
            textBoxMaxTemp.Text = String.Empty;
            comboBoxEng1.Text = String.Empty;
            comboBoxEng2.Text = String.Empty;
            textBoxEng1arr.Text = String.Empty;
            textBoxEng2Arr.Text = String.Empty;
            textBoxEng1left.Text = String.Empty;
            textBoxEng2left.Text = String.Empty;
            textBoxCont.Text = String.Empty;
            textBoxConArr.Text = String.Empty;
            textBoxConLeft.Text = String.Empty;
            textBoxComments.Text = String.Empty;
            textBoxRig.Text = String.Empty;
            comboBoxIssues.Text = String.Empty;
        }

        

        public void checkEmptyFields()
        {
            bool checkEmpty = true;
            if (textBoxItem.Text == String.Empty || textBoxAsset.Text == String.Empty || textBoxArrived.Text == String.Empty ||
                textBoxInvoice.Text == String.Empty || textBoxCCD.Text == String.Empty || 
                textBoxPos.Text == String.Empty || textBoxStatus.Text == String.Empty || textBoxContainer.Text == String.Empty)
            {
                MessageBox.Show("Only Comment field can be empty");
            }
            else
            {
                checkEmpty = false;
            }
        }

        

        private void button1_InsertClick(object sender, EventArgs e)
        {
           
            try
            {
                string che = @"(select count(*) from Emp where item='" + textBoxItem.Text + "' and Asset='" + textBoxAsset.Text + "')";
                SqlCommand cmd = new SqlCommand("insert into Emp values('" + textBoxItem.Text + "','" + textBoxAsset.Text + "','"
                    + textBoxArrived.Text + "','" + textBoxInvoice.Text + "','" + textBoxCCD.Text + "', N'"+ textBoxRus.Text +"', "+ textBoxPos.Text +", '"
                    + textBoxStatus.Text + "','" + comboBoxBox.Text + "','" + textBoxContainer.Text + "','"
                    + textBoxComment.Text + "');", con);
                con.Open();
                SqlCommand cmda = new SqlCommand(che, con);
                int count = (int)cmda.ExecuteScalar();
                if (checkBoxNA.Checked)
                {
                    if (textBoxItem.Text == String.Empty || textBoxAsset.Text == String.Empty ||
                        textBoxArrived.Text == String.Empty || textBoxInvoice.Text == String.Empty ||
                        textBoxCCD.Text == String.Empty || textBoxPos.Text == String.Empty ||
                        textBoxStatus.Text == String.Empty || textBoxContainer.Text == String.Empty)
                    {
                        MessageBox.Show("Only Comment box can be empty");
                    }
                    else if (comboBoxBox.Text == "Choose Packing box type")
                    {
                        MessageBox.Show("Please choose the Packing Box type");
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(textBoxItem.Text + " " + textBoxAsset.Text + " inserted");
                        clear();
                    }
                }
                else
                {
                    if (count > 0)
                    {
                        MessageBox.Show(textBoxItem.Text + " " + textBoxAsset.Text + " already in the base");
                    }
                    else if (textBoxItem.Text == String.Empty || textBoxAsset.Text == String.Empty ||
                        textBoxArrived.Text == String.Empty || textBoxInvoice.Text == String.Empty ||
                        textBoxCCD.Text == String.Empty || textBoxPos.Text == String.Empty ||
                        textBoxStatus.Text == String.Empty || textBoxContainer.Text == String.Empty)
                    {
                        MessageBox.Show("Only Comment box can be empty");
                    }
                    else if (comboBoxBox.Text == "Choose Packing box type")
                    {
                        MessageBox.Show("Please choose the Packing Box type");
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(textBoxItem.Text + " " + textBoxAsset.Text + " inserted");
                        clear();
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public static void main(string[] args)
        {
            System.Windows.Forms.Application.Run(new Form1());
        }

        private void button2_ExitClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        public void button3_ShowAllClick(object sender, EventArgs e)   //CHANGE BUTTON NAME!!!
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    sqlConnect.SQLite_ShowALL(dataGridAllEquipment, conn, SQLite_selectALL_query + "Equ");

                }
                else {
                    sqlConnect.SQL_ShowAll(dataGridAllEquipment, con, SQL_selectALL_query + "Emp");
                }
                
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    if (comboBoxSearch.Text != "")
                    {
                        SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\itemsAll.db");
                        DataSet dTable = new DataSet();
                        try
                        {
                            conn.Open();
                            if (comboBoxSearch.Text == "Item")
                            {
                                SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT Item, Asset, Arrived, Invoice, CCD, 
                                NameRus, PositionCCD, Status,Box, Container, Comment from Equ where 
                                Item like '%" + textBox7.Text + "%'", conn);
                                adapter.Fill(dTable);
                                dataGridSearch.DataSource = dTable.Tables[0].DefaultView;
                            }
                            else if (comboBoxSearch.Text == "Asset")
                            {
                                SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT Item, Asset, Arrived, Invoice, CCD,
                                NameRus, PositionCCD, Status,Box, Container, Comment from Equ where 
                                Asset like '%" + textBox7.Text + "%'", conn);
                                adapter.Fill(dTable);
                                dataGridSearch.DataSource = dTable.Tables[0].DefaultView;
                            }
                            else if (comboBoxSearch.Text == "Status")
                            {
                                SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT Item, Asset, Arrived, Invoice, CCD,
                                NameRus, PositionCCD, Status,Box, Container, Comment from Equ where 
                                Status like '%" + textBox7.Text + "%'", conn);
                                adapter.Fill(dTable);
                                dataGridSearch.DataSource = dTable.Tables[0].DefaultView;
                            }
                            conn.Close();
                        }
                        catch (Exception ex){
                            MessageBox.Show("Error: " + ex);
                        }
                    }
                    else {
                        MessageBox.Show("Pls select Search by");
                    }
                }
                else {
                    if (comboBoxSearch.Text != "")
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        if (comboBoxSearch.Text == "Item")
                        {
                            cmd.CommandText = "select Item, Asset, Arrived, Invoice, CCD, NameRus, PositionCCD, Status, Box, Container, Comment from Emp where Item like '%" + textBox7.Text + "%'";
                        }
                        else if (comboBoxSearch.Text == "Asset")
                        {
                            cmd.CommandText = "select Item, Asset, Arrived, Invoice, CCD, NameRus, PositionCCD, Status, Box, Container, Comment from Emp where Asset like '%" + textBox7.Text + "%'";
                        }
                        else if (comboBoxSearch.Text == "Status")
                        {
                            cmd.CommandText = "select Item, Asset, Arrived, Invoice, CCD, NameRus, PositionCCD, Status, Box, Container, Comment from Emp where Status like '%" + textBox7.Text + "%'";
                        }
                        cmd.ExecuteNonQuery();
                        System.Data.DataTable dt = new SearchEquip.EmpDataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridSearch.DataSource = dt;
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pls select Search by");
                    }
                }
                
            } else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"]) {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    comboTools.Items.Clear();
                    comboModems.Items.Clear();
                    comboGWDbbp.Items.Clear();
                    SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\GWDTracker.db");
                    System.Data.DataSet dTable = new System.Data.DataSet();
                    string sqlQuery;
                    conn.Open();
                    try
                    {
                        sqlQuery = "SELECT * FROM jobsAndPM";
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, conn);
                        adapter.Fill(dTable);
                        dataGWDPM.DataSource = dTable.Tables[0].DefaultView;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    conn.Close();
                }
                else {
                    comboTools.Items.Clear();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from GWDTracker";
                    cmd.ExecuteNonQuery();
                    System.Data.DataTable dt = new GWDTrackerPM.GWDTrackerDataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGWDPM.DataSource = dt;
                    con.Close();
                }

                for (int i = 0; i < dataGWDPM.Rows.Count - 1; i = i + 2)
                {
                    for (int j = 0; j < dataGWDPM.Columns.Count; j++)
                    {
                        dataGWDPM.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightBlue;
                        if (dataGWDPM.Rows[i].Cells[18].Value.ToString().Trim() == "Yes")
                        {
                            dataGWDPM.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                    }
                }
                for (int i = 0; i < dataGWDPM.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGWDPM.Columns.Count; j++)
                    {
                        if (dataGWDPM.Rows[i].Cells[18].Value.ToString().Trim() == "Yes")
                        {
                            dataGWDPM.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                    }
                }
                //adding all the values in comboBoxes
                ComboboxLoading gwdPMComboB = new ComboboxLoading();
                gwdPMComboB.toolLoading(dataGWDPM, comboTools, 2);     //adding Tools
                gwdPMComboB.toolLoading(dataGWDPM, comboModems, 4);     //adding Modems
                gwdPMComboB.toolLoading(dataGWDPM, comboGWDbbp, 3);     //adding GWD Battery BullPlugs

            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"]) {
               //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            
        }

        private void showEquipment()
        {
            throw new NotImplementedException();
        }

        public void exportToExcel(DataGridView dataGridViewTABLE, string excelfilename)
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Application.Workbooks.Add(Type.Missing);
            xla.Columns.ColumnWidth = 15;
            for (int i = 1; i < dataGridViewTABLE.Columns.Count + 1; i++)
            {
                xla.Cells[1, i] = dataGridViewTABLE.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridViewTABLE.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewTABLE.Columns.Count; j++)
                {
                    if (dataGridViewTABLE.Rows[i].Cells[j].Value != null)
                    {
                        xla.Cells[i + 2, j + 1] = dataGridViewTABLE.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            xla.Visible = true;
        }

        private void generateExcel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                exportToExcel(dataGridAllEquipment, "ExportedUserDetail");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                exportToExcel(dataGridToManifest, "ExportedUserDetail");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                exportToExcel(dataGWDPM, "ExportedUserDetail");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])
            {
                exportToExcel(LithiumBattsView, "ExportedUserDetail");
            }
        }

        private void button4_DeleteClick(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("delete from Emp where Item='" + textBoxItem.Text + "' and Asset='" + textBoxAsset.Text + "'", con);
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(textBoxItem.Text + " " + textBoxAsset.Text + " deleted");
        }

        private void button5_ClearClick(object sender, EventArgs e)
        {
            dataGridAllEquipment.DataSource = null;
        }

        public void button6_SearchClick(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Item, Asset, Arrived, Invoice, CCD, Status, Box, Container, Comment from Emp where Asset like '%" + textBoxAsset.Text + "%'";
            cmd.ExecuteNonQuery();
            System.Data.DataTable dt = new SearchEquip.EmpDataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridAllEquipment.DataSource = dt;
            con.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridSearch.DataSource = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //exportToExcel(dataGridToManifest, "ExportedUserDetail");
        }

        private void addJobData_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand addGWDRecord = new SqlCommand("insert into GWDTracker (JobN, Client, Tool, Modem, ModemVer, CircHrs, MaxTemp, SurveyEng1, SurveyEng2, Eng1arr, Eng2arr, Eng1left, Eng2left, Container, ContArr, ContLeft, Comments, Rig, Issues) values('"
                + textBoxJobN.Text + "','" + textBoxClient.Text + "', '" + textBoxToolN.Text + "','" 
                + textBoxModem.Text + "', '" + textBoxModVer.Text + "', '" + textBoxCirHrs.Text + "', '"
                + textBoxMaxTemp.Text + "', '" + comboBoxEng1.Text+ "', '" + comboBoxEng2.Text + "','" + textBoxEng1arr.Text + "','" 
                + textBoxEng2Arr.Text + "','" + textBoxEng1left.Text + "','" + textBoxEng2left.Text + "','" 
                + textBoxCont.Text + "','" + textBoxConArr.Text + "','" + textBoxConLeft.Text + "','" 
                + textBoxComments.Text + "','" + textBoxRig.Text + "', '" + comboBoxIssues.Text + "');", con);
            try
            {
                addGWDRecord.ExecuteNonQuery();
                MessageBox.Show("Data " + textBoxJobN.Text + " added!");
            }catch(SqlException except)
            {
                MessageBox.Show("" + except);
            }
            finally
            {
                
                con.Close();
            }
            clearGWDTracker();

        }

        private void dataGridView1_cell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridAllEquipment.Rows[e.RowIndex];
                textBoxItem.Text = row.Cells[0].Value.ToString().Trim();
                textBoxAsset.Text = row.Cells[1].Value.ToString().Trim();
                textBoxArrived.Text = row.Cells[2].Value.ToString().Trim();
                textBoxInvoice.Text = row.Cells[3].Value.ToString().Trim();
                textBoxCCD.Text = row.Cells[4].Value.ToString().Trim();
                textBoxRus.Text = row.Cells[5].Value.ToString().Trim();
                textBoxPos.Text = row.Cells[6].Value.ToString().Trim();
                textBoxStatus.Text = row.Cells[7].Value.ToString().Trim();
                comboBoxBox.Text = row.Cells[8].Value.ToString().Trim();
                textBoxContainer.Text = row.Cells[9].Value.ToString().Trim();
                textBoxComment.Text = row.Cells[10].Value.ToString().Trim();
            }
        }

        private void dataGWDPM_cell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGWDPM.Rows[e.RowIndex];
                textBoxJobN.Text = row.Cells[0].Value.ToString().Trim();
                textBoxClient.Text = row.Cells[1].Value.ToString().Trim();
                textBoxToolN.Text = row.Cells[2].Value.ToString().Trim();
                gwdBullPlug.Text = row.Cells[3].Value.ToString().Trim();
                textBoxModem.Text = row.Cells[4].Value.ToString().Trim();
                textBoxModVer.Text = row.Cells[5].Value.ToString().Trim();
                textBoxCirHrs.Text = row.Cells[6].Value.ToString().Trim();
                textBoxMaxTemp.Text = row.Cells[7].Value.ToString().Trim();
                comboBoxEng1.Text = row.Cells[8].Value.ToString().Trim();
                comboBoxEng2.Text = row.Cells[9].Value.ToString().Trim();
                textBoxEng1arr.Text = row.Cells[10].Value.ToString().Trim();
                textBoxEng2Arr.Text = row.Cells[11].Value.ToString().Trim();
                textBoxEng1left.Text = row.Cells[12].Value.ToString().Trim();
                textBoxEng2left.Text = row.Cells[13].Value.ToString().Trim();
                textBoxCont.Text = row.Cells[14].Value.ToString().Trim();
                textBoxConArr.Text = row.Cells[15].Value.ToString().Trim();
                textBoxConLeft.Text = row.Cells[16].Value.ToString().Trim();
                textBoxComments.Text = row.Cells[17].Value.ToString().Trim();
                textBoxRig.Text = row.Cells[18].Value.ToString().Trim();
                comboBoxIssues.Text = row.Cells[19].Value.ToString().Trim();
                labelId.Text = row.Cells[20].Value.ToString().Trim();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void updateRec_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand chg = new SqlCommand("update Emp set Arrived=@arrived, " +
                "Invoice=@invoice, CCD=@CCD, NameRus=@nameRus, PositionCCD=@positionCCD, " + 
                "Status=@status, Box=@box, Container=@container, Comment=@comment " + 
                "where Item=@item and Asset=@asset",con);
            chg.Parameters.AddWithValue("@item", textBoxItem.Text);
            chg.Parameters.AddWithValue("@asset", textBoxAsset.Text);
            chg.Parameters.AddWithValue("@arrived", textBoxArrived.Text);
            chg.Parameters.AddWithValue("@invoice", textBoxInvoice.Text);
            chg.Parameters.AddWithValue("@CCD", textBoxCCD.Text);
            chg.Parameters.AddWithValue("@NameRus", textBoxRus.Text);
            chg.Parameters.AddWithValue("@positionCCD", textBoxPos.Text);
            chg.Parameters.AddWithValue("@status", textBoxStatus.Text);
            chg.Parameters.AddWithValue("@box", comboBoxBox.Text);
            chg.Parameters.AddWithValue("@container", textBoxContainer.Text);
            chg.Parameters.AddWithValue("@comment", textBoxComment.Text);
            chg.ExecuteNonQuery();
            MessageBox.Show(textBoxItem.Text + " " + textBoxAsset.Text + " updated");
            con.Close();
        }

        private void buttonUpdateGWDPM_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectDB.Text == "Local Database")
            {
                SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\GWDTracker.db");
                conn.Open();
                string UpdateJobToSQLite_Query = @"UPDATE jobsAndPM SET JobN=@JobN, Client=@Client, 
                    Tool=@Tool, gwdBBP = @Gwdbbp, Modem=@Modem, ModemVer=@ModemVer, CircHrs=@CircHrs, MaxTemp=@MaxTemp, 
                    SurveyEng1=@SurveyEng1, SurveyEng2=@SurveyEng2, Eng1Arr=@Eng1Arr, Eng2Arr=@Eng2Arr,
                    Eng1Left=@Eng1Left, Eng2Left=@Eng2Left, Container=@Container, ContArr=@ContArr,
                    ContLeft=@ContLeft, Comments=@Comments, Rig=@Rig, Issues=@Issues WHERE id=@id";
                try {
                    SQLiteCommand cmd = new SQLiteCommand(UpdateJobToSQLite_Query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@JobN", textBoxJobN.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Client", textBoxClient.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Tool", textBoxToolN.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Gwdbbp", gwdBullPlug.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Modem", textBoxModem.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@ModemVer", textBoxModVer.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@CircHrs", textBoxCirHrs.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@MaxTemp", textBoxMaxTemp.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@SurveyEng1", comboBoxEng1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@SurveyEng2", comboBoxEng2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Eng1Arr", textBoxEng1arr.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Eng2Arr", textBoxEng2Arr.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Eng1Left", textBoxEng1left.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Eng2Left", textBoxEng2left.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Container", textBoxCont.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@ContArr", textBoxConArr.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@ContLeft", textBoxConLeft.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Comments", textBoxComments.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Rig", textBoxRig.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Issues", comboBoxIssues.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@id", labelId.Text));
                    cmd.CommandText = UpdateJobToSQLite_Query;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("" + textBoxJobN.Text + " updated in Local DB");
                }catch (SQLiteException ex){
                    MessageBox.Show("Error: " + ex);
                }
                
            }else {
                con.Open();
                try
                {
                    SqlCommand gwdUpdate = new SqlCommand("update GWDTracker set JobN=@jobn, Client=@client, Tool=@tool, " +
                    "Modem=@modem, ModemVer=@modemver, CircHrs=@circhrs, MaxTemp=@maxtemp, SurveyEng1=@surveyeng1, " +
                    "SurveyEng2=@surveyeng2, Eng1arr=@eng1arr, Eng2arr = @eng2arr, Eng1left=@eng1left, Eng2left=@eng2left, " +
                    "Container=@container, ContArr=@contarr, ContLeft=@contleft, Comments=@comments, Rig=@rig, Issues=@issues " +
                    "where id=@id", con);
                    gwdUpdate.Parameters.AddWithValue("@id", labelId.Text);
                    gwdUpdate.Parameters.AddWithValue("@jobn", textBoxJobN.Text);
                    gwdUpdate.Parameters.AddWithValue("@client", textBoxClient.Text);
                    gwdUpdate.Parameters.AddWithValue("@tool", textBoxToolN.Text);
                    gwdUpdate.Parameters.AddWithValue("@modem", textBoxModem.Text);
                    gwdUpdate.Parameters.AddWithValue("@modemver", textBoxModVer.Text);
                    gwdUpdate.Parameters.AddWithValue("@circhrs", textBoxCirHrs.Text);
                    gwdUpdate.Parameters.AddWithValue("@maxtemp", textBoxMaxTemp.Text);
                    gwdUpdate.Parameters.AddWithValue("@surveyeng1", comboBoxEng1.Text);
                    gwdUpdate.Parameters.AddWithValue("@surveyeng2", comboBoxEng2.Text);
                    gwdUpdate.Parameters.AddWithValue("@eng1arr", textBoxEng1arr.Text);
                    gwdUpdate.Parameters.AddWithValue("@eng2arr", textBoxEng2Arr.Text);
                    gwdUpdate.Parameters.AddWithValue("@eng1left", textBoxEng1left.Text);
                    gwdUpdate.Parameters.AddWithValue("@eng2left", textBoxEng2left.Text);
                    gwdUpdate.Parameters.AddWithValue("@container", textBoxCont.Text);
                    gwdUpdate.Parameters.AddWithValue("@contarr", textBoxConArr.Text);
                    gwdUpdate.Parameters.AddWithValue("@contleft", textBoxConLeft.Text);
                    gwdUpdate.Parameters.AddWithValue("@comments", textBoxComments.Text);
                    gwdUpdate.Parameters.AddWithValue("@rig", textBoxRig.Text);
                    gwdUpdate.Parameters.AddWithValue("@issues", comboBoxIssues.Text);
                    gwdUpdate.ExecuteNonQuery();
                    MessageBox.Show(textBoxJobN.Text + " " + "record updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void litt_battery_add(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdLittBatt = new SqlCommand("insert into LBatteries values('" + textBoxN.Text + "','"
                    + comboBoxNwUd.Text + "','" + textBoxSN1.Text + "','" + textBoxSN2.Text + "','"
                    + textBoxSN3.Text + "', '" + textBoxMD.Text + "', '" + textBoxWhr.Text + "', '" 
                    + commentBatts.Text + "');", con);
               con.Open();
               cmdLittBatt.ExecuteNonQuery();
               MessageBox.Show("Battery inserted");
               clear();
               con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void litt_batt_update(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand chg = new SqlCommand("update Lbatteries set boxN=@box, condition=@condit, " + 
                    "serNum1=@sr1, serNum2=@sr2, serNum3=@sr3, Date=@DateMan, Status=@locat, Comment=@comment " + 
                    "where serNUm1=@sr1", con);
            chg.Parameters.AddWithValue("@box", textBoxN.Text);
            chg.Parameters.AddWithValue("@condit", comboBoxNwUd.Text);
            chg.Parameters.AddWithValue("@sr1", textBoxSN1.Text);
            chg.Parameters.AddWithValue("@sr2", textBoxSN2.Text);
            chg.Parameters.AddWithValue("@sr3", textBoxSN3.Text);
            chg.Parameters.AddWithValue("@DateMan", textBoxMD.Text);
            chg.Parameters.AddWithValue("@locat", textBoxWhr.Text);
            chg.Parameters.AddWithValue("@comment", commentBatts.Text);
            chg.ExecuteNonQuery();
            MessageBox.Show("Battery " + textBoxSN1.Text + " status updated");
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip showAll = new ToolTip();
            showAll.SetToolTip(button11, "Show All");
            showAll.SetToolTip(generateExcel, "Import to Excel");
            showAll.SetToolTip(button13, "Clear Table");
            showAll.SetToolTip(RemUpdt, "Remove or update batteries");
            showAll.SetToolTip(buttonCircHrs, "Tool circulation hours");
            //ToolTips end
            //setting default item in comboBoxSelectDB
            comboBoxSelectDB.SelectedIndex = 0;
            //comboBoxSelectDB.Enabled = false;
            SQLiteCreation SQLiteCrt = new SQLiteCreation();
            SQLiteCrt.SQLiteDBcreateGWDTracker();
        }


        private void lithiumBatts_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.LithiumBattsView.Rows[e.RowIndex];
                textBoxN.Text = row.Cells[0].Value.ToString().Trim();
                comboBoxNwUd.Text = row.Cells[1].Value.ToString().Trim();
                textBoxSN1.Text = row.Cells[2].Value.ToString().Trim();
                textBoxSN2.Text = row.Cells[3].Value.ToString().Trim();
                textBoxSN3.Text = row.Cells[4].Value.ToString().Trim();
                textBoxMD.Text = row.Cells[5].Value.ToString().Trim();
                textBoxWhr.Text = row.Cells[6].Value.ToString().Trim();
                commentBatts.Text = row.Cells[7].Value.ToString().Trim();
                labelBattID.Text = row.Cells[8].Value.ToString().Trim();
            }
        }

        public void buttonCircHrs_Click(object sender, EventArgs e)
        {
            MenuStripCircHrs.Show(buttonCircHrs, 0, buttonCircHrs.Height);
        }

        public void GWDTrackerToExcel(DataGridView dataGWDPM, string excelfilename)
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Application.Workbooks.Add(Type.Missing);
            xla.Columns.ColumnWidth = 15;
            for (int i = 1; i < dataGWDPM.Columns.Count + 1; i++)
            {
                xla.Cells[1, i] = dataGWDPM.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGWDPM.Rows.Count; i++)
            {
                for (int j = 0; j < dataGWDPM.Columns.Count; j++)
                {
                    if (dataGWDPM.Rows[i].Cells[j].Value != null)
                    {
                        xla.Cells[i + 2, j + 1] = dataGWDPM.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            xla.Visible = true;
        }

        private void GWDPMToExcel_Click(object sender, EventArgs e)
        {
            //GWDTrackerToExcel(dataGWDPM, "ExportedUserDetail");
        }

        private void RemoveUpdate_Click(object sender, EventArgs e)
        {
            RemvUpdt RUpdt = new RemvUpdt();
            RUpdt.Show();
        }

        private void buttonBattFilter_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment FROM LBatteries";
            cmd.ExecuteNonQuery();
            System.Data.DataTable dt = new Lithium.LBatteriesDataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            LithiumBattsView.DataSource = da;
            con.Close();
        }

        private void tabPage2_selected(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                comboBoxSearch.Enabled = true;
                textBox7.Enabled = true;
            }
            else {
                comboBoxSearch.Enabled = false;
                textBox7.Enabled = false;
            }
        }

       private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Type here...")
            {
                textBox7.Text = "";
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Type here...";
            }
        }

        private void comboboxSort_Select(object sender, EventArgs e)
        {
            if (comboBoxSort.Text == "All Sorted by BoxN")
            {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
                    System.Data.DataSet dTableLithium = new System.Data.DataSet();
                    SQLite_conn.Open();
                    try
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment
                                    FROM lithium order by boxN, condition", SQLite_conn);
                        adapter.Fill(dTableLithium);
                        LithiumBattsView.DataSource = dTableLithium.Tables[0].DefaultView;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    SQLite_conn.Close();
                }
                else {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment
                                    FROM LBatteries order by boxN, condition", con);

                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    LithiumBattsView.DataSource = dt;
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Close();
                }
                
                int i, iD, numbNewBatts = 0, numbUsedBatts = 0, numbSLBbatts = 0, numbSentbatts = 0;
                for (i = 0, iD = 1; i < LithiumBattsView.Rows.Count - 1; i++, iD++)
                {
                    LithiumBattsView.Rows[i].Cells[8].Value = iD;
                    if (LithiumBattsView.Rows[i].Cells[1].Value.ToString().Trim() == "used")
                    {
                        LithiumBattsView.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Orange;
                        numbUsedBatts++;
                    }
                    else
                    {
                        LithiumBattsView.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.LightGreen;
                        numbNewBatts++;
                        if (LithiumBattsView.Rows[i].Cells[6].Value.ToString().Trim() == "AMD-015S")
                        {
                            numbSLBbatts++;
                        }
                        else if (LithiumBattsView.Rows[i].Cells[6].Value.ToString().Trim() != "AMD-015S")
                        {
                            numbSentbatts++;
                        }
                    }
                }
                int max = Int32.Parse(LithiumBattsView.Rows[0].Cells[0].Value.ToString().Trim());
                for (i = 1; i < LithiumBattsView.Rows.Count - 1; i++)
                {
                    if (Int32.Parse(LithiumBattsView.Rows[i].Cells[0].Value.ToString().Trim()) >
                            Int32.Parse(LithiumBattsView.Rows[i - 1].Cells[0].Value.ToString().Trim()))
                    {
                        max = Int32.Parse(LithiumBattsView.Rows[i].Cells[0].Value.ToString().Trim());
                    }
                }


                labelNEW.Text = numbNewBatts.ToString();
                labelUSED.Text = numbUsedBatts.ToString();
                labelTotalBatts.Text = (numbNewBatts + numbUsedBatts).ToString();
                labelBaseInfo.Text = numbSLBbatts.ToString();
                labelSentInfo.Text = numbSentbatts.ToString();
                labelBoxesTotal.Text = max.ToString();
            }
            else if (comboBoxSort.Text == "New Batteries At Base")
            {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
                    System.Data.DataSet dTableLithium = new System.Data.DataSet();
                    SQLite_conn.Open();
                    try
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT boxN, condition, serNum1, serNum2, 
                            serNum3, Date, Status, Comment, ID FROM lithium where condition = 'new' and Status = 'AMD-015S'", SQLite_conn);
                        adapter.Fill(dTableLithium);
                        LithiumBattsView.DataSource = dTableLithium.Tables[0].DefaultView;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    SQLite_conn.Close();
                }
                else {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment " +
                                        "FROM LBatteries where condition = 'new' and Status = 'AMD-015S'";
                    cmd.ExecuteNonQuery();
                    System.Data.DataTable dt = new Lithium.LBatteriesDataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    LithiumBattsView.DataSource = dt;
                    con.Close();
                }

                for (int i = 0; i < LithiumBattsView.Rows.Count - 1; i++)
                {
                    if (LithiumBattsView.Rows[i].Cells[6].Value.ToString().Trim() == "AMD-015S" &&
                        LithiumBattsView.Rows[i].Cells[1].Value.ToString().Trim() == "new")
                    {
                        LithiumBattsView.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.LightGreen;
                        LithiumBattsView.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[8].Style.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
            else if (comboBoxSort.Text == "All Batteries Sent")
            {
                if (comboBoxSelectDB.Text == "Local Database")
                {
                    SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
                    System.Data.DataSet dTableLithium = new System.Data.DataSet();
                    SQLite_conn.Open();
                    try
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(@"SELECT boxN, condition, serNum1, serNum2, 
                            serNum3, Date, Status, Comment, ID FROM lithium where 
                            Status != 'AMD-015S' order by boxN, condition", SQLite_conn);
                        adapter.Fill(dTableLithium);
                        LithiumBattsView.DataSource = dTableLithium.Tables[0].DefaultView;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    SQLite_conn.Close();
                }
                else {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT boxN, condition, serNum1, serNum2, serNum3, Date, Status, Comment " +
                                        "FROM LBatteries where Status != 'AMD-015S' order by boxN, condition";
                    cmd.ExecuteNonQuery();
                    System.Data.DataTable dt = new Lithium.LBatteriesDataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    LithiumBattsView.DataSource = dt;
                    con.Close();
                }
                
                for (int i = 0; i < LithiumBattsView.Rows.Count - 1; i++)
                {
                    if (LithiumBattsView.Rows[i].Cells[6].Value.ToString().Trim() != "AMD-015S" &&
                        LithiumBattsView.Rows[i].Cells[1].Value.ToString().Trim() == "new")
                    {
                        LithiumBattsView.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.LightGreen;
                        LithiumBattsView.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[8].Style.BackColor = System.Drawing.Color.LightGray;
                    }
                    else if (LithiumBattsView.Rows[i].Cells[6].Value.ToString().Trim() != "AMD-015S" &&
                        LithiumBattsView.Rows[i].Cells[1].Value.ToString().Trim() == "used")
                    {
                        LithiumBattsView.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Orange;
                        LithiumBattsView.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                        LithiumBattsView.Rows[i].Cells[8].Style.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
        }

        private void tabControl1_selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                buttonCircHrs.Enabled = true;
            }
            else if (tabControl1.SelectedTab != tabControl1.TabPages["tabPage3"])
            {
                buttonCircHrs.Enabled = false;
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])
            {
                RemUpdt.Enabled = true;
                button11.Enabled = false;
            }
            else if (tabControl1.SelectedTab != tabControl1.TabPages["tabPage4"])
            {
                RemUpdt.Enabled = false;
                button11.Enabled = true;
            }
        }

        private void dataGridSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridSearch.Rows[e.RowIndex];
                manifestNameRus.Text = row.Cells[5].Value.ToString();
                manifestItem.Text = row.Cells[0].Value.ToString();
                manifestUoM.Text = "шт";
                manifestPartNumber.Text = "n/a";
                manifestAsset.Text = row.Cells[1].Value.ToString();
                manifestCCD.Text = row.Cells[4].Value.ToString();
                manifestPosCCD.Text = row.Cells[6].Value.ToString();
                manifestCargoOwner.Text = "Gyrodata";
                manifestHazardClass.Text = "n/a";
            }

        }

        private void addToManif_Click(object sender, EventArgs e)
        {
            String textNameRus = manifestNameRus.Text;  //
            String textItem = manifestItem.Text;        //
            String textQuantity = "";                   //
            String textUoM = manifestUoM.Text;          //
            String textPartNumber = manifestPartNumber.Text;    //
            String textAsset = manifestAsset.Text;      //
            String textCCD = manifestCCD.Text;          //
            String textPosCCD = manifestPosCCD.Text;    //
            String textCargoOwner = manifestCargoOwner.Text;    //
            String textHazardCalss = manifestHazardClass.Text;  //
            String textL = "";
            String textW = "";
            String textH = "";
            String textWeight = "";
            String textLabelDetails = "";

            String[] row = { textNameRus, textItem, textQuantity, textUoM, textPartNumber,
                            textAsset, textCCD, textPosCCD, textCargoOwner, textHazardCalss,
                            textL, textW, textH, textWeight, textLabelDetails};
            dataGridToManifest.Rows.Add(row);
        }

        private void deleteFromManifest_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridToManifest.SelectedRows)
            {
                dataGridToManifest.Rows.RemoveAt(row.Index);
            }
        }

        private void buttonExportTxt_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                ExportToTXTFromDTGView(dataGridAllEquipment, "Items_");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                ExportToTXTFromDTGView(dataGridSearch, "Search results_");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                ExportToTXTFromDTGView(dataGWDPM, "Sakhalin GWD Tracker_");
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"]) {
                ExportToTXTFromDTGView(LithiumBattsView, "Lithium Batteries_");
            }
        }

        public void ExportToTXTFromDTGView(DataGridView datagridSelect, string beginName)
        {
            SaveFileDialog saveTxt = new SaveFileDialog();
            saveTxt.FileName = beginName + date + ".txt";
            if (saveTxt.ShowDialog() == DialogResult.OK)
            {
                TextWriter txtwriter = new StreamWriter(saveTxt.FileName);
                for (int i = 0; i < datagridSelect.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < datagridSelect.Columns.Count; j++)
                    {
                        txtwriter.Write(datagridSelect.Rows[i].Cells[j].Value.ToString().Trim() + ",");
                    }
                    txtwriter.Write("\r\n");
                }
                txtwriter.Close();
            }
        }

        private void buttonToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile= new SaveFileDialog();
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Data.DataTable dt = (System.Data.DataTable)this.dataGWDPM.DataSource;
                dt.WriteXml(this.saveFileDialog1.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void buttonItemToSqlite_Click(object sender, EventArgs e)
        {
            string addItemToSQLite_Query = @"INSERT INTO Equ (Item, Asset, Arrived, Invoice, CCD, NameRus,
                                            PositionCCD, Status, Box, Container, Comment) VALUES (@item, @asset,
                                            @arrived, @invoice, @CCD, @NameRus, @positionCCD, @status, @box, 
                                            @container, @comment)";
            SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\itemsAll.db");
            SQLiteCommand cmd = new SQLiteCommand(conn);
            conn.Open();
            cmd.Parameters.Add(new SQLiteParameter("@item", textBoxItem.Text));
            cmd.Parameters.Add(new SQLiteParameter("@asset", textBoxAsset.Text));
            cmd.Parameters.Add(new SQLiteParameter("@arrived", textBoxArrived.Text));
            cmd.Parameters.Add(new SQLiteParameter("@invoice", textBoxInvoice.Text));
            cmd.Parameters.Add(new SQLiteParameter("@CCD", textBoxCCD.Text));
            cmd.Parameters.Add(new SQLiteParameter("@NameRus", textBoxRus.Text));
            cmd.Parameters.Add(new SQLiteParameter("@positionCCD", textBoxPos.Text));
            cmd.Parameters.Add(new SQLiteParameter("@status", textBoxStatus.Text));
            cmd.Parameters.Add(new SQLiteParameter("@box", comboBoxBox.Text));
            cmd.Parameters.Add(new SQLiteParameter("@container", textBoxContainer.Text));
            cmd.Parameters.Add(new SQLiteParameter("@comment", textBoxComment.Text));
            cmd.CommandText = addItemToSQLite_Query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("" + textBoxItem.Text + " " + textBoxAsset.Text + "added to Local DB!");
        }

        private void buttonJobsToSQLite_Click(object sender, EventArgs e)
        {
            string addJobToSQLite_Query = @"INSERT INTO jobsAndPM (JobN, Client, Tool, gwdBBP, Modem, ModemVer,
                                            CircHrs, MaxTemp, SurveyEng1, SurveyEng2, Eng1Arr, Eng2Arr, Eng1Left, 
                                            Eng2Left, Container, ContArr, ContLeft, Comments, Rig, Issues) VALUES (
                                            @JobN, @Client, @Tool, @Gwdbbp, @Modem, @ModemVer, @CircHrs, @MaxTemp, @SurveyEng1,
                                            @SurveyEng2, @Eng1Arr,@Eng2Arr, @Eng1Left, @Eng2Left, @Container, @ContArr,
                                            @ContLeft, @Comments, @Rig, @Issues)";
            SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\GWDTracker.db");
            SQLiteCommand cmd = new SQLiteCommand(conn);
            conn.Open();
            cmd.Parameters.Add(new SQLiteParameter("@JobN", textBoxJobN.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Client", textBoxClient.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Tool", textBoxToolN.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Gwdbbp", gwdBullPlug.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Modem", textBoxModem.Text));
            cmd.Parameters.Add(new SQLiteParameter("@ModemVer", textBoxModVer.Text));
            cmd.Parameters.Add(new SQLiteParameter("@CircHrs", textBoxCirHrs.Text));
            cmd.Parameters.Add(new SQLiteParameter("@MaxTemp", textBoxMaxTemp.Text));
            cmd.Parameters.Add(new SQLiteParameter("@SurveyEng1", comboBoxEng1.Text));
            cmd.Parameters.Add(new SQLiteParameter("@SurveyEng2", comboBoxEng2.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Eng1Arr", textBoxEng1arr.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Eng2Arr", textBoxEng2Arr.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Eng1Left", textBoxEng1left.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Eng2Left", textBoxEng2left.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Container", textBoxCont.Text));
            cmd.Parameters.Add(new SQLiteParameter("@ContArr", textBoxConArr.Text));
            cmd.Parameters.Add(new SQLiteParameter("@ContLeft", textBoxConLeft.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Comments", textBoxComments.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Rig", textBoxRig.Text));
            cmd.Parameters.Add(new SQLiteParameter("@Issues", comboBoxIssues.Text));
            cmd.CommandText = addJobToSQLite_Query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("" + textBoxJobN.Text + " added to Local DB");

        }

        private void buttonLBToSQLite_Click(object sender, EventArgs e)
        {
            string addBattToSQLite_Query = @"INSERT INTO lithium (boxN, condition, serNum1, serNum2, serNum3,
                                            Date, Status, Comment) VALUES ("+textBoxN.Text.Trim()+",'"+comboBoxNwUd.Text.Trim()+"','"
                                            +textBoxSN1.Text.Trim()+"','"+textBoxSN2.Text.Trim()+"','"+textBoxSN3.Text.Trim()+"','"
                                            +textBoxMD.Text.Trim()+"','"+textBoxWhr.Text.Trim()+"','"+commentBatts.Text.Trim()+"')";
            SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
            SQLiteCommand cmd = new SQLiteCommand(SQLite_conn);
            SQLite_conn.Open();
            cmd.CommandText = addBattToSQLite_Query;
            if (textBoxN.Text == "")
            {
                MessageBox.Show("Box Number can not be blank");
            }
            else {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Battery " + textBoxSN1.Text + " added to Local DB");

                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                SQLite_conn.Close();
            }
        }

        private void toolCircHoursToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double circHoursItem = circHoursTotal.itemCircHoursTotal(dataGWDPM, comboTools, 2, 6);
            if (comboTools.Text == "")
            {
                MessageBox.Show("Select Tool Number\r\n\r\n*If no Tools in the List, load the Jobs");
            }
            else
            {
                MessageBox.Show("Circ Hours for " + comboTools.Text + ": " + circHoursItem
                    + ", " + Math.Round(circHoursItem / 500 * 100, 2) + "%");
            }
        }

        private void toolJobLogCircHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboTools.Text == "")
            {
                MessageBox.Show("Please select the Tool");
            }
            else
            {
                circHoursJobLogCalculating circHrsTool = new circHoursJobLogCalculating("Tool", date);
                circHrsTool.printCircHoursToTxt(dataGWDPM, comboTools, 2, 6);
            }

        }

        private void modemCircHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double circHoursItem = circHoursTotal.itemCircHoursTotal(dataGWDPM, comboModems, 4, 6);
            if (comboModems.Text == "")
            {
                MessageBox.Show("Select Modem Number\r\n\r\n*If no Modem in the List, load the Jobs");
            }
            else
            {
                MessageBox.Show("Circ Hours for " + comboModems.Text + ": " + circHoursItem
                    + ", " + Math.Round(circHoursItem / 500 * 100, 2) + "%");
            }
        }

        private void modemJobLogCircHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboModems.Text == "")
            {
                MessageBox.Show("Please select the Modem");
            }
            else
            {
                circHoursJobLogCalculating circHrsModem = new circHoursJobLogCalculating("Modem", date);
                circHrsModem.printCircHoursToTxt(dataGWDPM, comboModems, 4, 6);
            }
        }

        private void bBPLGCircHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double circHoursItem = circHoursTotal.itemCircHoursTotal(dataGWDPM, comboGWDbbp, 3, 6);
            if (comboGWDbbp.Text == "")
            {
                MessageBox.Show("Select BullPlug Number\r\n\r\n*If no BullPlug in the List, load the Jobs");
            }
            else
            {
                MessageBox.Show("Circ Hours for " + comboGWDbbp.Text + ": " + circHoursItem
                    + ", " + Math.Round(circHoursItem / 500 * 100, 2) + "%");
            }
        }

        private void bBPLGJobLogCircHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboGWDbbp.Text == "")
            {
                MessageBox.Show("Please select the BullPlug");
            }
            else
            {
                circHoursJobLogCalculating circHrsBBP = new circHoursJobLogCalculating("GWD Bull Plug", date);
                circHrsBBP.printCircHoursToTxt(dataGWDPM, comboGWDbbp, 3, 6);
            }
        }

        private void sqliteUpdt_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
            conn.Open();
            string UpdateBatteriesToSQLite_Query = @"UPDATE lithium SET boxN=@boxn,
                                                        condition=@condition, 
                                                        serNum1=@sernum1,
                                                        serNum2=@sernum2, 
                                                        serNum3=@sernum3,
                                                        Date=@date,
                                                        Status=@status,
                                                        Comment=@comment WHERE ID=@id";
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(UpdateBatteriesToSQLite_Query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@boxn", Int32.Parse(textBoxN.Text)));
                cmd.Parameters.Add(new SQLiteParameter("@condition", comboBoxNwUd.Text));
                cmd.Parameters.Add(new SQLiteParameter("@sernum1", textBoxSN1.Text));
                cmd.Parameters.Add(new SQLiteParameter("@sernum2", textBoxSN2.Text));
                cmd.Parameters.Add(new SQLiteParameter("@sernum3", textBoxSN3.Text));
                cmd.Parameters.Add(new SQLiteParameter("@date", textBoxMD.Text));
                cmd.Parameters.Add(new SQLiteParameter("@status", textBoxWhr.Text));
                cmd.Parameters.Add(new SQLiteParameter("@comment", commentBatts.Text));
                cmd.Parameters.Add(new SQLiteParameter("@id", labelBattID.Text));
                cmd.CommandText = UpdateBatteriesToSQLite_Query;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("" + textBoxSN1.Text + " updated in Local DB");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}