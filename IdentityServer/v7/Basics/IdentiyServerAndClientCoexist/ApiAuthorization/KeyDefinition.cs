using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class KeyDefinition
    {
        public string Type { get; set; }
        public bool? Persisted { get; set; }
        public string FilePath { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string StoreLocation { get; set; }
        public string StoreName { get; set; }
        public string StorageFlags { get; set; }
    }
}
