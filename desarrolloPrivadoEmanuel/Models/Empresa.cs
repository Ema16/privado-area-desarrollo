using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Empresa
{
    public int CodEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? DireccionEmpresa { get; set; }

    public string? TelefonoEmpresa { get; set; }

    public virtual ICollection<Contiene> Contienes { get; set; } = new List<Contiene>();

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
