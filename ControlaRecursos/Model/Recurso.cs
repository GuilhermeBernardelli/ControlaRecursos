//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlaRecursos.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recurso()
        {
            this.Pessoa_Recurso = new HashSet<Pessoa_Recurso>();
        }
    
        public int recurso_id { get; set; }
        public string nome { get; set; }
        public string codigo { get; set; }
        public Nullable<bool> indicativo_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pessoa_Recurso> Pessoa_Recurso { get; set; }
    }
}
