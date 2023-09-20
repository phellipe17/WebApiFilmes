using FiilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FiilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]

public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id=0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id=id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmeporId), new { id = filme.Id }, filme );
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme([FromQuery]int take)
    {
        return filmes.Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeporId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpDelete("{id}")]
    public void RemoveFilme([FromRoute] int id, [FromRoute] int dura)
    {
        var filme = filmes.FirstOrDefault(f => f.Id == id && f.Duracao == dura);
        if (filme != null)
        {
            filmes.Remove(filme);
            Console.WriteLine("Filme removido.");
        }
        else
        {
            Console.WriteLine("Filme não encontrado.");
        }
    }
}
