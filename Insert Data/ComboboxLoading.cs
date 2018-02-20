using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Insert_Data
{
    class ComboboxLoading
    {
        //components for loading the Tools to Combobox:
        string Tool1, Tool2, temp, temptodelete;

        //temporary array
        string[] arrTool = new string[100];

        public void toolLoading(DataGridView datagridView, ComboBox comboBox, int indexTool)
        {

            int p = 0, t = 0, w = 0, n = 0, m = 0;

            //loading Tools into ComboBox
            for (int i = 0; i < datagridView.Rows.Count - 1; i++)
            {
                arrTool[n] = datagridView.Rows[i].Cells[indexTool].Value.ToString().Trim();
                n++;
            }
            for (t = 1; t < n; t++)
            {
                for (w = 0; w < n - t; w++)
                {
                    if (arrTool[w].CompareTo(arrTool[w + 1]) > 0)
                    {
                        temp = arrTool[w];
                        arrTool[w] = arrTool[w + 1];
                        arrTool[w + 1] = temp;
                    }
                }
            }
            for (t = 0; t < datagridView.Rows.Count - 1; t++)
            {
                if (arrTool[t] == arrTool[t + 1] || arrTool[t] == "")
                {
                    continue;
                }
                else
                {
                    comboBox.Items.Add(arrTool[t]);
                }
            }
        }

        public double itemCircHoursTotal(DataGridView givenDataGridView, ComboBox itemTextFromBox, int itemIndex, int circHoursIndex) {
            double circHours = 0;
            string toolItem = itemTextFromBox.Text;         //Name of item from ComboBox
            for (int i = 0; i < givenDataGridView.Rows.Count - 1; i++)
            {
                if (givenDataGridView.Rows[i].Cells[itemIndex].Value.ToString().Trim() == itemTextFromBox.Text &&
                        givenDataGridView.Rows[i].Cells[circHoursIndex].Value.ToString().Trim() != "")
                {
                    circHours = Double.Parse(givenDataGridView.Rows[i].Cells[circHoursIndex].Value.ToString().Trim()) + circHours;
                }
            }
            return circHours;
        }

    }
}
