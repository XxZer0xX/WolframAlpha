using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WolframAlphaWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Browser = new WebBrowser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = new WolframAlpha.HtmlResultQuery( "british flag" ).Execute();

            // setting up testing for display of HTML result.
            Browser.DocumentStream = new MemoryStream( new byte[2000] );
        }
    }
}
