﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace TMD.Repository.Repositories
{
    public class InquiryRepository : BaseRepository<Inquiry>, IInquiryRepository
    {
        public InquiryRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Inquiry> DbSet
        {
            get { return db.Inquiry; }
        }

        public Inquiry GetInquiryAndInquiryDetail(int inquiryid)
        {
            return DbSet.Include(x => x.InquiryDetails).FirstOrDefault(x => x.InquiryID.Equals(inquiryid));
        }

    }
}
