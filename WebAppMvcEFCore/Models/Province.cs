using System.Collections.Generic;

namespace WebAppMvcEFCore.Models
{
    public class Province
    {
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
