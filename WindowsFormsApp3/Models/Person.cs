using System;
using WindowsFormsApp3.Models;

namespace WindowsFormsApp3.Model
{
    /// <summary>
    /// ������
    /// </summary>
    public class Person
    {
        
        public Guid Id { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ���� ��������
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// <inheritdoc cref="WindowsFormsApp3.Models.Gender"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// ������� ������
        /// </summary>
        public decimal AvgGrade{ get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public bool Expelled { get; set; }
        /// <summary>
        /// �������������
        /// </summary>
        public bool Dept { get; set; }

    }
}