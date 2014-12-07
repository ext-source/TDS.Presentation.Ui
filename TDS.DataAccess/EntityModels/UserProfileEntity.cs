using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNet.Identity.EntityFramework;

namespace TDS.DataAccess.EntityModels
{
    [Table("UserProfile")]
    public class UserProfileEntity : IdentityUser
    {
    }
}