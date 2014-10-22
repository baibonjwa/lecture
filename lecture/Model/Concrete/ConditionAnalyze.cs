using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using System.Data.SqlClient;
using lecture.Model.Entities;

namespace lecture.Model.Concrete
{
    public class ConditionAnalyze : IConditionAnalyze
    {
        public String AndAnalyze(MultCondition mc)
        {
            String results = "";
            for (int i = 0; i < mc.ConditionList.Count; i++)
            {
                results += " and " + mc.ConditionList[i].ConditionName + ConvertOperate(mc.ConditionList[i].Operator) + mc.ConditionList[i].ConditionValue;
            }
            return results;
        }
        public SqlParameter[] AndAnalyzePara(MultCondition mc, ref String sqlstr)
        {
            SqlParameter[] para = new SqlParameter[mc.ConditionList.Count];

            for (int i = 0; i < mc.ConditionList.Count; i++)
            {
                if (mc.ConditionList[i].Operator != Operator.Like)
                {
                    para[i] = new SqlParameter();
                    sqlstr += " and " + mc.ConditionList[i].ConditionName + ConvertOperate(mc.ConditionList[i].Operator) + "@" + mc.ConditionList[i].ConditionName;
                    para[i].ParameterName = "@" + mc.ConditionList[i].ConditionName;
                    para[i].Value = mc.ConditionList[i].ConditionValue;
                }
                else
                {
                    para[i] = new SqlParameter();
                    sqlstr += " and " + mc.ConditionList[i].ConditionName + " " + ConvertOperate(mc.ConditionList[i].Operator) + " " + "@" + mc.ConditionList[i].ConditionName;
                    para[i].ParameterName = "@" + mc.ConditionList[i].ConditionName;
                    para[i].Value = "" + mc.ConditionList[i].ConditionValue + "%";
                    sqlstr += " escape '/' ";
                }
            }
            return para;
        }
        public String OrAnalyze(MultCondition mc)
        {
            String results = "";
            for (int i = 0; i < mc.ConditionList.Count; i++)
            {
                results += " and " + mc.ConditionList[i].ConditionName + ConvertOperate(mc.ConditionList[i].Operator) + mc.ConditionList[i].ConditionValue;
            }
            return results;
        }
        public SqlParameter[] OrAnalyzePara(MultCondition mc, ref String sqlstr)
        {
            SqlParameter[] para = new SqlParameter[mc.ConditionList.Count];

            for (int i = 0; i < mc.ConditionList.Count; i++)
            {
                para[i] = new SqlParameter();
                sqlstr += " and " + mc.ConditionList[i].ConditionName + ConvertOperate(mc.ConditionList[i].Operator) + "@" + mc.ConditionList[i].ConditionName;
                para[i].ParameterName = "@" + mc.ConditionList[i].ConditionName;
                para[i].Value = mc.ConditionList[i].ConditionValue;
            }
            return para;
        }

        private String ConvertOperate(Operator op)
        {
            string results = "";
            switch (op)
            {
                case Operator.Equal:
                    {
                        results = "=";
                        break;
                    }
                case Operator.LessThan:
                    {
                        results = "<";
                        break;
                    }
                case Operator.LessThanAndEqual:
                    {
                        results = "<=";
                        break;
                    }
                case Operator.MoreThan:
                    {
                        results = ">";
                        break;
                    }
                case Operator.MoreThanAndEqual:
                    {
                        results = ">=";
                        break;
                    }
                case Operator.NotEqual:
                    {
                        results = "<>";
                        break;
                    }
                case Operator.Like:
                    {
                        results = "like";
                        break;
                    }
            }
            return results;
        }

    }
}