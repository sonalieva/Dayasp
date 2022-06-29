using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dayasp.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Profession { get; set; }
        [MaxLength(200)]
        public string Desc { get; set; }

        public string TwitUrl { get; set; }
        public string FbUrl { get; set; }
        public string InsUrl { get; set; }
        public string LinkUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
