using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PUNTOVENTA.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.caja> cajas { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.dias_permitidos> dias_permitidos { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.cliente> clientes { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.venta> ventas { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.usuario> usuarios { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.categoria_producto> categoria_producto { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.impuesto> impuestoes { get; set; }

        public System.Data.Entity.DbSet<PUNTOVENTA.Models.producto> productoes { get; set; }
    }
}