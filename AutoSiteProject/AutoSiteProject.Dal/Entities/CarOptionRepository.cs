﻿using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.Dal.Interfaces;

namespace AutoSiteProject.Dal.Entities
{
    public class CarOptionRepository : GenericRepository<CarOption>
    {
        public CarOptionRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            
        }
    }
}
