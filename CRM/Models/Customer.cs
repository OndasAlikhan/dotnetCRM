﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
