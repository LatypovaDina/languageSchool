//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace languageSchool
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public partial class Usluga
    {
        public int ID { get; set; }
        public string UslugaName { get; set; }
        public string UslugaPhoto { get; set; }
        public int UslugaTime { get; set; }
        public decimal UslugiCost { get; set; }
        public Nullable<double> UslugiSkid { get; set; }
		public string State
        {
            get
            {
                return Convert.ToBoolean(UslugiSkid) ? "0.1" : null;
            }
        }
    public SolidColorBrush solidColorBrush

        {
            get
            {
                return Convert.ToBoolean(UslugiSkid) ? Brushes.Green : Brushes.White;
            }
        }

    }
}
