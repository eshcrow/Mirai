﻿using System.ComponentModel.DataAnnotations;

namespace Mirai.Database.Tables
{
    class Feed
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
