using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiJWT.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USR_RG")]

        public string RG {  get; set; }
    }
}
