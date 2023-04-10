using System.ComponentModel.DataAnnotations;

namespace FiilmesAPI.Models;

public class Filme
{
    public int Id { get; set; }
    [Required (ErrorMessage ="O título do filme e obrigatorio.")]
    [StringLength(30, ErrorMessage ="O titulo do filme não pode ser muito grande.")]
    public string Titulo { get; set; }
    [Required (ErrorMessage ="O Genero do filme e obrigatorio.")]
    [MaxLength(50, ErrorMessage ="O tamanho do genero nao pode exceder 50 caracteres.")]
    public string Genero { get; set; }
    [Required]
    [Range(70,600 , ErrorMessage ="A duracao deve ser entre 70 e 600 minutos.")]
    public int Duracao { get; set; }

    

}
