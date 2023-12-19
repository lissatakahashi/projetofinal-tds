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
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set; } = new();
        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            if(!ModelState.IsValid) {
                return Page();
            }

            try {
                _context.Add(AlunoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Aluno/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}