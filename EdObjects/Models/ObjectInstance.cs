//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdObjects.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ObjectInstance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ObjectInstance()
        {
            this.ObjectInstance1 = new HashSet<ObjectInstance>();
            this.Container = new HashSet<Container>();
            this.Container1 = new HashSet<Container>();
            this.PropertyValues = new HashSet<PropertyValues>();
        }
    
        public int Id { get; set; }
        public int IdTypeObject { get; set; }
        public Nullable<int> BaseId { get; set; }
    
        public virtual ObjectType ObjectType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectInstance> ObjectInstance1 { get; set; }
        public virtual ObjectInstance ObjectInstance2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Container> Container { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Container> Container1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyValues> PropertyValues { get; set; }
        public virtual Version Version { get; set; }
    }
}
