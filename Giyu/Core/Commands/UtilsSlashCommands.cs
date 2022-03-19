﻿using Discord;
using Discord.Interactions;
using Giyu.Core.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Giyu.Core.Commands
{
    public class UtilsSlashCommands : InteractionModuleBase<SocketInteractionContext>
    {

        [SlashCommand("purge", "Apaga mensagens de um canal de voz. limite de 100 mensagens.")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeChatCommand(uint quantidade)
            => await Context.Channel.SendMessageAsync(await UtilsManager.PurgeChatAsync(Context.Channel as ITextChannel, quantidade));

        [SlashCommand("youtube", "Cria uma sessão com o youtube together.")]
        [RequireUserPermission(GuildPermission.CreateInstantInvite)]
        public async Task YoutubeTogetherCommand()
            => await RespondAsync(embed: await UtilsManager.YoutubeTogetherAsync(Context.User as IVoiceState));
    }
}
