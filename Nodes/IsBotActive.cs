using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;

namespace RgAbilitybotCs
{
    public class IsBotActive : ConditionNode
    {
        public IsBotActive() : base("Is Bot Active?")
        {
        }

        /**
         * Generated from prompt:
         * 
         */
        public override NodeStatus Execute(RG rgObject)
        {
        	// Is active?
        	return NodeStatus.SUCCESS;
        }
    }
}