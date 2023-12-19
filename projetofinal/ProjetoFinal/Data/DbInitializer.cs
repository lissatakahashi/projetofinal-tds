using ProjetoFinal.Model;

namespace ProjetoFinal.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) 
        {
            if(!context.Alunos!.Any())
            {
                var alunos = new AlunoModel[] {
                    new AlunoModel {
                        Nome = "Alícia Santos",
                        Telefone = "3253-2357",
                        DataNascimento = DateTime.Parse("2010-02-10"),
                        Diagnostico = "Nenhum"
                    },
                };
                context.AddRange(alunos);
            }
            
            context.SaveChanges();
        }
    }
}