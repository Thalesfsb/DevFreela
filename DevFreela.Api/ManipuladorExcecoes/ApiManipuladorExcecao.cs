using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.ManipuladorExcecoes
{
    public class ApiManipuladorExcecao : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var detalhes = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = exception.Message + " Server error",
            };

            // Fazer o que preferir como logar o erro
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(detalhes, cancellationToken);

            return true;
        }
    }
}
