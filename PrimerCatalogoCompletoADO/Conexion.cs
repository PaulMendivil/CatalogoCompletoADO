using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrimerCatalogoCompletoADO
{
    public class Conexion
    {
        SqlConnection cn = new SqlConnection("Data Source = DESKTOP-UC0TM7V; Initial Catalog = ALMACEN_GENERAL; Integrated Security = true");
        SqlDataReader dr;

        public struct strPacientes
        {
            public int ID;
            public String Nombre;
        }

        public void Listar(ref strPacientes[] arrPac, String Filtro)
        {
            cn.Open();
            SqlCommand comando = new SqlCommand();
            SqlParameter par = new SqlParameter("@filtro", Filtro);
            comando.Connection = cn;
            comando.Parameters.Add(par);
            comando.CommandText = "SELECT COUNT(*) FROM CONSULTORIO_PRACTICA.COPPacientes WHERE NombrePaciente LIKE '%'+@filtro+'%'";
            
            try
            {
                int NF = Convert.ToInt32(comando.ExecuteScalar());
                arrPac = new strPacientes[NF];
                comando.CommandText = "SELECT * FROM CONSULTORIO_PRACTICA.COPPacientes WHERE NombrePaciente LIKE '%'+@filtro+'%'";
                dr = comando.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    arrPac[i] = new strPacientes();
                    arrPac[i].ID = Convert.ToInt32(dr["idPaciente"]);
                    arrPac[i].Nombre = dr["NombrePaciente"].ToString();
                    i++;
                }
                dr.Close();
            }
            catch (Exception)
            {
                cn.Close();
                throw;
            }

            cn.Close();
        }
        

        public bool Agregar(strPacientes agg)
        {
            cn.Open();
            SqlParameter par1 = new SqlParameter("@id", agg.ID);
            SqlParameter par2 = new SqlParameter("@Nombre", agg.Nombre);
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add(par1);
            comando.Parameters.Add(par2);
            comando.Connection = cn;
            comando.CommandText = "INSERT INTO CONSULTORIO_PRACTICA.COPPacientes VALUES(@id, @Nombre)";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cn.Close();
                return false;
                throw;
            }
            cn.Close();
            return true;
        }

        public bool Modificar(strPacientes mod)
        {
            cn.Open();
            SqlParameter par1 = new SqlParameter("@id", mod.ID);
            SqlParameter par2 = new SqlParameter("@Nombre", mod.Nombre);
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add(par1);
            comando.Parameters.Add(par2);
            comando.Connection = cn;
            comando.CommandText = "UPDATE CONSULTORIO_PRACTICA.COPPacientes SET NombrePaciente = @Nombre WHERE idPaciente = @id";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cn.Close();
                return false;
                throw;
            }
            cn.Close();
            return true;
        }

        public bool Eliminar(strPacientes del)
        {
            cn.Open();
            SqlParameter par1 = new SqlParameter("@id", del.ID);
            SqlParameter par2 = new SqlParameter("@Nombre", del.Nombre);
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add(par1);
            comando.Parameters.Add(par2);
            comando.Connection = cn;
            comando.CommandText = "DELETE FROM CONSULTORIO_PRACTICA.COPPacientes WHERE idPaciente = @id";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cn.Close();
                return false;
                throw;
            }
            cn.Close();
            return true;
        }

    }
}
