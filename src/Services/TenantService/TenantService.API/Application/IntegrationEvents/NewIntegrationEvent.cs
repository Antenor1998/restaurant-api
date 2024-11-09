using SharedKernel.lib.Messaging;

namespace TenantService.API.Application.IntegrationEvents;

public class NewIntegrationEvent : IntegrationEvent {
    public string EmployeeId { get; }
    public string ClienteAlias { get; }
    public string AttendanceRecordId { get; }

    public NewIntegrationEvent(string attendanceRecordId, string clienteAlias, string employeeId) {
        AttendanceRecordId = attendanceRecordId;
        ClienteAlias = clienteAlias;
        EmployeeId = employeeId;
    }
}
