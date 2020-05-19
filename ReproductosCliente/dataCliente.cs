using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductosCliente 
{

    class dataCliente
    {
        public String _name;
        public String _apellido;
        public String _carrera;
        public String _matricula;
        public double _saldo;
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
            return _name;
        }
        public void setName()
        {
            _name = "Luis Eduardo";
        }

        public String getApellido()
        {
            return _apellido;
        }
        public void setApellido()
        {
            _apellido = "Aguirre Fuentes";
        }

        public String getCarrera()
        {
            return _carrera;
        }
        public void setCarrera()
        {
            _carrera = "LIS";
        }

        public String getMatricula()
        {
            return _matricula;
        }
        public void setMatricula()
        {
            _matricula = "ZS17016273";
        }

        public double getSaldo()
        {
            return _saldo;
        }
        public void setSaldo()
        {
            _saldo = 13.50;
        }

    }
        
}
