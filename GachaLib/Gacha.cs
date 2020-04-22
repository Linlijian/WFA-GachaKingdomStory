using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachaLib
{
    public class Gacha
    {

        #region prop
        private bool Event;
        private string EventRemark;
        private double[] Luckys;

        private List<GachaponModel> MGachapons;
        private List<GachaponModel> MRollResult;
        private List<GachaponItemModel> MGachaponItems;
        #endregion

        #region model
        public class GachaponModel
        {
            public string Rank { get; set; }
            public int Start { get; set; }
            public double Rate { get; set; }
            public string GachaponType { get; set; }
            public double[] Luckys { get; set; }
    }
        public class GachaponItemModel
        {
            public string Name { get; set; }
            public string Rank { get; set; }
            public string Remark { get; set; }
            public int Start { get; set; }
        }
        #endregion

        #region contraster
        public Gacha()
        {
            MGachapons = new List<GachaponModel>();
            MRollResult = new List<GachaponModel>();
            MGachaponItems = new List<GachaponItemModel>();
        }
        #endregion

        #region Method
        public void AddGachapon(string _rank, int _start, double _rate, string _gachaponType)
        {
            var gacha = new GachaponModel();

            gacha.Rank = _rank;
            gacha.Rate = _rate;
            gacha.Start = _start;
            gacha.GachaponType = _gachaponType;

            MGachapons.Add(gacha);
        }
        public void AddGachaponItem(string _rank, int _start, string _name, string _remark = "")
        {
            var item = new GachaponItemModel();

            item.Rank = _rank;
            item.Name = _name;
            item.Start = _start;
            item.Remark = _remark;

            MGachaponItems.Add(item);
        }
        public void OpenGachapon(bool rolls = false)
        {
            double weight = AddGachaponLucky();
            Random rnd = new Random();

            if (!rolls)
            {
                Rolls(weight);
            }
            else
            {

            }
        }
        private void Rolls(double _weight)
        {
            Random rnd = new Random();
            int rndLucky = rnd.Next(0, _weight.AsInt());

            //find sss ss s <=============

            //continue
        }
        private double AddGachaponLucky()
        {
            double weight = SummaryRates((from _rate in MGachapons select new GachaponModel { Rate = _rate.Rate }).ToList());
            //Luckys = new double[weight.AsInt()];
            //CalculatorRate();

            //foreach (var result in MRollResult)
            //{
            //    result.Luckys = new double[result.Rate.AsInt()];
            //    MRollResult.MergeObject(LuckyRate(result, weight));
            //}

            return weight;
        }
        //private GachaponModel LuckyRate(GachaponModel _result, double _weight)
        //{
        //    Random rnd = new Random();
        //    int rndLucky;


        //    //while (i < _result.Rate)
        //    //{
        //    //    rndLucky = rnd.Next(0, _weight.AsInt());

        //    //    if (i == 0) _result.Luckys[i++] = rndLucky;
        //    //    if (Array.FindAll(_result.Luckys, element => element == rndLucky).Count() > 0) continue;

        //    //    _result.Luckys[i] = rndLucky;
        //    //    i++;
        //    //}

        //    int i = (from l in Luckys where l != 0 select l).Count();
        //    int next = _result.Rate.AsInt() + i;
        //    while (i < next)
        //    {
        //        rndLucky = rnd.Next(0, _weight.AsInt());

        //        if (i == 0)
        //        {
        //            Luckys[i] = rndLucky;
        //            i++;
        //            continue;
        //        }
        //        if (Array.FindAll(Luckys, element => element == rndLucky).Count() > 0) continue;

        //        Luckys[i] = rndLucky;
        //        i++;
        //    }


        //    return _result;
        //}
        private void CalculatorRate()
        {
            foreach (var cal in MGachapons)
            {
                MRollResult.Add(new GachaponModel
                {
                    Rate = cal.Rate * 100,
                    Start = cal.Start,
                    Rank = cal.Rank
                });
            }           
        }
        public void EventGachapon(string _eventRemark = "", bool _event = true)
        {
            if (_eventRemark == "") return;

            int isEvent = MGachaponItems.Select(t => t.Remark == _eventRemark).Count();
            if (isEvent > 0)
            {
                Event = _event;
                EventRemark = _eventRemark;
            }            
        }
        private double SummaryRates(List<GachaponModel> _rates)
        {
            double sum = 0;
            foreach (var rates in _rates)
            {
                sum += rates.Rate * 100;
            }

            return sum;
        }
        public List<GachaponModel> InfoGachapon()
        {
            return MGachapons;
        }
        public List<GachaponItemModel> InfoGachaponItem()
        {
            return MGachaponItems;
        }

        //get remark
        //set remark
        private void AddRate(List<GachaponModel> _rates)
        {
           
        }
        #endregion

    }
}
