﻿using AutoSiteProject.Models.Bl.Interfaces.Managers;
using AutoSiteProject.Models.Dal.Interfaces;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.Bl.Managers
{
    public class CountryManager : BaseManager<Country>, ICountryManager
    {
        public CountryManager(IGenericRepository<Country> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            
        }
    }
}
