using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.DTO;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.ViewModels
{
    public partial class SupplementDetailsViewModel: ObservableObject
    {


        private readonly ISupplementDetailService _supplementDetailService;

        public SupplementDetailsViewModel(ISupplementDetailService supplementDetailService)
        {
            _supplementDetailService = supplementDetailService;
        }

        [ObservableProperty]
        private int dayNum;

        [ObservableProperty]
        private decimal amount;


        [ObservableProperty]
        private TimeSpan startTime;

        [ObservableProperty]
        private TimeSpan endTime;

        [ObservableProperty]
        private string companyName;


        [ObservableProperty]
        private string status;
     

        [RelayCommand]
        public async Task AddSupplementDetail()
        {
            var supplementDetail = new SupplementDetailsDTO
            {
                Weekday=(DayOfWeek)dayNum,
                Amount = amount,
                StartTime=DateTime.Today.Add(startTime),
                EndTime=DateTime.Today.Add(endTime)
                
            };
            var supplementDetails = new List<SupplementDetailsDTO> { supplementDetail };

           var response = await _supplementDetailService.AddSupplementDetails(supplementDetails, companyName);

            if (response != null)
            {
                Status = "Succesfully added supplement detail";
            }
            else
            {
                Status = "Error adding supplement detail";
            }

        }



    }
}
