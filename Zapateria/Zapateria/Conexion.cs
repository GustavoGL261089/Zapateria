using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Zapateria
{
    class Conexion
    {
        MySqlCommand Query = new MySqlCommand();
        MySqlConnection conexion;
        MySqlDataReader consultar;
        public string sql = ";server=localhost;user id=root;database=p_zapateria;password=smallville";

        public void test_connection()
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                MessageBox.Show("Conectado con éxito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public Lista obten_inventario()
        {
            Lista lista=null,tem;
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "select idzapatos,color,modelo,talla,precio,existencias,marcas.marca from marcas, zapatos where zapatos.marca=marcas.idmarcas;";
                Query.Connection = conexion;
                consultar = Query.ExecuteReader();

                while (consultar.Read())
                {

                    if (lista == null)
                    {
                        lista = new Lista(consultar.GetInt32(0), consultar.GetString(6), consultar.GetString(2), consultar.GetString(1), consultar.GetInt32(4), consultar.GetInt32(5), 0, consultar.GetInt32(3));
                    }
                    else
                    {
                        tem = new Lista(consultar.GetInt32(0), consultar.GetString(6), consultar.GetString(2), consultar.GetString(1), consultar.GetInt32(4), consultar.GetInt32(5), 0, consultar.GetInt32(3));
                        tem.next = lista;
                        lista = tem;
                    }
                }

                consultar.Close();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }

        public string obten_marca(string marca)
        {
            string m = "";
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "SELECT marca FROM marcas WHERE codigobarra='"+marca+"'";
                Query.Connection = conexion;
                consultar = Query.ExecuteReader();

                while (consultar.Read())
                {
                    m=consultar.GetString(0);
                }

                consultar.Close();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return m;
        }

        public List<string> obtener_marcas()
        {
            List<string> marcas= new List<string>();

            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "SELECT marca FROM marcas";
                Query.Connection = conexion;
                consultar = Query.ExecuteReader();

                while (consultar.Read())
                {
                    marcas.Add(consultar.GetString(0));
                }

                consultar.Close();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return marcas;
        }

        public string sesion(string nombre, string clave)
        {
            string tipo = "invalido";
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "SELECT tipo FROM usuarios WHERE nombre='"+nombre+"' and clave='"+clave+"'";
                Query.Connection = conexion;
                consultar = Query.ExecuteReader();

                while (consultar.Read()){
                    tipo = consultar.GetString(0);
                }

                consultar.Close();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return tipo;
        }


        public void insertar_usuario(string nombre, string clave, string tipo)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "Insert into usuarios (nombre, clave, tipo) values ('"+nombre+"', '"+clave+"', '"+tipo+"')";
                Query.Connection = conexion;
                Query.ExecuteNonQuery();

                MessageBox.Show("Registro insertado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertar_venta(string vendedor, string fecha, string total)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "Insert into venta (vendedor, fecha, total) values ('" + vendedor + "', '" + fecha + "', '" + total + "')";
                Query.Connection = conexion;
                Query.ExecuteNonQuery();

                MessageBox.Show("Registro insertado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertar_marca(string marca, string codigo)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "Insert into marcas (marca, codigobarra) values ('" + marca + "', '" + codigo + "')";
                Query.Connection = conexion;
                Query.ExecuteNonQuery();

                MessageBox.Show("Registro insertado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void eliminar_registro(int id, string tabla, string campo)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "DELETE FROM "+tabla+" WHERE "+campo+"="+id+"";
                Query.Connection = conexion;
                Query.ExecuteNonQuery();

                MessageBox.Show("Registro eliminado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void modificarzapato(int id, int cantidad, string modelo, string color, float talla, int precio)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "UPDATE zapatos SET color='" + color + "', modelo='" + modelo + "', talla=" + talla + ", precio=" + precio + ", existencias=" + cantidad + " WHERE idzapatos=" + id;
                    Query.Connection = conexion;
                    Query.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertar_zapato(int cantidad, string marca_cadena, string modelo, string color, float talla, int precio)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                MySqlCommand Query2 = new MySqlCommand();
                int marca=0;
                Query2.CommandText = "SELECT idmarcas FROM marcas WHERE marca='"+marca_cadena+"'";
                Query2.Connection = conexion;
                consultar = Query2.ExecuteReader();
                while (consultar.Read())
                {
                    marca = consultar.GetInt32(0);
                }
                consultar.Close();
 
                if (marca == 0)
                {
                    MessageBox.Show("Marca no encontrada", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Query.CommandText = "Insert into zapatos (color, modelo, talla, precio, existencias, marca)" +
                                        "values ('" + color + "', '" + modelo + "', '" + talla + "', '" + precio + "', '" + cantidad + "', '" + marca + "')";
                    Query.Connection = conexion;
                    Query.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertar_subventa(int ventatotal, int zapato, int cantidad, int precio, int subtotal)
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = sql;
                conexion.Open();
                Query.CommandText = "Insert into zapatos (ventatotal, zapato, cantidad, precio, subtotal)" +
                                    "values ('" + ventatotal + "', '" + zapato + "', '" + cantidad + "', '" + precio + "', '" + subtotal + "')";
                Query.Connection = conexion;
                Query.ExecuteNonQuery();

                MessageBox.Show("Registro insertado con exito", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
