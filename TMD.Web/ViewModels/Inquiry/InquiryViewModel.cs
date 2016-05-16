﻿using System.Collections.Generic;
using Models=TMD.Web.Models;

namespace TMD.Web.ViewModels.Inquiry
{
    public class InquiryViewModel
    {
        public InquiryViewModel()
        {
            Contacts = new List<Models.ContactModel>();
            Products=new List<Models.Product>();
            InquiryDetail= new List<Models.InquiryDetailModel>();
        }
        public Models.InquiryModel InquiryModel { get; set; }
        public IList<Models.ContactModel> Contacts { get; set; }
        public IList<Models.Product> Products { get; set; }
        public IList<Models.InquiryDetailModel> InquiryDetail { get; set; }
    }
}