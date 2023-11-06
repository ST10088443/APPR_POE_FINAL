using Disaster_Alleviation_Foundation_App.NewFolder;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Disaster_Alleviation_Foundation_App.NewFolder
{
    public class DonationListViewModel
    {
        public List<MonetaryDonation> MonetaryDonations { get; set; }
        public List<GoodsDonations> GoodsDonations { get; set; }
        public List<Disaster> Disasters { get; set; }
    }
}
