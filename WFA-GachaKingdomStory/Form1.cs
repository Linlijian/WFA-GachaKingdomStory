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

            Random rnd = new Random();
            int rndLucky = rnd.Next(1, 100);


            var gacha = new Gacha();

            gacha.AddGachapon(Rarity.SS, 1, 70, "Rate Up");
            gacha.AddGachapon(Rarity.SSS, 3, 0.5, "Rate Up");
            gacha.AddGachapon(Rarity.S, 1, 90, "Rate Up");
            gacha.OpenGachapon();

            var a = gacha.InfoGachapon();
        }
    }
}
