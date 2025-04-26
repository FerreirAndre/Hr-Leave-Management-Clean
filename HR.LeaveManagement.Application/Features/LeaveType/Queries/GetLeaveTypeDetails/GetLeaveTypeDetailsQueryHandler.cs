using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);
        return data;
    }
}