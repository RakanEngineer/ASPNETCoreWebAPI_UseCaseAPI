using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI_UseCaseAPI.Dtos.Tickets
{
    public record ChangePriorityDto([Range(1, 5)] int Priority);
}
