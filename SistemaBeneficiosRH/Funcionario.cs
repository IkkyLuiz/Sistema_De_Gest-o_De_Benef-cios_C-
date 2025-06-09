using System.Collections.Generic;

public class Funcionario
{
    public string Nome { get; set; }
    public int Id { get; set; }
    public List<Beneficio> Beneficios { get; set; } = new List<Beneficio>();
}