﻿using AutoMapper;
using Core._01_Services.Interfaces;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("adicionar-produto")]
    public void AdicionarAluno(Produto produtoDTO)
    {
        Produto produto = _mapper.Map<Produto>(produtoDTO);
        _service.Adicionar(produto);
    }
    [HttpGet("listar-produto")]
    public List<Produto> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-produto")]
    public void EditarProduto(Produto p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-produto")]
    public void DeletarProduto(int id)
    {
        _service.Remover(id);
    }
}
