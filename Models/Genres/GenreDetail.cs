﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Genres
{
    public class GenreDetail
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
