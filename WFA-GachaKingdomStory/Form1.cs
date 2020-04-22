using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GachaLib;

namespace WFA_GachaKingdomStory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var gacha = new Gacha();

            gacha.AddGachapon("SS","4","0.12","Rate Up");
            gacha.AddGachapon("SS", "5", "0.02", "Rate Up");
            gacha.OpenGachapon(3000);

            var a = gacha.InfoGachapon();
        }
    }
}
