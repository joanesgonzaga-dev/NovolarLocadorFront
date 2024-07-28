using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace NovolarLocadorFront.ViewModel
{
    public class ProprietarioViewModel
    {
        private readonly int TotalContratoInativo = 0;
        private readonly int TotalContratosAtivos = 0;
        public decimal ValorTotalAlugueis = 0.0M;

        public string EnderecoCompleto { get; set; }
        public int TotalContratos { get; set; }
        public int QuantidadeImoveisLocados { get; set; } = 0;
        public List<Contrato> ContratosAtivos { get; set; }
        public List<Contrato> ContratosItivos { get; set; }
        public List<Contrato> Contratos { get; set; }
        public List<ImovelDTO> Imoveis { get; set; }

        public List<Banco> Bancos { get; set; }

        public Proprietario Proprietario { get; set; }

        public ProprietarioViewModel(UserSession userSession)
        {
            Proprietario = userSession.Proprietario;
            InicializaContratos();
            InicializaBancos();
            TotalContratosAtivos = ContratosAtivos.Count;
            TotalContratos = Contratos.Count;
            
            Imoveis = userSession.Imoveis;
            CalculaValorTotalAlugueis();
        }

        private void InicializaContratos()
        {
            Contratos = new List<Contrato>();
            ContratosAtivos = new List<Contrato>();
            ContratosItivos = new List<Contrato>();
            EnderecoCompleto = $"{Proprietario.st_endereco_pes}, {Proprietario.st_numero_pes} - {Proprietario.st_complemento_pes}. {Proprietario.st_bairro_pes}. {Proprietario.st_estado_pes}";
            foreach (var beneficiario in Proprietario.proprietarios_beneficiarios)
            {
                if (beneficiario.id_proprietario_pes is null)
                {
                    continue;
                }

                if (beneficiario.contratos != null)
                {
                    foreach (var contrato in beneficiario.contratos)
                    {
                        Contratos.Add(contrato);
                        int.TryParse(contrato.fl_ativo_con, out int intAtivo);
                        bool isAtivo = intAtivo.Equals("1") ? true : false;
                        if (isAtivo)
                        {
                            ContratosAtivos.Add(contrato);
                        }
                        else
                        {
                            ContratosItivos.Add(contrato);
                        }
                    }
                }
            }
        }
        private void CalculaValorTotalAlugueis()
        {
            foreach (var item in Imoveis)
            {
                this.ValorTotalAlugueis += item.ValorAluguel;
                this.QuantidadeImoveisLocados += item.isLocado == 1 ? 1 : 0;
            }
        }

        private void InicializaBancos()
        {
            var _applicationGlobals = ServiceLocator._applicationGlobals;
            Bancos = new List<Banco>();

            foreach (var banco in _applicationGlobals.Bancos)
            {
                Bancos.Add(new Banco
                {
                    Codigo = banco.Key.Trim(),
                    Nome = banco.Value,
                });
            }
        }
    }
}
