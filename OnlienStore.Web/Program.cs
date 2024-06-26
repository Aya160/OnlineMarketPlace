using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Identity;
using OnlineStore.Core.Services;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.Helpers;

namespace OnlienStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            // Add services to the container.

            #region Identity&Token services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                //option.Password.RequiredLength = 8;
                //option.Password.RequireUppercase = false;
                //option.Password.RequireNonAlphanumeric = false;
                //option.User.RequireUniqueEmail = true;
            })
    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            #endregion

            #region AddScoped

            builder.Services.AddScoped<ITokenService,TokenService>();

            builder.Services.AddScoped(typeof(CategoryRepo<>));

            builder.Services.AddScoped(typeof(ProductRepo<>));
            //builder.Services.AddAutoMapper(typeof(MappingProfile));

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
