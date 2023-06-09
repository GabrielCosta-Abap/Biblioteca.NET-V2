﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext (DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca.Models.Autor> Autor { get; set; } = default!;

        public DbSet<Biblioteca.Models.Cliente>? Cliente { get; set; }

        public DbSet<Biblioteca.Models.Livro>? Livro { get; set; }

        public DbSet<Biblioteca.Models.Locacao>? Locacao { get; set; }

        public DbSet<Biblioteca.Models.Usuario>? Usuario { get; set; }
    }
}
