﻿using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository repository;
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            repository = enderecoRepository;
        }
        public void Adicionar(Endereco endereco)
        {
            repository.Adicionar(endereco);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Endereco> Listar()
        {
            return repository.Listar();
        }
        public List<Endereco> ListarEnderecoPorId(int usuarioId)
        {
            return repository.ListarEnderecoPorId(usuarioId);
        }

        public Endereco BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Endereco editEndereco)
        {
            repository.Editar(editEndereco);
        }
    }
}
