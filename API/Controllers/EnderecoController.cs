using AutoMapper;
using Core._01_Services;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoService _service;
    private readonly IMapper _mapper;
    public EnderecoController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new EnderecoService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-Endereco")]
    public void AdicionarAluno(Endereco enderecoDTO)
    {
        Endereco produto = _mapper.Map<Endereco>(enderecoDTO);
        _service.Adicionar(enderecoDTO);
    }
    //[HttpGet("listar-Endereco")]
    //public List<Endereco> ListarAluno()
    //{
    //    return _service.Listar();
    //}

    [HttpGet("Listar-Enderecos-de-Usuario")]
    public List<Endereco> ListarCarrinho(int usuarioId)
    {
        return _service.ListarEnderecoPorId(usuarioId);
    }

    [HttpPut("editar-Endereco")]
    public void EditarProduto(Endereco E)
    {
        _service.Editar(E);
    }
    [HttpDelete("deletar-Endereco")]
    public void DeletarProduto(int id)
    {
        _service.Remover(id);
    }
}
