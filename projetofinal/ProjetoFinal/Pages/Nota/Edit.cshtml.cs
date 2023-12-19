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

namespace ProjetoFinal.Pages.Nota
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public NotaModel NotaModel { get; set; } = new();
        public List<AlunoModel>? AlunoList { get; set; }

        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notas == null) {
                return NotFound();
            }

            var notaModel = await _context.Notas.FirstOrDefaultAsync(nota => nota.NotaID == id);

            if (notaModel == null) {
                return NotFound();
            }

            NotaModel = notaModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            var notaToUpdate = await _context.Notas!.FindAsync(id);

            if (notaToUpdate == null) {
                return NotFound();
            }

            notaToUpdate.Prova1 = NotaModel.Prova1;
            notaToUpdate.Prova2 = NotaModel.Prova2;
            notaToUpdate.Trabalho = NotaModel.Trabalho;
            notaToUpdate.Atividade = NotaModel.Atividade;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Nota/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}