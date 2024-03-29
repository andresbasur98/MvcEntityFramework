﻿using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEnfermos
    {
        private EnfermosContext context;

        public RepositoryEnfermos(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.context.Enfermos
                           select datos;
            return consulta.ToList();
        }

        public Enfermo BuscarEnfermo(int inscripcion)
        {
            var consulta = from datos in this.context.Enfermos
                           where datos.Inscripcion == inscripcion
                           select datos;
            // Cuantos datos devolverá la consulta

            if(consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.First();
            }
        }

        public List<Genero> GetGeneros()
        {
            var consulta = (from datos in this.context.Enfermos
                            select datos.Sexo).Distinct();
            List<Genero> generos = new List<Genero>();
            foreach(String dato in consulta)
            {
                Genero gen = new Genero();
                gen.Value = dato;
                if(dato.ToLower() == "f")
                {
                    gen.Text = "FEMENINO";
                }
                else
                {
                    gen.Text = "MASCULINO";
                }
                generos.Add(gen);
            }
            return generos;
        }

        public List<Enfermo> GetEnfermosGenero(String genero)
        {
            var consulta = from datos in this.context.Enfermos
                           where datos.Sexo == genero
                           select datos;
            return consulta.ToList();
        }


        public void EliminarEnfermo(int inscripcion)
        {
            // Necesitamos buscar la entidad a eliminar
            Enfermo enf = this.BuscarEnfermo(inscripcion);
            // ELIMINAMOS EL OBJETO DEL CONTEXT Y SU DBSET
            this.context.Enfermos.Remove(enf);
            // Si desdeamos almacenar los cambios en BBDD
            this.context.SaveChanges();
        }

        public void InsertarEnfermo(int inscripcion, String apellido, String direccion, DateTime fechanac, String genero, String nss)
        {
            Enfermo enfermo = new Enfermo();
            enfermo.Inscripcion = inscripcion;
            enfermo.Apellido = apellido;
            enfermo.Direccion = direccion;
            enfermo.FechaNacimiento = fechanac;
            enfermo.Sexo = genero;
            enfermo.SeguridadSocial = nss;
            this.context.Enfermos.Add(enfermo);
            this.context.SaveChanges();
        }

        public void ModificarEnfermo(int inscripcion, String apellido, String direccion, 
            DateTime fechanac, String genero, String nss)
        {
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            enfermo.Apellido = apellido;
            enfermo.Direccion = direccion;
            enfermo.FechaNacimiento = fechanac;
            enfermo.Sexo = genero;
            enfermo.SeguridadSocial = nss;
            this.context.SaveChanges();
        }
    }
}
