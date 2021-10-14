using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Mapping
{
    public class MappingTest : IClassFixture<MappingTestFixture>
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public MappingTest(MappingTestFixture mappingTestFixture)
        {
            _configurationProvider = mappingTestFixture.ConfigurationProvider;
            _mapper = mappingTestFixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configurationProvider.AssertConfigurationIsValid();
        }
    }
}
