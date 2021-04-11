using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;
namespace database1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection sc = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adap = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        private void Form3_Load(object sender, EventArgs e)
        {
            sc.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\George\Documents\sample.accdb";
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = "select * from address" ;

            adap.SelectCommand = cmd;
            adap.Fill(ds, "address");
            
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.ReportPath=@"C:\Users\George\Desktop\database1\database1\Report5.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();


            //this.reportViewer2.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Close();
            cmd.Dispose();
            adap.Dispose();
            ds.Dispose();
            this.reportViewer1.LocalReport.ReportPath = null;
            this.reportViewer1.LocalReport.DataSources.Clear();

            string sID = Microsoft.VisualBasic.Interaction.InputBox("Enter the ID", "ID");
            sc.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\George\Documents\sample.accdb";
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = "select * from address where EmpId=" + sID;
            DataSet ds1=new DataSet();
            adap.SelectCommand = cmd;
            adap.Fill(ds1, "address");

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            this.reportViewer1.LocalReport.ReportPath = @"C:\Users\George\Desktop\database1\database1\Report4.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
