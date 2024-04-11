using Castle.DynamicProxy.Generators.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Application.Abstraction.Services;

namespace UnicamParadigmi.Application.Middlewares
{
    public class MiddlewareExample
    {
        private RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILibroService libroService)
        {
            context.RequestServices.GetRequiredService<ILibroService>();
            await _next.Invoke(context);
        }
    }
}
