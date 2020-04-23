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

        private List<GachaponLuckyModel> MGachaponsLucky;
        private List<GachaponModel> MGachapons;
        private List<GachaponModel> MRollResult;
        private List<GachaponItemModel> MRollResults;
        private List<GachaponItemModel> MGachaponItems;
        #endregion

        #region model
        public class GachaponModel
        {
            public Rarity Rank { get; set; }
            public int Start { get; set; }
            public double Rate { get; set; }
            public string GachaponType { get; set; }
            public List<GachaponLuckyModel> MGachaponsLuckys { get; set; }
            public List<GachaponItemModel> MItemResult { get; set; }
        }
        public class GachaponItemModel
        {
            public string Name { get; set; }
            public Rarity Rank { get; set; }
            public string Remark { get; set; }
            public int Start { get; set; }
        }
        public class GachaponLuckyModel
        {
            public double Lucky { get; set; }
            public Rarity Rank { get; set; }
        }
        #endregion

        #region contraster
        public Gacha()
        {
            MGachapons = new List<GachaponModel>();
            MRollResult = new List<GachaponModel>();
            MRollResults = new List<GachaponItemModel>();
            MGachaponItems = new List<GachaponItemModel>();
            MGachaponsLucky = new List<GachaponLuckyModel>();
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
                Rolls(weight, 10);
            }


        }
        private void Rolls(double _weight, int _count)
        {
            Random rnd = new Random();
            double rndLucky;
            
            //find sss ss s <=============
            for (int i = 1; i <= _count; i++)
            {
                rndLucky = rnd.Next(0, _weight.AsInt());
              
                foreach(var result in MRollResult)
                {
                    if (result.MGachaponsLuckys.Where(w => w.Lucky == rndLucky).Count() > 0) 
                    {
                        MRollResults.Add(WhereItem(result));
                        break;
                    }
                }
            }

            //continue
            
        }
        private GachaponItemModel WhereItem(GachaponModel _result)
        {
            //find item in MGachaponItems
            var item = new GachaponItemModel();
            if (!Event)
            {
                 item = (from items in MGachaponItems where items.Rank == _result.Rank select items).PickRandom();
            }
            else
            {
                //evemt
            }
            return item;
        }
        private double AddGachaponLucky()
        {
            double weight = SummaryRates((from _rate in MGachapons select new GachaponModel { Rate = _rate.Rate }).ToList());

            CalculatorRate();
            foreach (var result in MRollResult)
            {
                MRollResult.MergeObject(CalculatorLucky(result));
            }
            
            return weight;
        }
        private GachaponModel CalculatorLucky(GachaponModel _result)
        {
            int i = MGachaponsLucky.Count();
            int next = _result.Rate.AsInt() + i;

            for(int round =0;round < _result.Rate; round++)
            {
                MGachaponsLucky.Add(new GachaponLuckyModel { Lucky = i, Rank = _result.Rank });
                i++;
            }

            _result.MGachaponsLuckys = MGachaponsLucky.Where(m => m.Rank == _result.Rank)
                .Select(m => new GachaponLuckyModel { Lucky = m.Lucky, Rank = m.Rank }).ToList();
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
        public List<GachaponItemModel> InfoGachaponResult()
        {
            return MRollResults;
        }

        //get remark
        //set remark
        private void AddRate(List<GachaponModel> _rates)
        {
           
        }
        #endregion

    }
}
