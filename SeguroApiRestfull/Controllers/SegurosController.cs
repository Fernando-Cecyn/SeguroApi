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
                MarcaModelo = dto.MarcaModelo
            },
            Segurado = new Segurado
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                Idade = dto.Idade
            }
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