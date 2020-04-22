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
        private List<string> Ranks;
        private List<int> Starts;
        private List<float> Rates;
        private List<string> GachaponTypes;

        private List<GachaponModel> MGachapons;
        private List<GachaponItemModel> MGachaponItems;
        #endregion

        #region model
        public class GachaponModel
        {
            public string Rank { get; set; }
            public int Start { get; set; }
            public float Rate { get; set; }
            public string GachaponType { get; set; }
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
            MGachaponItems = new List<GachaponItemModel>();
        }
        #endregion

        #region Method
        public void AddGachapon(string _rank, int _start, float _rate, string _gachaponType)
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
        public void OpenGachapon(int _gold = 0, bool roll = false)
        {
            
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
        public List<GachaponModel> InfoGachapon()
        {
            //AddRank((from _ranks in MGachapons select new GachaponModel { Rank = _ranks.Rank }).ToList());
            return MGachapons;
        }
        public List<GachaponItemModel> InfoGachaponItem()
        {
            //AddRank((from _ranks in MGachapons select new GachaponModel { Rank = _ranks.Rank }).ToList());
            return MGachaponItems;
        }
        private void AddRank(List<GachaponModel> _ranks)
        {
            foreach(var rank in _ranks)
            {
                Ranks.Add(rank.Rank);
            }
        }
        private void AddStar(List<GachaponModel> _starts)
        {
            foreach (var start in _starts)
            {
                Starts.Add(start.Start);
            }
        }
        private void AddGachapon(List<GachaponModel> _gachaponType)
        {
            foreach (var gachaponType in _gachaponType)
            {
                GachaponTypes.Add(gachaponType.ToString());
            }
        }
        private void AddRate(List<GachaponModel> _rates)
        {
            foreach (var rates in _rates)
            {
                Rates.Add(rates.Rate);
            }
        }
        #endregion

    }
}
