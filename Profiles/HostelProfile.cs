using AutoMapper;
using ath_hostels.ViewModels;
using ath_hostels.Models;

namespace ath_hostels.Profiles
{
    public class HostelProfile: Profile
    {
        public HostelProfile()
        {
            CreateMap<Hostel, HostelViewModel>();
        }
            
    }
}
