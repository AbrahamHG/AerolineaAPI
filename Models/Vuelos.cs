﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AerolineaAPI.Models;

public partial class Vuelos
{
    [Key]
    public int ID_vuelo { get; set; }

    public int? Ruta_ID { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string Num_Vuelo { get; set; }

    public DateOnly? Fecha_vuelo { get; set; }

    public double? Hora_vuelo { get; set; }

    public int? Piloto_ID { get; set; }

    public int? Avion_ID { get; set; }

    public bool? Estatus { get; set; }

    [ForeignKey("Avion_ID")]
    [InverseProperty("Vuelos")]
    public virtual Aviones Avion { get; set; }

    [ForeignKey("Piloto_ID")]
    [InverseProperty("Vuelos")]
    public virtual Pilotos Piloto { get; set; }

    [ForeignKey("Ruta_ID")]
    [InverseProperty("Vuelos")]
    public virtual Rutas Ruta { get; set; }
}