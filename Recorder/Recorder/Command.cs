﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recorder
{
    public class Command : ICommand
    {
        private IModifiable recorder;

        public Command(IModifiable modifiable)
        {
            recorder = modifiable;
        }

        public void Execute(string commandString)
        {
            bool isValid = false;
            string[] commandBits = commandString.Split(' ');
            if (commandBits.Count() > 1)
            {
                string commandType = commandBits[0].ToLower();
                switch (commandType)
                {
                    case DeleteCommand:
                        recorder.DeleteByKey(commandBits[1]);
                        isValid = true;
                        break;
                    case AddCommand:
                        if (commandBits.Count() > 2)
                        {
                            recorder.Add(commandBits[1], int.Parse(commandBits[2]));
                            isValid = true;
                        }
                        break;

                    default:
                        break;
                }

                
            }

        }

        private const string DeleteCommand = "drop";
        private const string AddCommand = "value";
    }
}
