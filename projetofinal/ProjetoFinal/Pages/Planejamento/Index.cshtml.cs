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
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<PlanejamentoModel> PlanejamentoList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            PlanejamentoList = await _context.Planejamentos!.ToListAsync();
            return Page();
        }
    }
}