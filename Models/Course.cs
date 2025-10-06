﻿using Microsoft.EntityFrameworkCore;

namespace TestingPlatform.Models
{

    [Index(nameof(Name), IsUnique = true)]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        
        public List<Group> Groups { get; set; }
        public List<Test> Tests { get; set; }
    }
}
