﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Data.Preparation
{
    public class TrainingData
    { 
        public string Id { get; set; }
        public string? SportTeamId { get; set; }
        public string? Title { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}