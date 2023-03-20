﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence.Repositories
{
    public class CarRepository : Repostiory<Car>, ICarRepository
    {
        public CarRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
