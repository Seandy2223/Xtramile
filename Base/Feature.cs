using Microsoft.Extensions.Configuration;
using Xtramile.Base.CustomException;
using Xtramile.Base.Interface;

namespace Xtramile.Base
{
    public class Feature : IFeature
    {
        private readonly IConfiguration _configuration;

        public Feature(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetFeatureConfig(string feature)
        {
            var featureValue = _configuration[$"Features:{feature}"];
            if (string.IsNullOrWhiteSpace(featureValue))
                throw new FeatureNotFoundException("Feature not Found");

            return featureValue;
        }
    }
}
