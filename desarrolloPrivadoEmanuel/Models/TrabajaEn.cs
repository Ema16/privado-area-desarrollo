using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class TrabajaEn
{
    public int CodEmpleadoDepartamento { get; set; }

    public int CodEmpleado { get; set; }

    public int CodDepartamento { get; set; }

    public virtual Departamento CodDepartamentoNavigation { get; set; } = null!;

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;
}
