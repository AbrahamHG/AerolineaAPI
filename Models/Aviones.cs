﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AerolineaAPI.Models;

public partial class Aviones
{
    [Key]
    public int ID_Avion { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Codigo { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Modelo { get; set; }

    public double? Horas_vuelo { get; set; }

    public int? Capacidad { get; set; }

    public bool? Disponibilidad { get; set; }

    [InverseProperty("Avion")]
    public virtual ICollection<Vuelos> Vuelos { get; set; } = new List<Vuelos>();
}