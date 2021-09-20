using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.CrossCutting.Configuration.Configurations;
using Xunit;

namespace TaskManager.CrossCutting.Configuration.Tests.Unit.Map
{
    public class MappingProfileTests
    {
        [Fact]
        public void MappingProfile_VerifyValidConfiguration()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            var mapper = new Mapper(config);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
