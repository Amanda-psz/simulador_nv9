using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using sistemaGestaoPizzaria.model;
using Renci.SshNet.Messages.Authentication;

namespace sistemaGestaoPizzaria.services
{
    public class ProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService()
        {}

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultDto> CalculaTempoPreparo(Pedido pedido)
        {
            if (pedido == null || pedido.pizzas == null || pedido.pizzas.Count == 0)
            {
                return new ResultDto { Sucesso = false, Mensagem = "Pedido não efetuado." };
            }

            // Verifica se a API de produtos está disponível
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:8081/api/produto");
            if (!response.IsSuccessStatusCode)
            {
                return new ResultDto { Sucesso = false, Mensagem = "Erro ao buscar produtos." };
            }

            var produtosJson = await response.Content.ReadAsStringAsync();
            List<ProdutoRequest> produtos = JsonSerializer.Deserialize<List<ProdutoRequest>>(produtosJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            int tempoPreparo = 0;

            foreach (var pizza in pedido.pizzas)
            {
                var produto = produtos.FirstOrDefault(p => p.nome.ToLower() == pizza.nome.ToLower());

                if (produto == null)
                {
                    return new ResultDto { Sucesso = false, Mensagem = $"Produto '{pizza.nome}' não encontrado." };
                }

                tempoPreparo += produto.tempoDePreparo * pizza.quantidade;
            }


            return new ResultDto
            {
                Sucesso = true,
                Mensagem = $"Seu pedido ficará pronto em aproximadamente {tempoPreparo} minutos.",
                TempoPreparo = tempoPreparo
            };
        }

        public int CalculaTempoPreparoParaTestePorQuantidade(Pedido pedido)
        {
            if (pedido == null || pedido.pizzas == null || pedido.pizzas.Count == 0)
            {
                return 0;
            }

            //Exemplo de tempos de preparo para diferentes pizzas (sem precisar da API)
            var temposDePreparo = new Dictionary<string, int>
            {
                { "Portuguesa", 30 },
                { "Marguerita", 30 },
                { "Nutella", 35 }
            };

            int tempoTotal = 0;

            foreach (var pizza in pedido.pizzas)
            {
                if (temposDePreparo.TryGetValue(pizza.nome, out int tempoPreparo))
                {
                    tempoTotal += tempoPreparo * pizza.quantidade;
                }
            }

            return tempoTotal;
        }

        public int CalculaTempoPreparoParaTesteMaiorTempo(Pedido pedido)
        {
            if (pedido == null || pedido.pizzas == null || pedido.pizzas.Count == 0)
            {
                return 0;
            }

            // Exemplo de tempos de preparo para diferentes pizzas (sem precisar da API)
            var temposDePreparo = new Dictionary<string, int>
            {
                { "Frango com Catupiry", 35 },
                { "Quatro queijos", 30 },
                { "Brigadeiro", 40 }
            };

            int maiorTempo = 0;

            foreach (var pizza in pedido.pizzas)
            {
                if (temposDePreparo.TryGetValue(pizza.nome, out int tempoPreparo))
                {
                    maiorTempo = Math.Max(maiorTempo, tempoPreparo);
                }
            }

            return maiorTempo;
        }
    }
}
