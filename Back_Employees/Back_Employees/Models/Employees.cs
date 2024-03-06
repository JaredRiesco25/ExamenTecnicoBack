using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back_Employees.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }
        public bool Estatus { get; set; }


        public Employees() { }

        public Employees(int idEmployee, string nombreEmployee, string fechaEmployee, int edadEmployee, string posicionEmployee, bool estatusEmployee) 
        {
            Id = idEmployee; 
            Nombre = nombreEmployee;
            FechaNacimiento = fechaEmployee;
            Edad = edadEmployee;
            Posicion = posicionEmployee;
            Estatus = estatusEmployee;
        }

        public Employees(string nombreEmployee, string fechaEmployee, int edadEmployee, string posicionEmployee, bool estatusEmployee)
        {
            Nombre = nombreEmployee;
            FechaNacimiento = fechaEmployee;
            Edad = edadEmployee;
            Posicion = posicionEmployee;
            Estatus = estatusEmployee;
        }

    }
}