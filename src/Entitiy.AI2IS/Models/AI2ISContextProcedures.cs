using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.AI2IS.Models;

public partial class AI2ISContext
{
    private IAI2ISContextProcedures _procedures;

    public virtual IAI2ISContextProcedures Procedures
    {
        get
        {
            if(_procedures is null) _procedures = new AI2ISContextProcedures(this);
            return _procedures;
        }
        set
        {
            _procedures = value;
        }
    }

    public IAI2ISContextProcedures GetProdures()
    {
        return Procedures;
    }

    protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
    {
        
    }
}

public partial class AI2ISContextProcedures : IAI2ISContextProcedures
{
    private readonly AI2ISContext _context;

    public AI2ISContextProcedures(AI2ISContext context)
    {
        _context = context;
    }
}
