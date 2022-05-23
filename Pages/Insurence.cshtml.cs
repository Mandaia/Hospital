using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Hospital.Pages
{
    public class InsurenceModel : PageModel
    {

        private readonly IConfiguration _configuration;
        public List<Insurence> insurences = new List<Insurence>();

        public InsurenceModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            insurences = GetInsurenceList();
        }

        private List<Insurence> GetInsurenceList()
        {
            throw new NotImplementedException();
        }

        private List<Insurence> GetInsurenceList(List<Insurence> insurences)
        {
            insurences = GetInsurenceList(insurences);
            return insurences;
        }
    }
}
