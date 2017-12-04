using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria
{
    public class Lista
    {
            public int id;
            public string marca;
            public string modelo;
            public string color;
            public int precio;
            public int cantidad;
            public int descuento;
            public float talla;
            public Lista next;

            public Lista(int id, string marca, string modelo, string color, int precio, int cantidad, int descuento, float talla)
            {
                next = null;
                this.id = id;
                this.marca = marca;
                this.modelo = modelo;
                this.color = color;
                this.precio = precio;
                this.cantidad = cantidad;
                this.descuento = descuento;
                this.talla = talla;
            }

    }
}
