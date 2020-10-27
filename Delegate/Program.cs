using System;

namespace Delegate
{
    class Program
    {
        public delegate void MyDelegateA();                          // pas de param en entrée ni sortie
        public delegate void MyDelegateB(string valA, string valB);  // param en entrée pas en sortie
        public delegate int MyDelegateC(int valA, int valB);         // param en entrée et en sortie

        static void Main(string[] args)
        {   // Appel méthode AfficheBjr de la classe MaClass
            MyDelegateA myDelegateA;
            myDelegateA = MaClass.AfficheBjr;
            myDelegateA();

            // Appel via méthode anonyme
            myDelegateA = delegate () { Console.WriteLine("Bonjour"); };
            myDelegateA();

            // Appel via méthode anonyme expression Lambda
            myDelegateA = () => { Console.WriteLine("Bonjour"); };
            myDelegateA();

            // Via Action<> pour Appel méthode AfficheBjr de la classe MaClass
            Action myActionA = MaClass.AfficheBjr;
            myActionA();

            // Via Action<> pour Appel via méthode anonyme
            Action myActionB = delegate () { Console.WriteLine("Bonjour"); };
            myActionB();

            // Via Action<> pour Appel via méthode anonyme expression Lambda
            Action myActionC = () => { Console.WriteLine("Bonjour"); };
            myActionC();


            Console.WriteLine("===============================================================================");
            MyDelegateB myDelegateB;

            // Appel méthode AfficheMsg de la classe MaClass
            myDelegateB = MaClass.AfficheMsg;
            myDelegateB("BAENS", "LUDOVIC");

            // Appel via méthode anonyme
            myDelegateB = delegate (string nom, string prenom) { Console.WriteLine($"Nom {nom}- Prenom {prenom}"); };
            myDelegateB("BAENS", "EMELINE");
            // Appel via méthode anonyme expression Lambda
            myDelegateB = (string nom, string prenom) => { Console.WriteLine($"Nom {nom}- Prenom {prenom}"); };
            myDelegateB("BAENS", "LEA");

            // Via Action<> pour Appel méthode AfficheMsg de la classe MaClass
            Action<string, string> myActionD = MaClass.AfficheMsg;
            myActionD("BAENS","FRANCOIS");

            // Via Action<> pour Appel via méthode anonyme
            Action<string, string> myActionE = delegate (string nom, string prenom) { Console.WriteLine($"Nom {nom}- Prenom {prenom}"); };
            myActionE("BAENS","PIERRE");

            // Via Action<> pour Appel via méthode anonyme expression Lambda
            Action<string, string> myActionF = (string nom, string prenom) => { Console.WriteLine($"Nom {nom}- Prenom {prenom}"); };
            myActionF("BAENS","RIRI");


            Console.WriteLine("===============================================================================");
            MyDelegateC myDelegateC;

            // Appel méthode CalculEntier de la classe MaClass
            myDelegateC = MaClass.CalculEntier;
            Console.WriteLine(myDelegateC(5, 5));

            // Appel via méthode anonyme
            myDelegateC = delegate (int nbrA, int nbrB) { return nbrA + nbrB; };
            Console.WriteLine(myDelegateC(5, 10));
            

            // Appel via méthode anonyme expression Lambda
            myDelegateC = (int nbrA, int nbrB) => { return nbrA + nbrB; };
            Console.WriteLine(myDelegateC(10, 10));

            // Via Func<> pour Appel méthode AfficheMsg de la classe MaClass
            Func<int, int, int> myFuncA = MaClass.CalculEntier;
            Console.WriteLine(myFuncA(200,20));
            // Via Func<> pour Appel via méthode anonyme
            Func<int, int, int> myFuncB = delegate (int nbrA, int nbrB) { return nbrA + nbrB; };
            Console.WriteLine(myFuncB(400,500));

            // Via Func<> pour Appel via méthode anonyme expression Lambda
            Func<int, int, int> myFuncC = (int nbrA, int nbrB) => { return nbrA + nbrB; };
            Console.WriteLine(myFuncC(110, 220));



            Console.ReadKey();
        }
    }

    public class MaClass
    {
        public static void AfficheBjr()
        {
            Console.WriteLine("Bonjour");
        }

        public static void AfficheMsg(string nom, string prenom)
        {
            Console.WriteLine($"Nom {nom}- Prenom {prenom}");
        }

        public static int CalculEntier(int nbrA, int nbrB)
        {
            return nbrA + nbrB;
        }
    }
}
