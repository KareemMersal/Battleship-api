using BattleShip.Api.CustomExceptions;
using BattleShip.Api.CustomProblemDetails;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShip.Api.AppStart
{
    public static class ProblemDetailsStartup
    {
        public static IServiceCollection AddCustomProblemDetailsMapping(this IServiceCollection services)
        {
            services
                .AddProblemDetails(setup =>
                {
                    setup.Map<DuplicateEntryException>(exception => new DuplicateProblemDetail
                    {
                        Title = "Duplicate Entry",
                        Detail = exception.Message,
                        Status = StatusCodes.Status409Conflict
                    });

                    setup.Map<ValidationModelException>(exception => new ValidationModelProblemDetail()
                    {
                        Title = "Validation Model Failed",
                        Detail = exception.ErrorMessage,
                        Status = StatusCodes.Status400BadRequest,
                        Type = exception.EntityType
                    });

                    setup.Map<InsertFailedException>(exception => new InsertFailedProblemDetail()
                    {
                        Title = "Insert to Database Failed",
                        Detail = exception.ErrorMessage,
                        Status = StatusCodes.Status400BadRequest,
                        Type = exception.EntityType
                    });

                    setup.Map<InvalidDataException>(exception => new InvalidDataProblemDetail()
                    {
                        Title = "Invalid Data",
                        Detail = exception.ErrorMessage,
                        Status = StatusCodes.Status400BadRequest,
                        Type = exception.EntityType
                    });
                });

            return services;
        }
    }
}
