﻿using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Authorization.Managers
{
    public class EditionManager : AbpEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureRepository)
            : base(
                editionRepository,
                editionFeatureRepository
            )
        {

        }
    }
}
