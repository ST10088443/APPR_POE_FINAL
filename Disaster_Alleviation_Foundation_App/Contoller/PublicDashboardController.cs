using Disaster_Alleviation_Foundation_App.Models;
using Microsoft.AspNetCore.Mvc;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Disaster_Alleviation_Foundation_App.Data;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation_App.Contoller
{
    public class PublicDashboardController : Controller
    {
        private readonly DAFContext AppDbContext; // Replace with your actual context

        public PublicDashboardController(DAFContext context)
        {
            AppDbContext = context;
        }
        public IActionResult Index()
        {
            var model = new PublicDashboardModel
            {
                TotalMonetaryDonations = AppDbContext.MonetaryDonation.Sum(d => d.Amount),
                TotalGoodsReceived = AppDbContext.GoodsDonation.Sum(d => d.NumberOfItems),
                ActiveDisasters = AppDbContext.Disaster
                .Where(d => IsDisasterActive(d)) // Implement your logic for active disasters
                .Select(d => new ActiveDisasterInfo
                {
                    Name = d.Name,
                    Description = d.Description,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate
                })
                .ToList()
            };

            return View(model);
        }

        private bool IsDisasterActive(Disaster disaster)
        {

            return DateTime.Now >= disaster.StartDate && DateTime.Now <= disaster.EndDate;
        }
    }
}
