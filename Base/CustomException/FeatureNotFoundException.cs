using System;

namespace Xtramile.Base.CustomException
{
    public class FeatureNotFoundException : Exception
    {
        public FeatureNotFoundException()
        {
        }

        public FeatureNotFoundException(string message)
            : base(message)
        {
        }

        public FeatureNotFoundException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
