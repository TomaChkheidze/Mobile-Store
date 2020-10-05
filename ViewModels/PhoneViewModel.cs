using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Picture { get; set; }
    }
}
