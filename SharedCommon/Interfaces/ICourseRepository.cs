﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCommon.Entities;

namespace SharedCommon.Interfaces
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        List<Course> GetCourses(string CourseIDFilter);
    }
}