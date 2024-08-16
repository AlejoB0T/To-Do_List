using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Models
{
    public class Tarea
    {

        public string Titulo { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime? FechaLimite { get; private set; } // la fecha limite es opcional
        public bool Completado { get; private set; }


        // Constructor; Inicializa Tarea
        public Tarea(string titulo, string descripcion, DateTime? fechaLimite)
        {

            Titulo = titulo;
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            Completado = false;

        }

        // Metodo; Para Marcar Tarea
        public void Completar()
        {

            Completado = true;

        }

        // Metodo; Estado Tarea y Fecha limite a texto
        public override string ToString()
        {
            string estado = Completado ? "Completado" : "Pendiente";
            string fechaTexto = FechaLimite.HasValue ? FechaLimite.Value.ToShortDateString() : "Sin fecha limite";
            return $"{Titulo} - {Descripcion} (Fecha limite: {fechaTexto}) - {estado}";
        }
    }
}