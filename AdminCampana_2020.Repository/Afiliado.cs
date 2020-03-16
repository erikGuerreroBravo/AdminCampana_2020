//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminCampana_2020.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Afiliado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Afiliado()
        {
            this.Auditoria = new HashSet<Auditoria>();
        }
    
        public int id { get; set; }
        public string strNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string strCurp { get; set; }
        public string strClaveElector { get; set; }
        public Nullable<int> idPersona { get; set; }
        public Nullable<int> idDireccion { get; set; }
        public Nullable<int> idTelefono { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual Telefono Telefono { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auditoria> Auditoria { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}
