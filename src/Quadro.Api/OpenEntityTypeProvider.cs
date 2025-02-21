﻿using Quadro.DataModel.Entities.Customers;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public class OpenEntityTypeProvider : IEntityTypeProvider
    {
        private readonly Dictionary<string, Type> entityTypes = new Dictionary<string, Type>();

        public OpenEntityTypeProvider()
        {
            AddType<CustomerDto>();
        }

        private void AddType<T>()
        {
            entityTypes.Add(typeof(T).FullName!, typeof(T));
        }

        public Type GetType(string type)
        {
            var found = entityTypes.TryGetValue(type, out Type? value);
            if (!found)
                throw new Exception("Type not found");
            return value!;
        }
    }
}
