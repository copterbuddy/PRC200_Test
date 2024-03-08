using Entitiy.AI2IS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.AI2IS;

public class AI2ISOptionBuilder
{
    private readonly DbContextOptionsBuilder<AI2ISContext> builder;

    public AI2ISOptionBuilder(string connectionString, int commandTimeoutInMinute)
    {
        builder = new DbContextOptionsBuilder<AI2ISContext>();
        builder.UseSqlServer(connectionString, opts =>
        {
            opts.EnableRetryOnFailure();
            opts.CommandTimeout((int)TimeSpan.FromMinutes(commandTimeoutInMinute).TotalSeconds);
        });
    }

    internal DbContextOptions Build()
    {
        return builder.Options;
    }
}
