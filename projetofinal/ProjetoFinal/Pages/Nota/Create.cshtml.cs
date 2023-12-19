using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Model;

namespace ProjetoFinal.Pages.Nota
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public List<AlunoModel>? AlunoList { get; set; }
        public NotaModel NotaModel { get; set; } = new();
        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if(!ModelState.IsValid) {
                return Page();
            }

            try {
                _context.Add(NotaModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Nota/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}