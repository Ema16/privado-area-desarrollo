using System;
using System.Collections.Generic;

namespace desarrolloPrivadoEmanuel.Models;

public partial class Empleado
{
    public int CodEmpleado { get; set; }

    public string? NombreEmpleado { get; set; }

    public string? TelefonoEmpleado { get; set; }

    public decimal? SueldoBase { get; set; }

    public decimal? NuevoSueldo { get; set; }

    public string? EstadoContrato { get; set; }

    public DateTime? FechaContrato { get; set; }

    public string? EstadoEmpleado { get; set; }

    public DateTime? FechaInicioContrato { get; set; }

    public string? EstadoAntiguedad { get; set; }

    public int CodPuesto { get; set; }

    public virtual Puesto CodPuestoNavigation { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual ICollection<HistorialIncremento> HistorialIncrementos { get; set; } = new List<HistorialIncremento>();

    public virtual ICollection<TrabajaEn> TrabajaEns { get; set; } = new List<TrabajaEn>();
}
