﻿using Microsoft.EntityFrameworkCore;
using ToDo.Entidades;

namespace ToDo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<ToDoEntity> Todo { get; set; }
    }
}
