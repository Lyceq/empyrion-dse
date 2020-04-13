using Eleon.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkCity.Simulation
{
    public class GameRequestEventArgs : EventArgs
    {
        public CmdId reqId;
        public ushort seqNr;
        public object data;

        public GameRequestEventArgs() : base() { }

        public GameRequestEventArgs(CmdId reqId, ushort seqNr, object data)
        {
            this.reqId = reqId;
            this.seqNr = seqNr;
            this.data = data;
        }
    }

    public delegate void GameRequestHandler(object sender, GameRequestEventArgs e);

    public class ModGameApiSimulator : ModGameAPI
    {
        public ulong ticks = 0;

        public event GameRequestHandler GameRequestReceived;

        public ModGameApiSimulator() { }

        public void Console_Write(string txt)
        {
        }

        public ulong Game_GetTickTime()
        {
            return this.ticks;
        }

        public bool Game_Request(CmdId reqId, ushort seqNr, object data)
        {
            if (this.GameRequestReceived != null)
                this.GameRequestReceived(this, new GameRequestEventArgs(reqId, seqNr, data));
            return true;
        }
    }
}
