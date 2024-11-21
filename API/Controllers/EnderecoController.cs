using AutoMapper;
using Core._01_Services.Interfaces;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _service;
    private readonly IMapper _mapper;

    public EnderecoController(IEnderecoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("adicionar-Endereco")]
    public Endereco AdicionarAluno(Endereco enderecoDTO)
    {
        Endereco end = _mapper.Map<Endereco>(enderecoDTO);
        _service.Adicionar(enderecoDTO);
        return end;
    }
    //[HttpGet("listar-Endereco")]
    //public List<Endereco> ListarAluno()
    //{
    //    return _service.Listar();
    //}

    [HttpGet("Listar-Enderecos-de-Usuario")]
    public List<Endereco> ListarEndereco([FromQuery]int usuarioId)
    {
        return _service.ListarEnderecoPorId(usuarioId);
    }

    [HttpPut("Editar-Endereco")]
    public void EditarProduto(Endereco E)
    {
        _service.Editar(E);
    }
    [HttpDelete("deletar-endereco")]
    public void DeletarProduto(int id)
    {
        _service.Remover(id);
    }
}
