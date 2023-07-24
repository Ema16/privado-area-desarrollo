using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Puesto
{
    public int CodPuesto { get; set; }

    public string? NombrePuesto { get; set; }

    public decimal? PagoPuesto { get; set; }

    public virtual ICollection<Contiene> Contienes { get; set; } = new List<Contiene>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
