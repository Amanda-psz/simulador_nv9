using sistemaGestaoPizzaria.model;

namespace sistemaGestaoPizzaria.domain
{
    public interface IProdutoRepository
    {
        Produto Add(ProdutoRequest produtoRequest);
        Produto? Update(int  id, ProdutoRequest produtoRequest);
        void Delete(int id);
        List<Produto> GetAll();
        Produto? Get(int id);

    }
}
