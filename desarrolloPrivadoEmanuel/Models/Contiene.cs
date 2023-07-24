using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Contiene
{
    public int CodEmpresaDepartamento { get; set; }

    public int CodDepartamento { get; set; }

    public int CodPuesto { get; set; }

    public int CodEmpresa { get; set; }

    public decimal? PagoPuesto { get; set; }

    public virtual Departamento CodDepartamentoNavigation { get; set; } = null!;

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;

    public virtual Puesto CodPuestoNavigation { get; set; } = null!;
}
