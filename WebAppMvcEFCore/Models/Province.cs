using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppMvcEFCore.Models
{
    public class Province
    {
        [Key]
        [MaxLength(30)]
        [DisplayName("Province Code")]
        public string ProvinceCode { get; set; }
        [DisplayName("Province")]
        public string ProvinceName { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
