using Eleon.Modding;
using System;
using System.Collections.Generic;

namespace DarkCity
{
    /// <summary>
    /// Handles requests to the legacy GameModAPI and dispatches the response events to callback delegates.
    /// These functions only work when the mod is loaded by a server; either a dedicated server or single player client.
    /// If the GameModAPI is not availble then the callback delegate is immediately invoked with null data.
    /// Also provides events for information coming from the server that is not a reponse to a request.
    /// </summary>
    public class ServerApi
    {
        /// <summary>
        /// Sequence number used to identify responses from Empyrion that are intended for this mod.
        /// </summary>
        public const ushort SequenceNumber = 5433;

        /// <summary>
        /// Stores a queue of delegates for each CmdId. When the CmdId is received by <see cref="DispatchEvent"/> then the data is passed to the next available delegate.
        /// </summary>
        private static Dictionary<CmdId, Queue<Delegate>> callbacks = new Dictionary<CmdId, Queue<Delegate>>();
        // All instances of ServerApi will share a common delegate queue.

        public ServerApi() { }

        /// <summary>
        /// Enqueues a callback delegate for a specific CmdId.
        /// </summary>
        /// <param name="cmd">The event CmdId that is expected to be received from Empyrion.</param>
        /// <param name="callback">A callback delegate that will receive the data from the event. Data will be an object that must be cast into the data type associated with the event.</param>
        private void AddCallback(CmdId cmd, Delegate callback)
        {
            if (DarkCity.LegacyApi == null)
            {
                // LegacyApi is not availble so a response will never arrive.
                // This means the process is not owned by a dedicated server.
                callback.DynamicInvoke(null);
            }
            else
            {
                if (!callbacks.ContainsKey(cmd))
                    callbacks[cmd] = new Queue<Delegate>();

                callbacks[cmd].Enqueue(callback);
            }
        }

        /// <summary>
        /// Events from Empyrion that have already been determined to be destined for this mod are passed to this method. Each event CmdId has a queue of callback delegates waiting for a
        /// response. The delegate that is next in line is dequeued and given the event data.
        /// </summary>
        /// <param name="cmd">The event CmdId received from Empyrion.</param>
        /// <param name="data">A data object received with the event. The callback delegate will need to cast it to the type associated with the event.</param>
        public void DispatchEvent(CmdId cmd, object data)
        {
            if (callbacks.ContainsKey(cmd))
            {
                Delegate callback = callbacks[cmd].Dequeue();
                if (callback != null)
                {
                    callback.DynamicInvoke(data);
                }
            }
        }

        /// <summary>
        /// Requests a list of entity IDs for all logged in players.
        /// </summary>
        /// <param name="callback">Callback for receiving the IdList response.</param>
        public void RequestPlayerList(Action<IdList> callback)
        {
            AddCallback(CmdId.Event_Player_List, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_Player_List, SequenceNumber, null);
        }

        /// <summary>
        /// Requests <see cref="PlayerInfo"/> regarding a specific player.
        /// </summary>
        /// <param name="playerId">The entity ID of the player to request info about.</param>
        /// <param name="callback">Callback for receiving the PlayerInfo response.</param>
        public void RequestPlayerInfo(int playerId, Action<PlayerInfo> callback)
        {
            AddCallback(CmdId.Event_Player_Info, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_Player_Info, SequenceNumber, new Id(playerId));
        }

        /// <summary>
        /// Requests all structures and their info, including in unloaded playfields.
        /// </summary>
        /// <param name="callback">Callback for receiving the GlobalStructureList response.</param>
        public void RequestGlobalStructureList(Action<GlobalStructureList> callback)
        {
            AddCallback(CmdId.Event_GlobalStructure_List, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_GlobalStructure_List, SequenceNumber, null);
        }

        /// <summary>
        /// Requests block statistics for a specific structure. Result is a count of blocks by block ID.
        /// </summary>
        /// <param name="structureId">Structure ID of the structure that the block statistics are about.</param>
        /// <param name="callback">Callback for receiving the IdStructureBlockInfo response.</param>
        public void RequestStructureBlockStatistics(int structureId, Action<IdStructureBlockInfo> callback)
        {
            AddCallback(CmdId.Event_Structure_BlockStatistics, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_Structure_BlockStatistics, SequenceNumber, new Id(structureId));
        }

        /// <summary>
        /// Requests information about all factions.
        /// </summary>
        /// <param name="callback">Callback for receiving the FactionInfoList response.</param>
        public void RequestGetFactions(Action<FactionInfoList> callback)
        {
            // 1 is the magic number to request faction info for all factions.
            RequestGetFactions(1, callback);
        }

        /// <summary>
        /// Requests information about a single faction.
        /// </summary>
        /// <param name="factionId">The faction ID of the faction to request info about.</param>
        /// <param name="callback">Callback for receiving the FactionInfoList response.</param>
        public void RequestGetFactions(int factionId, Action<FactionInfoList> callback)
        {
            AddCallback(CmdId.Event_Get_Factions, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_Get_Factions, SequenceNumber, new Id(factionId));
        }

        /// <summary>
        /// Sends an in-game message to a single player. This is not a reference to single-player mode but instead means that only one player will receive the message.
        /// The in-game message is a box that appears in the upper-right of the screen, much like a base attack message. Id will be the entity ID of the player to receive the message.
        /// </summary>
        /// <param name="data">Parameters that define the look and content of the message.</param>
        public void RequestInGameMessageSinglePlayer(IdMsgPrio data)
        {
            // No callback for this request.
            DarkCity.LegacyApi.Game_Request(CmdId.Request_InGameMessage_SinglePlayer, SequenceNumber, data);
        }

        /// <summary>
        /// Sends an in-game message to all players in a faction. The in-game message is a box that appears in the upper-right of the screen, much like a base attack message.
        /// Id will be the faction ID of the faction to receive the message.
        /// </summary>
        /// <param name="data">Parameters that define the look and content of the message.</param>
        public void RequestInGameMessageFaction(IdMsgPrio data)
        {
            // No callback for this request.
            DarkCity.LegacyApi.Game_Request(CmdId.Request_InGameMessage_Faction, SequenceNumber, data);
        }

        /// <summary>
        /// Sends an in-game message to a single player. This is not a reference to single-player mode but instead means that only one player will receive the message.
        /// The in-game message is a box that appears in the upper-right of the screen, much like a base attack message. Id is ignored.
        /// </summary>
        /// <param name="data">Parameters that define the look and content of the message.</param>
        public void RequestInGameMessageAllPlayers(IdMsgPrio data)
        {
            // No callback for this request.
            DarkCity.LegacyApi.Game_Request(CmdId.Request_InGameMessage_AllPlayers, SequenceNumber, data);
        }

        /// <summary>
        /// Sends a message to a player that will be shown as a message box with up to 2 buttons. Callback delegate will receive which button was selected.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="callback">Callback to receive the IdAndIntValue response. Id will be the entity ID of the player that responded and int will be the button that was selected.
        /// 0 refers to the positive button (PosButtonText) and 1 refers to the negative button (NegButtonText).</param>
        public void RequestShowDialogSinglePlayer(DialogBoxData data, Action<IdAndIntValue> callback)
        {
            AddCallback(CmdId.Event_DialogButtonIndex, callback);
            DarkCity.LegacyApi.Game_Request(CmdId.Request_ShowDialog_SinglePlayer, SequenceNumber, data);
        }
    }
}
