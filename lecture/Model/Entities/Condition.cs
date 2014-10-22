using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lecture.Model.Entities
{
    public enum Operator
    {
        Equal,
        NotEqual,
        MoreThan,
        MoreThanAndEqual,
        LessThan,
        LessThanAndEqual,
        Like
    }
    public class Condition
    {
        public String ConditionName { set; get; }
        public String ConditionValue { set; get; }
        public Operator Operator { set; get; }
    }
    public class MultCondition
    {
        private List<Condition> _conditionList = new List<Condition>();
        public List<Condition> ConditionList
        {
            set
            {
                _conditionList = ConditionList;
            }
            get
            {
                return _conditionList;
            }
        }
        public void AddCondition(Condition r)
        {
            _conditionList.Add(r);
        }
        public void RemoveCondition(Condition r)
        {
            _conditionList.Remove(r);
        }
    }
}