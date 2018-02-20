using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Insert_Data
{
    class SQLiteCreation
    {
        public void SQLiteDBcreateGWDTracker() {
            if (!File.Exists("SQLite Local\\GWDTracker.db"))
            {
                SQLiteConnection.CreateFile("SQLite Local\\GWDTracker.db");
                string createItemsTable = @"CREATE TABLE IF NOT EXISTS
                                    [jobsAndPM] (
                                    [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    [JobN] NVARCHAR(15) NULL, 
                                    [Client] NVARCHAR(15) NULL,
                                    [Tool] NVARCHAR(7) NULL,
                                    [gwdBBP] NVARCHAR(12) NULL,
                                    [Modem] NVARCHAR(7) NULL,
                                    [ModemVer] NVARCHAR(10) NULL,
                                    [CircHrs] NVARCHAR(10) NULL,
                                    [MaxTemp] NVARCHAR(10) NULL,
                                    [SurveyEng1] NVARCHAR(30)  NULL,
                                    [SurveyEng2] NVARCHAR(30)  NULL,
                                    [Eng1Arr] NVARCHAR(10)  NULL,
                                    [Eng2Arr] NVARCHAR(10)  NULL,
                                    [Eng1left] NVARCHAR(10)  NULL,
                                    [Eng2left] NVARCHAR(10)  NULL,
                                    [Container] NVARCHAR(10) NULL,
                                    [ContArr] NVARCHAR(10) NULL,
                                    [ContLeft] NVARCHAR(10) NULL,
                                    [Comments] NTEXT NULL,
                                    [Rig] NVARCHAR(20) NULL,
                                    [Issues] NVARCHAR(3) NULL)";

                SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\GWDTracker.db");
                SQLiteCommand cmd = new SQLiteCommand(SQLite_conn);
                SQLite_conn.Open();
                cmd.CommandText = createItemsTable;
                cmd.ExecuteNonQuery();
                SQLite_conn.Close();
            }
            if (!File.Exists("SQLite Local\\itemsAll.db"))
            {
                SQLiteConnection.CreateFile("SQLite Local\\itemsAll.db");
                string createItemsTable = @"CREATE TABLE IF NOT EXISTS
                                    [Equ] (
                                    [Item] NVARCHAR(20) NULL,
                                    [Asset] NVARCHAR(20) NULL, 
                                    [Arrived] NVARCHAR(19) NULL,
                                    [Invoice] NVARCHAR(11) NULL,
                                    [CCD] NVARCHAR(50) NULL,
                                    [NameRus] NVARCHAR(250) NULL,
                                    [PositionCCD] NUMERIC(3,0) NULL,
                                    [Status] NVARCHAR(20) NULL,
                                    [Box] NTEXT NULL,
                                    [Container] NVARCHAR(10) NULL,
                                    [Comment] NTEXT NULL)";
                SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\itemsAll.db");
                SQLiteCommand cmd = new SQLiteCommand(SQLite_conn);
                SQLite_conn.Open();
                cmd.CommandText = createItemsTable;
                cmd.ExecuteNonQuery();
                SQLite_conn.Close();
            }
            if (!File.Exists("SQLite Local\\LBatteries.db"))
            {
                SQLiteConnection.CreateFile("SQLite Local\\LBatteries.db");
                string createBattsTable = @"CREATE TABLE IF NOT EXISTS
                                    [lithium] (
                                    [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    [boxN] INTEGER(3) NULL, 
                                    [condition] NVARCHAR(4) NULL,
                                    [serNum1] NVARCHAR(20) NULL,
                                    [serNum2] NVARCHAR(20) NULL,
                                    [serNum3] NVARCHAR(20) NULL,
                                    [Date] NVARCHAR(20) NULL,
                                    [Status] NVARCHAR(20) NULL,
                                    [Comment] NVARCHAR(50) NULL)";

                SQLiteConnection SQLite_conn = new SQLiteConnection("data source = SQLite Local\\LBatteries.db");
                SQLiteCommand cmd = new SQLiteCommand(SQLite_conn);
                SQLite_conn.Open();
                cmd.CommandText = createBattsTable;
                cmd.ExecuteNonQuery();
                SQLite_conn.Close();
            }
        }
    }
}
