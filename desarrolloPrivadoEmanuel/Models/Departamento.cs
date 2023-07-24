using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Departamento
{
    public int CodDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public virtual ICollection<Contiene> Contienes { get; set; } = new List<Contiene>();

    public virtual ICollection<TrabajaEn> TrabajaEns { get; set; } = new List<TrabajaEn>();
}
