using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlaRecursos.Control
{
    public class ValidadorCpf
    {
        public bool validadorCPF(string CPF)
        {
            int tot = 0, op = 10, dig1, dig2;

            if (CPF.Count() > 11 || CPF.Count() < 11)
            {
                return false;
            }

            if (CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555" ||
                CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" || CPF == "99999999999" || CPF == "00000000000")
            {
                return false;
            }

            dig1 = int.Parse(CPF[9].ToString());
            dig2 = int.Parse(CPF[10].ToString());

            for (int i = 0; i < 9; i++)
            {
                tot += int.Parse(CPF[i].ToString()) * op;
                op--;
            }

            if (tot % 11 == 1 || tot % 11 == 0)
            {
                if (dig1 != 0)
                {
                    return false;
                }
            }
            else
            {
                if (dig1 != 11 - tot % 11)
                {
                    return false;
                }
            }

            tot = 0;
            op = 11;

            for (int i = 0; i < 10; i++)
            {
                tot += int.Parse(CPF[i].ToString()) * op;
                op--;
            }

            if (tot % 11 == 1 || tot % 11 == 0)
            {
                if (dig2 != 0)
                {
                    return false;
                }
            }
            else
            {
                if (dig2 != 11 - tot % 11)
                {
                    return false;
                }
            }

            return true;
        }
    }
}