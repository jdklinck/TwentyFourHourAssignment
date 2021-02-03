﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

    }
}
