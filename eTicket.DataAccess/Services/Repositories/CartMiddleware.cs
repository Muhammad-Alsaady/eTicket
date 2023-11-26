using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class CartMiddleware
    {
        private readonly RequestDelegate _next;

        public CartMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.Session.GetString("CartId") == null)
            {
                context.Session.SetString("CartId", Guid.NewGuid().ToString());
            }

            await _next(context);
        }
    }
   
}
