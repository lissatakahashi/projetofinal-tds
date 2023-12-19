using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoFinal.Data;
using ProjetoFinal.Model;

namespace ProjetoFinal.Pages.Planejamento
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public PlanejamentoModel PlanejamentoModel { get; set; } = new();

        public Delete(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }

            var planejamentoModel = await _context.Planejamentos.FirstOrDefaultAsync(planejamento => planejamento.PlanejamentoID == id);

            if (planejamentoModel == null) {
                return NotFound();
            }

            PlanejamentoModel = planejamentoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            var planejamentoToDelete = await _context.Planejamentos!.FindAsync(id);

            if (planejamentoToDelete == null) {
                return NotFound();
            }

            try {
                _context.Planejamentos.Remove(planejamentoToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Planejamento/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}