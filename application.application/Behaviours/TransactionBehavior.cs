using application.application.Abstractions.Messaging;
using application.application.Abstractions.Persistence;
using MediatR;

namespace application.application.Behaviours
{
    public sealed class TransactionBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Queries should NOT open transactions
            if (request is not ICommand)
                return await next();

            try
            {
                var response = await next();

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return response;
            }
            catch
            {
                // DB transaction rollback happens in Infrastructure
                throw;
            }
        }
    }
}
