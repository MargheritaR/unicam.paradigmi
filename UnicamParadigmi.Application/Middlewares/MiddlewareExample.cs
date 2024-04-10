using Castle.DynamicProxy.Generators.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Application.Services;

namespace UnicamParadigmi.Application.Middlewares
{
    public class MiddlewareExample
    {
        private RequestDelegate _next;
        private readonly LibroService _libroService;
        public MiddlewareExample(RequestDelegate next, LibroService libroService) 
        {
            _next = next;
            _libroService = libroService;
        }

        public async Task Invoke(HttpContext context)
        {
            //dopo lo implementiamo
            await _next.Invoke(context);
        }
    }
}
