using ViafacilReceipts.Dtos;
using ViafacilReceipts.Entities;

namespace ViafacilReceipts.Mapping;

public static class ReceiptMapping
{
    public static Receipt ToReceipt(this CreateReceiptDto createDto, string number, float value)
    {
        return new Receipt
        {
            Number = number,
            Value = value,
            Products = createDto.Products.Select(p => p.Id).ToArray(),
            Status = createDto.Status
        };
    }

    // public static Receipt ToReceipt(this UpdateReceiptDto updateDto)
    // {
    //     return new Receipt
    //     {
    //         Name = updateDto.Name,
    //         Description = updateDto.Description,
    //         Amount = updateDto.Amount
    //     };
    // }
}
