using AutoMapper;
using MediatR;
using Persons.Application.Common.Exceptions;
using Persons.Application.Common.GenericHandler;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.Interfaces.UnitOfWork;
using Persons.Domain.Base;
using Persons.Domain.Enum;

namespace Persons.Application.GenericHandler
{
    public class BaseCommandHandler<TCommand, TEntity, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : BaseCommand<TResponse>
        where TEntity : BaseEntity
        where TResponse : class
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseCommandHandler(IBaseRepository<TEntity> baseCrudService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseCrudService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            TEntity operationResult;

            await _unitOfWork.BeginTransaction();
            try
            {
                operationResult = request.ActionType switch
                {
                    ActionsTypes.Create => await _baseRepository.Add(entity),
                    ActionsTypes.Update => await _baseRepository.Update(entity),
                    ActionsTypes.Delete => await _baseRepository.Delete(entity.Id),
                    _ => throw new ArgumentException($"Action Type '{request.ActionType}' is not supported, you can only Create, Update or Delete")
                };

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                // Customize the exception handling as needed:
                if (ex is NotFoundException)
                    throw;
                else
                    throw new Exception($"An error occurred during the {request.ActionType} operation: {ex.Message}", ex);
            }

            return _mapper.Map<TResponse>(operationResult);
        }
    }
}