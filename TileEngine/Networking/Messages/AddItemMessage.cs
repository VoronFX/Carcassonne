﻿
namespace MultiplayerGame.Networking.Messages
{
    using Lidgren.Network;
    using Lidgren.Network.Xna;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AddItemMessage : IGameMessage
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemySpawnedMessage"/> class.
        /// </summary>
        /// <param name="im">
        /// The im.
        /// </param>
        public AddItemMessage(NetIncomingMessage im)
        {
            this.Decode(im);
        }


        public AddItemMessage(string codeValue, int id,int Count,int colorID,bool Size)
        {
            this.ID = id;
            this.CodeValue = codeValue;
            this.MessageTime = NetTime.Now;
            this.Count = Count;
            this.ColorID = colorID;
            this.Size = Size;
        }

        #endregion

        #region Public Properties

        public bool Size { get; set; }

        public int ColorID { get; set; }
        /// <summary>
        /// Gets or sets CodeValue.
        /// </summary>
        public string CodeValue { get; set; }

        /// <summary>
        /// Gets or sets MessageTime.
        /// </summary>
        public double MessageTime { get; set; }

        /// <summary>
        /// Gets MessageType.
        /// </summary>
        public GameMessageTypes MessageType
        {
            get
            {
                return GameMessageTypes.AddItemState;
            }
        }

        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }

  
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
        

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The decode.
        /// </summary>
        /// <param name="im">
        /// The im.
        /// </param>
        public void Decode(NetIncomingMessage im)
        {
            this.CodeValue = im.ReadString();
            this.MessageTime = im.ReadDouble();
            this.ID = im.ReadInt32();
            this.Count = im.ReadInt32();
            this.ColorID = im.ReadInt32();
            this.Size = im.ReadBoolean();

        }

        /// <summary>
        /// The encode.
        /// </summary>
        /// <param name="om">
        /// The om.
        /// </param>
        public void Encode(NetOutgoingMessage om)
        {
            om.Write(this.CodeValue);
            om.Write(this.MessageTime);
            om.Write(this.ID);
            om.Write(this.Count);
            om.Write(this.ColorID);
            om.Write(this.Size);
        }

        #endregion
    }
}