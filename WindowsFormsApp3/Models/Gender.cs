using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Мужской")]
        Male = 1,

        /// <summary>
        /// 
        /// </summary>
		[Description("Женский")]
        Female = 2,

        /// <summary>
        /// 
        /// </summary>
		[Description("Пёс")]
        Dog = 3,

        /// <summary>
        /// 
        /// </summary>
		[Description("Кот")]
		Cat = 4,
	}
}
