﻿using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Giyu.Core.Managers
{
    public class UtilsManager
    {
        public static async Task<string> PurgeChatAsync(ITextChannel textChannel, uint amount)
        {
            if(amount < 1 || amount > 100)
            {
                return $"Utilize valores de 1-100";
            }

            var messages = await textChannel.GetMessagesAsync((int)amount + 1).FlattenAsync();

            foreach (var message in messages)
            {
                await Task.Delay(500);
                await textChannel.DeleteMessageAsync(message.Id);
            }

            return $"{amount} apagadas.";
        }

        public static async Task<Embed> YoutubeTogetherAsync(IVoiceState VoiceState)
        {
            IInviteMetadata Invite = await VoiceState.VoiceChannel.CreateInviteToApplicationAsync(DefaultApplications.Youtube, maxAge: 86400, maxUses: 0, isTemporary: false);

            Color YTColor = new Color(0xFF0000);

            EmbedBuilder embed = new EmbedBuilder()
                .WithAuthor(name: "YouTube Together", iconUrl: "https://cdn.discordapp.com/emojis/749289646097432667.png?v=1")
                .WithColor(YTColor)
                .WithDescription($"__**[Clique aqui para começar.](https://discord.com/invite/{Invite.Code})**__\n" +
                " **Aviso:** Funciona apenas para Desktop.");

            return embed.Build();
        }
    }
}
