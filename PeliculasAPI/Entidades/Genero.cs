using PeliculasAPI.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{

    // clase que va a representar la tabla de generos
    public class Genero//: IValidatableObject // Validacion por modelo 
    {
        // propiedades id y nombre del genero

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50)]
        [PrimeraLetraMayuscula] // regla de validacion personalizada por atributo
        public string Nombre { get; set; }

        //[Range(18, 120)]
        //public int Edad { get; set; }

        //[CreditCard]
        //public string TarjetaDeCredito { get; set; }

        //[Url]
        //public string URL { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser Mayuscula", new string[] { nameof(Nombre)});// nameof le corresponde al campo nombre
                }
            }
        }
    }
}
