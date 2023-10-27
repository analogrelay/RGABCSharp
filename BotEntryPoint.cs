using System.Collections.Generic;
using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;

namespace RgAbilitybotCs
{
    public class BotEntryPoint : RGBehaviorTreeBot
    {
        protected override bool GetIsSpawnable() => true;
        protected override RGBotLifecycle GetBotLifecycle() => RGBotLifecycle.Managed;

        private const string CharacterConfig = @"{""foo"":""here's\nan\nannoying\nvalue"",""baz"":{""yeah"":""there are even nested objects"",""and"":[""arrays"",""too""]},""biz"":true,""boz"":null}";

        protected override void ConfigureBotInternal(RG rgObject)
        {
            rgObject.SetCharacterConfigFromJson(CharacterConfig);
        }

        protected override RootNode BuildBehaviorTree()
        {
            var doAThing = new SelectorNode("Do A thing?");
            doAThing.AddChild(new Invert(new IsThereAPlayerNearby()));
            doAThing.AddChild(new AlwaysFail());
            doAThing.AddChild(new AlwaysSucceed());

            var topLevelSequenceNode = new SequenceNode("Top Level Sequence Node");
            topLevelSequenceNode.AddChild(new IsBotActive());
            topLevelSequenceNode.AddChild(new PerformAction());
            topLevelSequenceNode.AddChild(doAThing);
            topLevelSequenceNode.AddChild(new AlwaysFail(new Node14()));

            var rootNode = new RootNode("Root Node");
            rootNode.AddChild(topLevelSequenceNode);

            return rootNode;
        }
    }
}