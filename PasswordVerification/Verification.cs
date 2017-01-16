using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerification
{
    public class ValidationException : System.Exception
    {
        public ValidationException(string s) : base(s)
        {

        }
    }
    public class Verification
    {
            private string _password;
            //private static int[] flag = new int[5];
            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }
            public Verification()
        {

        }
            private Verification(string password)
            {
                _password = password;
            }
        public bool Verify(string Password,object type)
        {
            bool ret= false;
            if (type.GetType()==typeof(Internal))
            {
                Internal i=(Internal)type;
               
                ret = i.VerifyPassword(Password);
            }
            else if (type.GetType()==typeof(External))
            {
                External e = (External)type;
                ret = e.VerifyPassword(Password);
            }
            else
            {
                //if (count >= 3)
                //    return false;
                //else 
                Console.WriteLine("ERROR");
            }
            return ret;

        }


        public class External: Verification
        {
            public External():base()
            {
            }
            public bool VerifyPassword(string Password)
            {
                int count = 0;
                try
                {
                    VerifyNull(Password);
                }
                catch (ValidationException e)
                {
                    count++;
                }
                try
                {
                    VerifyLength(Password);
                }
                catch (ValidationException e)
                {
                    count++;
                }
                try
                {
                    VerifyLower(Password);
                }
                catch (ValidationException e)
                {
                    count++;
                }
                try
                {
                    VerifyUpper(Password);
                }
                catch (ValidationException e)
                {
                    count++;
                }
                try
                {
                    VerifyNumber(Password);
                }
                catch (ValidationException e)
                {
                    count++;
                }
                if (count >= 3)
                    return false;
                else return true;
            }
            public static bool VerifyNull(string Password)
            {
                if (string.IsNullOrEmpty(Password))
                {
                    //flag[0] = 1;
                    throw new ValidationException("Password can't be empty");
                    // return false;
                }
                return true;
            }
            public static bool VerifyUpper(string Password)
            {

                if (!(Password.Any(c => char.IsUpper(c))))
                {
                    //flag[2] = 1;
                    throw new ValidationException("Password should have at least one upper case letter");
                }
                return true;
            }

            public static bool VerifyLower(string Password)
            {

                if (!(Password.Any(c => char.IsLower(c))))
                {
                    //flag[2] = 1;
                    throw new ValidationException("Password should have at least one Lower case letter");
                }
                return true;
            }
            public static bool VerifyNumber(string Password)
            {

                if (!(Password.Any(c => char.IsNumber(c))))
                {
                    //flag[2] = 1;
                    throw new ValidationException("Password should have at least one number");
                }
                return true;
            }
            public static bool VerifyLength(string Password)
            {

                if (Password.Length <= 8)
                {
                    //flag[2] = 1;
                    throw new ValidationException("password should have minimum of 8 charcaters");
                }
                return true;
            }
        }
        public class Internal : Verification
        {
            public Internal() : base()
            {
            }
            
            public bool VerifyPassword(string Password)
            {
                if (Password.Length > 8)
                    return true;
                else return false;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                //PasswordValidator.Verify(Console.ReadLine());
                //Console.WriteLine(Verification.Verify(Console.ReadLine()));
                // object i = new Internal("dhan");
                //Console.WriteLine(i.GetType());
                string password = Console.ReadLine();
                //Internal e = new Internal();
                External e = new External();
                Verification v = new Verification();
                v.Verify(password, e);
                Console.WriteLine(v.Verify(password,e));
                Console.ReadKey();
            }
        }
    }
    }

