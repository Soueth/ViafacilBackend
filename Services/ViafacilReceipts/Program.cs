using System.Globalization;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ViafacilReceipts.Cofigurations;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddHttpClient();

builder.Services.ConfigureDb(builder.Configuration);
builder.Services.AddServicesAndServices();

var app = builder.Build();

// var document = Document.Create(container =>
// {
//     container.Page(page =>
//             {
//                 page.Size(PageSizes.A4);
//                 page.Margin(50);
//                 page.PageColor(Colors.White);
//                 page.DefaultTextStyle(x => x.FontSize(12));

//                 // Cabeçalho
//                 page.Header().Row(row =>
//                 {
//                     row.RelativeItem().Column(col =>
//                     {
//                         col.Item().Text("NOTA FISCAL").Bold().FontSize(16);
//                         col.Item().Text("Número: NF-001-2023");
//                         col.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy}");
//                     });

//                     row.RelativeItem().Column(col =>
//                     {
//                         col.Item().Text("Emitente:").Bold();
//                         col.Item().Text("Empresa ABC Ltda");
//                         col.Item().Text("CNPJ: 12.345.678/0001-99");
//                         col.Item().Text("Rua das Flores, 123 - São Paulo/SP");
//                     });
//                 });

//                 // Conteúdo principal
//                 page.Content().Column(col =>
//                 {
//                     // Destinatário
//                     col.Item().PaddingBottom(20).Column(c =>
//                     {
//                         c.Item().Text("Destinatário:").Bold();
//                         c.Item().Text("Cliente XYZ SA");
//                         c.Item().Text("CNPJ: 98.765.432/0001-11");
//                         c.Item().Text("Av. Paulista, 456 - São Paulo/SP");
//                     });

//                     // Itens
//                     col.Item().Table(table =>
//                     {
//                         // Definição das colunas
//                         table.ColumnsDefinition(columns =>
//                         {
//                             columns.RelativeColumn();
//                             columns.ConstantColumn(80);
//                             columns.ConstantColumn(80);
//                             columns.ConstantColumn(80);
//                         });

//                         // Cabeçalho da tabela
//                         table.Header(header =>
//                         {
//                             header.Cell().Text("Descrição").Bold();
//                             header.Cell().AlignRight().Text("Quantidade").Bold();
//                             header.Cell().AlignRight().Text("Unitário").Bold();
//                             header.Cell().AlignRight().Text("Total").Bold();
//                         });

//                         // Dados dos itens
//                         var items = new[]
//                         {
//                             new { Descricao = "Produto A", Quantidade = 2, Unitario = 150.00m },
//                             new { Descricao = "Produto B", Quantidade = 1, Unitario = 299.90m }
//                         };

//                         foreach (var item in items)
//                         {
//                             table.Cell().Text(item.Descricao);
//                             table.Cell().AlignRight().Text(item.Quantidade.ToString());
//                             table.Cell().AlignRight().Text(item.Unitario.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
//                             table.Cell().AlignRight().Text((item.Quantidade * item.Unitario).ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
//                         }
//                     });

//                     // Totais
//                     col.Item().PaddingTop(20).AlignRight().Column(totais =>
//                     {
//                         var subtotal = 50;
                        
//                         totais.Item().Text($"Subtotal: {subtotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
//                         totais.Item().Text($"Impostos (10%): {(subtotal * 0.1m).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
//                         totais.Item().Text($"Total: {(subtotal * 1.1m).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}").Bold();
//                     });
//                 });

//                 // Rodapé
//                 page.Footer().AlignCenter().Text(t =>
//                 {
//                     t.Span("Página ");
//                     t.CurrentPageNumber();
//                 });
//             });
//         });


// document.ShowInCompanion();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

app.Run("http://0.0.0.0:8081");
