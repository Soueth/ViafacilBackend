using ViafacilReceipts.Dtos;
using ViafacilReceipts.Entities;
using ViafacilReceipts.Typing;

namespace ViafacilReceipts.Interfaces;

public interface IReceiptService
{
    Task<Receipt> CreateReceipt(CreateReceiptDto createReceipt);
    Task<bool?> UpdateReceipt(Guid id, UpdateReceiptDto updateReceipt);
    // Task<ChangeStatusResponse> PrintReceipt(Guid id);
    Task<Receipt?> FindReceipt(Guid id);
    Task<List<Receipt>> FindReceipts(QueryReceiptDto queryDto);
    // Task<bool?> DeleteReceipt(Guid id);
}
