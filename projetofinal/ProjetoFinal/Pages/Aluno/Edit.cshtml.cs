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

namespace ProjetoFinal.Pages.Aluno
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set; } = new();

        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(aluno => aluno.AlunoID == id);

            if (alunoModel == null) {
                return NotFound();
            }

            AlunoModel = alunoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            var alunoToUpdate = await _context.Alunos!.FindAsync(id);

            if (alunoToUpdate == null) {
                return NotFound();
            }

            alunoToUpdate.Nome = AlunoModel.Nome;
            alunoToUpdate.Telefone = AlunoModel.Telefone;
            alunoToUpdate.DataNascimento = AlunoModel.DataNascimento;
            alunoToUpdate.Diagnostico = AlunoModel.Diagnostico;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Aluno/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}