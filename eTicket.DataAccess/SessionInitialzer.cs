using eTicket.DataAccess.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess
{
    public class SessionInitialzer
    {
        //public static ShoppingCart Initialze(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<IHttpContextAccessor>();
        //        var Dbcontext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        //        var CartId = context.HttpContext?.Session.GetString("CartId");
        //        if (CartId is null)
        //        {
        //            CartId = Guid.NewGuid().ToString();
        //            context.HttpContext?.Session.SetString("CartId", CartId);
        //        }
        //        return new ShoppingCart(Dbcontext) { ShoppingCartId = CartId };
        //    }
        //}
    }
}
