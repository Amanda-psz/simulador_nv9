using sistemaGestaoPizzaria.model;
using sistemaGestaoPizzaria.services;

namespace APITest
{
    public class Tests
    {
        private ProdutoService _produtoService;

        [SetUp]
        public void Setup()
        {
            _produtoService = new ProdutoService();
        }

        [Test]
        public void VerificaCalculoTempoPreparoPedidoPorQuantidade()
        {
            var pizzas = new List<Pizza>
            {
                new Pizza { nome = "Portuguesa", quantidade = 1 }, // 30 min
                new Pizza { nome = "Marguerita", quantidade = 1 }, // 30 min
                new Pizza { nome = "Nutella", quantidade = 2 } // 35 x 2 = 70 min
            };

            var pedido = new Pedido { pizzas = pizzas };

            int tempoCalculado = _produtoService.CalculaTempoPreparoParaTestePorQuantidade(pedido);

            int tempoEstipulado = 30 + 30 + (35 * 2); // 130 minutos

            Assert.AreEqual(tempoEstipulado, tempoCalculado, "O cálculo do tempo de preparo do pedido está incorreto.");
        }

        [Test]
        public void VerificaCalculoTempoPreparoPedidoPorMaiorTempo()
        {
            // Criando um pedido com pizzas para testar o cálculo
            var pizzas = new List<Pizza>
            {
                new Pizza { nome = "Frango com Catupiry", quantidade = 1 },
                new Pizza { nome = "Quatro queijos", quantidade = 2 },
                new Pizza { nome = "Brigadeiro", quantidade = 1 }
            };

            var pedido = new Pedido { pizzas = pizzas };

            // Chamando diretamente o método interno de cálculo
            int tempoCalculado = _produtoService.CalculaTempoPreparoParaTesteMaiorTempo(pedido);

            int tempoEstipulado = 40; // levando em consideração a pizza que leva mais tempo de preparo

            Assert.AreEqual(tempoEstipulado, tempoCalculado, "O cálculo do tempo de preparo do pedido está incorreto.");
        }
    }
}