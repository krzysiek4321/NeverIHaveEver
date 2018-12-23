using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace NeverIHaveEver
{
    public class Questions
    {
        private List<String> __questMaster;
        private LinkedList<String> __questShake;
        private int Randomness = 1;
        private Random randGen = new Random();

        public Questions(StreamReader fs)
        {
            if (fs == null) throw new FieldAccessException("Question Create: func arg is null");
            __questMaster = new List<string>();
            String line;
            while (null != (line = fs.ReadLine()))
                __questMaster.Add(line);
            //TODO: Krystian dopisz fatal dla usera żeby go zmotywować do UPDATU
            __questShake = MakeRandomList();
        }
        private LinkedList<String> MakeRandomList()
        {
            if (__questShake == null) __questShake = new LinkedList<string>();
            List<String> copy = new List<string>(__questMaster);

            for (int k = 0; k < Randomness; ++k)
            {
                for (int i = 0; i < copy.Count; ++i)
                {
                    int randIdx = randGen.Next() % copy.Count;
                    //zamiana elementów
                    String pom = copy[i];
                    copy[i] = copy[randIdx];
                    copy[randIdx] = pom;
                }
            }
            foreach (var Var in copy)
                __questShake.AddFirst(Var);
            return __questShake;
        }
        public String GetRandomQuestion()
        {
            String question;
            if (__questShake == null || __questShake.Count < 1)
                __questShake = MakeRandomList();
            question = __questShake.First.Value;
            __questShake.RemoveFirst();
            return question;
        }
    }
}
