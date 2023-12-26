using BusinessLogicLayer.DTOs.Dialog;
using BusinessLogicLayer.DTOs.Message;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IDialogService
    {
        Task SendMessage(MessageAddDto dto);
        Task Delete(long id);
        Task<DialogGetDto> GetById(long id);
        Task<ICollection<DialogGetDto>> GetAll();
        Task<ICollection<MessageGetDto>> GetMessagesByDialogId(long id);
    }
}
