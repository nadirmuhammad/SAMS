﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class AspNetRoleRepository : BaseRepository<AspNetRole>, IAspNetRoleRepository
    {
        public AspNetRoleRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<AspNetRole> DbSet
        {
            get { return db.UserRoles; }
        }
        public IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin()
        {
            return DbSet.Where(x => x.Name != "SuperAdmin");
        }
    }
}
