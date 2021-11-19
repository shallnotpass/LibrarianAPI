using LibrarianApi.BuisnessLayer;
using LibrarianApi.BuisnessLayer.Contracts;
using LibrarianApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibrarianApi
{
	public static class ServicesConfiguration
	{
		public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IBookService, BookService>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
		}
	}
}
