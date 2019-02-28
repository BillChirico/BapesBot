﻿using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Adds 1 to a Counter. Displays the Wins after addition.
    /// </summary>
    public class AddWinCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchClient _twitchClient;

        public AddWinCommand(ITwitchClient twitchClient, ICounterService counterService) : base("addwin")
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            _counterService.AddCount();
            _twitchClient.SendMessage(message.ChatMessage.Channel,
                $"Win Added. Current Wins: {_counterService.GetCount().Counter}");

            return Task.FromResult(true);
        }
    }
}