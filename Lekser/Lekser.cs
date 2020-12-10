using System.Collections.Generic;
using System.Linq;

namespace Lekser
{
    class Lekser
    {
        public List<Token> Token;

        public bool analizuj(string arg)
        {
            Token = new List<Token>();
            var index = 0;
            var rez = new LekRezultat();
            rez.Rezultat = false;

            while (index < arg.Length && (rez = S(arg, index)).Rezultat)
            {
                Token.Add(rez.Token);
                index = index + rez.Token.Argument.Length;
            }

            return rez.Rezultat;
        }

        public LekRezultat S(string args, int i)
        {
            LekRezultat result;
            if ((result = N(args, i)).Rezultat) return result;
            if ((result = B(args, i)).Rezultat) return result;
            return (result = L(args, i)).Rezultat ? result : O(args, i);
        }

        public LekRezultat O(string args, int i)
        {
            var result = new LekRezultat();
            if (args[i] != '+' && args[i] != '-' && args[i] != '*' && args[i] != '/') return result;
            result.Rezultat = true;
            result.Token = new Token(Typ.Operator, args[i].ToString(), i);
            return result;
        }


        public LekRezultat N(string args, int i)
        {
            var result = new LekRezultat();
            if (args[i] != '(' && args[i] != ')') return result;
            result.Rezultat = true;
            result.Token = new Token(Typ.Nawias, args[i].ToString(), i);
            return result;
        }

        public LekRezultat B(string args, int i)
        {
            LekRezultat buffor, result = new LekRezultat();
            if (args.Length > i + 1 && args[i] == ' ' && (buffor = B(args, i + 1)).Rezultat)
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.BialeZnaki, args[i].ToString() + buffor.Token.Argument, i);
                return result;
            }
            else if (args[i] == ' ')
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.BialeZnaki, args[i].ToString(), i);
                return result;
            }

            return result;
        }

        public LekRezultat L(string args, int i)
        {
            LekRezultat buffor, result = new LekRezultat();
            if (args[i] == '0')
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.Liczba, args[i].ToString(), i);
                return result;
            }
            else if (args.Length > i + 1 && "123456789".Contains(args[i]) && (buffor = R(args, i + 1)).Rezultat)
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.Liczba, args[i].ToString() + buffor.Token.Argument, i);
                return result;
            }
            return result;
        }

        public LekRezultat R(string args, int i)
        {
            LekRezultat buffor, result = new LekRezultat();
            if (args.Length > i + 1 && "123456789".Contains(args[i]) && (buffor = R(args, i + 1)).Rezultat)
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.Liczba, args[i].ToString() + buffor.Token.Argument, i);
                return result;
            }
            else if (args.Length > i + 1 && args[i] == '0' && (buffor = R(args, i + 1)).Rezultat)
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.Liczba, args[i].ToString() + buffor.Token.Argument, i);
                return result;
            }
            else if ("123456789".Contains(args[i]))
            {
                result.Rezultat = true;
                result.Token = new Token(Typ.Liczba, args[i].ToString(), i);
                return result;
            }
            result.Token = new Token(Typ.Liczba, "", i);
            result.Rezultat = true;
            return result;
        }

    }
}
