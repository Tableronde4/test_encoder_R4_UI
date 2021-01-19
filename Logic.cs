using System;
using System.IO;

namespace test_encoder_R4_UI
{
    public class Logic
    {
        public LogicMemory logicMemory = new LogicMemory();
        public Output outputLogic = new Output();
        public StreamWriter sw;

        public void OpenFile(Input input)
        {
            var path = "Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            sw = new StreamWriter($"{path}/ResultOfSimulationR4_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

            sw.WriteLineAsync($"SimulationTestStartAt = {DateTime.Now:yyyyMMdd_HHmmss}");
            sw.WriteLineAsync("EachLineIsComposedOF:\nIndex,Counter,Direction");
        }
        public void CloseFile()
        {
            sw.WriteLineAsync($"SimulationTestEndedAt = {DateTime.Now:yyyyMMdd_HHmmss}");
            sw.Close();
        }
        public Output LogicR4(Input input)
        {
            switch (logicMemory.Etat)
            {
                case 0:
                    IsStartingNewCycle(input);
                    break;
                case 1:
                    if (IsBlackBoxOn(input) == 1) break;
                    if (IsBothChanging(input, 1) == 1) break;
                    if (IsPulseChanging(input, 1) == 1) break;
                    IsIndexChanging(input, 1);
                    break;
                case 2:
                    if (IsBlackBoxOn(input) == 1) break;
                    if (IsBothChanging(input, 2) == 1) break;
                    if (IsPulseChanging(input, 2) == 1) break;
                    IsIndexChanging(input, 1);
                    break;
                case 3:
                    if (IsBlackBoxOn(input) == 1) break;
                    if (IsBothChanging(input, 3) == 1) break;
                    if (IsPulseChanging(input, 3) == 1) break;
                    IsIndexChanging(input, 3);
                    break;
                case 4:
                    if (IsBlackBoxOn(input) == 1) break;
                    if (IsBothChanging(input, 4) == 1) break;
                    if (IsPulseChanging(input, 4) == 1) break;
                    IsIndexChanging(input, 4);
                    break;
                case 5:
                    IsEndCycle(input);
                    break;
            }
            return outputLogic;
        }
        private void IsStartingNewCycle(Input input)
        {
            if (input.IndexI == 1)
            {
                logicMemory.Etat = 1;
                logicMemory.IndexCounter = 1;
            }
        }
        private int IsBlackBoxOn(Input input)
        {
            if (input.BlackBox == 1)
            {
                logicMemory.Etat = 5;
                sw.WriteLineAsync($"{logicMemory.IndexCounter},{logicMemory.Counter},{logicMemory.Direction}");
                outputLogic.Counter = logicMemory.Counter;
                outputLogic.IndexO = logicMemory.IndexCounter;
                outputLogic.Direction = logicMemory.Direction;
                return 1;
            }
            return 0;
        }
        private int IsBothChanging(Input input, int etat)
        {
            switch (etat)
            {
                case 1:
                    if (input.Pulse == 1 && input.IndexI == 0)
                    {
                        logicMemory.Etat = 3;
                        logicMemory.Counter++;
                        return 1;
                    }
                    break;
                case 2:
                    if (input.Pulse == 0 && input.IndexI == 0)
                    {
                        logicMemory.Etat = 4;
                        return 1;
                    }
                    break;
                case 3:
                    if (input.Pulse == 0 && input.IndexI == 1)
                    {
                        logicMemory.Etat = 1;
                        logicMemory.IndexCounter++;
                        return 1;
                    }
                    break;
                case 4:
                    if (input.Pulse == 1 && input.IndexI == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.IndexCounter++;
                        logicMemory.Counter++;
                        return 1;
                    }
                    break;
            }
            return 0;
        }
        private int IsPulseChanging(Input input, int etat)
        {
            switch (etat)
            {
                case 1:
                    if (input.Pulse == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.Counter++;
                        return 1;
                    }
                    break;
                case 2:
                    if (input.Pulse == 0)
                    {
                        logicMemory.Etat = 1;
                        return 1;
                    }
                    break;
                case 3:
                    if (input.Pulse == 0)
                    {
                        logicMemory.Etat = 4;
                        return 1;
                    }
                    break;
                case 4:
                    if (input.Pulse == 1)
                    {
                        logicMemory.Etat = 3;
                        logicMemory.Counter++;
                        return 1;
                    }
                    break;
            }
            return 0;
        }
        private int IsIndexChanging(Input input, int etat)
        {
            switch (etat)
            {
                case 1:
                    if (input.IndexI == 0)
                    {
                        logicMemory.Etat = 4;
                    }
                    break;
                case 2:
                    if (input.IndexI == 0)
                    {
                        logicMemory.Etat = 3;
                    }
                    break;
                case 3:
                    if (input.IndexI == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.IndexCounter++;
                    }
                    break;
                case 4:
                    if (input.IndexI == 1)
                    {
                        logicMemory.Etat = 1;
                        logicMemory.IndexCounter++;
                    }
                    break;
            }
            return 0;
        }
        private void IsEndCycle(Input input)
        {
            if (input.LimitOpen == 1 || input.LimitClose == 1)
            {
                logicMemory.Etat = 0;

                logicMemory.Counter = 0;
                outputLogic.Counter = logicMemory.Counter;

                logicMemory.IndexCounter = 0;
                outputLogic.IndexO = logicMemory.IndexCounter;

                if (input.LimitOpen == 1)
                {
                    logicMemory.Direction = '^';
                    outputLogic.Direction = ' ';
                }
                else
                {
                    logicMemory.Direction = 'v';
                    outputLogic.Direction = ' ';
                }
            }
        }
    }
    public class LogicMemory
    {
        public int Etat { get; set; }
        public int Counter { get; set; }
        public int IndexCounter { get; set; }
        public char Direction { get; set; }
    }
}
