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
        private double EventRate;
        private double[] Luckys;

        private List<GachaponModel> MGachapons;
        private List<GachaponModel> MRollResult;
        private List<GachaponItemModel> MGachaponItems;
        #endregion

        #region model
        public class GachaponModel
        {
            public Rarity Rank { get; set; }
            public int Start { get; set; }
            public double Rate { get; set; }
            public string GachaponType { get; set; }
            public double[] Luckys { get; set; }
    }
        public class GachaponItemModel
        {
            public string Name { get; set; }
            public Rarity Rank { get; set; }
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
        public void AddGachapon(Rarity _rank, int _start, double _rate, string _gachaponType)
        {
            var gacha = new GachaponModel();

            gacha.Rank = _rank;
            gacha.Rate = _rate;
            gacha.Start = _start;
            gacha.GachaponType = _gachaponType;

            MGachapons.Add(gacha);
        }
        public void AddGachaponItem(Rarity _rank, int _start, string _name, string _remark = "")
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
                Rolls(weight, 1);
            }
            else
            {
                Rolls(weight, 9);
            }
        }
        private void Rolls(double _weight, int _count)
        {
            Random rnd = new Random();
            int rndLucky;

            //find sss ss s <=============
            for (int i = 0; i <= _count; i++)
            {
                rndLucky = rnd.Next(0, _weight.AsInt());
                switch (MGachapons[i].Rank)
                {
                    case Rarity.SSS:
                        if (rndLucky < MGachapons[i].Luckys.Count())
                        {
                            WhereEvent();
                        }
                        
                        break;
                    case Rarity.SS:
                        if (rndLucky < MGachapons[i].Rate)
                        {
                            WhereEvent();
                        }

                        break;
                    default:return;
                }
            }

            //continue
        }
        private void WhereEvent()
        {
           
        }
        private double AddGachaponLucky()
        {
            double weight = SummaryRates((from _rate in MGachapons select new GachaponModel { Rate = _rate.Rate }).ToList());
            bool first = true;
            Luckys = new double[weight.AsInt()];

            CalculatorRate();
            foreach (var result in MRollResult)
            {
                result.Luckys = new double[result.Rate.AsInt()];
                MRollResult.MergeObject(CalculatorLucky(result, weight, first));
                first = false;
            }
            
            return weight;
        }
        private GachaponModel CalculatorLucky(GachaponModel _result, double _weight, bool _first)
        {
            _result.Luckys = new double[_result.Rate.AsInt()];

            int i = (from l in Luckys where l != 0 select l).Count();
            int next = _result.Rate.AsInt() + i;

            for(int round =0;round < _result.Rate; round++)
            {
                if (_first)
                {
                    Luckys[i] = Luckys.Max().AsInt();
                    _result.Luckys[round] = Luckys[i];
                    _first = false;
                    i++;
                    continue;
                }

                if(Luckys.Max() > 0 && round == 0)
                {
                    Luckys[i] = Luckys.Max().AsInt() + 1;
                    _result.Luckys[round] = Luckys.Max().AsInt();
                    i+=2;
                    continue;
                }

                Luckys[i] = Luckys.Max().AsInt() + 1;
                _result.Luckys[round] = Luckys[i];
                i++;
            }

            return _result;        
        }
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
        public void EventGachapon(double _eventRate, string _eventRemark = "", bool _event = true)
        {
            EventRate = _eventRate * 100;
            Event = _event;

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

            return Event ? sum += EventRate : sum;
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
