using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Contrato
{
    public int CodContrato { get; set; }

    public DateTime? FechaContrato { get; set; }

    public int CodEmpleado { get; set; }

    public int CodEmpresa { get; set; }

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;
}
