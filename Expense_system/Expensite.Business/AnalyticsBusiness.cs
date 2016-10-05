using Expensite.Data;
using Expensite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensite.Business
{
    public class AnalyticsBusiness
    {
        AnalyticsData analyticsData = new AnalyticsData();
        public List<TempEntity> data()
        {
            return analyticsData.data();
        }
        public List<Chart> GetPieChartData(List<AnalyticsEntity> entity)
        {
            //AnalyticsData analdata = new AnalyticsData();
            return analyticsData.GetPieChartData(entity);
        }
        public List<TempEntity> ExpensetypeId()
        {
            return analyticsData.ExpensetypeId();
        }

      
    }
}
