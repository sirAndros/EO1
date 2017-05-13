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
    
    public partial class ObjectType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ObjectType()
        {
            this.ObjectInstance = new HashSet<ObjectInstance>();
            this.Properties = new HashSet<Properties>();
            this.ObjectType1 = new HashSet<ObjectType>();
            this.ObjectType2 = new HashSet<ObjectType>();
            this.ObjectType11 = new HashSet<ObjectType>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> BaseType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectInstance> ObjectInstance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Properties> Properties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectType> ObjectType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectType> ObjectType2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectType> ObjectType11 { get; set; }
        public virtual ObjectType ObjectType21 { get; set; }
    }
}
