﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Homework
    {

        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public int  TimeSent { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
