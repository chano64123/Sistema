﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class bdJeaNetEntities : DbContext
    {
        public bdJeaNetEntities()
            : base("name=bdJeaNetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbAlertas> tbAlertas { get; set; }
        public virtual DbSet<tbAuditoria> tbAuditoria { get; set; }
        public virtual DbSet<tbCargos> tbCargos { get; set; }
        public virtual DbSet<tbClienteDisposiivo> tbClienteDisposiivo { get; set; }
        public virtual DbSet<tbClientes> tbClientes { get; set; }
        public virtual DbSet<tbCompras> tbCompras { get; set; }
        public virtual DbSet<tbComprobante> tbComprobante { get; set; }
        public virtual DbSet<tbCondicion> tbCondicion { get; set; }
        public virtual DbSet<tbDetalleCompras> tbDetalleCompras { get; set; }
        public virtual DbSet<tbDetalleComprobante> tbDetalleComprobante { get; set; }
        public virtual DbSet<tbDispositivos> tbDispositivos { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbKardex> tbKardex { get; set; }
        public virtual DbSet<tbLotes> tbLotes { get; set; }
        public virtual DbSet<tbProveedores> tbProveedores { get; set; }
        public virtual DbSet<tbTurnos> tbTurnos { get; set; }
        public virtual DbSet<tbSesiones> tbSesiones { get; set; }
    
        public virtual ObjectResult<USP_S_ListarProductosSemestre_Result> USP_S_ListarProductosSemestre()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarProductosSemestre_Result>("USP_S_ListarProductosSemestre");
        }
    
        public virtual ObjectResult<USP_S_ListarProductosVendidosAnual_Result> USP_S_ListarProductosVendidosAnual()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarProductosVendidosAnual_Result>("USP_S_ListarProductosVendidosAnual");
        }
    
        public virtual ObjectResult<USP_S_ListarPRoductosVendidosMes_Result> USP_S_ListarPRoductosVendidosMes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarPRoductosVendidosMes_Result>("USP_S_ListarPRoductosVendidosMes");
        }
    
        public virtual ObjectResult<USP_S_ListarProductosVendidosSemana_Result> USP_S_ListarProductosVendidosSemana()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarProductosVendidosSemana_Result>("USP_S_ListarProductosVendidosSemana");
        }
    
        public virtual ObjectResult<USP_S_ListarVentaDeEmpleadosPorSemestre_Result> USP_S_ListarVentaDeEmpleadosPorSemestre()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentaDeEmpleadosPorSemestre_Result>("USP_S_ListarVentaDeEmpleadosPorSemestre");
        }
    
        public virtual ObjectResult<USP_S_ListarVentaDeEmpleadosPorTrimestre_Result> USP_S_ListarVentaDeEmpleadosPorTrimestre()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentaDeEmpleadosPorTrimestre_Result>("USP_S_ListarVentaDeEmpleadosPorTrimestre");
        }
    
        public virtual ObjectResult<USP_S_ListarVentasEmpleadoAnual_Result> USP_S_ListarVentasEmpleadoAnual()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentasEmpleadoAnual_Result>("USP_S_ListarVentasEmpleadoAnual");
        }
    
        public virtual ObjectResult<USP_S_ListarVentasMensualesPorEmpleado_Result> USP_S_ListarVentasMensualesPorEmpleado()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentasMensualesPorEmpleado_Result>("USP_S_ListarVentasMensualesPorEmpleado");
        }
    
        public virtual ObjectResult<USP_S_ListarVentasPorDiaEmpleado_Result> USP_S_ListarVentasPorDiaEmpleado()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentasPorDiaEmpleado_Result>("USP_S_ListarVentasPorDiaEmpleado");
        }
    
        public virtual ObjectResult<USP_S_ListarVentasProductosTrimestre_Result> USP_S_ListarVentasProductosTrimestre()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarVentasProductosTrimestre_Result>("USP_S_ListarVentasProductosTrimestre");
        }
    
        public virtual ObjectResult<USP_S_ListarIncidencias_Result> USP_S_ListarIncidencias()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_S_ListarIncidencias_Result>("USP_S_ListarIncidencias");
        }
    }
}
