using System;

namespace CustomerWcf
{
    internal class EnableCorsAttribute : Attribute
    {
        private string origins;
        private string headers;
        private string methods;

        public EnableCorsAttribute(string origins, string headers, string methods)
        {
            this.origins = origins;
            this.headers = headers;
            this.methods = methods;
        }
    }
}