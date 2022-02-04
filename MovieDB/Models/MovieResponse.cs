using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required(ErrorMessage ="Movie Title is Required")]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(100)]
        public string Notes { get; set; }

        //Build foreign key relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
