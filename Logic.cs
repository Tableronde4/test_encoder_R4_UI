namespace test_encoder_R4_UI
{

    public class Logic
    {
        public LogicMemory logicMemory = new LogicMemory();
        public Output outputLogic = new Output();
        public Output LogicR4(Input Input)
        {
            switch (logicMemory.Etat)
            {
                case 0:
                    if (Input.IndexI == 1)
                    {
                        logicMemory.Etat = 1;
                        logicMemory.IndexCounter = 1;
                    }
                    break;
                case 1:
                    if (Input.BlackBox == 1)
                    {
                        logicMemory.Etat = 5;
                        outputLogic.Counter = logicMemory.Counter;
                        outputLogic.IndexO = logicMemory.IndexCounter;
                    }
                    else if (Input.Pulse == 1 && Input.IndexI == 0)
                    {
                        logicMemory.Etat = 3;
                        logicMemory.Counter++;
                    }
                    else if (Input.Pulse == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.Counter++;
                    }
                    else if (Input.IndexI == 0)
                    {
                        logicMemory.Etat = 4;
                    }
                    break;
                case 2:
                    if (Input.BlackBox == 1)
                    {
                        logicMemory.Etat = 5;
                        outputLogic.Counter = logicMemory.Counter;
                        outputLogic.IndexO = logicMemory.IndexCounter;
                    }
                    else if (Input.Pulse == 0 && Input.IndexI == 0)
                    {
                        logicMemory.Etat = 4;
                    }
                    else if (Input.Pulse == 0)
                    {
                        logicMemory.Etat = 1;
                    }
                    else if (Input.IndexI == 0)
                    {
                        logicMemory.Etat = 3;
                    }
                    break;
                case 3:
                    if (Input.BlackBox == 1)
                    {
                        logicMemory.Etat = 5;
                        outputLogic.Counter = logicMemory.Counter;
                        outputLogic.IndexO = logicMemory.IndexCounter;
                    }
                    else if (Input.Pulse == 0 && Input.IndexI == 1)
                    {
                        logicMemory.Etat = 1;
                        logicMemory.IndexCounter++;
                    }
                    else if (Input.Pulse == 0)
                    {
                        logicMemory.Etat = 4;
                    }
                    else if (Input.IndexI == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.IndexCounter++;
                    }
                    break;
                case 4:
                    if (Input.BlackBox == 1)
                    {
                        logicMemory.Etat = 5;
                        outputLogic.Counter = logicMemory.Counter;
                        outputLogic.IndexO = logicMemory.IndexCounter;
                        outputLogic.Direction = logicMemory.Direction;
                    }
                    else if (Input.Pulse == 1 && Input.IndexI == 1)
                    {
                        logicMemory.Etat = 2;
                        logicMemory.IndexCounter++;
                        logicMemory.Counter++;
                    }
                    else if (Input.Pulse == 1)
                    {
                        logicMemory.Etat = 3;
                        logicMemory.Counter++;
                    }
                    else if (Input.IndexI == 1)
                    {
                        logicMemory.Etat = 1;
                        logicMemory.IndexCounter++;
                    }
                    break;
                case 5:
                    if (Input.LimitOpen == 1 || Input.LimitClose == 1)
                    {
                        logicMemory.Etat = 0;
                        logicMemory.Counter = 0;
                        if (Input.LimitOpen == 1)
                        {
                            logicMemory.Direction = 'v';
                            outputLogic.Direction = logicMemory.Direction;
                        }
                        else
                        {
                            logicMemory.Direction = '^';
                            outputLogic.Direction = logicMemory.Direction;
                        }
                    }
                    break;
            }
            return outputLogic;
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
