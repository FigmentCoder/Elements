using System.Threading.Tasks;

using Elements.Common.Types;
using Elements.Models;

namespace Elements.Services
{
    public interface IRequestAccess
    {
        Task<Result> Request();
    }

    public interface IAddReminder
    {
        Task<ReminderDto> Add(ReminderDto reminderDto);
    }

    public interface IRemoveReminder
    {
        Task<ReminderDto> Remove(ReminderDto reminderDto);
    }
}