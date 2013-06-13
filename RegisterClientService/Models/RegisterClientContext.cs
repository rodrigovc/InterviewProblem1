using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegisterClientService
{
    /// <summary>
    /// Contexto de dados para EntityFramework.
    /// </summary>
    public class RegisterClientContext : DbContext
    {
        /// <summary>
        /// Usuários.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}