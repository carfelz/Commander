using Commander.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class CommanderBbContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public CommanderBbContext( DbContextOptions<CommanderBbContext> options ) : base(options)
        {
            //
        }


    }
}
