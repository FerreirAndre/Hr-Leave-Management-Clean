using Hr.LeaveManagement.Domain.Common;

namespace Hr.LeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public int DefaultDays { get; set; }
}