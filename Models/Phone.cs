using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Models
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public float Weight { get; set; }
        public float ScreenSize { get; set; }
        public string ScreenResolution { get; set; }
        public string CPU { get; set; }
        public float RAM { get; set; }
        public float Memory { get; set; }
        public string OS { get; set; }
        public float Price { get; set; }
        public string[] Media { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
