using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtil
{
    public class ValidarTelefone
    {
        public bool validarTelefone(string fone)
        {
            string[] split = fone.Split(new Char[] { '(', ')', ' ', '-', '_'});

            string n = "";

            for (int c = 0; c < split.Length; c++)
            {
                if(split[c] != "")
                {
                    n += split[c];
                }
            }

            char[] chars = n.ToCharArray();

                if (chars.Length == 10)
                {
                for (int c = 0; c < chars.Length; c++)
                {
                    if (chars[c] == '0' || chars[c] == '1' || chars[c] == '2' || chars[c] == '3' || chars[c] == '4' || chars[c] == '5' || chars[c] == '6' || chars[c] == '7' || chars[c] == '8' || chars[c] == '9')
                    {
                        if(c == 9)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}
