namespace ProjetoFinal.Model {
    public class NotaModel {
        public int? NotaID { get; set; }
        public decimal? Prova1 { get; set; }
        public decimal? Prova2 { get; set; }
        public decimal? Trabalho { get; set; }
        public decimal? Atividade { get; set; }
        // public AlunoModel? Aluno { get; set; }
        public List<AlunoModel>? Alunos { get; set; }

        public double? Media
        {
        get
        {
            if (Prova1.HasValue && Prova2.HasValue && Trabalho.HasValue && Atividade.HasValue)
            {
                double media = ((double)Prova1.Value * 3.5 + (double)Prova2.Value * 3.5 + (double)Trabalho.Value * 2 + (double)Atividade.Value * 1) / 10;
                return Math.Round(media, 1);
            }

            return null;
        }
      }
    }
}