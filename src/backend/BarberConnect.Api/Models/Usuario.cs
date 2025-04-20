using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BarberConnect.Api.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
