using System.Collections.Generic;
using RegressionGames.RGBotLocalRuntime;
using RegressionGames.StateActionTypes;
using UnityEngine;

namespace RgAbilitybotCs
{
    public class BotEntryPoint : RGBehaviorTreeBot
    {
        protected override bool GetIsSpawnable() => true;
        protected override RGBotLifecycle GetBotLifecycle() => RGBotLifecycle.MANAGED;

        protected override void ConfigureBotInternal(RG rgObject)
        {
            rgObject.CharacterConfig = "";
        }

        protected override RootNode BuildBehaviorTree()
        {
            var topLevelSequenceNode = new SequenceNode("Top Level Sequence Node");
            topLevelSequenceNode.AddChild(new IsBotActive());
            topLevelSequenceNode.AddChild(new PerformAction());
            var rootNode = new RootNode("Root Node");
            rootNode.AddChild(topLevelSequenceNode);
        }
    }
}