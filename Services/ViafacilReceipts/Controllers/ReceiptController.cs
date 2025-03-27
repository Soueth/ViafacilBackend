using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ViafacilReceipts.Utils;
using ViafacilReceipts.Dtos;
using ViafacilReceipts.Entities;
using ViafacilReceipts.Interfaces;
using ViafacilReceipts.Typing;

namespace ViafacilReceipts.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private readonly IReceiptService _receiptService;
    private readonly HttpClient _httpClient;

    public ReceiptController(IReceiptService receiptService, HttpClient httpClient)
    {
        _receiptService = receiptService;
        _httpClient = httpClient;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Receipt>>> GetReceipts([FromQuery] QueryReceiptDto query)
    {
        return await _receiptService.FindReceipts(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Receipt>> GetReceipt(Guid id)
    {
        Receipt? Receipt = await _receiptService.FindReceipt(id);
        if (Receipt == null) return NotFound();

        return Receipt;
    }

    [HttpPost()]
    public async Task<IResult> CreateReceipt([FromBody] CreateReceiptDto createReceipt)
    {
        Receipt Receipt = await _receiptService.CreateReceipt(createReceipt);

        var response = await _httpClient.GetAsync($"{APP_CONSTANTS.productsUrl}");

        if (!response.IsSuccessStatusCode)
        {
            return Results.BadRequest();
        }

        return Results.CreatedAtRoute
        (
            nameof(CreateReceipt),
            new { id = Receipt.Id },
            Receipt
        );
    }

    [HttpPatch()]
    public async Task<ActionResult<bool?>> UpdateReceipt(Guid id, [FromBody] UpdateReceiptDto updateReceipt)
    {
        bool? success = await _receiptService.UpdateReceipt(id, updateReceipt);

        if (success == null) return NotFound();
        
        return success;
    }

    // [HttpPatch("print/{id}")]
    // public async Task<ChangeStatusResponse> PrintReceipt(Guid id)
    // {
    //     return await _receiptService.PrintReceipt(id);
    // }
}
