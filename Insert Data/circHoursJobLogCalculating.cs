using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Insert_Data
{
    class circHoursJobLogCalculating
    {
        public string item;
        public string date;

        public double circHrsItem;                                 //Total circ hours calculated
        ComboboxLoading cmbbLg = new ComboboxLoading();     //initialize the component fo ComboboxLoading

        public circHoursJobLogCalculating(string item, string date) {    //Class constructor
            this.item = item;
            this.date = date;
        }

        public void printCircHoursToTxt(DataGridView dtgv, ComboBox cmbb, int itemIndex, int circIndex) {

            //For Tool itemIndex = 2        //circIndex = 6
            //For Modem itemIndex = 4
            //For GWDBBP itemIndex = 3

            circHrsItem = cmbbLg.itemCircHoursTotal(dtgv, cmbb, itemIndex, circIndex);
            SaveFileDialog saveTxt = new SaveFileDialog();
            saveTxt.FileName = item + " " + cmbb.Text + " Job Log.txt";
            if (saveTxt.ShowDialog() == DialogResult.OK)
            {
                TextWriter txtwriter = new StreamWriter(saveTxt.FileName);
                txtwriter.Write("File created: " + date + "\t\t\tGyrodata Sakhalin Inventory\r\n");
                txtwriter.Write("\r\n");
                txtwriter.Write(item + " " + cmbb.Text + "\r\n");
                txtwriter.Write("\r\n");
                txtwriter.Write("Job Numbers\t\tCirc Hrs\r\n");
                txtwriter.Write("\r\n");
                for (int i = 0; i < dtgv.Rows.Count - 1; i++)
                {
                    if (dtgv.Rows[i].Cells[itemIndex].Value.ToString().Trim() == cmbb.Text)
                    {
                        txtwriter.Write(dtgv.Rows[i].Cells[0].Value.ToString().Trim() + "\t\t");
                        txtwriter.Write(dtgv.Rows[i].Cells[circIndex].Value.ToString().Trim());
                        txtwriter.Write("\r\n");
                    }
                }
                txtwriter.Write("______________________________");
                txtwriter.Write("\r\n");
                txtwriter.Write("\r\n");
                txtwriter.Write("Total CircHrs: \t\t" + circHrsItem);
                txtwriter.Close();
            }
        }
    }
}
