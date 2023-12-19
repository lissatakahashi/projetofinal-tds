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
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public PlanejamentoModel PlanejamentoModel { get; set; } = new();

        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Planejamentos == null) {
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
            if (!ModelState.IsValid) {
                return Page();
            }

            var planejamentoToUpdate = await _context.Planejamentos!.FindAsync(id);

            if (planejamentoToUpdate == null) {
                return NotFound();
            }

            planejamentoToUpdate.Titulo = PlanejamentoModel.Titulo;
            planejamentoToUpdate.Descricao = PlanejamentoModel.Descricao;
            planejamentoToUpdate.Data = PlanejamentoModel.Data;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Planejamento/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}