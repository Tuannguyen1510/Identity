using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Test.Models;
using Test.ViewModels;

namespace Test.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public DbSet<Group> Dbgroups { get; set; }

        public DbSet<Course> Dbcourses { get; set; }

        
        // file thêm 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims" , "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens" , "security");


            builder.Entity<Group>().HasKey(u => u.IdGroups);

            builder.Entity<Course>().HasKey(c => c.IdCourses);

            builder.Entity<Course>()
                .HasOne(c => c.group)
                .WithMany(u => u.courses)
                .HasForeignKey(c => c.IdGroups)
                .OnDelete(DeleteBehavior.Restrict);

        }




    }
}














// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using API.Data;
// using API.Models;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// namespace API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ShippersController : ControllerBase
//     {
//         private readonly MyDbContext _context;

//         public ShippersController(MyDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Shippers
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             var ship = _context.Shippers.ToList();
//             return Ok(Ok(ship));
//         }

//         // GET: api/Shippers/5
//         [HttpGet("{id}")]
//         public IActionResult GetById(int id)
//         {
//             var ship = _context.Shippers.SingleOrDefault(x => x.Id == id);
//             if (ship != null)
//             {
//                 return Ok(Ok(ship));
//             }
//             else
//             {
//                 return NotFound();
//             }

//         }
//         [HttpPost]

//         public IActionResult Create(ShipperModels model)
//         {
//             try
//             {
//                 var ship = new Shipper
//                 {
//                     Name = model.Name,
//                     Phone = model.Phone,
//                     Company = model.Company,
//                 };

//                 _context.Add(model);
//                 _context.SaveChanges();
//                 return Ok();
//             }
//             catch (Exception)
//             {

//                 return BadRequest();
//             }
//         }

//         // 

//         [HttpPut]
//         public IActionResult UpdateById(int id, ShipperModels models)
//         {
//             var ship = _context.Shippers.SingleOrDefault(x => x.Id == id);

//             if(ship != null)
//             {
//                 ship.Name = models.Name;
//                 ship.Phone = models.Phone;
//                 ship.Company = models.Company;
//                 _context.SaveChanges();
//                 return Ok();
//             }
//             else
//             {
//                 return NotFound();
//             }
//         }


//     }
	
// }





