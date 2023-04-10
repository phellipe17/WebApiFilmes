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
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id=id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
        
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme()
    {
        return filmes;
    }

    [HttpGet("id")]
    public Filme? RecuperaFilmeporId(int id1)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id1);
    }

    [HttpDelete("id")]
    public void RemoveFilme([FromBody] Filme filme)
    {
        filmes.Remove(filme);
        Console.WriteLine("Filme removido.");
    }
}
