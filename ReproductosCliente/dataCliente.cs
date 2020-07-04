using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductosCliente 
{

    class dataCliente
    {
        public String nombre;
        public String apellido;
        public String carrera;
        public String matricula;
        public double saldo;
        public dataCliente()
        {
            Console.WriteLine("Datacliente iniciada");
            settearTODO(); //ahora cada que se instancia la clase se settean todos los valores
            //no es lo correcto pero funciona
        }

        public void settearTODO()
        {
            setName();
            setApellido();
            setCarrera();
            setSaldo();
            setMatricula();
        }

        public String getName()
        {
            return nombre;
        }
        public void setName()
        {
            nombre = "Luis Eduardo";
        }

        public String getApellido()
        {
            return apellido;
        }
        public void setApellido()
        {
            apellido = "Aguirre Fuentes";
        }

        public String getCarrera()
        {
            return carrera;
        }
        public void setCarrera()
        {
            carrera = "LIS";
        }

        public String getMatricula()
        {
            return matricula;
        }
        public void setMatricula()
        {
            matricula = "ZS17016273";
        }

        public double getSaldo()
        {
            return saldo;
        }
        public void setSaldo()
        {
            saldo = 13.50;
        }

    }
        
}
