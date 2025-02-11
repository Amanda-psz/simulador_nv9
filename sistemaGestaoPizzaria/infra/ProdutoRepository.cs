using sistemaGestaoPizzaria.domain;
using sistemaGestaoPizzaria.model;

namespace sistemaGestaoPizzaria.infra
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public Produto Add(ProdutoRequest produtoRequest)
        {
            var produto = new Produto(produtoRequest.nome, produtoRequest.tempoDePreparo);
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public List<Produto> GetAll()
        {
            return _context.Produto.ToList();
        }

        public Produto? Get(int id)
        {
            return _context.Produto.Find(id);
        }

        public Produto? Update(int id, ProdutoRequest produtoRequest)
        {
            var produto = _context.Produto.Find(id);
            if (produto != null)
            {
                produto.nome = produtoRequest.nome;
                produto.tempoDePreparo = produtoRequest.tempoDePreparo;
                _context.Produto.Update(produto);
                _context.SaveChanges();
                return produto;
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var produto = _context.Produto.Find(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}