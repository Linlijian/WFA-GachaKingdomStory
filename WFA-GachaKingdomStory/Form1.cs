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

            gacha.AddGachapon(Rarity.SS, 3, 9.5, "Rate Up");
            gacha.AddGachapon(Rarity.SSS,5, 0.005, "Rate Up");
            gacha.AddGachapon(Rarity.S, 1, 90, "Rate Up");

            gacha.AddGachaponItem(Rarity.S,1,"LUBU","HUN");
            gacha.AddGachaponItem(Rarity.SS, 1, "WEIBU", "HUN");
            gacha.AddGachaponItem(Rarity.S, 1, "MUBU", "HUN");

            gacha.AddGachaponItem(Rarity.SSS, 1, "POIT", "WEI");
            gacha.AddGachaponItem(Rarity.SS, 1, "ADRR", "WEI");
            gacha.AddGachaponItem(Rarity.S, 1, "LOOIU", "WEI");

            gacha.AddGachaponItem(Rarity.SS, 1, "SHUSHI", "SHU");
            gacha.AddGachaponItem(Rarity.SSS, 1, "SHULIO", "SHU");
            gacha.AddGachaponItem(Rarity.SSS, 1, "SHUSHU", "SHU");

            //gacha.OpenGachapon(true);
            //var aa = gacha.InfoGachaponResult();


            //event X2.5
            gacha.EventGachapon(2.5,true,"HUN");
            gacha.OpenGachapon(true);
            var aaa = gacha.InfoGachaponResult();
        }
    }
}
