using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public class Main
    {
        static void Start(string[] args)
        {
            BaseAction action = new ActionSendEmail();
            action.takeAction();
        }        
    }
}
