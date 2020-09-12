using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext
{
    public class SecurityPaymentContext : DbContext
    {
        public SecurityPaymentContext(DbContextOptions<SecurityPaymentContext> options) : base(options) { }

    } 
}
