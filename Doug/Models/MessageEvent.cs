﻿using Newtonsoft.Json;

namespace Doug.Models
{
    public class MessageEvent
    {
        private const string GroupType = "group";
        private const string CoffeeParrotEmoji = ":coffeeparrot:";

        public string ClientMsgId { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string Ts { get; set; }
        public string Channel { get; set; }
        public string EventTs { get; set; }
        public string ChannelType { get; set; }

        public bool IsValid()
        {
            return ChannelType == GroupType;
        }

        public bool IsValidCoffeeParrot()
        {
            return IsValid() && Text.StartsWith(CoffeeParrotEmoji);
        }
    }
}