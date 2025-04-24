using Parcial3_aplicaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3_aplicaciones.Clases
{
    public class clsTorneos
    {
        private DBExamenEntities dbExamen = new DBExamenEntities();
        public Torneo torneo { get; set; }

        public string Guardar()
        {
            try
            {
                torneo.idAdministradorITM = 1;
                dbExamen.Torneos.Add(torneo);
                dbExamen.SaveChanges();
                return "¡Torneo guardado exitosamente con id: " + torneo.idTorneos;
            }
            catch (Exception ex)
            {
                return "Error al guardar el torneo: " + ex.Message;
            }
        }

        public string Actualizar(int idTorneo, Torneo nuevosDatos)
        {
            try
            {
                Torneo torneo = dbExamen.Torneos.FirstOrDefault(t => t.idTorneos == idTorneo);
                if (torneo == null)
                {
                    return "No se encontró un torneo con id: " + idTorneo;
                }

                torneo.TipoTorneo = nuevosDatos.TipoTorneo;
                torneo.NombreTorneo = nuevosDatos.NombreTorneo;
                torneo.NombreEquipo = nuevosDatos.NombreEquipo;
                torneo.ValorInscripcion = nuevosDatos.ValorInscripcion;
                torneo.FechaTorneo = nuevosDatos.FechaTorneo;
                torneo.Integrantes = nuevosDatos.Integrantes;

                dbExamen.SaveChanges();
                return "¡Torneo actualizado exitosamente!";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el torneo: " + ex.Message;
            }
        }

        public string Eliminar(int idTorneo)
        {
            try
            {
                Torneo torneo = dbExamen.Torneos.FirstOrDefault(t => t.idTorneos == idTorneo);

                if (torneo == null)
                {
                    return "No se encontro torneo con id: " + idTorneo;
                }

                dbExamen.Torneos.Remove(torneo);
                dbExamen.SaveChanges();

                return "¡Torneo eliminado exitosamente!";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el torneo: " + ex.Message;
            }
        }

        public List<Torneo> ConsultarTorneos(string tipo, string nombre, DateTime? fecha)
        {
            var torneos = dbExamen.Torneos.ToList();

            if (!string.IsNullOrEmpty(tipo))
                torneos = torneos.Where(t => t.TipoTorneo.Contains(tipo)).ToList();

            if (!string.IsNullOrEmpty(nombre))
                torneos = torneos.Where(t => t.NombreTorneo.Contains(nombre)).ToList();

            if (fecha.HasValue)
                torneos = torneos.Where(t => t.FechaTorneo.Date == fecha.Value.Date).ToList();

            return torneos;
        }
    }
}
