//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kp.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int id { get; set; }
        public int client { get; set; }
        public int staff { get; set; }
        public int service { get; set; }
        public double cost { get; set; }
        public double sale { get; set; }
        public bool finished { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Services Services { get; set; }
        public virtual Staff Staff1 { get; set; }
    }
}
