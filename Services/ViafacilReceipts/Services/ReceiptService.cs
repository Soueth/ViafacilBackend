using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ViafacilReceipts.Data;
using ViafacilReceipts.Dtos;
using ViafacilReceipts.Entities;
using ViafacilReceipts.Interfaces;
using ViafacilReceipts.Mapping;
using ViafacilReceipts.Typing;

namespace ViafacilReceipts.Services;

public class ReceiptService : IReceiptService
{
    private readonly ReceiptsContext _context;

    public ReceiptService(ReceiptsContext context)
    {
        _context = context;
    }

    public async Task<Receipt> CreateReceipt(CreateReceiptDto createReceipt)
    {
        int miliseconds = DateTime.Now.Millisecond;
        int count = await _context.Receipts.CountAsync();
        string number = $"NF-{count}{miliseconds}";

        float value = createReceipt.Products.Sum(p => p.Amount * p.Value);

        Receipt receipt = createReceipt.ToReceipt(number, value);

        // var response = await _httpClient.PatchAsync("http://localhost:50001/api/products/update");

        var _receipt = _context.Add(receipt);

        await _context.SaveChangesAsync();

        return _receipt.Entity;
    }

    public async Task<Receipt?> FindReceipt(Guid id)
    {
        return await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Receipt>> FindReceipts(QueryReceiptDto queryDto)
    {
        return await _context.Receipts
            .Take(queryDto.Limit)
            .ToListAsync();
    }

    public async Task<bool?> UpdateReceipt(Guid id, UpdateReceiptDto updateReceipt)
    {
        var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id);

        if (receipt == null) return null;

        receipt.Annotations = updateReceipt.Annotations ?? receipt.Annotations;
        receipt.CustomerName = updateReceipt.CustomerName ?? receipt.CustomerName;
        receipt.CustomerDocument = updateReceipt.CustomerDocument ?? receipt.CustomerDocument;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<ChangeStatusResponse> PrintReceipt(Guid id)
    {
        var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id);

        if (receipt == null) return ChangeStatusResponse.ReceiptNotFound;
        if (receipt.Status == Status.Fechada) return ChangeStatusResponse.ClosedReceipt;

        receipt.Status = Status.Fechada;

        bool changed = await _context.SaveChangesAsync() > 0;

        return changed ? ChangeStatusResponse.Success : ChangeStatusResponse.CantChange;
    }

    private void mountPdf(Receipt receipt)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("NOTA FISCAL");
                        col.Item().Text($"Número: NF-{receipt.Number}");
                        col.Item().Text($"Data: {receipt.CreatedAt:dd/MM/yyyy}");
                    });

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Emitente").Bold();
                        col.Item().Text("Via Fácil LTDA").Bold();
                    });
                });

                page.Content().Column(col =>
                {
                    col.Item().PaddingBottom(20).Column(c =>
                    {
                        c.Item().Text("Destinatário").Bold();
                        c.Item().Text($"Client {receipt.CustomerName}");
                        c.Item().Text($"CPF/CNPJ {receipt.CustomerDocument}");
                    });

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(80);
                            columns.ConstantColumn(80);
                            columns.ConstantColumn(80);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Nome").Bold();
                            header.Cell().Text("Valor").Bold();
                            header.Cell().Text("Quantidade").Bold();
                            header.Cell().Text("Subtotal").Bold();
                        });

                            // TODO: terminar de formatar o PDF
                        // foreach (ProductDto product in receipt.Products)
                        // {
                        // }
                    });
                });
            });
        });
    }

    // public async Task<bool?> DeleteReceipt(Guid id)
    // {
    //     var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id);

    //     if (receipt == null) return null;

    //     _context.Receipts.Remove(receipt);

    //     return await _context.SaveChangesAsync() > 0;
    // }
}