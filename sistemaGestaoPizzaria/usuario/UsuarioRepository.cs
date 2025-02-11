namespace sistemaGestaoPizzaria.usuario
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string nome, string senha)
        {
            var usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Id = 1, Nome = "Joaquim", Senha = "joaquim", Role = "garçom" });
            usuarios.Add(new Usuario { Id = 2, Nome = "Marcos", Senha = "marcos", Role = "cozinheiro" });

            return usuarios.FirstOrDefault(x =>
                x.Nome == nome
                && x.Senha == senha);
        }
    }
}
