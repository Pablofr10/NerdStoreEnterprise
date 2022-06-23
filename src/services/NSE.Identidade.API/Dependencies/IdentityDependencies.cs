using Microsoft.AspNetCore.Identity;
using NSE.Identidade.API.Data;

namespace NSE.Identidade.API.Dependencies;

public static class IdentityDependencies
{
    public static void IdentityDependency(this IServiceCollection service)
    {
        service.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); }
    
}