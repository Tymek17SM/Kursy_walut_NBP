using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using WebAPI.Wrappers;

namespace WebAPI.Middelwares
{
    public class ErrorHandlingMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NbpApiException nbpexception)
            {
                context.Response.StatusCode = (int)nbpexception.HttpResponseMessage.StatusCode;

                var message = await nbpexception.HttpResponseMessage.Content.ReadAsStringAsync();
                message = message.ToLower().Contains("Brak danych".ToLower()) ? "Brak danych o kursie" : message;

                await context.Response.WriteAsJsonAsync(new Response(false, message));
            }
            catch(InputDataException exception)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new Response(false, exception.Message));
            }
            catch
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response(false, "Coś poszło nie tak :/"));
            }
        }
    }
}
