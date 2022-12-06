using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Operaciones
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Sumar(int numero1, int numero2);

        [OperationContract]
        int Restar(int numero1, int numero2);

        [OperationContract]
        int Multiplicar(int numero1, int numero2);

        [OperationContract]
        int Dividir(int numero1, int numero2);

        [OperationContract]
        string Saludo(string nombre);

    }
}
