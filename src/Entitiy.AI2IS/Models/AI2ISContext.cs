using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.AI2IS.Models;

public partial class AI2ISContext : DbContext
{
    public AI2ISContext()
    {
    }

    public AI2ISContext(DbContextOptions<AI2ISContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
