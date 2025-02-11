﻿using Quadro.Globalization.Attributes;
using Quadro.Interface.Customers;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Entities.Customers
{
    public class CustomerDto : StorableGuid, ICustomerEntity
    {
        public string ERPId { get; set; } = null!;

        [Header("Name", Globalization.Language.en)]
        [Header("Naam", Globalization.Language.nl)]
        public string Name { get; set; } = string.Empty;

        public string? PriceListId { get; set; }
    }
}
