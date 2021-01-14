using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Deportivo: Coche, ICoche
    {
        public Deportivo(String marca, String modelo, String imagen, int velocidadMaxima)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelocidadMaxima = velocidadMaxima;
        }
        public Deportivo()
        {
            this.Marca = "type-r";
            this.Modelo = "Honda";
            this.Imagen = "civic-tuneado.jpg";
            this.Velocidad = 0;
            this.VelocidadMaxima = 250;
        }

    }
}
