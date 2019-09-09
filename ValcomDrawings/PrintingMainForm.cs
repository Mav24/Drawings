﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValcomData;

namespace ValcomDrawings
{
    public partial class PrintingMainForm : Form
    {
        public PrintingMainForm()
        {
            InitializeComponent();
        }
        public List<DrawingLine> drawingLineItems;
        public Drawing drawing;

        private void PrintingMainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Drawing Printout for {drawing.BOMDescription}";
            ReportParameter[] rParams = new ReportParameter[]
            {
                new ReportParameter("Description", drawing.BOMDescription),
                new ReportParameter("PrintDate", DateTime.Now.ToLongDateString())
            };
            reportViewer1.LocalReport.SetParameters(rParams);
            DataTable1BindingSource.DataSource = drawingLineItems;
            this.reportViewer1.RefreshReport();
        }
    }
}
