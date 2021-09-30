using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace urlRegEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string regex = @"^https?:\/\/[a-z0-9.]+\.[a-z]+\/?";
            Regex r = new Regex(regex, RegexOptions.Compiled | RegexOptions.CultureInvariant);
            if (r.IsMatch(url))
            {
                string regex2 = @"[a-z]+\/?$";
                Regex r2 = new Regex(regex2, RegexOptions.Compiled | RegexOptions.CultureInvariant);
                string tld = Convert.ToString(r2.Match(url));
                tld = tld.EndsWith("/") ? tld.Remove(tld.Length - 1) : tld;
                string regex3 = "^https";
                Regex r3 = new Regex(regex3, RegexOptions.Compiled | RegexOptions.CultureInvariant);
                string protocol = r3.IsMatch(url) ? "HTTPS" : "HTTP";
                label1.Text = $"Valid URL; {protocol}; {tld}";
            }
            else
            {
                label1.Text = "Invalid URL";
            }
        }
    }
}
