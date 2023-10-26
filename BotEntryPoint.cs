using System.Collections.Generic;
using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;

namespace RgAbilitybotCs
{
    public class BotEntryPoint : RGBehaviorTreeBot
    {
        protected override bool GetIsSpawnable() => true;
        protected override RGBotLifecycle GetBotLifecycle() => RGBotLifecycle.Managed;

        protected override void ConfigureBotInternal(RG rgObject)
        {
            rgObject.CharacterConfig = new Dictionary<string, object>()
            {
                ["foo"] = &quot;bar&quot;,
                ["baz"] = 42,
                ["biz"] = true,
                ["boz"] = null,
            };
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

            var rootNode = new RootNode("Root Node");
            rootNode.AddChild(topLevelSequenceNode);

            return rootNode;
        }
    }
}