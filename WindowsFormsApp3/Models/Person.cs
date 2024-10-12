using System;
using System.ComponentModel.DataAnnotations;
using WindowsFormsApp3.Models;

namespace WindowsFormsApp3.Model
{
    /// <summary>
    /// Студет
    /// </summary>
    public class Person
    {
        
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// <inheritdoc cref="WindowsFormsApp3.Models.Gender"/>
        /// </summary>
        [Range(0,5)]
        public Gender Gender { get; set; }
        /// <summary>
        /// Средняя оценка
        /// </summary>
        public decimal AvgGrade{ get; set; }
        /// <summary>
        /// Отчислен
        /// </summary>
        public bool Expelled { get; set; }
        /// <summary>
        /// Задолженности
        /// </summary>
        public bool Dept { get; set; }

    }
}