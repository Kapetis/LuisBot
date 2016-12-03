using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Luis;

namespace LuisBot.Dialogs
{
    //"App ID", "Subscription key"
    //^ap to App Settings, ^ap to onoma sou
    [LuisModel("274282f2-4e28-4813-a104-89a213c794d7", "450e0ac17e004d8dac329c4bbcde75f7")]
    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {
        public static Championships champs = new Championships();

        [LuisIntent("TeamCount")]
        public async Task GetTeamCount(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"There are { champs.GetTeamCount() } teams.");
            context.Wait(MessageReceived);
        }

       

        [LuisIntent("BestTeam")]
        public async Task BestTeam(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ champs.GetHighestRatedTeam()} is the best team in the championships.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("WorstTeam")]
        public async Task BottomTeam(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ champs.GetLowestRatedTeam()} is the worst team in the championships.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I have no idea what you are talking about.");
            context.Wait(MessageReceived);
        }
    }
}