//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoWPF.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_()
        {
            this.Address = new HashSet<Address>();
        }
    
        public int Id_Order { get; set; }
        public Nullable<int> Fk_Driver { get; set; }
        public Nullable<int> Fk_Client { get; set; }
        public string cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
