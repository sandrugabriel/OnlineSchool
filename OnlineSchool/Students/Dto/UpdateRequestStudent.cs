﻿using OnlineSchool.Books.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineSchool.Students.Dto
{
    public class UpdateRequestStudent
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? Age { get; set; }

    }
}
