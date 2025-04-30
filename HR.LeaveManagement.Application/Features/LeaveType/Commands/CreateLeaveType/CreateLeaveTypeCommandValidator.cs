using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
            .NotNull();
        
        RuleFor(x => x.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} must not exceed 100 characters")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("LeaveType already exists.");
        
        this._leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}