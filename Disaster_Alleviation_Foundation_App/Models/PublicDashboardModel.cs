using System;
using System.Collections.Generic;

namespace Disaster_Alleviation_Foundation_App.Models
{
    public class PublicDashboardModel
    {
        public decimal TotalMonetaryDonations { get; set; }
        public int TotalGoodsReceived { get; set; }
        public List<ActiveDisasterInfo> ActiveDisasters { get; set; }
    }

    public class ActiveDisasterInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
