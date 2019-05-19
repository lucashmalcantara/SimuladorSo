﻿using SimuladorSo.Models;
using SimuladorSo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Repositories
{
    public class RamRepository : IRamRepository
    {
        private const float TAMANHO_TOTAL_MB = 1024;

        private readonly Dictionary<string, Processo> _posicoesMemoria = new Dictionary<string, Processo>();
        private Stack<PaginaMemoria> _paginasDisponiveisMemoria;

        private readonly float _tamanhoPaginaMB;
        public RamRepository(float tamanhoPaginaMB)
        {
            _tamanhoPaginaMB = tamanhoPaginaMB;
            PopularPaginas();
        }

        private void PopularPaginas()
        {
            var totalPaginas = (int)(TAMANHO_TOTAL_MB / _tamanhoPaginaMB);
            _paginasDisponiveisMemoria = new Stack<PaginaMemoria>();

            for (int i = 0; i < totalPaginas; i++)
                _paginasDisponiveisMemoria.Push(new PaginaMemoria(_tamanhoPaginaMB));
        }

        public string Alocar(string enderecoFisico, Processo processo)
        {
            int quantidadePaginasNecessarias = (int)Math.Ceiling(processo.TamanhoEmMB / _tamanhoPaginaMB);

            if (quantidadePaginasNecessarias > _paginasDisponiveisMemoria.Count)
                throw new OutOfMemoryException("Não foi possível alocar o processo, pois a memória principal está cheia.");

            processo.PaginasMemoria = RetornarPaginas(quantidadePaginasNecessarias);

            _posicoesMemoria.Add(enderecoFisico, processo);
            return enderecoFisico;
        }

        private List<PaginaMemoria> RetornarPaginas(int quantidadePaginasNecessarias)
        {
            var paginas = new List<PaginaMemoria>();

            for (int i = 0; i < quantidadePaginasNecessarias; i++)
                paginas.Add(_paginasDisponiveisMemoria.Pop());

            return paginas;
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _posicoesMemoria.Values.ToList();
        }

        public float RetornarEspacoDisponivelMB()
        {
            return _tamanhoPaginaMB * _paginasDisponiveisMemoria.Count;
        }

        public string RetornarEnderecoFisicoDisponivel()
        {
            return Guid.NewGuid().ToString();
        }

        public Processo Desalocar(string enderecoFisico)
        {
            var processo = _posicoesMemoria[enderecoFisico];
            _posicoesMemoria.Remove(enderecoFisico);

            foreach (var pagina in processo.PaginasMemoria)
                _paginasDisponiveisMemoria.Push(pagina);

            processo.PaginasMemoria = null;
            return processo;
        }

        public Dictionary<string, Processo> RetornarPosicoesMemoria()
        {
            return _posicoesMemoria;
        }
    }
}
