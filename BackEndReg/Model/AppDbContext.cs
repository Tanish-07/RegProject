using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndReg.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SignUp> SaveSignUp { get; set; }

        public DbSet<adminLogin> AdminLogins { get; set; }


        //SignUp Table
        [Table("userLog")]
        public class SignUp
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; }
            public string fullName { get; set; } = null;
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

        //Login DTO
        public class LoginDTO
        {
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

        //Admin Table
        [Table("adminCredentials")]
        public class adminLogin
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; }
            public string emailId { get; set; } = null;
            public string password { get; set; } = null;
        }

    }
}
