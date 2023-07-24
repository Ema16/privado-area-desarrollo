using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class HistorialIncremento
{
    public int CodHistorialIncremento { get; set; }

    public DateTime? FechaAumento { get; set; }

    public decimal? PorcentajeAumento { get; set; }

    public decimal? SaldoAnterior { get; set; }

    public decimal? NuevoSaldo { get; set; }

    public decimal? SaldoBase { get; set; }

    public int CodEmpleado { get; set; }

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;
}
