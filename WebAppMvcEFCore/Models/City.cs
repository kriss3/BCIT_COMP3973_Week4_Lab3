using System.ComponentModel;

namespace WebAppMvcEFCore.Models
{
    public class City
    {
        public int CityId { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        public int Population { get; set; }

        public string ProvinceCode { get; set; }
        public Province Province { get; set; }
    }
}
