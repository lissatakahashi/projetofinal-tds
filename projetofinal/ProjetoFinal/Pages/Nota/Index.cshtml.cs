using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Model;

namespace ProjetoFinal.Pages.Nota
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<NotaModel> NotaList { get; set; } = new();
        public List<AlunoModel> AlunoList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            NotaList = await _context.Notas!.ToListAsync();
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }
    }
}