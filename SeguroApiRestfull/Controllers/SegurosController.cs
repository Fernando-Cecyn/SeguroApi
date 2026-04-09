using Microsoft.AspNetCore.Mvc;
using Seguro.Application.Services;
using Seguro.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class SegurosController : ControllerBase
{
    private readonly SeguroService _service;

    public SegurosController(SeguroService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(SeguroRequestDto dto)
    {
        var seguro = new Apolice
        {
            Veiculo = new Veiculo
            {
                Valor = dto.ValorVeiculo,
                MarcaModelo =  string.IsNullOrWhiteSpace(dto.MarcaModelo) || string.Equals(dto.MarcaModelo, "string") ? "Place Holder: Mitsubishi 1995 Eclipse GST" : dto.MarcaModelo
    },
            Segurado = new Segurado
            {
                Nome =  string.IsNullOrWhiteSpace(dto.Nome)|| string.Equals(dto.Nome, "string") ? "Place Holder: Brian O'Conner" : dto.Nome,
                CPF = string.IsNullOrWhiteSpace(dto.CPF) || string.Equals(dto.CPF, "string") ? "Place Holder: 123.456.789-09" : dto.CPF,
                Idade = int.Equals(dto.Idade, 0) ? 28 : dto.Idade
            }

            // Ajustes para permitir falhar graciosamente em caso de valores vazios, Mantendo a rastreabilidade por termos Place Holder
        };

        var resultado = await _service.CriarSeguroAsync(seguro);
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id)
    {
        var seguro = await _service.ObterPorIdAsync(id);
        return Ok(seguro);
    }

    [HttpGet("relatorio")]
    public async Task<IActionResult> Relatorio()
    {
        var media = await _service.ObterMediaAsync();
        return Ok(new { mediaValorSeguro = media });
    }
}