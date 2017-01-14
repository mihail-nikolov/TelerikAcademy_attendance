﻿using System.Collections.Generic;
using System.Linq;

namespace FastAndFurious.ConsoleApplication.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetById<T>(this IEnumerable<T> collection, int id) where T : IIdentifiable<int>
        {
            return collection.FirstOrDefault(x => x.Id == id);
        }
        
    }
}
