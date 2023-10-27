using System.Collections.Generic;
using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;

namespace RgAbilitybotCs
{
    public class BotEntryPoint : RGBehaviorTreeBot
    {
        protected override bool GetIsSpawnable() => true;
        protected override RGBotLifecycle GetBotLifecycle() => RGBotLifecycle.Managed;

        private const string CharacterConfig = @"{""characterType"":""Archer""}";

        public override void ConfigureBot(RG rgObject)
        {
            rgObject.SetCharacterConfigFromJson(CharacterConfig);
        }

        protected override RootNode BuildBehaviorTree()
        {
            var topLevelSequenceNode = new SequenceNode("Top Level Sequence Node");
            topLevelSequenceNode.AddChild(new IsThereAnEntityNearby());
            topLevelSequenceNode.AddChild(new SelectSkill());
            topLevelSequenceNode.AddChild(new PerformSkill());

            var rootNode = new RootNode("Root Node");
            rootNode.AddChild(topLevelSequenceNode);

            return rootNode;
        }
    }
}