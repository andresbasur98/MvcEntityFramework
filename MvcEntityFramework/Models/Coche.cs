using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Coche: ICoche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }

        public int VelocidadMaxima { get; set; }
        public int Velocidad { get; set; }

        public Coche()
        {
            this.Marca = "Volkswagen";
            this.Modelo = "Escarabajo";
            this.Imagen = "civic-antiguo.jpg";
            this.VelocidadMaxima = 200;
            this.Velocidad = 0;
        }
        public void Acelerar()
        {
            this.Velocidad += 10;

            if(this.Velocidad >= this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }

        }

        public void Frenar()
        {
            this.Velocidad -= 10;
            if(this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
        }
    }
}
