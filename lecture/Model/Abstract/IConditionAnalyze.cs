using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;
using System.Data.SqlClient;

namespace lecture.Model.Abstract
{
    public interface IConditionAnalyze
    {
        String AndAnalyze(MultCondition mc);
        SqlParameter[] AndAnalyzePara(MultCondition mc, ref String sqlstr);
        String OrAnalyze(MultCondition mc);
        SqlParameter[] OrAnalyzePara(MultCondition mc, ref String sqlstr);
    }
}