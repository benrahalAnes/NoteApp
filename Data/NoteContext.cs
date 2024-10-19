using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data
{
    public class NoteContext:DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options): base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        
    }
}