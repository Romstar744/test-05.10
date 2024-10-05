using System;
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
        public string Name { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// <inheritdoc cref="WindowsFormsApp3.Models.Gender"/>
        /// </summary>
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