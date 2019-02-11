using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassUtil
{
    public static class Validation
    {
        public static bool validarEmail(string email)
        {
            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool validarTelefone(string fone)
        {
            string[] split = fone.Split(new Char[] { '(', ')', ' ', '-', '_' });

            string n = "";

            for (int c = 0; c < split.Length; c++)
            {
                if (split[c] != "")
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
                        if (c == 9)
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
